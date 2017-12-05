using System;
using System.Collections.Generic;

namespace DBFirstEFCore
{
    public partial class Books
    {
        public Books()
        {
            BookAuthors = new HashSet<BookAuthors>();
        }

        public int BookId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Publisher { get; set; }
        public string Title { get; set; }

        public ICollection<BookAuthors> BookAuthors { get; set; }
    }
}
