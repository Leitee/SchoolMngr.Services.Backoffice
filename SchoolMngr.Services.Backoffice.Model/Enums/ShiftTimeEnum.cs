
namespace SchoolMngr.Services.Backoffice.Model.Enums
{
    using System.ComponentModel;

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
