using Services.DTO.Inventario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces.Inventario
{
    public interface IVarillaService
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
