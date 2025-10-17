using ChildSafe.Application.Dtos;
using ChildSafe.Application.Interfaces;
using ChildSafe.Domain.Entities;
using ChildSafe.Domain.Interfaces;

namespace ChildSafe.Application.Services
{
    public class AttendanceService(IAttendanceRepository attendanceRepository) : IAttendanceService
    {
        public async Task AddAsync(AttendanceDto attendance)
        {
           await attendanceRepository.AddAsync(new Attendance
            {
                 CreatedBy = attendance.CreatedBy,
                 Date = attendance.Date,
                 StudentId = attendance.StudentId,
                 WentFromHomeTime = attendance.WentFromHomeTime,
                 ReachedSchoolTime = attendance.ReachedSchoolTime,
                 Id = attendance.Id,
                 WentFromSchoolTime = attendance.WentFromSchoolTime,
                 ReachedHomeTime = attendance.ReachedHomeTime,
                 LastUpdatedBy = attendance.LastUpdatedBy,
                 LastUpdatedOn = attendance.LastUpdatedOn,
                 Student = null!,
           });
        }

        public Task<IEnumerable<AttendanceDto>> GetAllAsync(int studentId)
        {
            throw new NotImplementedException();
        }

        public Task<AttendanceDto?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(AttendanceDto attendance)
        {
            await attendanceRepository.UpdateAsync(new Attendance
            {
                CreatedBy = attendance.CreatedBy,
                Date = attendance.Date,
                StudentId = attendance.StudentId,
                WentFromHomeTime = attendance.WentFromHomeTime,
                ReachedSchoolTime = attendance.ReachedSchoolTime,
                Id = attendance.Id,
                WentFromSchoolTime = attendance.WentFromSchoolTime,
                ReachedHomeTime = attendance.ReachedHomeTime,
                LastUpdatedBy = attendance.LastUpdatedBy,
                LastUpdatedOn = attendance.LastUpdatedOn,
            });
        }
    }
}
