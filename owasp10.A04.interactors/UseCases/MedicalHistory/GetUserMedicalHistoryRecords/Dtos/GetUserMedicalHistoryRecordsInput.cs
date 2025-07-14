namespace owasp10.A04.business.UseCases.GetUserMedicalHistoryRecords.Dtos;

public record GetUserMedicalHistoryRecordsInput
{
    public string Username { get; set; }
}