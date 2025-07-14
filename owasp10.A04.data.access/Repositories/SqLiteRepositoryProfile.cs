using AutoMapper;
using owasp10.A04.business.Entities;

namespace owasp10.A04.data.access.Repositories;

public class SqLiteRepositoryProfile : Profile
{
    public SqLiteRepositoryProfile()
    {
        CreateMap<MedicalHistory, Tables.MedicalHistory>();
        CreateMap<Tables.MedicalHistory, MedicalHistory>();
        CreateMap<Tests, Tables.Tests>();
        CreateMap<Tables.Tests, Tests>();
    }
}
