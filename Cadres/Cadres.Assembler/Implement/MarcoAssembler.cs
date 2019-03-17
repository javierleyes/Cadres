using AutoMapper;
using Cadres.Assembler.Base;
using Cadres.Assembler.Interface;
using Cadres.Domain.Entity;
using Cadres.Dto;

namespace Cadres.Assembler.Implement
{
    public class MarcoAssembler : GenericAssembler<Marco, MarcoDTO>, IMarcoAssembler
    {
        public override Marco FromTo(MarcoDTO dto)
        {
            Marco entity = Mapper.Map<Marco>(dto);

            return entity;
        }

        public override MarcoDTO ToDTO(Marco entity)
        {
            MarcoDTO dto = Mapper.Map<MarcoDTO>(entity);

            return dto;
        }
    }

    public class MarcoMappingProfile : Profile
    {
        public MarcoMappingProfile()
        {
            CreateMap<Marco, MarcoDTO>();
            CreateMap<MarcoDTO, Marco>();
        }
    }
}
