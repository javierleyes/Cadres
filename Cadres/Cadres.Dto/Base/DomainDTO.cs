using System;

namespace Cadres.Dto.Base
{
    public class DomainDTO<TKey> : IDomainDTO<TKey> where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }
}
