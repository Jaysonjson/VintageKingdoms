using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VintageKingdoms.Common
{
    public static class KingdomEvents
    {
       public static event KingdomDelegate EventKingdomCreated;


       public static void FireKingdomCreated(Common.Kingdom kingdom)
       {
            EventKingdomCreated?.Invoke(kingdom);
       }
    }

}
