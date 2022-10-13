using BookCaféConsumerREST;
using BookCaféModelLib.model;

Consumer consumer = new Consumer();

List<Book> books = await consumer.GetAllAsync();

foreach (Book b in books)
{
    Console.WriteLine(b);
}




// Creating the new book
Book createdBook = new() { BookTitle = "New Title", BookAuthor = "New Author", BookGenre = "New Genre", BookPublisher = "New Publisher", BookDescription = "New Description", BookPrice = 200 };

Book returnBook = await consumer.PostAsync(createdBook);

Console.WriteLine("A new book has been created: " + returnBook);

Console.ReadKey();