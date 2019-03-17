using Cadres.Domain.Base;
using Cadres.Dto.Base;

namespace Cadres.Assembler.Base
{
    public interface IGenericAssembler<TEntity, TDto>
        where TEntity : IDomain<long>
        where TDto : IDomainDTO<long>
    {
        TEntity FromTo(TDto dto);

        TDto ToDTO(TEntity entity);
    }
}
