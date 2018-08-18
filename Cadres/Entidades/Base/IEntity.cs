using System;

namespace Entidades.Base
{
    public interface IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }

        bool IsTransient();
    }
}
