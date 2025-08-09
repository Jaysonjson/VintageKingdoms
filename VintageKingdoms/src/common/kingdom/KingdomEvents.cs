using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VintageKingdoms.Kingdom
{
    public static class KingdomEvents
    {
       public static event Action<Common.Kingdom> EventKingdomCreated;


       public static void FireKingdomCreated(Common.Kingdom kingdom)
       {
            EventKingdomCreated?.Invoke(kingdom);
       }
    }

}
