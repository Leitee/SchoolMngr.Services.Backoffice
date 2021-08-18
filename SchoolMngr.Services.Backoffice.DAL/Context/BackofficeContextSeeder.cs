
namespace SchoolMngr.Services.Backoffice.DAL.Context
{
    using SchoolMngr.Services.Backoffice.Model.Entities;
    using SchoolMngr.Services.Backoffice.Model.Enums;
    using System;
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
            await SeedSubjectsAsync(cancellationToken);
            await SeedRoomsAsync(cancellationToken);
            await SeedTeachersAsync(cancellationToken);
            await SeedClassesAsync(cancellationToken);
            //await SeedEnrollmentAsync(cancellationToken);
            //await SeedAssigmentsAsync(cancellationToken);
        }

        private static async Task SeedClassesAsync(CancellationToken cancellationToken)
        {
            _context.Classes.AddRange(
                new Class
                {
                    DivisionName = "1ra",
                    Shift = ShiftTimeEnum.MORNING,
                    StartsAt = new DateTime().AddHours(8),
                    Day = DayOfWeek.Monday,
                    SubjectId = _context.Subjects.Single(x => x.CodeName.Equals("PROG1")).Id,
                    ClassRoomId = _context.ClassRooms.Single(x => x.Description.Equals("ClassRoom 1")).Id,
                },
                new Class
                {
                    DivisionName = "2da",
                    Shift = ShiftTimeEnum.AFTERNOON,
                    StartsAt = new DateTime().AddHours(18),
                    Day = DayOfWeek.Tuesday,
                    SubjectId = _context.Subjects.Single(x => x.CodeName.Equals("MAT1")).Id,
                    ClassRoomId = _context.ClassRooms.Single(x => x.Description.Equals("ClassRoom 1")).Id,
                },
                new Class
                {
                    DivisionName = "1ra",
                    Shift = ShiftTimeEnum.MORNING,
                    StartsAt = new DateTime().AddHours(9),
                    Day = DayOfWeek.Monday,
                    SubjectId = _context.Subjects.Single(x => x.CodeName.Equals("FIS1")).Id,
                    ClassRoomId = _context.ClassRooms.Single(x => x.Description.Equals("ClassRoom 1")).Id,
                },
                new Class
                {
                    DivisionName = "2da",
                    Shift = ShiftTimeEnum.NIGHT,
                    StartsAt = new DateTime().AddHours(21).AddMinutes(30),
                    Day = DayOfWeek.Friday,
                    SubjectId = _context.Subjects.Single(x => x.CodeName.Equals("RED1")).Id,
                    ClassRoomId = _context.ClassRooms.Single(x => x.Description.Equals("ClassRoom 2")).Id,
                },
                new Class
                {
                    DivisionName = "1ra",
                    Shift = ShiftTimeEnum.AFTERNOON,
                    StartsAt = new DateTime().AddHours(15).AddMinutes(15),
                    Day = DayOfWeek.Wednesday,
                    SubjectId = _context.Subjects.Single(x => x.CodeName.Equals("PROG2")).Id,
                    ClassRoomId = _context.ClassRooms.Single(x => x.Description.Equals("ClassRoom 2")).Id,
                },
                new Class
                {
                    DivisionName = "2da",
                    Shift = ShiftTimeEnum.NIGHT,
                    StartsAt = new DateTime().AddHours(22).AddMinutes(30),
                    Day = DayOfWeek.Thursday,
                    SubjectId = _context.Subjects.Single(x => x.CodeName.Equals("ALG1")).Id,
                    ClassRoomId = _context.ClassRooms.Single(x => x.Description.Equals("ClassRoom 2")).Id,
                },
                new Class
                {
                    DivisionName = "1ra",
                    Shift = ShiftTimeEnum.MORNING,
                    StartsAt = new DateTime().AddHours(11),
                    Day = DayOfWeek.Monday,
                    SubjectId = _context.Subjects.Single(x => x.CodeName.Equals("PROG1")).Id,
                    ClassRoomId = _context.ClassRooms.Single(x => x.Description.Equals("ClassRoom 3")).Id,
                },
                new Class
                {
                    DivisionName = "1ra",
                    Shift = ShiftTimeEnum.MORNING,
                    StartsAt = new DateTime().AddHours(7).AddMinutes(30),
                    Day = DayOfWeek.Saturday,
                    SubjectId = _context.Subjects.Single(x => x.CodeName.Equals("MAT2")).Id,
                    ClassRoomId = _context.ClassRooms.Single(x => x.Description.Equals("ClassRoom 3")).Id,
                }); 

            await _context.SaveChangesAsync(cancellationToken);
        }

        /*
        private static async Task SeedAssigmentsAsync(CancellationToken cancellationToken)
        {
            _context.Assingments.AddRange(
                new Assignment
                {
                    From = new DateTime(2020, 03, 01),
                    Created = DateTime.Now,
                    To = new DateTime(2020, 11, 30),
                    TeacherId = _context.Teachers
                },
                new Assignment
                {
                    From = new DateTime(2020, 03, 01),
                    Created = DateTime.Now,
                    To = new DateTime(2020, 11, 30),
                    SubjectId = 2,
                    TeacherId = 2
                },
                new Assignment
                {
                    From = new DateTime(2020, 03, 01),
                    Created = DateTime.Now,
                    To = new DateTime(2020, 11, 30),
                    SubjectId = 3,
                    TeacherId = 3
                },
                new Assignment
                {
                    From = new DateTime(2020, 03, 01),
                    Created = DateTime.Now,
                    To = new DateTime(2020, 11, 30),
                    SubjectId = 4,
                    TeacherId = 4
                },
                new Assignment
                {
                    From = new DateTime(2020, 03, 01),
                    Created = DateTime.Now,
                    To = new DateTime(2020, 11, 30),
                    SubjectId = 5,
                    TeacherId = 5
                });

            await _context.SaveChangesAsync(cancellationToken);
        }
        */
        private static async Task SeedEnrollmentAsync(CancellationToken cancellationToken)
        {
            _context.Enrollments.AddRange(
                new Enrollment 
                { 
                    StudentProfileId = "31872700", 
                    StudentStatus = StudentStatusEnum.ACTIVE,
                    //ClassId = _context.Classes.Single(x => x.)
                },
                new Enrollment 
                { 
                    StudentProfileId = "33669524", 
                    StudentStatus = StudentStatusEnum.ACTIVE 
                }
                );

            await _context.SaveChangesAsync(cancellationToken);
        }

        private static async Task SeedTeachersAsync(CancellationToken cancellationToken)
        {
            _context.Teachers.AddRange(
                new Teacher { EmployeeNumber = "32165498", IdentityUserId = Guid.NewGuid() },
                new Teacher { EmployeeNumber = "24815484", IdentityUserId = Guid.NewGuid() },
                new Teacher { EmployeeNumber = "35558451", IdentityUserId = Guid.NewGuid() },
                new Teacher { EmployeeNumber = "32548751", IdentityUserId = Guid.NewGuid() },
                new Teacher { EmployeeNumber = "36358848", IdentityUserId = Guid.NewGuid(), IsTemporary = true }
                );

            await _context.SaveChangesAsync(cancellationToken);
        }

        private static async Task SeedSubjectsAsync(CancellationToken cancellationToken)
        {
            _context.Subjects.AddRange(
                new Subject { CodeName = "MAT1", FullName = "Matemáticas" , GradeId = 1},
                new Subject { CodeName = "FIS1", FullName = "Fisica" , GradeId = 1},
                new Subject { CodeName = "RED1", FullName = "Redes" , GradeId = 2},
                new Subject { CodeName = "MAT2", FullName = "Matemáticas 2", GradeId = 1 },
                new Subject { CodeName = "ALG1", FullName = "Algoritmos", GradeId = 2},
                new Subject { CodeName = "PROG1", FullName = "Programación", GradeId = 3},
                new Subject { CodeName = "PROG2", FullName = "Programación 2", GradeId = 3 }
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
                new ClassRoom { Description = "ClassRoom 1", MaxCapacity = 100 },
                new ClassRoom { Description = "ClassRoom 2", MaxCapacity = 50 },
                new ClassRoom { Description = "ClassRoom 3", MaxCapacity = 25 }
                );

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
