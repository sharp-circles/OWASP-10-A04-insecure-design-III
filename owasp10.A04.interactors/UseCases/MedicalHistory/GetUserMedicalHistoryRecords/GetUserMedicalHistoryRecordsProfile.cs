using AutoMapper;
using owasp10.A04.business.UseCases.GetUserMedicalHistoryRecords.Dtos;

namespace owasp10.A04.business.UseCases.MedicalHistory.GetUserMedicalHistoryRecords;

public class GetUserMedicalHistoryRecordsProfile : Profile
{
    public GetUserMedicalHistoryRecordsProfile()
    {
        CreateMap<Entities.MedicalHistory, GetUserMedicalHistoryRecordsOutput>();
    }
}
