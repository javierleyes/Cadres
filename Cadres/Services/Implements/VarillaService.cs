using DAO;
using Entidades;
using Entidades.DTO;
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

        public IList<VarillaDTO> GetByDisponibilidad(bool estaDisponible)
        {
            return this.EntityDAO.GetByEstadoDisponibilidad(estaDisponible).Select(x => EntityConverter.ConvertVarillaToVarillaDTO(x)).ToList();
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

        public IList<VarillaDTO> GetByAncho(decimal ancho)
        {
            return this.EntityDAO.GetByAncho(ancho).ToList().Select(x => EntityConverter.ConvertVarillaToVarillaDTO(x)).ToList();
        }
    }
}
