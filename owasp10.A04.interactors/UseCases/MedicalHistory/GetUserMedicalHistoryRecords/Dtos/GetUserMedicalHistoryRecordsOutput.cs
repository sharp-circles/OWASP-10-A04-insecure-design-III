namespace owasp10.A04.business.UseCases.GetUserMedicalHistoryRecords.Dtos;

public record GetUserMedicalHistoryRecordsOutput
{
    public int Id { get; set; }
    public long UserId { get; set; }
    public string UserName { get; set; }
    public sbyte Age { get; set; }
    public string Treatment { get; set; }
    public string Affection { get; set; }
    public bool UndergoneSurgery { get; set; }
}
