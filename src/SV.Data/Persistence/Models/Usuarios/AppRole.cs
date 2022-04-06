using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace SV.Data.Persistence.Models.Usuarios
{
    public class AppRole : IdentityRole<Guid>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
