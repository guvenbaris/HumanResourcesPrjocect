using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constans;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
   public class ManagerManager : IManagerService
   {
       private IManagerDal _managerDal;

       public ManagerManager(IManagerDal managerDal)
       {
           _managerDal = managerDal;
       }
       public List<Manager> GetAll()
       {
           return _managerDal.GetAll(m=>m.Statement == true);
       }

        public Manager GetById(int id)
        {
            return _managerDal.Get(m => m.ManagerId == id);
        }
        public void Update(Manager entity)
        {
            if (CheckIfSpanOfControlCount(entity.SpanOfControl) &&
                CheckManagerDepartmentCount(entity.ManagerId, entity.DepartmentId))
            {
                Console.WriteLine(Messages.ManagerUpdated);
                _managerDal.Update(entity);
            }
        }
        public void Delete(Manager entity)
        {
            entity.Statement = false;
            _managerDal.Update(entity);
        }

        public void Add(Manager entity)
        {
            if (CheckIfSpanOfControlCount(entity.SpanOfControl) &&
                CheckManagerDepartmentCount(entity.ManagerId, entity.DepartmentId))
            {
                Console.WriteLine(Messages.ManagerAdded);
                _managerDal.Add(entity);
            }
            
        }
        private bool CheckIfSpanOfControlCount(int spanOfControl)
        {
            if (spanOfControl >= 1 & spanOfControl <= 15)
            {
                return true;
            }
            Console.WriteLine(Messages.SpanOfControlNotCorrect);
            return false;
        }

        private bool CheckManagerDepartmentCount(int managerId,int departmentId)
        {
            var managers =  _managerDal.GetAll(m => m.ManagerId == managerId);
            int count = 0;
            foreach (var manager in managers)
            {
                if (manager.DepartmentId == departmentId)
                {
                    count++;
                }
            }
            if (count <= 5)
            {
                return true;
            }

            Console.WriteLine(Messages.DepartmentCountIsNotCorrect);
            return false;

        }
    }
}
