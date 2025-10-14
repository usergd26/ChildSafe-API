
using ChildSafe.Application.Dtos;

namespace ChildSafe.Application.Interfaces
{
    public interface IStudentService
    {
        public Task<IEnumerable<StudentDto>> GetAllAsync();
        public Task<StudentDto> GetByIdAsync(int id);
        public Task AddAsync(StudentDto student);
        public Task UpdateAsync(StudentDto student);
        public Task DeleteAsync(int id);
    }
}
