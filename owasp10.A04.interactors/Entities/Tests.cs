namespace owasp10.A04.business.Entities;

public class Tests : Entity
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public int Score { get; set; }
    public string Type { get; set; }
    public string Facility { get; set; }
}
