using Reinforced.Typings.Attributes;
using System.ComponentModel;

namespace SchoolMngr.BackOffice.Model.Enums
{
    [TsEnum(IncludeNamespace = false)]
    public enum RolesEnum
    {
        [Description("Dev")]
        DEBUG = -1,
        [Description("Admin")]
        ADMINISTRADOR = 1,
        [Description("Teacher")]
        TEACHER = 2,
        [Description("Student")]
        STUDENT = 3
    }
}
