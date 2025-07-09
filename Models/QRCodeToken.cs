// QRCodeToken.cs
public class QRCodeToken
{
    public int Id { get; set; }
    public string? Uuid { get; set; }
    public bool IsUsed { get; set; }
    public DateTime Expiration { get; set; }
}