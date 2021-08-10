
namespace SchoolMngr.Services.Backoffice.DAL.Context
{
    using Microsoft.EntityFrameworkCore;
    using SchoolMngr.Services.Backoffice.Model.Entities;
    using System.Reflection;

    public class BackofficeDbContext : DbContext
    {
        public BackofficeDbContext(DbContextOptions<BackofficeDbContext> options)
            : base(options)
        {
            //_appSettings.ConnectionString = $"Server={config["SQLSERVER_NAME"]};Database=SchoolMngr;User=sa;Password=Devadmin321;";
        }

        public DbSet<Grade> Grades { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Assignment> Assingments { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
