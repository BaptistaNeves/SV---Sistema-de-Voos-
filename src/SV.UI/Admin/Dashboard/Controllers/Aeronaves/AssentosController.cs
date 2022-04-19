using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SV.Application.InputModels.Aeronaves;
using SV.Application.Interfaces.Services.Aeronaves;
using SV.Core.Interfaces.Notifications;
using SV.UI.Admin.Dashboard.ViewModels.Aeronaves;
using SV.UI.Base;
using System;
using System.Threading.Tasks;

namespace SV.UI.Admin.Dashboard.Controllers.Aeronaves
{
    [Area("Dashboard")]
    [Authorize(Roles = "Operador,Admin")]
    public class AssentosController : MainController
    {
        private readonly IAssentoService _assentoService;
        private readonly IClasseService _classeService;
        private readonly IAeronaveService _aeronaveService;
        private readonly IMapper _mapper;
        public AssentosController(INotifier notifier,
                                  IAssentoService assentoService,
                                  IClasseService classeService,
                                  IAeronaveService aeronaveService, 
                                  IMapper mapper) : base(notifier)
        {
            _assentoService = assentoService;
            _classeService = classeService;
            _aeronaveService = aeronaveService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("admin/assentos")]
        public async Task<IActionResult> Index()
        {
            return View(await _assentoService.ObterTodosAssentos());
        }

        [HttpGet]
        [Route("admin/novo-assento")]
        public async Task<IActionResult> Create()
        {
            return View(new AssentoViewModel { 
                Aeronaves = await _aeronaveService.ObterTodasAeronaves(),
                Classes = await _classeService.ObterTodasClasses()
            });
        }

        [HttpPost]
        [Route("admin/novo-assento")]
        public async Task<IActionResult> Create(AssentoInputModel assentoModel)
        {
            if (!ModelState.IsValid) return View(assentoModel);

            await _assentoService.Inserir(assentoModel);

            if (!OperacaoIsValide()) return View(assentoModel); ;

            TempData["success"] = "Assento cadastrado com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("admin/editar-assento/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var assento = await _assentoService.ObterAssetoPorId(id);

            if (assento == null)
            {
                return NotFound();
            }

            return View(new AssentoViewModel
            {
                AssentoModel = assento,
                Aeronaves = await _aeronaveService.ObterTodasAeronaves(),
                Classes = await _classeService.ObterTodasClasses()
            });
        }


        [HttpPut, ActionName("Edit")]
        [Route("admin/editar-assento/{id:guid}")]
        public async Task<IActionResult> EditPost(Guid id, AssentoInputModel assentoModel)
        {
            if (!ModelState.IsValid) return View(assentoModel);

            await _assentoService.Atualizar(assentoModel);

            if (!OperacaoIsValide()) return View(assentoModel);

            TempData["success"] = "Assento atualizado com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("admin/excluir-assento/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var aeronave = await _assentoService.ObterAssetoPorId(id);

            if (aeronave == null)
            {
                return NotFound();
            }

            await _assentoService.Remover(id);

            if (!OperacaoIsValide()) return View();

            TempData["success"] = "Assento excluido com sucesso!";

            return RedirectToAction(nameof(Index));
        }

    }
}
