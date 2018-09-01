using DAO;
using Entidades;
using Entidades.DTO;
using Entidades.Filter;
using Services.Base;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implements
{
    public class VarillaService : GenericService<VarillaDAO, Varilla, int>, IVarillaService
    {
        public VarillaService(VarillaDAO entityDAO) : base(entityDAO)
        {
        }

        public void Insert(VarillaDTO varillaDTO)
        {
            Varilla varilla = EntityConverter.ConvertVarillaDTOToVarilla(varillaDTO);

            this.Save(varilla);
        }

        public VarillaDTO GetDTOById(int id)
        {
            Varilla varilla = this.GetById(id);

            VarillaDTO dto = EntityConverter.ConvertVarillaToVarillaDTO(varilla);

            return dto;
        }

        public IList<VarillaDTO> GetDTOAll()
        {
            return this.GetAll().Select(x => EntityConverter.ConvertVarillaToVarillaDTO(x)).ToList();
        }

        public void DarDeBaja(VarillaDTO varillaDTO)
        {
            Varilla varilla = EntityConverter.ConvertVarillaDTOToVarilla(varillaDTO);
            varilla.Disponible = false;

            this.Save(varilla);
        }

        public void SetCantidad(VarillaDTO varillaDTO)
        {
            Varilla varilla = EntityConverter.ConvertVarillaDTOToVarilla(varillaDTO);

            this.Save(varilla);
        }

        public void SetPrecio(VarillaDTO varillaDTO)
        {
            Varilla varilla = EntityConverter.ConvertVarillaDTOToVarilla(varillaDTO);

            this.Save(varilla);
        }

        public IList<VarillaDTO> GetByFilter(FilterVarilla filter)
        {
            return this.EntityDAO.GetByFilter(filter).Select(x => EntityConverter.ConvertVarillaToVarillaDTO(x)).ToList();
        }
    }
}
