using owasp10.A04.business.Entities;
using SQLite;
using System.Reflection;

namespace owasp10.A04.data.access.Migrations;

public static class SqLiteMigrationManager
{
    private static readonly string DbName = SqLiteConstants.DbName;
    private static readonly string DbDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "./";

    public static async Task RunMigrationsAsync()
    {
        var context = new SQLiteAsyncConnection(Path.Combine(DbDirectory, DbName));

        var medicalHistories = await context.GetTableInfoAsync(nameof(MedicalHistory));
        var tests = await context.GetTableInfoAsync(nameof(Tests));

        if (!medicalHistories.Any())
        {
            await context.CreateTableAsync<Tables.MedicalHistory>();

            var medicalHistoryUserOne = new Tables.MedicalHistory()
            {
                Id = 1,
                UserId = 1,
                UserName = "Matthew",
                Age = 42,
                Affection = "Fibromyalgia",
                Treatment = "Advil",
                UndergoneSurgery = true
            };

            var medicalHistoryUserTwo = new Tables.MedicalHistory()
            {
                Id = 2,
                UserId = 2,
                UserName = "McConaughey",
                Age = 38,
                Affection = "Arrhythmia",
                Treatment = "Marlboro Cigarettes",
                UndergoneSurgery = true
            };

            await context.InsertAsync(medicalHistoryUserOne);
            await context.InsertAsync(medicalHistoryUserTwo);
        }

        if (!tests.Any())
        {
            await context.CreateTableAsync<Tables.Tests>();

            var testOne = new Tables.Tests()
            {
                Id = 1,
                UserId = 1,
                UserName = "Matthew",
                Score = 72,
                Type = "Blood",
                Facility = "Er Clínico"
            };

            var testTwo = new Tables.Tests()
            {
                Id = 1,
                UserId = 1,
                UserName = "Matthew",
                Score = 23,
                Type = "Urine",
                Facility = "Er Materno"
            };

            await context.InsertAsync(testOne);
            await context.InsertAsync(testTwo);
        }

        await context.CloseAsync();
    }
}
