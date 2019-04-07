using System;

namespace Cadres.Web.Models.DTO.Base
{
    public class GenericView<TKey> : IGenericView<TKey> where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }
}