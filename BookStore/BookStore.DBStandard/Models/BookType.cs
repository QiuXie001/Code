using System;
using System.Collections.Generic;

namespace BookStore.DBStandard.Models;

public partial class BookType
{
    public int BookTypeId { get; set; }

    public string? BookType1 { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}