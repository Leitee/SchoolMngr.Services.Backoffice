/// <summary>
/// 
/// </summary>
namespace SchoolMngr.BackOffice.DAL
{
    using Microsoft.EntityFrameworkCore;
    using SchoolMngr.BackOffice.Model.Entities;
    using SchoolMngr.BackOffice.Model.Enums;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class SchoolMngrContextSeed
    {
        private readonly SchoolDbContext _context;

        public SchoolMngrContextSeed(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task SeedAllAsync(CancellationToken cancellationToken)
        {
            if (await _context.Grades.AnyAsync()) return;

            await SeedGradesAsync(cancellationToken);

            await SeedRoomsAsync(cancellationToken);

            await SeedSubjectsAsync(cancellationToken);

            await SeedTeachersAsync(cancellationToken);

            await SeedAssigmentsAsync(cancellationToken);

            await SeedClassesAsync(cancellationToken);
        }

        private async Task SeedClassesAsync(CancellationToken cancellationToken)
        {
            _context.Classes.AddRange(
                new Class
                {
                    Id = 1,
                    Name = "1ra",
                    Shift = ShiftTimeEnum.MORNING,
                    RoomId = 3,
                    AssingmentId = 3
                },
                new Class
                {
                    Id = 2,
                    Name = "2da",
                    Shift = ShiftTimeEnum.AFTERNOON,
                    RoomId = 2,
                    AssingmentId = 2
                },
                new Class
                {
                    Id = 3,
                    Name = "1ra",
                    Shift = ShiftTimeEnum.MORNING,
                    RoomId = 3,
                    AssingmentId = 3
                },
                new Class
                {
                    Id = 4,
                    Name = "2da",
                    Shift = ShiftTimeEnum.NIGHT,
                    RoomId = 4,
                    AssingmentId = 4
                },
                new Class
                {
                    Id = 5,
                    Name = "1ra",
                    Shift = ShiftTimeEnum.AFTERNOON,
                    RoomId = 5,
                    AssingmentId = 5
                },
                new Class
                {
                    Id = 6,
                    Name = "2da",
                    Shift = ShiftTimeEnum.NIGHT,
                    RoomId = 1,
                    AssingmentId = 1
                },
                new Class
                {
                    Id = 7,
                    Name = "1ra",
                    Shift = ShiftTimeEnum.MORNING,
                    RoomId = 2,
                    AssingmentId = 2
                },
                new Class
                {
                    Id = 8,
                    Name = "1ra",
                    Shift = ShiftTimeEnum.MORNING,
                    RoomId = 3,
                    AssingmentId = 3
                });

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedAssigmentsAsync(CancellationToken cancellationToken)
        {
            _context.Assingments.AddRange(
                new Assingment
                {
                    Id = 1,
                    StartsTime = new DateTime(2020, 03, 01),
                    Created = DateTime.Now,
                    EndsTime = new DateTime(2020, 11, 30),
                    SubjectId = 1,
                    TeacherId = 1
                },
                new Assingment
                {
                    Id = 2,
                    StartsTime = new DateTime(2020, 03, 01),
                    Created = DateTime.Now,
                    EndsTime = new DateTime(2020, 11, 30),
                    SubjectId = 2,
                    TeacherId = 2
                },
                new Assingment
                {
                    Id = 3,
                    StartsTime = new DateTime(2020, 03, 01),
                    Created = DateTime.Now,
                    EndsTime = new DateTime(2020, 11, 30),
                    SubjectId = 3,
                    TeacherId = 3
                },
                new Assingment
                {
                    Id = 4,
                    StartsTime = new DateTime(2020, 03, 01),
                    Created = DateTime.Now,
                    EndsTime = new DateTime(2020, 11, 30),
                    SubjectId = 4,
                    TeacherId = 4
                },
                new Assingment
                {
                    Id = 5,
                    StartsTime = new DateTime(2020, 03, 01),
                    Created = DateTime.Now,
                    EndsTime = new DateTime(2020, 11, 30),
                    SubjectId = 5,
                    TeacherId = 5
                });

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedTeachersAsync(CancellationToken cancellationToken)
        {
            _context.Teachers.AddRange(
                new Teacher { Id = 32165498, IdentityUserId = 11 },
                new Teacher { Id = 24815484, IdentityUserId = 12 },
                new Teacher { Id = 35558451, IdentityUserId = 13 },
                new Teacher { Id = 32548751, IdentityUserId = 14 },
                new Teacher { Id = 36358848, IdentityUserId = 15, IsTemporary = true }
                );

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedSubjectsAsync(CancellationToken cancellationToken)
        {
            _context.Subjects.AddRange(
                new Subject { Id = 1, CodeName = "Mat1", Description = "Matemáticas" },
                new Subject { Id = 2, CodeName = "Fis1", Description = "Fisica" },
                new Subject { Id = 3, CodeName = "Red1", Description = "Redes" },
                new Subject { Id = 4, CodeName = "Alg1", Description = "Algoritmos" },
                new Subject { Id = 5, CodeName = "Prog1", Description = "Programación", RequiredId = 4 }
                );

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedGradesAsync(CancellationToken cancellationToken)
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

        private async Task SeedRoomsAsync(CancellationToken cancellationToken)
        {
            _context.Rooms.AddRange(
                new Room { Id = 1, Description = "Aula 1", Capacity = 100 },
                new Room { Id = 2, Description = "Aula 2", Capacity = 50 },
                new Room { Id = 3, Description = "Aula 3", Capacity = 25 }
                );

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
