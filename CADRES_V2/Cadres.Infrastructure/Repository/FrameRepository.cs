using Cadres.Domain.Entity;
using Cadres.Infrastructure.Base;
using Cadres.Infrastructure.Repository.Interface;

namespace Cadres.Infrastructure.Repository
{
    public class FrameRepository : BaseRepository<Frame>, IFrameRepository
    {
        public FrameRepository(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
        }
    }
}
