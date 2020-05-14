using Reinforced.Typings.Attributes;
using System.ComponentModel;

namespace SchoolMngr.BackOffice.Model.Enums
{
    [TsEnum(IncludeNamespace = false)]
    public enum StudentStateEnum
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
