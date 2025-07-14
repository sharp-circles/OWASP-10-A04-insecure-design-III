using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using owasp10.A04.api.Controllers.Endpoints.Tests.GetUserBloodTestScores.ViewModels;
using owasp10.A04.business.UseCases.Tests.GetUserBloodTestScores.Contracts;
using owasp10.A04.business.UseCases.Tests.GetUserBloodTestScores.Dtos;
using System.ComponentModel.DataAnnotations;

namespace owasp10.A04.api.Controllers.Endpoints.Tests.GetUserBloodTestScores;

[ApiController]
[Route("[controller]")]
public class TestsController : ControllerBase
{
    private readonly IGetUserBloodTestScoresInteractor _businessInteractor;
    private readonly IMapper _mapper;

    public TestsController(IGetUserBloodTestScoresInteractor businessInteractor, IMapper mapper)
    {
        _businessInteractor = businessInteractor;
        _mapper = mapper;
    }

    [HttpGet()]
    public async Task<IActionResult> GetUserBloodTestScores([Required][FromQuery] string username)
    {
        var getUserBloodTestScoresInput = new GetUserBloodTestScoresInput() { Username = username };

        var getUserBloodTestScoresOutput = await _businessInteractor.Handle(getUserBloodTestScoresInput);

        var getUserBloodTestScoresViewModel = _mapper.Map<IEnumerable<GetUserBloodTestScoresViewModel>>(getUserBloodTestScoresOutput);

        return new OkObjectResult(getUserBloodTestScoresViewModel);
    }
}
