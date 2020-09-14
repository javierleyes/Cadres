using Cadres.Infrastructure.Repository.Interface;
using Cadres.Service.Dto;
using Cadres.Service.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Cadres.Service
{
    public class RodService : IRodService
    {
        private IRodRepository RodRepository { get; set; }
        public RodService(IRodRepository rodRepository)
        {
            RodRepository = rodRepository;
        }

        public IList<RodOutputDataContract> GetRodsAvailable()
        {
            // assembler
            return RodRepository.GetAll()
                .Where(x => x.Available == true)
                .Select(x => new RodOutputDataContract() { Name = x.Name, Code = x.Id })
                .ToList();
        }

        public RodOutputDataContract GetByid(long id)
        {
            var rod = RodRepository.GetById(id);
            return new RodOutputDataContract() { Name = rod.Name, Code = rod.Id };
        }
    }
}
