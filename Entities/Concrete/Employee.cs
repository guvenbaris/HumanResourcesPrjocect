using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Employee :IEntity
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int ManagerId { get; set; }
        public int AddressId { get; set; }  
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal SalaryPerHour { get; set; }
        public decimal TotalSalary { get; set; }
        public int WorkingHours { get; set; }
        public bool Statement { get; set; }

    }
}
