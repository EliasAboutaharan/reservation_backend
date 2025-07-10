// Visitor.cs
namespace Reservation.Models
{
    public enum VisitReason
    {
        RendezVous,
        Coworking
    }

    public class Visitor
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Status { get; set; }
        public VisitReason? VisitReason { get; set; }
        public int? ContactStaffId { get; set; }

        public List<Appointment>? Appointments { get; set; }
    }
}

