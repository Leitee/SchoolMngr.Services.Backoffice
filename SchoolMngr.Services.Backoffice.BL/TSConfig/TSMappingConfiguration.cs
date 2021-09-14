
namespace SchoolMngr.Services.Backoffice.BL.TSConfig
{
    using Reinforced.Typings.Ast.TypeNames;
    using Reinforced.Typings.Fluent;
    using SchoolMngr.Services.Backoffice.BL.Dtos;
    using SchoolMngr.Services.Backoffice.Model.Enums;

    public static class TSMappingConfiguration
    {
        public static void Configure(ConfigurationBuilder builder)
        {
            //Global config
            builder
                .Substitute(typeof(System.Guid), new RtSimpleTypeName("string"))
                .Substitute(typeof(System.DateTime), new RtSimpleTypeName("Date"))
                .Global(config =>
                {
                    config.CamelCaseForProperties(true);
                    config.UseModules(true);
                    config.AutoOptionalProperties(true);
                    config.ExportPureTypings(true);
                });

            builder.ExportAsInterface<AssignmentDto>()
                .AutoI(false)
                .WithPublicProperties()
                .OverrideName("Assignment");

            builder.ExportAsInterface<ClassDto>()
                .AutoI(false)
                .WithPublicProperties()
                .OverrideName("Class");

            builder.ExportAsInterface<ClassRoomDto>()
                .AutoI(false)
                .WithPublicProperties()
                .OverrideName("ClassRoom");

            builder.ExportAsInterface<EnrollmentDto>()
                .AutoI(false)
                .WithPublicProperties()
                .OverrideName("Enrollment");

            builder.ExportAsInterface<GradeDto>()
                .AutoI(false)
                .WithPublicProperties()
                .OverrideName("Grade");

            builder.ExportAsInterface<SubjectDto>()
                .AutoI(false)
                .WithPublicProperties()
                .OverrideName("Subject");

            builder.ExportAsInterface<TeacherDto>()
                .AutoI(false)
                .WithPublicProperties()
                .OverrideName("Teacher");

            builder.ExportAsEnum<SchoolRolesEnum>()
                .DontIncludeToNamespace();

            builder.ExportAsEnum<ShiftTimeEnum>()
                .DontIncludeToNamespace();
        }
    }
}