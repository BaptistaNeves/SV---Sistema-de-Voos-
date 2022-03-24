using AutoMapper;
using SV.Application.InputModels.Aeronaves;
using SV.Application.Interfaces.Services.Aeronaves;
using SV.Application.Services.Base;
using SV.Application.Validations.Aeronaves;
using SV.Core.Entities.Aeronaves;
using SV.Core.Interfaces.Notifications;
using SV.Core.Interfaces.Repositories.Aeronaves;
using SV.Core.ViewModels.Utility;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SV.Application.Services.Aeronaves
{
    public class AeronaveService : BaseService, IAeronaveService
    {
        private readonly IAeronaveRepository _aeronaveRepository;
        private readonly IMapper _mapper;
        public AeronaveService(INotifier notifier,
                               IAeronaveRepository aeronaveRepository, 
                               IMapper mapper) : base(notifier)
        {
            _aeronaveRepository = aeronaveRepository;
            _mapper = mapper;
        }

        public async Task<AeronaveInputModel> ObterAeronavePorId(Guid id)
        {
            return _mapper.Map<AeronaveInputModel>(await _aeronaveRepository.FindAsync(id));
        }

        public async Task<IEnumerable<Aeronave>> ObterTodasAeronaves()
        {
            return await _aeronaveRepository.GetAllAsync();
        }

        public async Task Inserir(AeronaveInputModel inputModel)
        {
            if (!IsValide(new AeronaveValidation(), inputModel)) return;

            var aeronave = _mapper.Map<Aeronave>(inputModel);

            if (await _aeronaveRepository.FirstOrDefaultAsync(c => c.Modelo == inputModel.Modelo) != null)
            {
                Notify("Já existe uma Aeronave Cadastrada com este Modelo!");
                return;
            }

            _aeronaveRepository.Add(aeronave);
            await _aeronaveRepository.SaveChangesAsync();
        }

        public async Task Atualizar(AeronaveInputModel inputModel)
        {
            if (!IsValide(new AeronaveValidation(), inputModel)) return;

            var aeronave = _mapper.Map<Aeronave>(inputModel);

            if (await _aeronaveRepository.FirstOrDefaultAsync(c => 
            c.Modelo == inputModel.Modelo && c.Id != aeronave.Id) != null)
            {
                Notify("Já existe uma Aeronave Cadastrada com este Modelo!");
                return;
            }

            _aeronaveRepository.Update(aeronave);
            await _aeronaveRepository.SaveChangesAsync();
        }

        public async Task Remover(Guid id)
        {
            var aeronave = await _aeronaveRepository.FindAsync(id);

            _aeronaveRepository.Remove(aeronave);

            await _aeronaveRepository.SaveChangesAsync();
        }

        public void Dispose()
        {
            _aeronaveRepository?.Dispose();
        }

    }
}
