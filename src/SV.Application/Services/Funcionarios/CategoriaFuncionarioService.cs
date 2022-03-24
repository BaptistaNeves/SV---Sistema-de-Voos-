using AutoMapper;
using SV.Application.InputModels.Funcionarios;
using SV.Application.Interfaces.Services.Funcionarios;
using SV.Application.Services.Base;
using SV.Application.Validations.Funcionarios;
using SV.Core.Entities.Funcionarios;
using SV.Core.Interfaces.Notifications;
using SV.Core.Interfaces.Repositories.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SV.Application.Services.Funcionarios
{
    public class CategoriaFuncionarioService : BaseService, ICategoriaFuncionarioService
    {
        private readonly ICategoriaFuncionarioRepository _categoriaFuncionarioRepository;
        private readonly IMapper _mapper;
        public CategoriaFuncionarioService(INotifier notifier, 
                                           ICategoriaFuncionarioRepository categoriaFuncionarioRepository, 
                                           IMapper mapper) : base(notifier)
        {
            _categoriaFuncionarioRepository = categoriaFuncionarioRepository;
            _mapper = mapper;
        }

        public async Task<CategoriaFuncionarioInputModel> ObterCategoriaFuncionarioPorId(Guid id)
        {
            return _mapper.Map<CategoriaFuncionarioInputModel>
                (await _categoriaFuncionarioRepository.FindAsync(id));
        }

        public async Task<IEnumerable<CategoriaFuncionario>> ObterTodasCategoriasFuncionarios()
        {
            return  _mapper.Map<IEnumerable<CategoriaFuncionario>>
                (await _categoriaFuncionarioRepository.GetAllAsync());
        }


        public async Task Inserir(CategoriaFuncionarioInputModel categoriaModel)
        {
            if (!IsValide(new CategoriaFuncionarioValidation(), categoriaModel)) return;

            var categoriaFuncionario = _mapper.Map<CategoriaFuncionario>(categoriaModel);

            if (await _categoriaFuncionarioRepository.FirstOrDefaultAsync(a => a.Nome == categoriaModel.Nome) != null)
            {
                Notify("Já existe uma Categoria de funcionario cadastrada com este nome!");
                return;
            }

            _categoriaFuncionarioRepository.Add(categoriaFuncionario);
            await _categoriaFuncionarioRepository.SaveChangesAsync();
        }

        public async Task Atualizar(CategoriaFuncionarioInputModel categoriaModel)
        {
            if (!IsValide(new CategoriaFuncionarioValidation(), categoriaModel)) return;

            var categoriaFuncionario = _mapper.Map<CategoriaFuncionario>(categoriaModel);

            if (await _categoriaFuncionarioRepository.FirstOrDefaultAsync(a =>
                  a.Nome == categoriaModel.Nome && a.Id != categoriaModel.Id) != null)
            {
                Notify("Já existe uma Categoria de Funcionario Cadastrada com este nome!");
                return;
            }

            _categoriaFuncionarioRepository.Update(categoriaFuncionario);
            await _categoriaFuncionarioRepository.SaveChangesAsync();
        }

        public async Task Remover(Guid id)
        {
            if (_categoriaFuncionarioRepository.FirstOrDefaultAsync(a => a.Id == id, "Funcionarios")
                .Result.Funcionarios.Any())
            {
                Notify("Esta Categoria possui funcionarios cadastrados não pode ser excluida!");
                return;
            }

            var categoriaFuncionario = await _categoriaFuncionarioRepository.FindAsync(id);
            _categoriaFuncionarioRepository.Remove(categoriaFuncionario);

            await _categoriaFuncionarioRepository.SaveChangesAsync();
        }

        public void Dispose()
        {
            _categoriaFuncionarioRepository?.Dispose();
        }

    }
}
