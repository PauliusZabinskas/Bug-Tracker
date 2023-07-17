

public class Bug
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public BugSeverity Severity { get; set; }
}

public enum BugSeverity
{
    LOW,
    MEDIUM,
    HIGH
}