namespace Entidades.DTOs
{
    public class VarillaDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public decimal Ancho { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }

        public bool Disponible { get; set; }

        public VarillaDTO()
        {
            this.Id = 0;
        }
    }
}
