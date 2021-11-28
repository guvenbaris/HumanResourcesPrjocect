using System;

namespace Entities.Concrete
{
    public class Mission :IEntity
    {
        public int Id { get; set; }
        public int MissionId { get; set; }
        public int WorkerId { get; set; }
        public int ManagerId { get; set; }
        public DateTime DeadLine { get; set; }
        public string Description { get; set; }
        public bool Statement { get; set; }

    }
}