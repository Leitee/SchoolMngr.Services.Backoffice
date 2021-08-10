
namespace SchoolMngr.Services.Backoffice.Model.Enums
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
