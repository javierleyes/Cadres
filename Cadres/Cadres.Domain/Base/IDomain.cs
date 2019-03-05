using System;

namespace Cadres.Domain.Base
{
    public interface IDomain<TKey> where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}
