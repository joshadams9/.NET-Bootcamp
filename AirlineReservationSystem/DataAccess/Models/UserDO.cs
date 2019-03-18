using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Common;

namespace DataAccess.Models
{
    public class UserDO
    {

        public int UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public RoleType Role  { get; set; }


     }
}
