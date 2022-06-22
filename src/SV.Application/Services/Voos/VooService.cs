using AutoMapper;
using SV.Application.InputModels.Voos;
using SV.Application.Interfaces.Services.Voos;
using SV.Application.Services.Base;
using SV.Application.Validations.Voos;
using SV.Core.DTOs.Voos;
using SV.Core.Entities.Voos;
using SV.Core.Interfaces.Notifications;
using SV.Core.Interfaces.Repositories.Voos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SV.Application.Services.Voos
{
    public class VooService : BaseService, IVooService
    {
        private readonly IVooRepository _vooRepository;
        private readonly IMapper _mapper;

        public VooService(INotifier notifier,
                          IVooRepository vooRepository, 
                          IMapper mapper) : base(notifier)
        {
            _vooRepository = vooRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Voo>> ObterTodosVoos()
        {
            return await _vooRepository.GetAllAsync();
        }
        public async Task<IEnumerable<VooDto>> ObterVoosParaVitrine()
        {
            return await _vooRepository.ObterVoos();
        }
        public async Task<IEnumerable<VooDto>> ObterVoosFiltrados()
        {
            return await _vooRepository.ObterVoosFiltrados();
        }

        public async Task<VooInputModel> ObterVooPorId(Guid id)
        {
            return _mapper.Map<VooInputModel>(await _vooRepository
                .FirstOrDefaultAsync(f => f.Id == id, isTracking: false));
        }

        public async Task<VooDto> ObterVooFiltradoPorId(Guid id)
        {
            return await _vooRepository.ObterVooFiltradoPorId(id);
        }

        public async Task Inserir(VooInputModel vooModel)
        {
            if (!IsValide(new VooValidation(), vooModel)) return;

            var voo = _mapper.Map<Voo>(vooModel);

            if (await _vooRepository.FirstOrDefaultAsync(c => c.Descricao == vooModel.Descricao) != null)
            {
                Notify("Já existe um voo cadastrado com esta Descrição/Nome!");
                return;
            }

            _vooRepository.Add(voo);
            await _vooRepository.SaveChangesAsync();
        }

        public async Task Atualizar(VooInputModel vooModel)
        {
            if (!IsValide(new VooValidation(), vooModel)) return;

            var voo = _mapper.Map<Voo>(vooModel);

            if (await _vooRepository.FirstOrDefaultAsync(c =>
                 c.Descricao == vooModel.Descricao && c.Id != vooModel.Id) != null)
            {
                Notify("Já existe um tipo de voo cadastrada com este nome!");
                return;
            }

            _vooRepository.Update(voo);
            await _vooRepository.SaveChangesAsync();
        }

        public async Task Remover(Guid id)
        {
            var voo = await _vooRepository.FindAsync(id);

            _vooRepository.Remove(voo);

            await _vooRepository.SaveChangesAsync();
        }

        public void Dispose()
        {
            _vooRepository?.Dispose();
        }

    }
}
