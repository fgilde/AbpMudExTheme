namespace SampleModule;

public static class SampleModuleDbProperties
{
    public static string DbTablePrefix { get; set; } = "SampleModule";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "SampleModule";
}
