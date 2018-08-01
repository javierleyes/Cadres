using Entidades;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IVarillaService
    {
        Varilla GetById(long idVarilla);

        IList<Varilla> GetAll();

        void Agregar(Varilla varilla);

        IList<Varilla> GetByDisponibilidad(bool estaDisponible);

        void ActualizarPrecio(Varilla varilla, decimal precio);

        void DarDeBaja(Varilla varilla);
    }
}
