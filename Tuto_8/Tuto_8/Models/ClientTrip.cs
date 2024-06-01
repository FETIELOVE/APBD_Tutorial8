﻿
namespace Tuto_8.Models;

public class ClientTrip
{
    public int IdClient { get; set; }

    public string Pesel { get; set; } = String.Empty;
    public int IdTrip { get; set; }

    public DateTime RegisteredAt { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual Trip IdTripNavigation { get; set; } = null!;
}
