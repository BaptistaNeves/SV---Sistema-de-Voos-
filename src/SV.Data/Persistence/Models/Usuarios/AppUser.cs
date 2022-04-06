using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace SV.Data.Persistence.Models.Usuarios
{
    public class AppUser : IdentityUser<Guid>
    {
        public string NomeDeUtilizador { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
