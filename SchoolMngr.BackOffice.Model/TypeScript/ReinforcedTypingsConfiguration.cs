/// <summary>
/// 
/// </summary>
namespace SchoolMngr.BackOffice.Model.TypeScript
{
    using Reinforced.Typings.Fluent;

    public static class ReinforcedTypingsConfiguration
    {
        public static void Configure(ConfigurationBuilder builder)
        {
            builder.Global(config =>
            {
                config.CamelCaseForProperties(true);
                config.UseModules(true);
                config.AutoOptionalProperties(true);
                config.ExportPureTypings(true);
            });
        }
    }
}