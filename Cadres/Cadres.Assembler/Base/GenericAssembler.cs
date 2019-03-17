using Cadres.Domain.Base;
using Cadres.Dto.Base;

namespace Cadres.Assembler.Base
{
    public abstract class GenericAssembler<TEntity, TDto> : IGenericAssembler<TEntity, TDto>
        where TEntity : Domain<long>
        where TDto : DomainDTO<long>
    {
        public abstract TEntity FromTo(TDto dto);

        public abstract TDto ToDTO(TEntity entity);
    }
}
