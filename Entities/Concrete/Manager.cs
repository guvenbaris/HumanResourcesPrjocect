namespace Entities.Concrete
{
    public class Manager :IEntity
    {
        public int Id { get; set; }
        public int ManagerId { get; set; }
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public int SpanOfControl { get; set; }
        public string Rank { get; set; }
        public bool Statement { get; set; }

    }
}