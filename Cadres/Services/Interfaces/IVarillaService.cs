using Entidades;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IVarillaService
    {
        Varilla GetById(long idVarilla);

        IList<Varilla> GetAll();

        void AgregarVarilla(Varilla varilla);

        IList<Varilla> GetVarillasByDisponibilidad(bool estaDisponible);

        void UpdatePrecio(Varilla varilla, decimal precio);
    }
}
