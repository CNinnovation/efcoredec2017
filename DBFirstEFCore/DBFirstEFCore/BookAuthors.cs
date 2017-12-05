using System;
using System.Collections.Generic;

namespace DBFirstEFCore
{
    public partial class BookAuthors
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        public Authors Author { get; set; }
        public Books Book { get; set; }
    }
}
