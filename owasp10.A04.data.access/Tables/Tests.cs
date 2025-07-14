using System.ComponentModel.DataAnnotations.Schema;

namespace owasp10.A04.data.access.Tables;

[Table("Tests")]
public class Tests : Entity
{
    [Column("user_id")]
    public int UserId { get; set; }
    [Column("username")]
    public string UserName { get; set; }
    [Column("score")]
    public int Score { get; set; }
    [Column("type")]
    public string Type { get; set; }
    [Column("facility")]
    public string Facility { get; set; }
}
