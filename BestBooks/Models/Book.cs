using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestBooks.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public Author AuthorId { get; set; }
        public Publisher PublisherId { get; set; }
        public Genre GenreId { get; set; }
        public DateTime DatePublished { get; set; }
    }
}