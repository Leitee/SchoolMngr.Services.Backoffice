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
        public DbSet<ClassRoom> Rooms { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Assingment> Assingments { get; set; }
        public DbSet<Class> Classes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            /*
            #region Identity fields seeding

            builder.Entity<ApplicationRole>().HasData(new List<ApplicationRole>
            {
                new ApplicationRole(RolesEnum.DEBUG.GetDescription(), "Full functionality over app and debugin") { Id = RolesEnum.DEBUG.GetId() },
                new ApplicationRole(RolesEnum.ADMINISTRADOR.GetDescription(), "Full permissions and features") { Id = RolesEnum.ADMINISTRADOR.GetId() },
                new ApplicationRole(RolesEnum.SUPERVISOR.GetDescription(), "Limited functionality just administrative permissions") { Id = RolesEnum.SUPERVISOR.GetId() },
                new ApplicationRole(RolesEnum.TEACHER.GetDescription(), "Limited functionality just teaching-relative permissions") { Id = RolesEnum.TEACHER.GetId() },
                new ApplicationRole(RolesEnum.STUDENT.GetDescription(), "Limited functionality just student-relative permissions") { Id = RolesEnum.STUDENT.GetId() }
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser("devadmin", "info@Codeitsistemas.com", "Jhon", "Doe")
            {
                Id = -1,
                EmailConfirmed = true,
                LockoutEnabled = false,
                TwoFactorEnabled = false,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Dev321"),
                SecurityStamp = string.Empty,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser("risanchez", "risanchez@admin.com", "Rick", "Sanchez")
            {
                Id = 1,
                EmailConfirmed = true,
                LockoutEnabled = false,
                TwoFactorEnabled = false,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Rick321"),
                SecurityStamp = string.Empty,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser("dabrown", "dabrown@teacher.com", "Dan", "Brown")
            {
                Id = 11,
                EmailConfirmed = true,
                LockoutEnabled = false,
                TwoFactorEnabled = false,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Dan321"),
                SecurityStamp = string.Empty,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser("brwayne", "bruce.wayne@student.com", "Bruce", "Wayne")
            {
                Id = 101,
                EmailConfirmed = true,
                LockoutEnabled = false,
                TwoFactorEnabled = false,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Bru321"),
                SecurityStamp = string.Empty,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser("anrand", "ayn.rand@student.com", "Ayn", "Rand")
            {
                Id = 102,
                EmailConfirmed = true,
                LockoutEnabled = false,
                TwoFactorEnabled = false,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Ayn321"),
                SecurityStamp = string.Empty,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser("mifriedman", "milton.friedman@student.com", "Milton", "Fiedman")
            {
                Id = 103,
                EmailConfirmed = true,
                LockoutEnabled = false,
                TwoFactorEnabled = false,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Mil321"),
                SecurityStamp = string.Empty,
            });

            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>() { UserId = -1, RoleId = RolesEnum.DEBUG.GetId() });
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>() { UserId = 1, RoleId = RolesEnum.ADMINISTRADOR.GetId() });
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>() { UserId = 11, RoleId = RolesEnum.TEACHER.GetId() });
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>() { UserId = 101, RoleId = RolesEnum.STUDENT.GetId() });
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>() { UserId = 102, RoleId = RolesEnum.STUDENT.GetId() });
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>() { UserId = 103, RoleId = RolesEnum.STUDENT.GetId() });

            #endregion
            */

            
        }
    }
}
