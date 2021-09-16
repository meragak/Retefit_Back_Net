using System;
using System.Collections.Generic;

namespace Retfeet.API.Models
{
    public partial class Missions
    {
        public Missions()
        {
            Usermissions = new HashSet<Usermissions>();
        }

        public int MissionId { get; set; }
        public string ClientName { get; set; }
        public int ClientNumber { get; set; }
        public string ClientAdress { get; set; }

        public virtual ICollection<Usermissions> Usermissions { get; set; }
    }
}
