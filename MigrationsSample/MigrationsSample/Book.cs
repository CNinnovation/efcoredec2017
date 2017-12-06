using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MigrationsSample
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }

        [StringLength(20)]
        public string Isbn { get; set; }

        [StringLength(50)]
        public string LeadAuthor { get; set; }
    }
}
