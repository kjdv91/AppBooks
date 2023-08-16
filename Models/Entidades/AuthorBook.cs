using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entidades
{
    [Table("AuthorBook")]
    public class AuthorBook
    {
        [Key]
        public int BookAuthorId { get; set; }
        public int authorId { get; set; }
        public int idBook { get; set; }
        
        [ForeignKey("authorId")]
        public Author Author { get; set; }

        [ForeignKey("idBook")]
        // propiedad de navegacion
        public Book Book { get; set; }
        public int Orden { get; set; }

        
    }
}
