using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entidades;
using Models.Entidades.Dtos;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinqController : ControllerBase
    {
        private readonly BooksApplicationDbContext _context;

        public LinqController(BooksApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetBooksQuery")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksQuery()
        {
            // query sintax
            var lista = await (from l in _context.Books.Include(x => x.Category)
                               select l).ToListAsync();

            return Ok(lista);
        }

        [HttpGet("GetBooksMethod")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksMethod()
        {
            // method sintax
            var lista = await _context.Books.Include(l => l.Category).ToListAsync();

            return Ok(lista);
        }

        [HttpGet("GetBooksNameQuery")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksNameQuery(string title)
        {
            // query sintax
            var lista = await (from l in _context.Books.Include(x => x.Category)
                               where l.Title == title
                               select l).ToListAsync();

            return Ok(lista);
        }

        [HttpGet("GetBooksNameMethod")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksNameMethod(string title)
        {
            // method sintax
            var lista = await _context.Books.Include(l => l.Category)
                         .Where(x => x.Title == title).ToListAsync();

            return Ok(lista);
        }

        [HttpGet("GetBookOrderBy")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBookOrderBy()
        {
            var listaBook = await _context.Books.Include(b => b.Category).
                OrderBy(b => b.Price).ToArrayAsync();

            return Ok(listaBook);
        }

        // me trae ciertas columnas
        [HttpGet("GetBooksProyectar")]

        public async Task<ActionResult<IEnumerable<Book>>> GetBooksProyectar()
        {
            // query sintax

            var listaFilter = await (from l in _context.Books.Include(x => x.Category)
                                     orderby l.Price
                                     select new BookDto { Titulo = l.Title, NombreCategoria = l.Category.categoryName, Precio = l.Price }
                                    ).ToListAsync();

            return Ok(listaFilter);
        }
        [HttpGet("GetBooksProyectarMethod")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksProyectarMethod()
        {
            // method sintax

            var listaFilterColumn = await _context.Books.Include(x => x.Category)
                .OrderBy(x => x.Price)
                .Select(b => new BookDto { Precio = b.Price, Titulo = b.Title }).ToListAsync();

            return Ok(listaFilterColumn);
        }

        [HttpGet("GetCategoryQuery")]
        public async Task<ActionResult<IEnumerable<Book>>> GetCategoryQuery() {


            var ccategory = await (from c in _context.Categories
                                   select new
                                   {
                                       Id = c.Id,
                                       Category = c.categoryName,
                                       Books = c.ListaBooks

                                   }).ToListAsync();
            return Ok(ccategory);
        }

        [HttpGet("GetCategoryMethod")]
        public async Task<ActionResult<IEnumerable<Book>>> GetCategoryMethod()
        {
            var categoryList = await _context.Categories
                    .Select(x => new
                    {
                        Id = x.Id,
                        Category = x.categoryName,
                        Books = x.ListaBooks
                    }).ToArrayAsync();

            return Ok(categoryList);
        }

        [HttpGet("GetLibrosUnionQuery")]

        public async Task<ActionResult<IEnumerable<Book>>> GetLibrosUnionQuery(){

            var list = await (from l in _context.Books.Include(l => l.Category)
                              orderby l.Title
                              where l.Price >= 20
                              select new
                              {
                                  Title = l.Title,
                                  Category = l.Category.categoryName,
                                  Price = l.Price,
                                  PublishDate = l.PublishDate
                              }
                              ).ToListAsync();


            var listTwo = await (from l in _context.Books.Include(l => l.Category)
                              orderby l.Title
                              where l.PublishDate.Year >= 2020
                              select new
                              {
                                  Title = l.Title,
                                  Category = l.Category.categoryName,
                                  Price = l.Price,
                                  PublishDate = l.PublishDate
                              }
                              ).ToListAsync();
            // concatena ambas listas
            var unionList = list.Union(listTwo);


            return Ok(unionList);


            
        }


        [HttpGet("GetLibrosUnionMethod")]

        public async Task<ActionResult<IEnumerable<Book>>> GetLibrosUnionMethod()
        {
            var listBookOne = await _context.Books.Include(

                    l => l.Category)
                    .Where(p=> p.Price>= 40)
                    .Select(l=>
                    new
                    {
                        Title = l.Title,
                        Category = l.Category.categoryName,
                        Price = l.Price,
                        PublishDate = l.PublishDate
                    }
                    )
                    
                .ToListAsync();


            var listBookTwo = await _context.Books.Include(

                    l => l.Category)
                    .Where(p => p.PublishDate.Year >= 2021)
                    .Select(l =>
                    new
                    {
                        Title = l.Title,
                        Category = l.Category.categoryName,
                        Price = l.Price,
                        PublishDate = l.PublishDate
                    }
                    )

                .ToListAsync();

            var listUnion = listBookOne.Union(listBookTwo);
            
            
            return Ok(listUnion);

        }



        }
}
