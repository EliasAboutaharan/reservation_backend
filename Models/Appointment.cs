// Appointment.cs
public class Appointment
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string? Time { get; set; }
    public int StaffId { get; set; }
    public int VisitorId { get; set; }
}