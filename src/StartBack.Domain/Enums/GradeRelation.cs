using System.ComponentModel;

namespace Entities.Models.Enums;

public enum GradeRelation
{
    [Description("PART_OF_FINAL")]
    PartOfFinal,
    [Description("SEPARATE")]
    Separate,
    [Description("BONUS")]
    Bonus,
    [Description("NOT_COUNTED")]
    NotCounted
}
