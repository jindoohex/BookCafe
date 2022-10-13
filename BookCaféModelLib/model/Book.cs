using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCaféModelLib.model
{
    public class Book
    {
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public string BookGenre { get; set; }
        public string BookPublisher { get; set; }
        public string BookDescription { get; set; }
        public int BookPrice { get; set; }



        public override string ToString()
        {
            return $"Title: {BookTitle}\tAuthor: {BookAuthor}\tGenre: {BookGenre}\tPublisher: {BookPublisher}\tDescription: {BookDescription}\tPrice: {BookPrice}";
        }

    }
}
