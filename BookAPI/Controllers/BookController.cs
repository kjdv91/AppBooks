using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entidades;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BooksApplicationDbContext _context;

        public BookController(BooksApplicationDbContext context)
        {
                _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            var listBook = await _context.Books.Include(x=>x.Category).ToListAsync();
            return Ok(listBook);
        }
    }
}
