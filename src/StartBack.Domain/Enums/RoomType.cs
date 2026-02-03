using System.ComponentModel;

namespace Entities.Models.Enums;

public enum RoomType
{
    [Description("CLASSROOM")]
    Classroom,
    [Description("LAB")]
    Lab,
    [Description("LIBRARY")]
    Library,
    [Description("AUDITORIUM")]
    Auditorium,
    [Description("OFFICE")]
    Office,
    [Description("OTHER")]
    Other
}
