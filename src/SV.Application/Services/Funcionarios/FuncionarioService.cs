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
using System.Threading.Tasks;

namespace SV.Application.Services.Funcionarios
{
    public class FuncionarioService : BaseService, IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IMapper _mapper;
        public FuncionarioService(INotifier notifier, 
                                  IFuncionarioRepository funcionarioRepository, 
                                  IMapper mapper) : base(notifier)
        {
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
        }

        public async Task<FuncionarioInputModel> ObterFuncionarioPorId(Guid id)
        {
            return _mapper.Map<FuncionarioInputModel>
                (await _funcionarioRepository.FindAsync(id));
        }

        public async Task<IEnumerable<Funcionario>> ObterTodosFuncionarios()
        {
            return _mapper.Map<IEnumerable<Funcionario>>
                 (await _funcionarioRepository.GetAllAsync());
        }

        public async Task Inserir(FuncionarioInputModel funcionarioModel)
        {
            if (!IsValide(new FuncionarioValidation(), funcionarioModel)) return;

            var funcionario = _mapper.Map<Funcionario>(funcionarioModel);

            if (await _funcionarioRepository.FirstOrDefaultAsync(a => a.Nome == funcionarioModel.Nome) != null)
            {
                Notify("Já existe um Funcionario Cadastrado com este nome!");
                return;
            }

            _funcionarioRepository.Add(funcionario);
            await _funcionarioRepository.SaveChangesAsync();
        }

        public async Task Atualizar(FuncionarioInputModel funcionarioModel)
        {
            if (!IsValide(new FuncionarioValidation(), funcionarioModel)) return;

            var funcionario = _mapper.Map<Funcionario>(funcionarioModel);

            if (await _funcionarioRepository.FirstOrDefaultAsync(a =>
                  a.Nome == funcionarioModel.Nome && a.Id != funcionarioModel.Id) != null)
            {
                Notify("Já existe umFuncionario Cadastrado com este nome!");
                return;
            }

            _funcionarioRepository.Update(funcionario);
            await _funcionarioRepository.SaveChangesAsync();
        }

        public async Task Remover(Guid id)
        {
            var funcionario = await _funcionarioRepository.FindAsync(id);

            _funcionarioRepository.Remove(funcionario);

            await _funcionarioRepository.SaveChangesAsync();
        }

        public void Dispose()
        {
            _funcionarioRepository?.Dispose();
        }
    }
}
