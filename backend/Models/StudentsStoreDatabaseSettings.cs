namespace backend.Models;

public class StudentsStoreDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string StudentCollectionName { get; set; } = null!;
}