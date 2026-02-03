using System.ComponentModel;

namespace Entities.Models.Enums;

public enum AttendanceType
{
    [Description("PRESENT")]
    Present,
    [Description("ABSENT")]
    Absent,
    [Description("TARDY")]
    Tardy,
    [Description("EXCUSED")]
    Excused,
    [Description("EARLY_LEAVE")]
    EarlyLeave
}
