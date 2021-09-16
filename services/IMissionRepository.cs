using Retfeet.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retfeet.API.services
{
    public interface IMissionRepository
    {

        public IEnumerable<Missions> getMission();
        public Missions getMission(int id);
        public Missions getFromUser(int userId);
        public void addMission(Missions mission);

        public void updateMission(Missions mission);
        public void deleteMission(Missions mission);
        public bool MissionExits(Missions mission);
        public void saveChanges();




    }
}
