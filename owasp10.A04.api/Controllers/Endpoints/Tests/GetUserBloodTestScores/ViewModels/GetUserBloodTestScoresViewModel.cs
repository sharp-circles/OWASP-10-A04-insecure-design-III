namespace owasp10.A04.api.Controllers.Endpoints.Tests.GetUserBloodTestScores.ViewModels;

public record GetUserBloodTestScoresViewModel
{
    public int UserId { get; set; }
    public int Score { get; set; }
}
