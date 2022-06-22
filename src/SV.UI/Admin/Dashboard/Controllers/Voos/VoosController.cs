using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SV.Application.InputModels.Aeronaves;
using SV.Application.InputModels.Voos;
using SV.Application.Interfaces.Services.Aeronaves;
using SV.Application.Interfaces.Services.Aeroportos;
using SV.Application.Interfaces.Services.Funcionarios;
using SV.Application.Interfaces.Services.Voos;
using SV.Core.Interfaces.Notifications;
using SV.UI.Admin.Dashboard.ViewModels.Aeronaves;
using SV.UI.Admin.Dashboard.ViewModels.Voos;
using SV.UI.Base;
using System;
using System.Collections;
using System.IO;
using System.Threading.Tasks;

namespace SV.UI.Admin.Dashboard.Controllers.Voos
{
    [Area("Dashboard")]
    [Authorize(Roles = "Operador,Admin")]
    public class VoosController : MainController
    {
        private readonly IVooService _vooService;
        private readonly IAeroportoService _aeroportoService;
        private readonly IAeronaveService _aeronaveService;
        private readonly ITipoDeVooService _tipoDeVooService;
        private readonly IFuncionarioService _funcionarioService;
        private readonly IAssentoService _assentoService;
        private readonly IClasseService _classeService;
        private string _url;
        public VoosController(INotifier notifier,
                              IVooService vooService,
                              IAeroportoService aeroportoService,
                              IAeronaveService aeronaveService,
                              ITipoDeVooService tipoDeVooService,
                              IFuncionarioService funcionarioService,
                              IAssentoService assentoService, 
                              IClasseService classeService) : base(notifier)
        {
            _vooService = vooService;
            _aeroportoService = aeroportoService;
            _aeronaveService = aeronaveService;
            _tipoDeVooService = tipoDeVooService;
            _funcionarioService = funcionarioService;
            _assentoService = assentoService;
            _classeService = classeService;
        }

        [HttpGet]
        [Route("admin/voos")]
        public async Task<IActionResult> Index()
        {
            return View(await _vooService.ObterVoosFiltrados());
        }


        [HttpGet]
        public async Task<IActionResult> ObterAssentos(Guid vooId)
        {
            var assentos = await _assentoService.ObterAssentosPorVooId(vooId);
            var voo = await _vooService.ObterVooPorId(vooId);

            if (assentos == null)
            {
                return NotFound();
            }

            return PartialView("_Assentos", new VooViewModel { Assentos = assentos, VooInputModel = voo});
        }

        [HttpGet]
        [Route("admin/novo-voo")]
        public async Task<IActionResult> Create()
        {
            return View(new VooViewModel
            {
                Aeronaves = await _aeronaveService.ObterTodasAeronaves(),
                Aeroportos = await _aeroportoService.ObterTodosAeroportos(),
                TiposDeVoo = await _tipoDeVooService.ObterTodosTiposDeVoo(),
                Pilotos = await _funcionarioService.ObterFuncionariosPiloto(),
                CoPilotos = await _funcionarioService.ObterFuncionariosCoPiloto()
            });
        }

        [HttpPost]
        [Route("admin/novo-voo")]
        public async Task<IActionResult> Create(VooViewModel vooModel)
        {
            if (!ModelState.IsValid)
            {
                return View(new VooViewModel
                {
                    VooInputModel = vooModel.VooInputModel,
                    Aeronaves = await _aeronaveService.ObterTodasAeronaves(),
                    Aeroportos = await _aeroportoService.ObterTodosAeroportos(),
                    TiposDeVoo = await _tipoDeVooService.ObterTodosTiposDeVoo(),
                    Pilotos = await _funcionarioService.ObterFuncionariosPiloto(),
                    CoPilotos = await _funcionarioService.ObterFuncionariosCoPiloto()
                });
            }

            var imgPrefixo = Guid.NewGuid() + "_";

            vooModel.VooInputModel.Imagem = imgPrefixo + Path
                .GetFileName(vooModel.VooInputModel.ImagemUpload.FileName.Trim());

            await _vooService.Inserir(vooModel.VooInputModel);

            if (!OperacaoIsValide())
            {
                return View(new VooViewModel
                {
                    VooInputModel = vooModel.VooInputModel,
                    Aeronaves = await _aeronaveService.ObterTodasAeronaves(),
                    Aeroportos = await _aeroportoService.ObterTodosAeroportos(),
                    TiposDeVoo = await _tipoDeVooService.ObterTodosTiposDeVoo(),
                    Pilotos = await _funcionarioService.ObterFuncionariosPiloto(),
                    CoPilotos = await _funcionarioService.ObterFuncionariosCoPiloto()
                });
            }

            if (!await UploadImage(vooModel.VooInputModel.ImagemUpload, imgPrefixo))
            {
                return View(new VooViewModel
                {
                    VooInputModel = vooModel.VooInputModel,
                    Aeronaves = await _aeronaveService.ObterTodasAeronaves(),
                    Aeroportos = await _aeroportoService.ObterTodosAeroportos(),
                    TiposDeVoo = await _tipoDeVooService.ObterTodosTiposDeVoo(),
                    Pilotos = await _funcionarioService.ObterFuncionariosPiloto(),
                    CoPilotos = await _funcionarioService.ObterFuncionariosCoPiloto()
                });
            }

            TempData["success"] = "Voo cadastrado com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("admin/editar-voo/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var voo = await _vooService.ObterVooPorId(id);

            if (voo == null)
            {
                return NotFound();
            }

            return View(new VooViewModel
            {
                VooInputModel = voo,
                Aeronaves = await _aeronaveService.ObterTodasAeronaves(),
                Aeroportos = await _aeroportoService.ObterTodosAeroportos(),
                TiposDeVoo = await _tipoDeVooService.ObterTodosTiposDeVoo(),
                Pilotos = await _funcionarioService.ObterFuncionariosPiloto(),
                CoPilotos = await _funcionarioService.ObterFuncionariosCoPiloto(),
                Assentos = await _assentoService.ObterTodosAssentos()
            });
        }


        [HttpPost]
        [Route("admin/editar-voo/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id, VooViewModel vooModel)
        {
            var voo = await _vooService.ObterVooPorId(id);

            if (voo == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(new VooViewModel
                {
                    VooInputModel = vooModel.VooInputModel,
                    Aeronaves = await _aeronaveService.ObterTodasAeronaves(),
                    Aeroportos = await _aeroportoService.ObterTodosAeroportos(),
                    TiposDeVoo = await _tipoDeVooService.ObterTodosTiposDeVoo(),
                    Pilotos = await _funcionarioService.ObterFuncionariosPiloto(),
                    CoPilotos = await _funcionarioService.ObterFuncionariosCoPiloto(),
                    Assentos = await _assentoService.ObterTodosAssentos()
                });
            }

            var imgPrefixo = Guid.NewGuid() + "_";

            var imagemAntiga = voo.Imagem;

            vooModel.VooInputModel.Imagem = imagemAntiga;

            if (vooModel.VooInputModel.ImagemUpload != null)
            {
                vooModel.VooInputModel.Imagem = imgPrefixo + Path.
                    GetFileName(vooModel.VooInputModel.ImagemUpload.FileName.Trim());

                if (!await UploadImage(vooModel.VooInputModel.ImagemUpload, imgPrefixo))
                {
                    return View(new VooViewModel
                    {
                        VooInputModel = vooModel.VooInputModel,
                        Aeronaves = await _aeronaveService.ObterTodasAeronaves(),
                        Aeroportos = await _aeroportoService.ObterTodosAeroportos(),
                        TiposDeVoo = await _tipoDeVooService.ObterTodosTiposDeVoo(),
                        Pilotos = await _funcionarioService.ObterFuncionariosPiloto(),
                        CoPilotos = await _funcionarioService.ObterFuncionariosCoPiloto(),
                        Assentos = await _assentoService.ObterTodosAssentos()
                    });
                }

                DeleteUploadedImage(imagemAntiga);
            }

            await _vooService.Atualizar(vooModel.VooInputModel);

            if (!OperacaoIsValide())
            {
                return View(new VooViewModel
                {
                    VooInputModel = vooModel.VooInputModel,
                    Aeronaves = await _aeronaveService.ObterTodasAeronaves(),
                    Aeroportos = await _aeroportoService.ObterTodosAeroportos(),
                    TiposDeVoo = await _tipoDeVooService.ObterTodosTiposDeVoo(),
                    Pilotos = await _funcionarioService.ObterFuncionariosPiloto(),
                    CoPilotos = await _funcionarioService.ObterFuncionariosCoPiloto(),
                    Assentos = await _assentoService.ObterTodosAssentos()
                });
            }

            TempData["success"] = "Voo atualizado com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("admin/excluir-voo/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var voo = await _vooService.ObterVooPorId(id);

            if (voo == null)
            {
                return NotFound();
            }

            await _vooService.Remover(id);

            if (!OperacaoIsValide())
            {
                return View(new VooViewModel
                {
                    Aeronaves = await _aeronaveService.ObterTodasAeronaves(),
                    Aeroportos = await _aeroportoService.ObterTodosAeroportos(),
                    TiposDeVoo = await _tipoDeVooService.ObterTodosTiposDeVoo(),
                    Pilotos = await _funcionarioService.ObterFuncionariosPiloto(),
                    CoPilotos = await _funcionarioService.ObterFuncionariosCoPiloto()
                });
            }

            DeleteUploadedImage(voo.Imagem);

            TempData["success"] = "Voo excluido com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("adicionar-atualizar-assento/{id:guid}")]
        public async Task<IActionResult> UpSertAssento(Guid id)
        {
            var assento = await _assentoService.ObterAssetoPorId(id);

            if(assento != null)
            {
                return PartialView("_UpSertAssento", new AssentoViewModel
                {
                    Classes = await _classeService.ObterTodasClasses(),
                    AssentoInputModel = assento
                });
            }
            else
            {
                return PartialView("_UpSertAssento", new AssentoViewModel
                {
                    Classes = await _classeService.ObterTodasClasses(),
                    AssentoInputModel = new AssentoInputModel()
                });
            }
        }

        [HttpPost]
        [Route("adicionar-atualizar-assento/{id:guid}")]
        public async Task<IActionResult> UpSertAssento(Guid id, AssentoViewModel assentoModel)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_UpSertAssento", new AssentoViewModel
                {
                    Classes = await _classeService.ObterTodasClasses(),
                    AssentoInputModel = assentoModel.AssentoInputModel
                });
            }

            if (assentoModel.AssentoInputModel.Id == Guid.Empty)
            {
                var vooId = id;
                assentoModel.AssentoInputModel.VooId = vooId;

                _url = Url.Action("ObterAssentos", "Voos", new { VooId = vooId });

                await _assentoService.Inserir(assentoModel.AssentoInputModel);

                if (!OperacaoIsValide())
                {
                    return PartialView("_UpSertAssento", new AssentoViewModel
                    {
                        Classes = await _classeService.ObterTodasClasses(),
                        AssentoInputModel = assentoModel.AssentoInputModel
                    });
                }

                return Json(new { success = true, _url });
            }

            _url = Url.Action("ObterAssentos", "Voos", new { VooId = assentoModel.AssentoInputModel.VooId });

            await _assentoService.Atualizar(assentoModel.AssentoInputModel);

            if (!OperacaoIsValide())
            {
                return PartialView("_UpSertAssento", new AssentoViewModel
                {
                    Classes = await _classeService.ObterTodasClasses(),
                    AssentoInputModel = assentoModel.AssentoInputModel
                });
            }

            return Json(new { success = true, _url });

        }


        [HttpGet]
        [Route("admin/excluir-assecto/{id:guid}")]
        public async Task<IActionResult> DeleteAssento(Guid id)
        {
            var assento = await _assentoService.ObterAssetoPorId(id);

            if (assento == null)
            {
                return NotFound();
            }

            await _assentoService.Remover(id);

            return RedirectToAction(nameof(Edit), new { id = assento.VooId });
        }

        [NonAction]
        public async Task<bool> UploadImage(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UploadedImages/Site/Voos/", imgPrefixo + Path.GetFileName(arquivo.FileName.Trim()));

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com este nome!");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }

        [NonAction]
        public void DeleteUploadedImage(string arquivo)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UploadedImages/Site/Voos/", arquivo);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
    }
}
