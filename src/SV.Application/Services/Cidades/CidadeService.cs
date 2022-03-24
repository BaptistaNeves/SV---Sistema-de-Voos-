using AutoMapper;
using SV.Application.InputModels.Cidades;
using SV.Application.Interfaces.Services.Cidades;
using SV.Application.Services.Base;
using SV.Application.Validations.Cidades;
using SV.Core.Entities.Cidades;
using SV.Core.Interfaces.Notifications;
using SV.Core.Interfaces.Repositories.Cidades;
using SV.Core.ViewModels.Cidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SV.Application.Services.Cidades
{
    public class CidadeService : BaseService, ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IMapper _mapper;
        public CidadeService(INotifier notifier,
                             ICidadeRepository cidadeRepository, 
                             IMapper mapper) : base(notifier)
        {
            _cidadeRepository = cidadeRepository;
            _mapper = mapper;
        }

        public async Task<CidadeViewModel> ObterCidadePorId(Guid id)
        {
            return _mapper.Map<CidadeViewModel>(await _cidadeRepository.FindAsync(id));
        }

        public async Task<IEnumerable<CidadeViewModel>> ObterTodasCidades()
        {
            return _mapper.Map<IEnumerable<CidadeViewModel>>(await _cidadeRepository.GetAllAsync());
        }

        public async Task Inserir(CidadeInputModel cidadeModel)
        {
            if (!IsValide(new CidadeValidation(), cidadeModel)) return;

            var cidade = _mapper.Map<Cidade>(cidadeModel);

            if(await _cidadeRepository.FirstOrDefaultAsync(c => c.Nome == cidadeModel.Nome) != null)
            {
                Notify("Já existe uma cidade Cadastrada com este nome!");
                return;
            }

            _cidadeRepository.Add(cidade);
            await _cidadeRepository.SaveChangesAsync();
        }
        public async Task Atualizar(CidadeInputModel cidadeModel)
        {
            if(!IsValide(new CidadeValidation(), cidadeModel)) return;

            var cidade = _mapper.Map<Cidade>(cidadeModel);

            if (await _cidadeRepository.FirstOrDefaultAsync(c =>
                 c.Nome == cidadeModel.Nome && c.Id != cidade.Id) != null)
            {
                Notify("Já existe uma cidade Cadastrada com este nome!");
                return;
            }

            _cidadeRepository.Update(cidade);
            await _cidadeRepository.SaveChangesAsync();
        }

        public async Task Remover(Guid id)
        {
            if(_cidadeRepository.FirstOrDefaultAsync(a => a.Id == id, "Aeroportos")
                .Result.Aeroportos.Any())
            {
                Notify("Esta cidade possui Aeroportos cadastrados não pode ser Excluido!");
                return;
            }

            var cidade = await _cidadeRepository.FindAsync(id);
            _cidadeRepository.Remove(cidade);

            await _cidadeRepository.SaveChangesAsync();
        }

        public void Dispose()
        {
            _cidadeRepository?.Dispose();
        }
    }
}
