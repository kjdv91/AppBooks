using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entidades
{
    [Table("Author")]
    public  class Author
    {
        [DisplayName("Autor")]
        [Key]
        public int AuthorId { get; set; }
        public string NameAuthor { get; set; }
        public string WebUrl { get; set; }

        // Autorr puede tener una lista de libros
        public List<AuthorBook> AuthorBooks { get; set;}
    }
}
