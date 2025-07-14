using AutoMapper;
using owasp10.A04.business.UseCases.Tests.GetUserBloodTestScores.Dtos;

namespace owasp10.A04.business.UseCases.Tests.GetUserBloodTestScores;

public class GetUserBloodTestScoresProfile : Profile
{
    public GetUserBloodTestScoresProfile()
    {
        CreateMap<Entities.Tests, GetUserBloodTestScoresOutput>();
    }
}
