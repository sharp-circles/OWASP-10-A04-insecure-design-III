namespace owasp10.A04.api.Controllers.Endpoints.MedicalHistory.GetUserMedicalHistoryRecords.ViewModels;

public record GetUserMedicalHistoryRecordsViewModel
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public string UserName { get; set; }
    public sbyte Age { get; set; }
    public string Treatment { get; set; }
    public string Affection { get; set; }
    public string UndergoneSurgery { get; set; }
}
