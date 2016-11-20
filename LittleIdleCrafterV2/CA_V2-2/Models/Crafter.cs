using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LIC
{
    public class Crafter
    {
        [Key]
        public int Id { get; set; }
        public virtual Item Mom { get; set; }
        public byte? MomsNeeded { get; set; }
        public virtual Item Dad { get; set; }
        public byte? DadsNeeded { get; set; }
        [Required]
        public virtual Item Kid { get; set; }
        [Required]
        public byte KidsMade { get; set; }
        [Required]
        public double BaseCost { get; set; }
        [Required]
        public double CostMultiplier { get; set; }
        [Required]
        public int Level { get; set; }
        public bool Researched { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{$"Crafter {Id}",-14}: {Kid.Name} ({KidsMade*Level})\n");
            if (Mom != null && MomsNeeded != null)
            {
                sb.Append($"{" Items needed",-14}:\n");
                sb.Append($"  {MomsNeeded*Level} {Mom.Name}\n");
                if (Dad != null && DadsNeeded != null)
                {
                    sb.Append($"  {DadsNeeded*Level} {Dad.Name}\n");
                }
            }
            sb.Append($"{" Cost",-14}: {BaseCost*Math.Pow(CostMultiplier,Level):0.00}\n");
            sb.Append($"{" Level",-14}: {Level}");
            return sb.ToString();
        }
    }
}