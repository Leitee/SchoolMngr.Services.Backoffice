
namespace SchoolMngr.Services.Model.Enums
{
    using System.ComponentModel;

    public enum StudentStatusEnum
    {
        [Description("Matriculado")]
        ENROLLED = 1,
        [Description("Regular")]
        ACTIVE,
        [Description("Irregular")]
        INACTIVE,
        [Description("Aprobado")]
        ACHIEVED
    }
}
