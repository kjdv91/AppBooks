using Microsoft.EntityFrameworkCore;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BooksApplicationDbContext : DbContext
    {
        public BooksApplicationDbContext(DbContextOptions options) : base(options)
        {


        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors{get; set;}

        public DbSet <Review> Reviews { get; set; }

        public DbSet <OfertPrice> OfertPrices { get; set; }

        public DbSet <AuthorBook> AuthorBooks { get; set; }
    }
}
