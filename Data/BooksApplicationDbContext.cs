using Microsoft.EntityFrameworkCore;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BooksApplicationDbContext: DbContext
    {
        public BooksApplicationDbContext(DbContextOptions options): base(options)
        {
            

        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Book> Books { get; set; }
    }
}
