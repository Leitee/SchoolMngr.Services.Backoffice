
namespace SchoolMngr.Services.Backoffice.Model.Enums
{
    using System.ComponentModel;

    public enum SchoolRolesEnum
    {
        [Description("Admin")]
        ADMINISTRADOR = 1,
        [Description("Teacher")]
        TEACHER = 2,
        [Description("Student")]
        STUDENT = 3
    }
}
