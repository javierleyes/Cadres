using Cadres.Domain.Entity;

namespace Cadres.BusinessTest
{
    public class FrameBuilder
    {
        private decimal _width { get; set; }
        private decimal _large { get; set; }
        private Rod _rod { get; set; }
        private string _note { get; set; }

        internal FrameBuilder(decimal width, decimal large, Rod rod)
        {
            _width = width;
            _large = large;
            _rod = rod;
        }

        internal FrameBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        internal Frame Build() => new Frame(_width, _large, _rod);

        public static implicit operator Frame(FrameBuilder builder) => builder.Build();
    }
}
