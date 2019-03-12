using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadres.Dto.Base
{
    public interface IDomainDTO<TKey> where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}
