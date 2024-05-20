using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQC.Business
{
    public static class PermisionHelper
    {
        public static bool CheckIsLeader()
        {
            return Properties.Settings.Default.Account == 2;
        }
    }
}
