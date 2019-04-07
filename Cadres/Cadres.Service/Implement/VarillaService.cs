using System.Collections.Generic;
using System.Linq;
using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using Cadres.Dto;
using Cadres.Service.Base;
using Cadres.Service.Filter;
using Cadres.Service.Interface;

namespace Cadres.Service.Implement
{
    public class VarillaService : GenericService<IVarillaRepository, Varilla, long>, IVarillaService
    {
        public VarillaService(IVarillaRepository entityRepository) : base(entityRepository) { }

        public void Actualizar(VarillaDTO dto)
        {
            Varilla varilla = EntityRepository.GetById(dto.Id);
            varilla.Disponible = dto.Disponible;
            varilla.Cantidad = dto.Cantidad;
            varilla.Precio = dto.Precio;

            EntityRepository.Update(varilla);
        }

        public VarillaDTO CrearNueva(VarillaDTO varillaDTO)
        {
            Varilla varilla = this.FromTo(varillaDTO);
            varilla.Disponible = true;

            varillaDTO.Id = EntityRepository.Save(varilla).Id;

            return varillaDTO;
        }

        public IList<VarillaDTO> GetAllDTO()
        {
            IList<VarillaDTO> dtos = new List<VarillaDTO>();

            IList<Varilla> varillas = this.EntityRepository.GetAll().ToList();

            foreach (Varilla varilla in varillas)
            {
                dtos.Add(this.ToDTO(varilla));
            }

            return dtos;
        }

        public IList<VarillaDTO> GetByFilter(VarillaFilter filter)
        {
            IList<VarillaDTO> varillaDTOs = new List<VarillaDTO>();

            IList<Varilla> varillas = this.EntityRepository.GetAll().Where(x => (x.Disponible == filter.Disponible) || (x.Ancho == filter.Ancho) || x.Nombre.Contains(filter.Nombre)).ToList();

            foreach (Varilla varilla in varillas)
            {
                varillaDTOs.Add(this.ToDTO(varilla));
            }

            return varillaDTOs;
        }

        public VarillaDTO GetDTOById(long id)
        {
            return this.ToDTO(this.EntityRepository.GetById(id));
        }

        private Varilla FromTo(VarillaDTO dto)
        {
            return new Varilla()
            {
                Ancho = dto.Ancho,
                Cantidad = dto.Cantidad,
                Disponible = dto.Disponible,
                Nombre = dto.Nombre,
                Precio = dto.Precio,
            };
        }
        private VarillaDTO ToDTO(Varilla entity)
        {
            return new VarillaDTO()
            {
                Id = entity.Id,
                Ancho = entity.Ancho,
                Nombre = entity.Nombre,
                Precio = entity.Precio,
                Cantidad = entity.Cantidad,
                Disponible = entity.Disponible,
            };
        }
    }
}
