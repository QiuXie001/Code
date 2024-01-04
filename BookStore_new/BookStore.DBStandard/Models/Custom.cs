using System;
using System.Collections.Generic;

namespace BookStore.DBStandard.Models;

public partial class Custom
{
    public int CustomId { get; set; }

    public string CustomPassword { get; set; } = null!;

    public string? CustomAge { get; set; }

    public string CustomTelephone { get; set; } = null!;

    public string? AdminIdentityId { get; set; }

    public string CustomName { get; set; } = null!;
}
