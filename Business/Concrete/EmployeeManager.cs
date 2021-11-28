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
   public class EmployeeManager : IEmployeeService
   {
       private IEmployeeDal _employeeDal;
       private IDepartmentDal _departmentDal;

       public EmployeeManager(IEmployeeDal employeeDal, IDepartmentDal departmentDal)
       {
           _employeeDal = employeeDal;
           _departmentDal = departmentDal;
       }
       public List<Employee> GetAll()
       {
          return _employeeDal.GetAll(e=>e.Statement==true);
       }

        public Employee GetById(int id)
        {
            return _employeeDal.Get(e => e.Id == id);
        }

        public void Update(Employee entity)
        {
            var department = _departmentDal.Get(d => d.DepartmentId == entity.DepartmentId);
            if (CheckPhoneNumberIsCorrect(entity.PhoneNumber)
                && CheckSalaryPerHourIsCorrect(entity.SalaryPerHour, department.DepartmentName)
                && CheckTotalSalaryIsCorrect(entity.TotalSalary, department.DepartmentName)
                && CheckWorkingHoursCorrect(entity.WorkingHours, department.DepartmentName))
            {
                Console.WriteLine(Messages.EmployeeUpdated);
                _employeeDal.Update(entity);
            }
        }
        public void Delete(Employee entity)
        {
            entity.Statement = false;
            _employeeDal.Update(entity);

        }

        public void Add(Employee entity)
        {
            var department = _departmentDal.Get(d => d.DepartmentId == entity.DepartmentId);
            if (CheckPhoneNumberIsCorrect(entity.PhoneNumber) 
                && CheckSalaryPerHourIsCorrect(entity.SalaryPerHour,department.DepartmentName) 
                && CheckTotalSalaryIsCorrect(entity.TotalSalary,department.DepartmentName)
                && CheckWorkingHoursCorrect(entity.WorkingHours,department.DepartmentName))
            {
                Console.WriteLine(Messages.EmployeeAdded);
                _employeeDal.Add(entity);
            }
        }
        private bool CheckPhoneNumberIsCorrect(string phoneNumber)
        {

            if (phoneNumber.Length == 10 && phoneNumber[0] != '0')
            {
                return true;
            }

            Console.WriteLine(Messages.PhoneNumberIsNotCorrect);
            return false;
        }
        private bool CheckSalaryPerHourIsCorrect(decimal salaryPerHour,string department)
        {
            if (department == "Business Development")
            {
                if (salaryPerHour >20)
                {
                    return true;
                }
                Console.WriteLine(Messages.SalaryPerHourIsNotCorrect);
                return false;
            }
            else
            {
                if (salaryPerHour > 17)
                {
                    return true;
                }
                Console.WriteLine(Messages.SalaryPerHourIsNotCorrect);
                return false;
            }
           
           
        }
        private bool CheckTotalSalaryIsCorrect(decimal totalSalary,string department)
        {

            if (department == "Business Development")
            {
                if (totalSalary >= 4000)
                {
                    return true;
                }
                Console.WriteLine(Messages.TotalSalaryIsNotCorrect);
                return false;
            }
            else
            {
                if (totalSalary >= 2825)
                {
                    return true;
                }
                Console.WriteLine(Messages.TotalSalaryIsNotCorrect);
                return false;
            }
        }
        private bool CheckWorkingHoursCorrect(int workingHours,string department)
        {
            if (department == "Business Development")
            {
                if (workingHours >= 8)
                {
                    return true;
                }
                Console.WriteLine(Messages.WorkingHoursIsNotCorrect);
                return false;
            }
            else
            {
                if (workingHours >= 8 & workingHours <= 10)
                {
                    return true;
                }
                Console.WriteLine(Messages.WorkingHoursIsNotCorrect);
                return false;
            }
        }
    }
}
