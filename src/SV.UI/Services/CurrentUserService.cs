using Microsoft.AspNetCore.Http;
using SV.Application.Interfaces.Common;
using System;
using System.Security.Claims;

namespace SV.UI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public string UserId { get; }
        public string Nome { get; }

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            Nome = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
        }
        

    }
}
