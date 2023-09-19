using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_Api.Core.Utils
{
    public class EnumUtil

    {
        public static string GetStringFromEnum(int role)
        { string roleString=null;
            switch (role)
            {
                case 0: roleString = "Intern";break;
                case 1: roleString = "TeamLeader";break;
                case 2: roleString = "Admin";break;
            }
           return roleString;
        }
    }
}
