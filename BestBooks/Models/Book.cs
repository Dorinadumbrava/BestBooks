using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BestBooks.Models
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        
        public ICollection<Author> AuthorId { get; set; }

        public Publisher PublisherId { get; set; }
        public ICollection<Genre> GenreId { get; set; }
        public DateTime DatePublished { get; set; }
    }
}