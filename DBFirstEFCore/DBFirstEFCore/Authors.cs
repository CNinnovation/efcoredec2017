using System;
using System.Collections.Generic;

namespace DBFirstEFCore
{
    public partial class Authors
    {
        public Authors()
        {
            BookAuthors = new HashSet<BookAuthors>();
        }

        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<BookAuthors> BookAuthors { get; set; }
    }
}
