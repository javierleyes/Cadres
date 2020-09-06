using Cadres.Domain.Base;

namespace Cadres.Domain.Entity
{
    public class Rod : Domain<long>
    {
        public string Name { get; set; }
        public decimal Width { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }

        public Rod(string name, decimal width, decimal price, bool available)
        {
            Name = name;
            Width = width;
            Price = price;
            Available = available;
        }
    }
}
