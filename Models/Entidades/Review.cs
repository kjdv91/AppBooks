using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entidades
{
    [Table("Review")]
    public class Review
    {
        [Key]
        [Column("ReviewId")]
        public int Id { get; set; }
        public string VoteName  { get; set; }
        public int StarNumber { get; set; }
        public string Comment { get; set; }
        public int idBook { get; set; }
        [ForeignKey("idBook")]
        // propiedad navvegacion
        public Book Book { get; set; }
    }
}
