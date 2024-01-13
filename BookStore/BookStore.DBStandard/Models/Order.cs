using System;
using System.Collections.Generic;

namespace BookStore.DBStandard.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string? Address { get; set; }

    public string BookId { get; set; } = null!;

    public int? Num { get; set; }

    public decimal? Price { get; set; }

    public int CustomId { get; set; }

    public DateTime? OrderTime { get; set; }

    public bool? ClearOrNot { get; set; }

    public bool? ReceiptOrNot { get; set; }
}
