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
   public class DepartmentManager : IDepartmentService
    {
        private IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        public List<Department> GetAll()
        {
            return _departmentDal.GetAll(d=>d.Statement == true);
        }

        public Department GetById(int id)
        {
            return _departmentDal.Get(d => d.DepartmentId == id);
        }

        public void Update(Department entity)
        {
            Console.WriteLine(Messages.DepartmentUpdated);
            _departmentDal.Update(entity);
        }

        public void Delete(Department entity)
        {
            entity.Statement = false;
            _departmentDal.Update(entity);
        }

        public void Add(Department entity)
        {
            Console.WriteLine(Messages.DepartmentAdded);
            _departmentDal.Add(entity);
        }
    }
}
