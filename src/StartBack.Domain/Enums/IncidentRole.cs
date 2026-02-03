using System.ComponentModel;

namespace Entities.Models.Enums;

public enum IncidentRole
{
    [Description("OFFENDER")]
    Offender,
    [Description("VICTIM")]
    Victim,
    [Description("WITNESS")]
    Witness,
    [Description("OTHER")]
    Other
}
