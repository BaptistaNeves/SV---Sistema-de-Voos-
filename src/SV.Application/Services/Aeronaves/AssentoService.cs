using AutoMapper;
using SV.Application.InputModels.Aeronaves;
using SV.Application.Interfaces.Services.Aeronaves;
using SV.Application.Services.Base;
using SV.Application.Validations.Aeronaves;
using SV.Core.Entities.Aeronaves;
using SV.Core.Interfaces.Notifications;
using SV.Core.Interfaces.Repositories.Aeronaves;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SV.Application.Services.Aeronaves
{
    public class AssentoService : BaseService, IAssentoService
    {
        private readonly IAssentoRepository _assentoRepository;
        private readonly IClasseRepository _classeRepository;
        private readonly IAeronaveRepository _aeronaveRepository;
        private readonly IMapper _mapper;
        public AssentoService(INotifier notifier,
                              IAssentoRepository assentoRepository,
                              IMapper mapper,
                              IClasseRepository classeRepository, 
                              IAeronaveRepository aeronaveRepository) : base(notifier)
        {
            _assentoRepository = assentoRepository;
            _mapper = mapper;
            _classeRepository = classeRepository;
            _aeronaveRepository = aeronaveRepository;
        }
        public async Task<AssentoInputModel> ObterAssetoPorId(Guid id)
        {
            return _mapper.Map<AssentoInputModel>(await _assentoRepository.FindAsync(id));
        }

        public async Task<IEnumerable<Assento>> ObterTodosAssentos()
        {
            return await _assentoRepository.GetAllAsync(inCludeProperties: "Aeronave,Classe");
        }

        public async Task Inserir(AssentoInputModel inputModel)
        {
            if (!IsValide(new AssentoValidation(), inputModel)) return;

            var assento = _mapper.Map<Assento>(inputModel);

            if (await _assentoRepository.FirstOrDefaultAsync(a => a.Numero == inputModel.Numero) != null)
            {
                Notify("Já existe um Assento Cadastrada com este Número!");
                return;
            }

            _assentoRepository.Add(assento);
            await _assentoRepository.SaveChangesAsync();
        }

        public async Task Atualizar(AssentoInputModel inputModel)
        {
            if (!IsValide(new AssentoValidation(), inputModel)) return;

            var assento = _mapper.Map<Assento>(inputModel);

            if (await _assentoRepository.FirstOrDefaultAsync(a =>
                a.Numero == inputModel.Numero && a.Id != assento.Id) != null)
            {
                Notify("Já existe uma cidade Cadastrada com este nome!");
                return;
            }

            _assentoRepository.Update(assento);
            await _assentoRepository.SaveChangesAsync();
        }

        public async Task Remover(Guid id)
        {
            var assento = await _assentoRepository.FindAsync(id);

            _assentoRepository.Remove(assento);

            await _assentoRepository.SaveChangesAsync();
        }

        public void Dispose()
        {
            _assentoRepository?.Dispose();
        }

    }
}
