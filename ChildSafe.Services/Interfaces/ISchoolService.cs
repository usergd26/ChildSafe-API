using ChildSafe.Application.Dtos;

namespace ChildSafe.Application.Interfaces
{
    public interface ISchoolService
    {
        public Task<IEnumerable<SchoolDto>> GetAllAsync();
        public Task<SchoolDto> GetByIdAsync(int id);
        public Task AddAsync(SchoolDto school);
        public Task UpdateAsync(SchoolDto school);
        public Task DeleteAsync(int id);
    }
}
