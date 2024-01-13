using System;
using System.Collections.Generic;

namespace BookStore.DBStandard.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string? AuthorName { get; set; }

    public string Title { get; set; } = null!;

    public decimal? Price { get; set; }

    public string? BookCoverUrl { get; set; }

    public int BookTypeId { get; set; }

    public string? BookTag { get; set; }

    public virtual BookType BookType { get; set; } = null!;
}
