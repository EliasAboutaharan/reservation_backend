namespace Reservation.DTOs
{
    public class AppointmentCheckRequest
    {
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public int StaffId { get; set; }
    }
}