using ChildSafe.Application.Dtos;

namespace ChildSafe.Application.Interfaces
{
    public interface IAttendanceService
    {
        Task<IEnumerable<AttendanceDto>> GetAllAsync(int studentId);
        Task<AttendanceDto?> GetByIdAsync(int id);
        Task AddAsync(AttendanceDto attendance);
        Task UpdateAsync(AttendanceDto attendance);
    }
}
