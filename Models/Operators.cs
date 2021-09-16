using System;
using System.Collections.Generic;

namespace Retfeet.API.Models
{
    public partial class Operators
    {
        public Operators()
        {
            Users = new HashSet<Users>();
        }

        public int OperatorId { get; set; }
        public string OperatorName { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
