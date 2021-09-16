using System;
using System.Collections.Generic;

namespace Retfeet.API.Models
{
    public partial class Users
    {
        public Users()
        {
            Usermissions = new HashSet<Usermissions>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Adress { get; set; }
        public int OperatorId { get; set; }

        public virtual Operators Operator { get; set; }
        public virtual ICollection<Usermissions> Usermissions { get; set; }
    }
}
