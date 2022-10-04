using BookCaféModelLib.model;

namespace BookCaféRest.Managers
{
    public class BookManager : IBookManager
    {
        private static List<Book> _books = new List<Book>()
        {
            new Book(){BookTitle="The Seven Balls", 
                BookAuthor="Jens Dam", 
                BookGenre="Thriller", 
                BookPublisher="Betræk Forlaget", 
                BookDescription="En beskrivelse...", 
                BookPrice=150},

            new Book(){BookTitle="Ocean Neat", 
                BookAuthor="Pia Krud", 
                BookGenre="Kronik", 
                BookPublisher="Betræk Forlaget", 
                BookDescription="En beskrivelse...", 
                BookPrice=200},

            new Book(){BookTitle="True Patriot", 
                BookAuthor="Sønner Tue", 
                BookGenre="Fantasy", 
                BookPublisher="Betræk Forlaget", 
                BookDescription="En beskrivelse...", 
                BookPrice=250},

        };


        public BookManager()
        {

        }

        public Book Create(Book book)
        {
            if (_books.Exists(b => b.BookTitle == book.BookTitle))
                throw new ArgumentException("There is already a book with this title.");

            _books.Add(book);
            return book;
        }

        public List<Book> Get()
        {
            return new List<Book>(_books);
        }

        public Book GetBookByTitle(string bookTitle)
        {
            return _books.Find(b => b.BookTitle == bookTitle);
        }

        public Book GetBookByGenre(string bookGenre)
        {
            return _books.Find(b => b.BookGenre == bookGenre.ToLower());
        }

        public List<Book> GetBooksByGenre(string bookGenre)
        {
            return _books.FindAll(b => b.BookGenre.ToLower().Contains(bookGenre.ToLower()));
        }

        public Book Get(string bookTitle)
        {
            if (!_books.Exists(b => b.BookTitle == bookTitle))
                throw new KeyNotFoundException();

            return _books.Find(b => b.BookTitle == bookTitle);
        }

        public List<Book> SearchBookPrice(int? lowPrice, int? highPrice)
        {
            // Finds all books with low price
            List<Book> booksTemp = (lowPrice is null)? _books : _books.Where(b => b.BookPrice >= lowPrice).ToList();

            // Finds all books with high price
            return (highPrice is null)? booksTemp : booksTemp.Where(b => b.BookPrice <= highPrice).ToList();
        }

        public List<Book> BookIndexLow()
        {
            return null;
        }

        public List<Book> BookIndexHigh()
        {
            return null;
        }


        public Book Update(string bookTitle, int bookPrice, Book book)
        {
            Book updateBook = GetBookByTitle(bookTitle);
            if (updateBook != null)
            {
                updateBook.BookTitle = book.BookTitle;
                updateBook.BookAuthor = book.BookAuthor;
                updateBook.BookGenre = book.BookGenre;
                updateBook.BookPublisher = book.BookPublisher;
                updateBook.BookDescription = book.BookDescription;
                updateBook.BookPrice = bookPrice;
            }
            return updateBook;

        }

        // Alternative update method
        public Book UpdateAlternative(string bookTitle, int bookPrice, Book book)
        {
            int index = _books.FindIndex(b => b.BookTitle == bookTitle);
            _books[index] = book;
            return _books[index];
        }

        public Book Delete(string bookTitle)
        {
            Book deleteBook = GetBookByTitle(bookTitle);
            _books.Remove(deleteBook);
            return deleteBook;
        }
    }
}
