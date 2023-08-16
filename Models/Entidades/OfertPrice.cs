using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entidades
{
    [Table("OfertPrice")]
    public class OfertPrice
    {
        [Key]
        public int PriceOfertId { get; set; }
        public decimal NewPrice { get; set; }
        [Column("PromotionalText")]
        public string TextPromotional { get; set; }
        public int idBook { get; set; }
        [ForeignKey("idBook")]
        public Book Book { get; set; }
    }
}
