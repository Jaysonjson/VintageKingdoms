using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VintageKingdoms.src.common.kingdom
{
    public interface IKingdomType
    {
        int MinPlayers();
        string GetName();
        string GetMonarchTitle();
    }
}
