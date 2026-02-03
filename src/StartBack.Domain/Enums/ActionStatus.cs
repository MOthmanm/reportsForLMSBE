using System.ComponentModel;

namespace Entities.Models.Enums;

public enum ActionStatus
{
    [Description("PENDING")]
    Pending,
    [Description("IN_PROGRESS")]
    InProgress,
    [Description("COMPLETED")]
    Completed,
    [Description("CANCELLED")]
    Cancelled
}
