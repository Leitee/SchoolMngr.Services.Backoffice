/// <summary>
/// 
/// </summary>
namespace SchoolMngr.BackOffice.DAL
{
    using Microsoft.EntityFrameworkCore;
    using SchoolMngr.BackOffice.Model.Entities;
    using System.Reflection;

    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
            //_appSettings.ConnectionString = $"Server={config["SQLSERVER_NAME"]};Database=SchoolMngr;User=sa;Password=Devadmin321;";
        }

        public DbSet<Grade> Grades { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Assingment> Assingments { get; set; }
        public DbSet<Class> Classes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());            
        }
    }
}
