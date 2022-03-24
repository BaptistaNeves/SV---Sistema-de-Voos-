using AutoMapper;
using SV.Application.InputModels.Aeroportos;
using SV.Application.Interfaces.Services.Aeroportos;
using SV.Application.Services.Base;
using SV.Application.Validations.Aeroportos;
using SV.Core.Entities.Aeroportos;
using SV.Core.Interfaces.Notifications;
using SV.Core.Interfaces.Repositories.Aeroportos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SV.Application.Services.Aeroportos
{
    public class AeroportoService : BaseService, IAeroportoService
    {
        private readonly IAeroportoRepository _aeroportoRepository;
        private readonly IMapper _mapper;
        public AeroportoService(INotifier notifier,
                                IAeroportoRepository aeroportoRepository, 
                                IMapper mapper) : base(notifier)
        {
            _aeroportoRepository = aeroportoRepository;
            _mapper = mapper;
        }

        public async Task<AeroportoInputModel> ObterAeroportoPorId(Guid id)
        {
            return _mapper.Map<AeroportoInputModel>(await _aeroportoRepository.FindAsync(id));
        }

        public async Task<IEnumerable<Aeroporto>> ObterTodosAeroportos()
        {
            return await _aeroportoRepository.GetAllAsync(inCludeProperties:"Cidade");
        }

        public async Task Inserir(AeroportoInputModel inputModel)
        {
            if (!IsValide(new AeroportoValidation(), inputModel)) return;

            var aeroporto = _mapper.Map<Aeroporto>(inputModel);

            if (await _aeroportoRepository.FirstOrDefaultAsync(a => a.Nome == inputModel.Nome) != null)
            {
                Notify("Já existe um Aeroporto Cadastrado com este nome!");
                return;
            }

            _aeroportoRepository.Add(aeroporto);
            await _aeroportoRepository.SaveChangesAsync();
        }

        public async Task Atualizar(AeroportoInputModel inputModel)
        {
            if (!IsValide(new AeroportoValidation(), inputModel)) return;

            var aeroporto = _mapper.Map<Aeroporto>(inputModel);

            if (await _aeroportoRepository.FirstOrDefaultAsync(a =>
                 a.Nome == inputModel.Nome && a.Id != inputModel.Id) != null)
            {
                Notify("Já existe um Aeroporto Cadastrada com este nome!");
                return;
            }

            _aeroportoRepository.Update(aeroporto);
            await _aeroportoRepository.SaveChangesAsync();
        }

        public async Task Remover(Guid id)
        {
            var aeroporto = await _aeroportoRepository.FindAsync(id);

            _aeroportoRepository.Remove(aeroporto);

            await _aeroportoRepository.SaveChangesAsync();
        }

        public void Dispose()
        {
            _aeroportoRepository?.Dispose();
        }
    }
}
