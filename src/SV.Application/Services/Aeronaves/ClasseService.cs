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
using System.Linq;
using System.Threading.Tasks;

namespace SV.Application.Services.Aeronaves
{
    public class ClasseService : BaseService, IClasseService
    {
        private readonly IClasseRepository _classeRepository;
        private readonly IMapper _mapper;
        public ClasseService(INotifier notifier,
                             IClasseRepository classeRepository, 
                             IMapper mapper) : base(notifier)
        {
            _classeRepository = classeRepository;
            _mapper = mapper;
        }

        public async Task<ClasseInputModel> ObterClassePorId(Guid id)
        {
            return _mapper.Map<ClasseInputModel>(await _classeRepository.FindAsync(id));
        }

        public async Task<IEnumerable<Classe>> ObterTodasClasses()
        {
            return await _classeRepository.GetAllAsync();
        }


        public async Task Inserir(ClasseInputModel inputModel)
        {
            if (!IsValide(new ClasseValidation(), inputModel)) return;

            var classe = _mapper.Map<Classe>(inputModel);

            if (await _classeRepository.FirstOrDefaultAsync(c => c.Descricao == inputModel.Descricao) != null)
            {
                Notify("Já existe uma Classe Cadastrada com esta Descrição!");
                return;
            }

            _classeRepository.Add(classe);
            await _classeRepository.SaveChangesAsync();
        }

        public async Task Atualizar(ClasseInputModel inputModel)
        {
            if(!IsValide(new ClasseValidation(), inputModel)) return;

            var classe = _mapper.Map<Classe>(inputModel);

            if (await _classeRepository.FirstOrDefaultAsync(c =>
                 c.Descricao == inputModel.Descricao && c.Id != classe.Id) != null)
            {
                Notify("Já existe uma Classe Cadastrada com este nome!");
                return;
            }

            _classeRepository.Update(classe);
            await _classeRepository.SaveChangesAsync();
        }

        public async Task Remover(Guid id)
        {
            if (_classeRepository.FirstOrDefaultAsync(a => a.Id == id, "Assentos")
                .Result.Assentos.Any())
            {
                Notify("Esta Classe possui Assentos cadastrados não pode ser Excluido!");
                return;
            }

            var cidade = await _classeRepository.FindAsync(id);
            _classeRepository.Remove(cidade);

            await _classeRepository.SaveChangesAsync();
        }

        public void Dispose()
        {
            _classeRepository?.Dispose();
        }
    }
}
