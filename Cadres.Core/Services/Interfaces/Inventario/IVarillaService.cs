using DAL.Interfaces.Inventario;
using Entidades.Inventtario;
using Services.DTO.Inventario;
using Services.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces.Inventario
{
    public interface IVarillaService : IBaseService<IVarillaRepository, Varilla>
    {
        void Insert(VarillaDTO varillaDTO);

        VarillaDTO GetDTOById(int id);

        IList<VarillaDTO> GetDTOAll();

        void SetCantidad(VarillaDTO varillaDTO);

        void SetPrecio(VarillaDTO varillaDTO);

        void DarDeBaja(VarillaDTO varillaDTO);

        IList<VarillaDTO> GetByDisponibilidad(bool estaDisponible);

        IList<VarillaDTO> GetByAncho(decimal ancho);
    }
}
