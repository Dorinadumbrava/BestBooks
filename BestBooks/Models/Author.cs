using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BestBooks.Models
{ [Table("Authors")]
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}