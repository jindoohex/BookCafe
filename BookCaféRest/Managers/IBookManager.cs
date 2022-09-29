using BookCaféModelLib.model;

namespace BookCaféRest.Managers
{
    public interface IBookManager
    {
        // CRUD
        Book Create(Book book);
        List<Book> Get();
        Book Update(string bookTitle, int bookPrice, Book book);
        Book Delete(string bookTitle);


        // Get books by specific title
        Book GetBookByTitle(string bookTitle);
        // Get books by specific genre
        Book GetBookByGenre(string bookGenre);
        List<Book> GetBooksByGenre(string bookGenre);

        // Get books by filtered price
        List<Book> SearchBookPrice(int? lowPrice, int? highPrice);
    }
}
