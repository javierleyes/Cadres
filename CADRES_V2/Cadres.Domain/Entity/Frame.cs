using Cadres.Domain.Base;
using Cadres.Domain.Status;
using System;

namespace Cadres.Domain.Entity
{
    public class Frame : Domain<long>
    {
        public decimal Width { get; set; }
        public decimal Large { get; set; }
        public Rod Rod { get; set; }
        public FrameStatus.FrameMakingStatus MakingStatus { get; set; }
        public string Note { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }

        public Frame(decimal width, decimal large, Rod rod, string note = "")
        {
            Width = width;
            Large = large;
            Rod = rod;
            Note = note;
            MakingStatus = FrameStatus.FrameMakingStatus.Pending;
            Price = CalculatePrice();
            Code = GenerateCode();
        }

        // Business rule
        // width and large [cm]
        // become to mts
        // ( perimeter [cm] + 8 x width rod [cm] ) x price rod [$/m2]
        private decimal CalculatePrice()
        {
            decimal metersNeeded = (CalculatePerimeter() + CalculateRodAngle()) / 100;
            return (metersNeeded * Rod.Price);
        }

        private decimal CalculatePerimeter()
            => Width * 2 + Large * 2;

        private decimal CalculateRodAngle()
            => 8 * Rod.Width;

        private string GenerateCode()
            => DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
    }
}
