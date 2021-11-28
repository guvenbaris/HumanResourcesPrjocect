namespace Entities.Concrete
{
    public class Department :IEntity
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public bool Statement { get; set; }

    }
}