using owasp10.A04.business.UseCases.GetUserMedicalHistoryRecords.Dtos;

namespace owasp10.A04.business.UseCases.GetUserMedicalHistoryRecords.Contracts;

public interface IGetUserMedicalHistoryRecordsInteractor
{
    Task<IEnumerable<GetUserMedicalHistoryRecordsOutput>> Handle(GetUserMedicalHistoryRecordsInput getUserMedicalHistoryRecordsInput);
}
