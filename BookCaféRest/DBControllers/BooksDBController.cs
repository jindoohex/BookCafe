using BookCaféRest.DBManager;
using BookCaféRest.model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookCaféRest.DBControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksDBController : ControllerBase
    {
        private readonly IBooksDBManager bkmgr = new BooksDBManager();

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Books> Get()
        {
            return bkmgr.GetAllBooks();
        }

        // GET api/<BooksController>/5
        [HttpGet("{title}")]
        public Books Get(string title)
        {
            return bkmgr.Get(title);
        }

        // POST api/<BooksController>
        [HttpPost]
        public void Post([FromBody] Books value)
        {
            bkmgr.Create(value);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
