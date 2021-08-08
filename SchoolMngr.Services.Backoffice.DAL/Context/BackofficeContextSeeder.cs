
namespace SchoolMngr.Services.Backoffice.DAL.Context
{
    using SchoolMngr.Services.Model.Entities;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public static class BackofficeContextSeeder
    {
        private static BackofficeDbContext _context;

        public static void TrySeedAll(this BackofficeDbContext context)
        {
            if (context.Grades.Any()) return;

            SeedAllAsync(context, CancellationToken.None).Wait();
        }

        public static async Task SeedAllAsync(this BackofficeDbContext context, CancellationToken cancellationToken)
        {
            _context = context;

            await SeedGradesAsync(cancellationToken);

            await SeedRoomsAsync(cancellationToken);

            await SeedSubjectsAsync(cancellationToken);

            //await SeedAssigmentsAsync(cancellationToken);

            //await SeedTeachersAsync(cancellationToken);

            //await SeedClassesAsync(cancellationToken);
        }

        //private async Task SeedClassesAsync(CancellationToken cancellationToken)
        //{
        //    _context.Classes.AddRange(
        //        new Class
        //        {
        //            DivisionName = "1ra",
        //            Shift = ShiftTimeEnum.MORNING,
        //            ClassRoomId = 3,
        //        },
        //        new Class
        //        {
        //            DivisionName = "2da",
        //            Shift = ShiftTimeEnum.AFTERNOON,
        //            ClassRoomId = 2,
        //        },
        //        new Class
        //        {
        //            DivisionName = "1ra",
        //            Shift = ShiftTimeEnum.MORNING,
        //            ClassRoomId = 3,
        //        },
        //        new Class
        //        {
        //            DivisionName = "2da",
        //            Shift = ShiftTimeEnum.NIGHT,
        //            ClassRoomId = 4,
        //        },
        //        new Class
        //        {
        //            DivisionName = "1ra",
        //            Shift = ShiftTimeEnum.AFTERNOON,
        //            ClassRoomId = 5,
        //        },
        //        new Class
        //        {
        //            DivisionName = "2da",
        //            Shift = ShiftTimeEnum.NIGHT,
        //            ClassRoomId = 1,
        //        },
        //        new Class
        //        {
        //            DivisionName = "1ra",
        //            Shift = ShiftTimeEnum.MORNING,
        //            ClassRoomId = 2,
        //        },
        //        new Class
        //        {
        //            DivisionName = "1ra",
        //            Shift = ShiftTimeEnum.MORNING,
        //            ClassRoomId = 3,
        //        });

        //    await _context.SaveChangesAsync(cancellationToken);
        //}

        //private async Task SeedAssigmentsAsync(CancellationToken cancellationToken)
        //{
        //    _context.Assingments.AddRange(
        //        new Assingment
        //        {
        //            From = new DateTime(2020, 03, 01),
        //            Created = DateTime.Now,
        //            To = new DateTime(2020, 11, 30),
        //            SubjectId = 1,
        //            TeacherId = 1
        //        },
        //        new Assingment
        //        {
        //            From = new DateTime(2020, 03, 01),
        //            Created = DateTime.Now,
        //            To = new DateTime(2020, 11, 30),
        //            SubjectId = 2,
        //            TeacherId = 2
        //        },
        //        new Assingment
        //        {
        //            From = new DateTime(2020, 03, 01),
        //            Created = DateTime.Now,
        //            To = new DateTime(2020, 11, 30),
        //            SubjectId = 3,
        //            TeacherId = 3
        //        },
        //        new Assingment
        //        {
        //            From = new DateTime(2020, 03, 01),
        //            Created = DateTime.Now,
        //            To = new DateTime(2020, 11, 30),
        //            SubjectId = 4,
        //            TeacherId = 4
        //        },
        //        new Assingment
        //        {
        //            From = new DateTime(2020, 03, 01),
        //            Created = DateTime.Now,
        //            To = new DateTime(2020, 11, 30),
        //            SubjectId = 5,
        //            TeacherId = 5
        //        });

        //    await _context.SaveChangesAsync(cancellationToken);
        //}

        //private async Task SeedTeachersAsync(CancellationToken cancellationToken)
        //{
        //    _context.Teachers.AddRange(
        //        new Teacher { EmployeeNumber = "32165498", IdentityUserId = 11 },
        //        new Teacher { EmployeeNumber = "24815484", IdentityUserId = 12 },
        //        new Teacher { EmployeeNumber = "35558451", IdentityUserId = 13 },
        //        new Teacher { EmployeeNumber = "32548751", IdentityUserId = 14 },
        //        new Teacher { EmployeeNumber = "36358848", IdentityUserId = 15, IsTemporary = true }
        //        );

        //    await _context.SaveChangesAsync(cancellationToken);
        //}

        private static async Task SeedSubjectsAsync(CancellationToken cancellationToken)
        {
            _context.Subjects.AddRange(
                new Subject { CodeName = "Mat1", FullName = "Matemáticas" },
                new Subject { CodeName = "Fis1", FullName = "Fisica" },
                new Subject { CodeName = "Red1", FullName = "Redes" },
                new Subject { CodeName = "Alg1", FullName = "Algoritmos", },
                new Subject { CodeName = "Prog1", FullName = "Programación" }
                );

            await _context.SaveChangesAsync(cancellationToken);
        }

        private static async Task SeedGradesAsync(CancellationToken cancellationToken)
        {
            _context.Grades.AddRange(
                new Grade { Id = 1, Name = "1er" },
                new Grade { Id = 2, Name = "2do" },
                new Grade { Id = 3, Name = "3ro" },
                new Grade { Id = 4, Name = "4to" },
                new Grade { Id = 5, Name = "5to" }
                );

            await _context.SaveChangesAsync(cancellationToken);
        }

        private static async Task SeedRoomsAsync(CancellationToken cancellationToken)
        {
            _context.ClassRooms.AddRange(
                new ClassRoom { Description = "Aula 1", MaxCapacity = 100 },
                new ClassRoom { Description = "Aula 2", MaxCapacity = 50 },
                new ClassRoom { Description = "Aula 3", MaxCapacity = 25 }
                );

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
