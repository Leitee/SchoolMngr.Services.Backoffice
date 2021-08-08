
namespace SchoolMngr.Services.Model.Enums
{
    using System.ComponentModel;

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
