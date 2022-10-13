using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using BookCaféModelLib;
using BookCaféModelLib.model;

namespace BookCaféConsumerREST
{

    public class Consumer
    {
        private static string URL = "http://localhost:5024/api/Books/";

        public async Task<List<Book>> GetAllAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage resp = await client.GetAsync(URL);
                if (resp.IsSuccessStatusCode)
                {
                    List<Book> cList = await resp.Content.ReadFromJsonAsync<List<Book>>();
                    return cList;
                }
                return new List<Book>(); // Could also be casting an exception here
            }
        }

        public async Task<Book> GetOneAsync(string title)
        {
            using (HttpClient client = new HttpClient())
            { 
                HttpResponseMessage resp = await client.GetAsync(URL + title);
                if (resp.IsSuccessStatusCode)
                {
                    Book singleBook = await resp.Content.ReadFromJsonAsync<Book>();
                    return singleBook;
                }
                return new Book(); // Could also be casting an exception here
            }
        }

        public async Task<Book> PutAsync(string title, Book changedBook)
        {
            using (HttpClient client = new HttpClient())
            {
                JsonContent content = JsonContent.Create(changedBook);

                HttpResponseMessage resp = await client.PutAsync(URL + title, content);
                if (resp.IsSuccessStatusCode)
                {
                    Book cBook = await resp.Content.ReadFromJsonAsync<Book>();
                    return cBook;
                }
                return new Book(); // Could also be casting an exception here
            }
        }

        public async Task<Book> PostAsync(Book book)
        {
            using (HttpClient client = new HttpClient())
            {
                JsonContent content = JsonContent.Create(book);

                HttpResponseMessage resp = await client.PostAsync(URL, content);
                if (resp.IsSuccessStatusCode)
                {
                    Book addedBook = await resp.Content.ReadFromJsonAsync<Book>();
                    return addedBook;
                }
                return new Book();
            }
        }
    }
}
