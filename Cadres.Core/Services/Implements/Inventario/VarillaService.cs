using DAL.Implements.Inventario;
using Entidades.Inventtario;
using Services.Assemblers;
using Services.DTO.Inventario;
using Services.Implements.Base;
using Services.Interfaces.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Implements.Inventario
{
    public class VarillaService : BaseService<VarillaRepository, Varilla, int>, IVarillaService
    {
        VarillaAssembler VarillaAssembler { get; set; }

        public VarillaService(VarillaRepository entityRepository) : base(entityRepository)
        {
            VarillaAssembler = new VarillaAssembler();
        }

        public void Insert(VarillaDTO varillaDTO)
        {
            Varilla varilla = VarillaAssembler.FromDTO(varillaDTO);

            this.Save(varilla);
        }

        public VarillaDTO GetDTOById(int id)
        {
            Varilla varilla = this.GetById(id);

            return VarillaAssembler.ToDTO(varilla); ;
        }

        public IList<VarillaDTO> GetDTOAll()
        {
            return this.GetAll().Select(x => VarillaAssembler.ToDTO(x)).ToList();
        }

        public IList<VarillaDTO> GetByDisponibilidad(bool estaDisponible)
        {
            return this.EntityRepository.GetWhere(x => x.Disponible == estaDisponible)
                .Select(x => VarillaAssembler.ToDTO(x)).ToList();
        }

        public void DarDeBaja(VarillaDTO varillaDTO)
        {
            Varilla varilla = VarillaAssembler.FromDTO(varillaDTO);
            varilla.Disponible = false;

            this.Save(varilla);
        }

        public void SetCantidad(VarillaDTO varillaDTO)
        {
            Varilla varilla = VarillaAssembler.FromDTO(varillaDTO);

            this.Save(varilla);
        }

        public void SetPrecio(VarillaDTO varillaDTO)
        {
            Varilla varilla = VarillaAssembler.FromDTO(varillaDTO);

            this.Save(varilla);
        }

        public IList<VarillaDTO> GetByAncho(decimal ancho)
        {
            return this.EntityRepository.GetWhere(x => x.Ancho == ancho)
                .Select(x => VarillaAssembler.ToDTO(x)).ToList();
        }
    }
}
