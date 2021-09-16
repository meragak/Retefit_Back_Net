using Retfeet.API.services;
using Retfeet.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retfeet.API.services
{
    public class MissionRepository : IMissionRepository
    {
        private readonly MyTechContext _context;
        public MissionRepository(MyTechContext context)
        {
            _context = context;
        }

        public void addMission(Missions mission)
        {
            _context.Missions.Add(mission);
        }

        public void deleteMission(Missions mission)
        {
            _context.Missions.Remove(mission);
        }

        public Missions getFromUser(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Missions> getMission()
        {
            throw new NotImplementedException();
        }

        public Missions getMission(int id)
        {
            return _context.Missions.FirstOrDefault(m => m.MissionId == id);
        }

        public bool MissionExits(Missions Mission)
        {
            throw new NotImplementedException();
        }

        public void saveChanges()
        {
            throw new NotImplementedException();
        }

        public void updateMission(Missions mission)
        {
            throw new NotImplementedException();
        }
    }
}
