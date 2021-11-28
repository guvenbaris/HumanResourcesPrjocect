using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constans;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.IdentityModel.Tokens;

namespace Business.Concrete
{
    public class MissionManager : IMissionService
    {
        private IMissionDal _missionDal;
        private IManagerDal _managerDal;

        public MissionManager(IMissionDal missionDal, IManagerDal managerDal)
        {
            _missionDal = missionDal;
            _managerDal = managerDal;
        }
        public List<Mission> GetAll()
        {
            return _missionDal.GetAll(m => m.Statement == true);
        }

        public Mission GetById(int id)
        {
            return _missionDal.Get(m => m.MissionId == id);
        }

        public void Update(Mission entity)
        {
            if (CheckDeadLine(entity.DeadLine) )

            {
                Console.WriteLine(Messages.MissionUpdated);
                _missionDal.Update(entity);
            }
        }
        public void Delete(Mission entity)
        {
            entity.Statement = false;
            _missionDal.Update(entity);
        }
        public void Add(Mission entity)
        {
            if (CheckDeadLine(entity.DeadLine) && CheckWorkerOnMissionCount(entity.WorkerId)
                && CheckManagerRank(entity.ManagerId))
            {
                Console.WriteLine(Messages.MissionAdded);
                _missionDal.Add(entity);
            }
        }
        private bool CheckDeadLine(DateTime dateTime)
        {
            if (DateTime.Now.AddYears(1) > dateTime)
            {
                return true;
            }
            return false;
        }
        private bool CheckWorkerOnMissionCount(int workerId)
        {
            var missions = _missionDal.GetAll(m => m.WorkerId == workerId);
            int count = 0;
            foreach (var mission in missions)
            {
                count += 1;
            }
            if (count > 1 & count < 10)
            {
                return true;
            }

            Console.WriteLine(Messages.WorkerMissionCountNotCorrect);
            return false;
        }

        private bool CheckManagerRank(int managerId)
        {
            var mission = _missionDal.Get(m => m.ManagerId == managerId);
            var manager = _managerDal.Get(m => m.Id == mission.ManagerId);
            if (manager.Rank == "Tier3")
            {
                Console.WriteLine(Messages.ManagerRankHighLevel);
                return false;
                
            }
            return true;
        }
    }
}
