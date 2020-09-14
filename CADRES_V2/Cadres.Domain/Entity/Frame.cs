using Cadres.Domain.Base;
using Cadres.Domain.Status;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cadres.Domain.Entity
{
    [Table("Frame", Schema = "dbo")]
    public class Frame : Domain<long>
    {
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Width { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Large { get; set; }

        [Required]
        public Rod Rod { get; set; }

        [Required]
        [Range(0, 2)]
        public FrameStatus.FrameMakingStatus MakingStatus { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string Note { get; set; }

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

        private decimal CalculatePrice()
            => Math.Round(((CalculatePerimeter() + CalculateRodAngle()) / 100) * CalculateRodPrice(), 0);

        private decimal CalculatePerimeter()
            => Width * 2 + Large * 2;

        private decimal CalculateRodAngle()
            => 8 * Rod.Width;

        private decimal CalculateRodPrice()
            => (Rod.Price + (Rod.Price * 21 / 100)) * 2;

        private string GenerateCode()
            => DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
    }
}
