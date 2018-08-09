using System;

namespace Entidades.Base
{
    public class Entity<TKey> : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }

        public bool IsTransient()
        {
            return Id.Equals(default(TKey));
        }
    }
}
