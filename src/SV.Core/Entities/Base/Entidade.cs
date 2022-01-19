using System;

namespace SV.Core.Entities.Base
{
    public abstract class Entidade
    {
        public Guid Id { get; set; }
        public Entidade()
        {
            Id = Guid.NewGuid();
        }
    }
}
