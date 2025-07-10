// DTOs/VisitorDto.cs
namespace Reservation.DTOs
{
    public class VisitorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Status { get; set; } = default!;
        public string VisitReason { get; set; } = default!;
        public int? ContactStaffId { get; set; }
        public string ContactStaffName { get; set; } = default!;
    }
}
