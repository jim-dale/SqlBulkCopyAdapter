namespace SqlBulkCopyPrototype;

using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using Bogus;
using Microsoft.Data.SqlClient;

public class Person
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}

internal static class Program
{
    static async Task Main(string[] args)
    {
        var peopleGenerator = new Faker<Person>()
            .StrictMode(ensureRulesForAllProperties: true)
            .RuleFor(p => p.Id, f => Guid.CreateVersion7())
            .RuleFor(p => p.Name, f => f.Name.FullName());

        var people = peopleGenerator.Generate(1_000_000);

        string connectionString = GetConnectionString();

        using SqlConnection sourceConnection = new(connectionString);

        await sourceConnection.OpenAsync().ConfigureAwait(false);

        SqlCommand commandRowCount = new("SELECT COUNT(*) FROM [dbo].[People];", sourceConnection);

        long countStart = Convert.ToInt64(await commandRowCount.ExecuteScalarAsync().ConfigureAwait(false));
        Console.WriteLine($"Starting row count = {countStart}");
        Stopwatch stopwatch = Stopwatch.StartNew();

        await BulkCopyPeopleAsync(people, sourceConnection).ConfigureAwait(false);

        stopwatch.Stop();
        long countEnd = Convert.ToInt64(await commandRowCount.ExecuteScalarAsync().ConfigureAwait(false));
        Console.WriteLine($"Ending row count = {countEnd}, Elapsed: {stopwatch.Elapsed}");
    }

    private static async Task BulkCopyPeopleAsync(List<Person> people, SqlConnection sourceConnection)
    {
        using IDataReader reader = new PeopleDataReaderAdapter(people);
        using SqlBulkCopy bulkCopy = new(sourceConnection);

        bulkCopy.DestinationTableName = "[dbo].[People]";
        bulkCopy.ColumnMappings.Add(0, 0);
        bulkCopy.ColumnMappings.Add(1, 1);

        try
        {
            await bulkCopy.WriteToServerAsync(reader).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    private static string GetConnectionString()
    {
        SqlConnectionStringBuilder builder = new(Environment.GetEnvironmentVariable("LOCAL_SQL"));
        builder.InitialCatalog = "PrototypeStore";

        return builder.ConnectionString;
    }
}
