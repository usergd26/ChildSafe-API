using ChildSafe.Domain.Entities;

namespace ChildSafe.Domain.Interfaces
{
    public interface ISchoolRepository
    {
        public Task<IEnumerable<School>> GetAllAsync();
        public Task<School?> GetByIdAsync(int id);
        public Task AddAsync(School school);
        public Task UpdateAsync(School school);
        public Task DeleteAsync(int id);
    }
}
