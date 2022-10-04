using BookCaféModelLib.model;
using BookCaféRest.Managers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookCaféRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        // Use the manager
        private static IBookManager mgr = new BookManager();


        // GET: api/<BooksController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get()
        {
            List<Book> bookList = mgr.Get();
            return (bookList.Count == 0) ? NoContent(): Ok(bookList);
        }


        // GET api/<BooksController>/5
        [HttpGet]                           // Method
        [Route("{bookTitle}")]              // URI
        public IActionResult GetBookByTitle(string bookTitle)
        {
            try
            {
                Book book = mgr.GetBookByTitle(bookTitle);
                return Ok(book);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet]                           // Method
        [Route("BookGenre/{bookGenre}")]    // URI
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetBooksByGenre(string bookGenre)
        {
            List<Book> books = mgr.GetBooksByGenre(bookGenre);

            return (books.Count == 0) ? NoContent() : Ok(books);
        }

        [HttpGet]                           // Method
        [Route("Search")]                   // URI
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get([FromQuery] BookPriceFilter filter)
        {
            List<Book> bookPriceList = mgr.SearchBookPrice(filter.LowPrice, filter.HighPrice);
            return (bookPriceList.Count == 0) ? NoContent() : Ok(bookPriceList);
        }


        // POST api/<BooksController>
        [HttpPost]                          // MethodS
        public IActionResult Post([FromBody] Book book)
        {
            try
            {
                Book newBook = mgr.Create(book);
                string uri = "api/Books/" + book.BookTitle;
                return Created(uri, newBook);
            }
            catch (ArgumentException ae)
            {

                return Conflict(ae.Message);
            }
            
        }


        // PUT api/<BooksController>/5
        [HttpPut]                           // Method
        [Route("{bookTitle}")]              // URI
        public IActionResult Put(string bookTitle, int bookPrice, [FromBody] Book book)
        {
            try
            {
                return Ok(mgr.Update(bookTitle, bookPrice, book));
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
        }


        // DELETE api/<BooksController>/5
        [HttpDelete]                        // Method
        [Route("{bookTitle}")]              // URI
        // [EnableCors("OnlyGetDelete")]
        public IActionResult Delete(string bookTitle)
        {
            try
            {
                return Ok(mgr.Delete(bookTitle));
            }
            catch (KeyNotFoundException knfe)
            {

                return NotFound(knfe.Message);
            }
            
        }


    }
}
