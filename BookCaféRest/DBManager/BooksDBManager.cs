using BookCaféModelLib.model;
using BookCaféRest.model;

namespace BookCaféRest.DBManager
{
    public class BooksDBManager : IBooksDBManager
    {
        private readonly BooksCaféContext _db = new BooksCaféContext();

        public void Create(Books books)
        {
            _db.Books.Add(books);
            _db.SaveChanges();              // Comitting the changes to the database
                                            // otherwise the database will not keep the changes
        }

        public List<Books> GetAllBooks()
        {
            return _db.Books.ToList();
        }

        public Books Get(string title)
        {
            return _db.Books.ToList().Find(bk => bk.Title == title);
        }

        public void Update(Books books)
        {
            throw new NotImplementedException();
        }

        public void Delete(string title)
        {
            throw new NotImplementedException();
        }
    }
}
