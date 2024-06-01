

namespace Tuto_8.DTOs;

public class AssignClientToTripDto
{
    public String FirstName { get; set; }= String.Empty;
    public String LastName { get; set; } =String.Empty;
    public String Email { get; set; } = String.Empty;
    public int Telephone { get; set; }
    public String Pesel { get; set; } =String.Empty;
    public int IdTrip { get; set; }
    public String TripName { get; set; }=String.Empty;
    public DateTime? PaymentDate { get; set; }
}

