namespace owasp10.A04.business.UseCases.Tests.GetUserBloodTestScores.Dtos;

public record GetUserBloodTestScoresOutput()
{
    public int UserId { get; set; }
    public int Score { get; set; }
}