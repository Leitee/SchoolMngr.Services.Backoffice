using Reinforced.Typings.Attributes;
using System.ComponentModel;

namespace SchoolMngr.BackOffice.Model.Enums
{
    [TsEnum]
    public enum ShiftTimeEnum
    {
        [Description("Mañana")]
        TOMORROW = 1,
        [Description("Tarde")]
        AFTERNOON = 2,
        [Description("Noche")]
        NIGHT = 3
    }
}
