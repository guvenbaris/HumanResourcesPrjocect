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
    public class WorkerManager : IWorkerService
    {
        private IWorkerDal _workerDal;

        public WorkerManager(IWorkerDal workerDal)
        {
            _workerDal = workerDal;
        }
        public List<Worker> GetAll()
        {
           return _workerDal.GetAll(w=>w.Statement == true);
        }

        public Worker GetById(int id)
        {
            return  _workerDal.Get(w => w.WorkerId == id);
        }

        public void Update(Worker entity)
        {
            Console.WriteLine(Messages.WorkerUpdated);
            _workerDal.Update(entity);
        }

        public void Delete(Worker entity)
        {
            entity.Statement = false;
            _workerDal.Update(entity);
        }

        public void Add(Worker entity)
        {
            Console.WriteLine(Messages.WorkerAdded);
            _workerDal.Add(entity);
            
        }

    }
}
