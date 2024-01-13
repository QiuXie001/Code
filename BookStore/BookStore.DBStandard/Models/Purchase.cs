using System;
using System.Collections.Generic;

namespace BookStore.DBStandard.Models;

public partial class Purchase
{
    public int PurchaseId { get; set; }

    public int AdminId { get; set; }

    public string BookId { get; set; } = null!;

    public int? Num { get; set; }

    public decimal? Price { get; set; }

    public DateTime? PurchaseTime { get; set; }
}
