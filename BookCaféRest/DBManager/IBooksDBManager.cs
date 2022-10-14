using BookCaféModelLib.model;
using BookCaféRest.model;

namespace BookCaféRest.DBManager
{
    public interface IBooksDBManager
    {
        List<Books> GetAllBooks();
        Books Get(string title);

        void Create(Books book);
        void Update(Books book);
        void Delete(string title);
    }
}
