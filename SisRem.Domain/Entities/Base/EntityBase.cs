using prmToolkit.NotificationPattern;
using System;

namespace SisRem.Domain.Entities.Base
{
    public abstract class EntityBase : Notifiable
    {
        protected EntityBase()
        {
            Id = Id;
        }

        public int Id { get; set; }
    }
}
