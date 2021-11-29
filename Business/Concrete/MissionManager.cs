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
            if (CheckDeadLine(entity.DeadLine) && CheckWorkerOnMissionCount(entity.MissionId)
                                               && CheckManagerRank(entity.ManagerId)) 

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
            if (CheckDeadLine(entity.DeadLine) && CheckWorkerOnMissionCount(entity.MissionId)
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
        private bool CheckWorkerOnMissionCount(int missionId)
        {
            var missions = _missionDal.GetAll(m => m.MissionId == missionId);
            int count = missions.Count;

            if (count >= 0 & count < 20)
            {
                return true;
            }

            Console.WriteLine(Messages.WorkerMissionCountNotCorrect);
            return false;
        }

        private bool CheckManagerRank(int managerId)
        {
            try
            {
                var missions = _missionDal.GetAll(m => m.ManagerId == managerId);
                foreach (var mission in missions)
                {
                    var manager = _managerDal.Get(m => m.ManagerId == mission.ManagerId);
                    if (manager.Rank == 3)
                    {
                        Console.WriteLine(Messages.ManagerRankHighLevel);
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            return true;
        }
    }
}
