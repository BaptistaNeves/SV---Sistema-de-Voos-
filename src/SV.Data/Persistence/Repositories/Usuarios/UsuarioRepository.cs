using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SV.Core.DTOs.Usuarios;
using SV.Core.Entities.Usuarios;
using SV.Core.Interfaces.Notifications;
using SV.Core.Interfaces.Repositories.Usuarios;
using SV.Core.Notifications;
using SV.Data.Persistence.Context;
using SV.Data.Persistence.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SV.Data.Persistence.Repositories.Usuarios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly INotifier _notifier;

        public UsuarioRepository(UserManager<AppUser> userManager,
                                 RoleManager<AppRole> roleManager,
                                 ApplicationDbContext context,
                                 INotifier notifier, 
                                 SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _notifier = notifier;
            _context = context;
            _signInManager = signInManager;
        }

        public async Task<IEnumerable<UsuarioDto>> GetAll()
        {
            return await _context.Users.AsNoTracking()
                .Select(usuario => new UsuarioDto
                {
                    Id = usuario.Id,
                    NomeDeUtilizador = usuario.NomeDeUtilizador,
                    Email = usuario.Email,
                    Telefone = usuario.PhoneNumber,
                    Perfil = usuario.UserRoles.Select(ur => ur.Role.Name).FirstOrDefault()
                }).ToListAsync();
        }


        public async Task<IEnumerable<UsuarioDto>> GetAllUsersLessLogged(Guid id)
        {
            return await _context.Users.AsNoTracking()
                .Where(u => u.Id != id)
                .Select(usuario => new UsuarioDto
                {
                    Id = usuario.Id,
                    NomeDeUtilizador = usuario.NomeDeUtilizador,
                    Email = usuario.Email,
                    Telefone = usuario.PhoneNumber,
                    Perfil = usuario.UserRoles.Select(ur => ur.Role.Name).FirstOrDefault()
                }).ToListAsync();
        }

        public async Task<UsuarioDto> GetByEmail(string email)
        {
            return await _context.Users.AsNoTracking()
                          .Where(u => u.Email == email)
                          .Include(ur => ur.UserRoles)
                          .ThenInclude(r => r.Role)
                          .Select(usuario => new UsuarioDto
                          {
                              Id = usuario.Id,
                              NomeDeUtilizador = usuario.NomeDeUtilizador,
                              Email = usuario.Email,
                              Telefone = usuario.PhoneNumber,
                              Perfil = usuario.UserRoles.Select(ur => ur.Role.Name).FirstOrDefault()
                          }).SingleOrDefaultAsync();
        }

        public async Task<UsuarioDto> GetById(Guid id)
        {
            return await _context.Users.AsNoTracking()
                           .Where(u => u.Id == id)
                           .Include(ur => ur.UserRoles)
                           .ThenInclude(r => r.Role)
                           .Select(usuario => new UsuarioDto
                           {
                               Id = usuario.Id,
                               NomeDeUtilizador = usuario.NomeDeUtilizador,
                               Email = usuario.Email,
                               Telefone = usuario.PhoneNumber,
                               Perfil = usuario.UserRoles.Select(ur => ur.Role.Name).FirstOrDefault()
                           }).SingleOrDefaultAsync();
        }

        public async Task Add(Usuario usuario)
        {
            var appUser = new AppUser
            {
                Id = usuario.Id,
                NomeDeUtilizador = usuario.NomeDeUtilizador,
                UserName = usuario.Email,
                Email = usuario.Email,
                PhoneNumber = usuario.Telefone
            };

            var resultado = await _userManager.CreateAsync(appUser, usuario.Senha);

            if (!resultado.Succeeded)
            {
                NotifyIdentityError(resultado);
                return;
            }

            await _userManager.AddToRoleAsync(appUser, usuario.Perfil);
        }

        public async Task Update(Usuario usuario)
        {
            var usuarioAtualizar = await _userManager.FindByIdAsync(usuario.Id.ToString());

            var perfilAntigo = (await _userManager.GetRolesAsync(usuarioAtualizar)).FirstOrDefault();

            await _userManager.UpdateSecurityStampAsync(usuarioAtualizar);

            usuarioAtualizar.NomeDeUtilizador = usuario.NomeDeUtilizador;
            usuarioAtualizar.UserName = usuario.Email;
            usuarioAtualizar.PhoneNumber = usuario.Telefone;
            usuarioAtualizar.Email = usuario.Email;

            var resultado = await _userManager.UpdateAsync(usuarioAtualizar);

            if (!resultado.Succeeded)
            {
                NotifyIdentityError(resultado);
                return;
            }

            if(usuario.Perfil != perfilAntigo)
            {
                await _userManager.RemoveFromRoleAsync(usuarioAtualizar, perfilAntigo);
                
                var resultRole = await _userManager.AddToRoleAsync(usuarioAtualizar, usuario.Perfil);

                if (!resultRole.Succeeded)
                {
                    NotifyIdentityError(resultRole);
                    return;
                }
            }

            if(!string.IsNullOrWhiteSpace(usuario.Senha))
            {
                var alterarSenhaResultado = await _userManager.ChangePasswordAsync(usuarioAtualizar, usuario.SenhaAntiga, usuario.Senha);

                if (!alterarSenhaResultado.Succeeded)
                {
                    NotifyIdentityError(alterarSenhaResultado);
                    return;
                }
            }

        }

        public async Task Remove(Guid id)
        {
            var usuario = await _userManager.FindByIdAsync(id.ToString());

            var resultado = await _userManager.DeleteAsync(usuario);

            if (!resultado.Succeeded)
            {
                NotifyIdentityError(resultado);
                return;
            }
        }

        public async Task<bool> Login(string email, string senha)
        {
            var resultado = await _signInManager.PasswordSignInAsync(email, senha, false, true);

            if (resultado.Succeeded)
            {
                return true;
            }

            if (resultado.IsLockedOut)
            {
                _notifier.Handle(new Notification("Usuário temporariamente bloqueado por tentativas inválidas!"));
                return false;
            }

            _notifier.Handle(new Notification("Usuário ou Senha incorretos!"));
            return false;
        }


        public async Task Logout()
        {
            await _signInManager.SignOutAsync();

        }

        private void NotifyIdentityError(IdentityResult result)
        {
            foreach (var erro in result.Errors)
            {
                _notifier.Handle(new Notification(erro.Description));
            }
        }

        public void Dispose()
        {
            _roleManager?.Dispose();
            _userManager?.Dispose();
            _context?.Dispose();
        }

    }
}
