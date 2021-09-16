using System;
using System.Collections.Generic;

namespace Retfeet.API.Models
{
    public partial class Usermissions
    {
        public int MissionId { get; set; }
        public int Userid { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UsermissionId { get; set; }

        public virtual Missions Mission { get; set; }
        public virtual Users User { get; set; }
    }
}
