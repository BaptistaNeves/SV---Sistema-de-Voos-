using SV.Core.DTOs.Usuarios;
using SV.Core.Entities.Usuarios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SV.Core.Interfaces.Repositories.Usuarios
{
    public interface IUsuarioRepository : IDisposable
    {
        Task<UsuarioDto> GetById(Guid id);
        Task<UsuarioDto> GetByEmail(string email);
        Task<IEnumerable<UsuarioDto>> GetAll();
        Task Add(Usuario entity);
        Task Update(Usuario entity);
        Task Remove(Guid id);
    }
}
