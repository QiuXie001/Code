using System;
using System.Collections.Generic;

namespace BookStore.DBStandard.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string? AdminName { get; set; }

    public string AdminPassword { get; set; } = null!;

    public string? AdminAge { get; set; }

    public string? AdminTelephone { get; set; }

    public string? AdminIdentityId { get; set; }
}
