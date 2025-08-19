using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using VintageKingdoms.Common;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Server;

namespace VintageKingdoms
{
    public class VKSystems
    {
        public static ICoreServerAPI Server;
        public static ICoreAPI Common;
        public static ICoreClientAPI Client;
        public static Mod Mod;
        public static KingdomManager KingdomManager = new KingdomManager();
        public static Harmony Harmony = new Harmony("vintagekingdoms");
        public static readonly List<string> OreMap = new()
        {
            "cobaltite",
        };
    }
}
