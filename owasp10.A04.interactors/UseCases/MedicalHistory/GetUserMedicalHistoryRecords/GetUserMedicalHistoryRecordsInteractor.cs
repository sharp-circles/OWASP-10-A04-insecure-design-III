using AutoMapper;
using owasp10.A04.business.Common;
using owasp10.A04.business.Data;
using owasp10.A04.business.UseCases.GetUserMedicalHistoryRecords.Contracts;
using owasp10.A04.business.UseCases.GetUserMedicalHistoryRecords.Dtos;

namespace owasp10.A04.business.UseCases.GetUserMedicalHistoryRecords;

public sealed class GetUserMedicalHistoryRecordsInteractor : IGetUserMedicalHistoryRecordsInteractor
{
    private readonly ISqLiteRepository<Entities.MedicalHistory> _medicalHistoryRecordsRepository;
    private readonly IMapper _mapper;

    public GetUserMedicalHistoryRecordsInteractor(ISqLiteRepository<Entities.MedicalHistory> medicalHistoryRecordsRepository, IMapper mapper)
    {
        _medicalHistoryRecordsRepository = medicalHistoryRecordsRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetUserMedicalHistoryRecordsOutput>> Handle(GetUserMedicalHistoryRecordsInput getUserMedicalHistoryRecordsInput)
    {
        var userMedicalHistoryRecords = await _medicalHistoryRecordsRepository.QueryAsync(DomainConstants.UserName, getUserMedicalHistoryRecordsInput.Username);

        var userMedicalHistoryRecordsOutput = _mapper.Map<IEnumerable<GetUserMedicalHistoryRecordsOutput>>(userMedicalHistoryRecords);

        return userMedicalHistoryRecordsOutput;
    }
}
