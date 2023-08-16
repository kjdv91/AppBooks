using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entidades.Dtos
{
    public class BookDto
    {
        public string Titulo  { get; set; }
        public string NombreCategoria { get; set; }
        public decimal Precio { get; set; }
    }
}
