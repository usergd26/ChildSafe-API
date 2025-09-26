namespace ChildSafe.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
        public AppUser Parent { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
