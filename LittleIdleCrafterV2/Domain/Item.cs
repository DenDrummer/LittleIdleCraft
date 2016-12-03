using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LIC.BL.Domain
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double BaseWorth { get; set; }
        [Required]
        public double Count { get; set; }
        [Required]
        public byte Tier { get; set; }
        [Required]
        public bool Researched { get; set; }

        public Item()
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{$"Item {Id}",-12}: {Name}\n");
            sb.Append($"{" Base worth",-12}: {BaseWorth:0.00}\n");
            sb.Append($"{" Count",-12}: {Count}\n");
            sb.Append($"{" Tier",-12}: {Tier}");
            return sb.ToString();
        }
    }
}