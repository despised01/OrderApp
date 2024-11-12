using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Class
{
    public class User
    {
        public Profile LoadProfile(int profileID)
        {
            return new Profile { ManagerID = 1, OfficeID = 10, DepartmentID = 20 };
        }

        public Profile LoadProfileByUserID(int userID)
        {
            return new Profile { ManagerID = 2, OfficeID = 30, DepartmentID = 40 };
        }
    }
}
