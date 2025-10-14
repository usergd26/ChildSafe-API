using ChildSafe.Domain.Entities;

namespace ChildSafe.Domain.Interfaces
{
    public interface IStudentRepository
    {
        public Task<IEnumerable<Student>> GetAllAsync();
        public Task<Student?> GetByIdAsync(int id);
        public Task AddAsync(Student student);
        public Task UpdateAsync(Student student);
        public Task DeleteAsync(int id);
    }
}
