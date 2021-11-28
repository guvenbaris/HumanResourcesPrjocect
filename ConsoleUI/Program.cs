using System;
using System.Collections.Generic;
using System.IO;
using Business;
using Business.Concrete;
using DataAccess;
using DataAccess.Concrete;
using Entities.Concrete;
using Newtonsoft.Json;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Adres Eklendi DB'ye
            //Department Eklendi DB'ye
            //Employee Eklendi DB'ye
            //Manager EKlendi DB'ye
            //Mission Eklendi DB'ye

            //AddressManager _addressManager = new AddressManager(new AddressDal());
            //DepartmentManager _departManager = new DepartmentManager(new DepartmentDal());
            //EmployeeManager _employeeManager = new EmployeeManager(new EmployeeDal(), new DepartmentDal());
            //ManagerManager _managerManager = new ManagerManager(new ManagerDal());
            //MissionManager _missionManager = new MissionManager(new MissionDal(),new ManagerDal());
            //WorkerManager _workerManager = new WorkerManager(new WorkerDal());


            EmployeeManager _employeeManager = new EmployeeManager(new EmployeeDal(), new DepartmentDal());
            //var employees =_employeeManager.GetAll();
            //foreach (var employee in employees)
            //{
            //    Console.WriteLine(employee.FullName);
            //}
            //EmployeeAddMethodControl(_employeeManager);
            //MissionControl();
            //GetJsonData(_workerManager);
            //AddressControled();
        }

        private static void AddressControled()
        {
            AddressManager _addressManager = new AddressManager(new AddressDal());

            foreach (var address in _addressManager.GetAll())
            {
                Console.WriteLine(address.City);
            }
        }

        private static void MissionControl()
        {
            MissionManager _missionManager = new MissionManager(new MissionDal(), new ManagerDal());
            Mission _mission = new Mission
            {
                ManagerId = 4,
                DeadLine = DateTime.Now.AddMonths(6),
                Description = "Bilgisayar Programlama",
                MissionId = 1,
                WorkerId = 50,
                Statement = true,
                Id = 1
            };
            _missionManager.Update(_mission);
        }

        private static void EmployeeAddMethodControl(EmployeeManager _employeeManager)
        {
            Employee _employee = new Employee
            {
                ManagerId = 1,
                AddressId = 12,
                DepartmentId = 1,
                FullName = "Kamil Atlar",
                Statement = true,
                PhoneNumber = "2462113941",
                TotalSalary = 2825,
                SalaryPerHour = 25,
                WorkingHours = 12
            };
            _employeeManager.Add(_employee);
        }

        private static void GetJsonData(WorkerManager _workerManager)
        {
            JsonDataHelper<Worker> Json = new JsonDataHelper<Worker>();
            var items = Json.ReadJsonFile(path: "Worker");
            foreach (var item in items)
            {
                item.Statement = true;
                _workerManager.Add(item);
            }
        }
    }
}
