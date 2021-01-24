using Reinforced.Typings.Attributes;
using System.ComponentModel;

namespace SchoolMngr.BackOffice.Model.Enums
{
    [TsEnum(IncludeNamespace = false)]
    public enum AttendanceEnum
    {
        [Description("Presente")]
        ATTENDED = 1,
        [Description("Ausente")]
        MISSED,
        [Description("Justificado")]
        REASON,
    }
}
