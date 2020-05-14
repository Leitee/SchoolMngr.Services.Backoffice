using Reinforced.Typings.Attributes;
using System.ComponentModel;

namespace SchoolMngr.BackOffice.Model.Enums
{
    [TsEnum(IncludeNamespace = false)]
    public enum ShiftTimeEnum
    {
        [Description("Morning")]
        MORNING = 1,
        [Description("Evening")]
        EVENING,
        [Description("Afternoon")]
        AFTERNOON,
        [Description("Night")]
        NIGHT 
    }
}
