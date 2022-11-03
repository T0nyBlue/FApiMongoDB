namespace FApi.Models;

public class FDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string FCollectionName { get; set; } = null!;
}