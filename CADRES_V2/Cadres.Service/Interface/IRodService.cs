using Cadres.Service.Dto;
using System.Collections.Generic;

namespace Cadres.Service.Interface
{
    public interface IRodService
    {
        IList<RodOutputDataContract> GetRodsAvailable();

        RodOutputDataContract GetByid(long id);
    }
}
