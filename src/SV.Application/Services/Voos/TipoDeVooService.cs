using AutoMapper;
using SV.Application.InputModels.Voos;
using SV.Application.Interfaces.Services.Voos;
using SV.Application.Services.Base;
using SV.Application.Validations.Voos;
using SV.Core.Entities.Voos;
using SV.Core.Interfaces.Notifications;
using SV.Core.Interfaces.Repositories.Voos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SV.Application.Services.Voos
{
    public class TipoDeVooService : BaseService, ITipoDeVooService
    {
        private readonly ITipoDeVooRepository _tipoDeVooRepository;
        private readonly IMapper _mapper;

        public TipoDeVooService(INotifier notifier,
                                ITipoDeVooRepository tipoDeVooRepository, 
                                IMapper mapper) : base(notifier)
        {
            _tipoDeVooRepository = tipoDeVooRepository;
            _mapper = mapper;
        }

        public async Task<TipoDeVooInputModel> ObterTipoDeVooPorId(Guid id)
        {
            return _mapper.Map<TipoDeVooInputModel>(await _tipoDeVooRepository.FindAsync(id));
        }

        public async Task<IEnumerable<TipoDeVoo>> ObterTodosTiposDeVoo()
        {
            return await _tipoDeVooRepository.GetAllAsync();
        }

        public async Task Inserir(TipoDeVooInputModel tipoDeVooModel)
        {
            if (!IsValide(new TipoDeVooValidation(), tipoDeVooModel)) return;

            var tipoDeVoo = _mapper.Map<TipoDeVoo>(tipoDeVooModel);

            if (await _tipoDeVooRepository.FirstOrDefaultAsync(c => c.Nome == tipoDeVooModel.Nome) != null)
            {
                Notify("Já existe um tipo de voo cadastrado com este nome!");
                return;
            }

            _tipoDeVooRepository.Add(tipoDeVoo);
            await _tipoDeVooRepository.SaveChangesAsync();
        }

        public async Task Atualizar(TipoDeVooInputModel tipoDeVooModel)
        {

            if (!IsValide(new TipoDeVooValidation(), tipoDeVooModel)) return;

            var tipoDeVoo = _mapper.Map<TipoDeVoo>(tipoDeVooModel);

            if (await _tipoDeVooRepository.FirstOrDefaultAsync(c =>
                 c.Nome == tipoDeVooModel.Nome && c.Id != tipoDeVooModel.Id) != null)
            {
                Notify("Já existe um tipo de voo cadastrada com este nome!");
                return;
            }

            _tipoDeVooRepository.Update(tipoDeVoo);
            await _tipoDeVooRepository.SaveChangesAsync();
        }

        public async Task Remover(Guid id)
        {
            if (_tipoDeVooRepository.FirstOrDefaultAsync(a => a.Id == id, "Voos")
                .Result.Voos.Any())
            {
                Notify("Este tipo de voo possui Voos cadastrados não pode ser excluido!");
                return;
            }

            var tipoDeVoo = await _tipoDeVooRepository.FindAsync(id);
            _tipoDeVooRepository.Remove(tipoDeVoo);

            await _tipoDeVooRepository.SaveChangesAsync();
        }

        public void Dispose()
        {
            _tipoDeVooRepository?.Dispose();
        }
    }
}
