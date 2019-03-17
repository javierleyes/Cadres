using System;

namespace Cadres.Dto.Base
{
    public interface IDomainDTO<TKey> where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}
