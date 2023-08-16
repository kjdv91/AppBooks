using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entidades
{
    //referencia a la tabla cateegorias de mi bvase de datos
    [Table("Categories")]
    public class Category
    {
        [Key]
        //hace referencia como se llama el id en la tabla
        [Column("idCategory")]
        public int Id { get; set; }
        public string categoryName { get; set; }
        // lista de libros
        public List<Book> ListaBooks { get; set; }
    }
}
