using AutoMapper;
using SV.Application.InputModels.Usuarios;
using SV.Application.Interfaces.Services.Usuarios;
using SV.Application.Services.Base;
using SV.Application.Validations.Usuarios;
using SV.Core.DTOs.Usuarios;
using SV.Core.Entities.Usuarios;
using SV.Core.Interfaces.Notifications;
using SV.Core.Interfaces.Repositories.Usuarios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SV.Application.Services.Usuarios
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioService(INotifier notifier,
                              IUsuarioRepository usuarioRepository, 
                              IMapper mapper) : base(notifier)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDto>> ObterTodosUsuarios()
        {
            return await _usuarioRepository.GetAll();
        }

        public async Task<UsuarioDto> ObterUsuarioPorEmail(string email)
        {
            return await _usuarioRepository.GetByEmail(email);
        }

        public async Task<UsuarioInputModel> ObterUsuarioPorId(Guid id)
        {
            return _mapper.Map<UsuarioInputModel>(await _usuarioRepository.GetById(id));
        }

        public async Task Inserir(UsuarioInputModel usuarioModel)
        {
            if (!IsValide(new UsuarioValidation(), usuarioModel)) return;

            var usuario = _mapper.Map<Usuario>(usuarioModel);

            await _usuarioRepository.Add(usuario);
        }

        public async Task Atualizar(UsuarioInputModel usuarioModel)
        {
            if (!IsValide(new UsuarioValidation(), usuarioModel)) return;

            var usuario = _mapper.Map<Usuario>(usuarioModel);

            await _usuarioRepository.Update(usuario);
        }

        public async Task Remove(Guid id)
        {
            await _usuarioRepository.Remove(id);
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }
    }
}
