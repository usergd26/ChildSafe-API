using ChildSafe.Domain.Entities;

namespace ChildSafe.Application.Dtos
{
    public class AttendanceDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public DateTime Date { get; set; }

        public DateTime? WentFromHomeTime { get; set; }
        public DateTime? ReachedSchoolTime { get; set; }
        public DateTime? WentFromSchoolTime { get; set; }
        public DateTime? ReachedHomeTime { get; set; }

        public string? CreatedBy { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }
}
