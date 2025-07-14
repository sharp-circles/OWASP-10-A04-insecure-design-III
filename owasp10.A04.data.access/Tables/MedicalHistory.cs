using SQLite;

namespace owasp10.A04.data.access.Tables;

[Table("MedicalHistory")]
public class MedicalHistory : Entity
{
    [Column("user_id")]
    public long UserId { get; set; }
    [Column("username")]
    public string UserName { get; set; }
    [Column("age")]
    public sbyte Age { get; set; }
    [Column("treatment")]
    public string Treatment { get; set; }
    [Column("affection")]
    public string Affection { get; set; }
    [Column("undergone_surgery")]
    public bool UndergoneSurgery { get; set; }
}
