using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Assemblers
{
    public interface IAssembler<TFullEntityDTO, TEntity>
    {
        TFullEntityDTO ToDTO(TEntity entity);

        TEntity FromDTO(TFullEntityDTO fullEntityDTO);
    }
}
