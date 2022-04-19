using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SV.Application.InputModels.Voos;
using SV.Application.Interfaces.Services.Aeronaves;
using SV.Application.Interfaces.Services.Aeroportos;
using SV.Application.Interfaces.Services.Voos;
using SV.Core.Interfaces.Notifications;
using SV.UI.Admin.Dashboard.ViewModels.Voos;
using SV.UI.Base;
using System;
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
        public VoosController(INotifier notifier,
                              IVooService vooService,
                              IAeroportoService aeroportoService,
                              IAeronaveService aeronaveService, 
                              ITipoDeVooService tipoDeVooService) : base(notifier)
        {
            _vooService = vooService;
            _aeroportoService = aeroportoService;
            _aeronaveService = aeronaveService;
            _tipoDeVooService = tipoDeVooService;
        }

        [HttpGet]
        [Route("admin/voos")]
        public async Task<IActionResult> Index()
        {
            return View(await _vooService.ObterVoosFiltrados());
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
                    TiposDeVoo = await _tipoDeVooService.ObterTodosTiposDeVoo()
                });
            }

            await _vooService.Inserir(vooModel.VooInputModel);

            if (!OperacaoIsValide())
            {
                return View(new VooViewModel
                {
                    VooInputModel = vooModel.VooInputModel,
                    Aeronaves = await _aeronaveService.ObterTodasAeronaves(),
                    Aeroportos = await _aeroportoService.ObterTodosAeroportos(),
                    TiposDeVoo = await _tipoDeVooService.ObterTodosTiposDeVoo()
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

            });
        }


        [HttpPost]
        [Route("admin/editar-voo/{id:guid}")]
        public async Task<IActionResult> Edit(VooInputModel vooModel)
        {
            if (!ModelState.IsValid)
            {
                return View(new VooViewModel
                {
                    Aeronaves = await _aeronaveService.ObterTodasAeronaves(),
                    Aeroportos = await _aeroportoService.ObterTodosAeroportos(),
                    TiposDeVoo = await _tipoDeVooService.ObterTodosTiposDeVoo(),

                });
            }

            await _vooService.Atualizar(vooModel);

            if (!OperacaoIsValide())
            {
                return View(new VooViewModel
                {
                    Aeronaves = await _aeronaveService.ObterTodasAeronaves(),
                    Aeroportos = await _aeroportoService.ObterTodosAeroportos(),
                    TiposDeVoo = await _tipoDeVooService.ObterTodosTiposDeVoo(),

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

                });
            }

            TempData["success"] = "Voo excluido com sucesso!";

            return RedirectToAction(nameof(Index));
        }
    }
}
