using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using owasp10.A04.api.Controllers.Endpoints.MedicalHistory.GetUserMedicalHistoryRecords.ViewModels;
using owasp10.A04.business.UseCases.GetUserMedicalHistoryRecords.Contracts;
using owasp10.A04.business.UseCases.GetUserMedicalHistoryRecords.Dtos;
using System.ComponentModel.DataAnnotations;

namespace owasp10.A04.api.Controllers.Endpoints.MedicalHistory.GetUserMedicalHistoryRecords;

[ApiController]
[Route("[controller]")]
public class MedicalHistoryController : ControllerBase
{
    private readonly IGetUserMedicalHistoryRecordsInteractor _businessInteractor;
    private readonly IMapper _mapper;

    public MedicalHistoryController(IGetUserMedicalHistoryRecordsInteractor businessInteractor, IMapper mapper)
    {
        _businessInteractor = businessInteractor;
        _mapper = mapper;
    }

    [HttpGet()]
    public async Task<IActionResult> GetUserMedicalHistoryRecords([Required][FromQuery] string username)
    {
        var userMedicalHistoryRecordsInteractorInput = new GetUserMedicalHistoryRecordsInput() { Username = username };

        var userMedicalHistoryRecordsInteractorOutput = await _businessInteractor.Handle(userMedicalHistoryRecordsInteractorInput);

        var userMedicalHistoryRecordsViewModel = _mapper.Map<IEnumerable<GetUserMedicalHistoryRecordsViewModel>>(userMedicalHistoryRecordsInteractorOutput);

        return new OkObjectResult(userMedicalHistoryRecordsViewModel);
    }
}

