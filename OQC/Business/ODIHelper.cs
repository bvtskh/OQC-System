using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQC.Business
{
    public static class ODIHelper
    {
        public static void UpdateWOQty(string WO, int Qty)
        {
            using(var db = new ClaimFormEntities())
            {
                string sql = $@"Update  ODI set WOQty = {Qty} where WO = '{WO}' and WOQty != {Qty}";
                db.Database.ExecuteSqlCommand(sql);
                db.SaveChanges();
            }
        }
    }
}
