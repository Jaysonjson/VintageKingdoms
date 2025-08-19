using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.Datastructures;
using Vintagestory.API.Util;
using Vintagestory.GameContent;

namespace VintageKingdoms.Common.Mixin
{
    [HarmonyPatch(typeof(ItemOre), "GetHeldItemInfo")]
    public class ItemOrePatch
    {

        static bool Prefix(ItemOre __instance, ItemSlot inSlot, StringBuilder dsc, IWorldAccessor world, bool withDebugInfo)
        {
            string str1 = __instance.LastCodePart(1);
            if (VKSystems.OreMap.Contains(str1))
            {
                JsonObject attributes = __instance.Attributes;
                if (attributes != null && attributes["metalUnits"].Exists)
                {
                    float num = attributes["metalUnits"].AsInt();
                    Item obj = world.GetItem(new AssetLocation("vintagekingdoms","nugget-" + str1));
                    if (obj?.CombustibleProps?.SmeltedStack?.ResolvedItemstack != null)
                    {
                        string str2 = obj.CombustibleProps.SmeltedStack.ResolvedItemstack.GetName().Replace(" ingot", "");
                        dsc.AppendLine(Lang.Get("{0} units of {1}", num.ToString("0.#"), str2));
                    }

                    dsc.AppendLine(Lang.Get("Parent Material: {0}", Lang.Get("rock-" + __instance.LastCodePart())));
                    dsc.AppendLine();
                    dsc.AppendLine(Lang.Get("Crush with hammer to extract nuggets"));
                }
                return false;
            }
            return true;
        }
    }
}
