// Appointment.cs
namespace Reservation.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Time { get; set; }

        public int StaffId { get; set; }
        public Staff? Staff { get; set; } // Propriété de navigation

        public int VisitorId { get; set; }
        public Visitor? Visitor { get; set; } // Propriété de navigation
    }
}