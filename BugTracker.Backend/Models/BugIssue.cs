

public class BugIssue
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public BugSeverity Severity { get; set; }
    public int CreatedBy { get; set; }
}

public enum BugSeverity
{
    LOW,
    MEDIUM,
    HIGH
}