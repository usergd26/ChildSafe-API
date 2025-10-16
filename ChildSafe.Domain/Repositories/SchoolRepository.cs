using ChildSafe.Domain.Entities;
using ChildSafe.Domain.Interfaces;

namespace ChildSafe.Domain.Repositories
{
    public class SchoolRepository(AppDbContext context) : ISchoolRepository
    {
        public async Task AddAsync(School school)
        {
            await context.Schools.AddAsync(school);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var school = await context.Schools.FindAsync(id);
            if (school != null)
            {
                school.IsDeleted = true;
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<School>> GetAllAsync()
        {
            return context.Schools;
        }

        public async Task<School?> GetByIdAsync(int id)
        {
            return await context.Schools.FindAsync(id);
        }

        public Task UpdateAsync(School school)
        {
            throw new NotImplementedException();
        }
    }
}
