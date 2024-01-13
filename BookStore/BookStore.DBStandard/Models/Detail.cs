using System;
using System.Collections.Generic;

namespace BookStore.DBStandard.Models;

public partial class Detail
{
    public int BookId { get; set; }

    public string? AuthorName { get; set; }

    public string? Title { get; set; }

    public decimal? Price { get; set; }

    public string? BookCoverUrl { get; set; }

    public int OrderId { get; set; }

    public string? Address { get; set; }

    public int? Num { get; set; }

    public string? BookType { get; set; }

    public string? BookTag { get; set; }
}
