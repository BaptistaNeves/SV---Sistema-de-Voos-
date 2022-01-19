using SV.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Core.Interfaces.Repositories.Generic
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entidade
    {
    }
}
