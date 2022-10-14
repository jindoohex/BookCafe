using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookCaféRest.model;

namespace BookCaféRest.DBControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksEFMadeDBController : ControllerBase
    {
        private readonly BooksCaféContext _context;

        public BooksEFMadeDBController(BooksCaféContext context)
        {
            _context = context;
        }

        // GET: api/BooksEFMade
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Books>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        // GET: api/BooksEFMade/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Books>> GetBooks(string id)
        {
            var books = await _context.Books.FindAsync(id);

            if (books == null)
            {
                return NotFound();
            }

            return books;
        }

        // PUT: api/BooksEFMade/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooks(string id, Books books)
        {
            if (id != books.Title)
            {
                return BadRequest();
            }

            _context.Entry(books).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BooksEFMade
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Books>> PostBooks(Books books)
        {
            _context.Books.Add(books);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BooksExists(books.Title))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBooks", new { id = books.Title }, books);
        }

        // DELETE: api/BooksEFMade/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooks(string id)
        {
            var books = await _context.Books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }

            _context.Books.Remove(books);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BooksExists(string id)
        {
            return _context.Books.Any(e => e.Title == id);
        }
    }
}
