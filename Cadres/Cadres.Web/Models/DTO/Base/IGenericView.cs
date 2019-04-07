using System;

namespace Cadres.Web.Models.DTO.Base
{
    public interface IGenericView<TKey> where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}
