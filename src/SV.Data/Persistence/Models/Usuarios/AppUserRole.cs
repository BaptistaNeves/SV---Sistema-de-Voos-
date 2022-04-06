using Microsoft.AspNetCore.Identity;
using System;

namespace SV.Data.Persistence.Models.Usuarios
{
    public class AppUserRole : IdentityUserRole<Guid>
    {
        public AppUser User { get; set; }
        public AppRole Role { get; set; }
    }
}
