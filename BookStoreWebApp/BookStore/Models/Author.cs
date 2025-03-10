using System;
using System.Collections.Generic;

namespace BookStore.Models;

public partial class Author
{
    public int AuthorId { get; set; }

    public string AuthorFirst { get; set; } = null!;

    public string AuthorLast { get; set; } = null!;

    public string FullName => $"{AuthorLast}, {AuthorFirst}";

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
