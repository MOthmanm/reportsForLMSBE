using System.ComponentModel;

namespace Entities.Models.Enums;

public enum IncidentStatus
{
    [Description("OPEN")]
    Open,
    [Description("IN_PROGRESS")]
    InProgress,
    [Description("RESOLVED")]
    Resolved,
    [Description("CLOSED")]
    Closed
}
