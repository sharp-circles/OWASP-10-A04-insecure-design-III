using AutoMapper;
using owasp10.A04.business.Common;
using owasp10.A04.business.Data;
using owasp10.A04.business.UseCases.Tests.GetUserBloodTestScores.Contracts;
using owasp10.A04.business.UseCases.Tests.GetUserBloodTestScores.Dtos;

namespace owasp10.A04.business.UseCases.Tests.GetUserBloodTestScores;

public class GetUserBloodTestScoresInteractor : IGetUserBloodTestScoresInteractor
{
    private readonly ISqLiteRepository<Entities.Tests> _testsRepository;
    private readonly IMapper _mapper;

    public GetUserBloodTestScoresInteractor(ISqLiteRepository<Entities.Tests> testsRepository, IMapper mapper)
    {
        _testsRepository = testsRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetUserBloodTestScoresOutput>> Handle(GetUserBloodTestScoresInput getUserBloodTestScoresInput)
    {
        var userBloodTestScoresRecords = await _testsRepository.QueryAsync(DomainConstants.UserName, getUserBloodTestScoresInput.Username);

        var userBloodTestScoresRecordsOutput = _mapper.Map<IEnumerable<GetUserBloodTestScoresOutput>>(userBloodTestScoresRecords);

        return userBloodTestScoresRecordsOutput;
    }
}
