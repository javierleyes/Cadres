using Cadres.Domain.Entity;

namespace Cadres.BusinessTest
{
    internal class RodBuilder
    {
        private string _name { get; set; }
        private decimal _width { get; set; }
        private decimal _price { get; set; }
        private bool _available { get; set; }

        internal RodBuilder(string name)
        {
            _name = name;
            _width = 3;
            _price = 60;
            _available = true;
        }

        internal RodBuilder WithWidth(decimal width)
        {
            _width = width;
            return this;
        }

        internal RodBuilder WithPrice(decimal price)
        {
            _price = price;
            return this;
        }

        internal RodBuilder WithUnavailable()
        {
            _available = false;
            return this;
        }

        internal Rod Build() => new Rod(_name, _width, _price, _available);

        public static implicit operator Rod(RodBuilder builder) => builder.Build();
    }
}
