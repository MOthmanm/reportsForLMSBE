using System.ComponentModel;

namespace Entities.Models.Enums;

public enum UniversityType
{
    [Description("PUBLIC")]
    Public,
    [Description("PRIVATE")]
    Private,
    [Description("COMMUNITY")]
    Community,
    [Description("TECHNICAL")]
    Technical,
    [Description("RESEARCH")]
    Research,
    [Description("OTHER")]
    Other
}
