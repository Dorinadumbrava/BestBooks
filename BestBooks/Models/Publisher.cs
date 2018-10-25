using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BestBooks.Models
{   [Table("Publishers")]
    public class Publisher
    {
        [Key]
        public int PublisherID { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        public ICollection<Book> Books { get; set; }

    }
}