using ChildSafe.Domain.Entities;
using ChildSafe.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChildSafe.Domain.Repositories
{
    public class StudentRepository(AppDbContext context) : IStudentRepository
    {
        public async Task AddAsync(Student student)
        {
             await context.Students.AddAsync(student);
             await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await context.Students.FindAsync(id);
            if (student != null)
            {
                student.IsDeleted = true;
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return context.Students;
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await context.Students.FindAsync(id);
        }

        public Task UpdateAsync(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
