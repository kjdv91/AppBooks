﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entidades
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int idBook { get; set; }
        public string Title { get; set; }
        public string BookDescription { get; set; }
        public DateTime PublishDate { get; set; }
        public decimal Price { get; set; }
        public string  UrlImage { get; set; }
        public int idCategory { get; set; }
        
        [ForeignKey("idCategory")]
        public Category Category { get; set; }
        // lista de autores a ese libro
        public List<AuthorBook> AuthorBooks { get; set; }
        // relacion 1 a 1
        public OfertPrice OfertPrice { get; set; }
        
        // un libro puede tener varios reviews
        public List<Review> Reviews { get; set; }
    }
}
