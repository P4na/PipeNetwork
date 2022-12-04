using System;
using System.Collections.Generic;

namespace dbAPI.Models;

public partial class Lead
{
    public long Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public DateOnly? Nascita { get; set; }

    public string Email { get; set; } = null!;

    public string? Cellulare { get; set; }

    public string? Indirizzo { get; set; }
}
