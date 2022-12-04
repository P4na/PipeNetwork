using System;
using System.Collections.Generic;

namespace dbAPI.Models;

public partial class Ticket
{
    public long Id { get; set; }

    public string Status { get; set; } = null!;
}
