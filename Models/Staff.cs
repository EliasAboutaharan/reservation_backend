// Staff.cs
namespace Reservation.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Role { get; set; }
        public string? Email { get; set; }

        public List<Appointment>? Appointments { get; set; } // Propriété de navigation
    }
}

