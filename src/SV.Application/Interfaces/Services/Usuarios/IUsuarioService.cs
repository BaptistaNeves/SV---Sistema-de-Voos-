using SV.Application.InputModels.Usuarios;
using SV.Core.DTOs.Usuarios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SV.Application.Interfaces.Services.Usuarios
{
    public interface IUsuarioService : IDisposable
    {
        Task<UsuarioInputModel> ObterUsuarioPorId(Guid id);
        Task<UsuarioDto> ObterUsuarioPorEmail(string email);
        Task<IEnumerable<UsuarioDto>> ObterTodosUsuarios();
        Task Inserir(UsuarioInputModel usuarioModel);
        Task Atualizar(UsuarioInputModel usuarioModel);
        Task Remove(Guid id);
    }
}
