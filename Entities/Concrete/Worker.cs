namespace Entities.Concrete
{
    public class Worker : IEntity
    {
        public int WorkerId { get; set; }
        public int MissionId { get; set; }
        public int EmployeeId { get; set; }
        public bool Statement { get; set; }

    }
}