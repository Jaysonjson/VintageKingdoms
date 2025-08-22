using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace VintageKingdoms.Common.Items
{
    //TODO: Fix, so I can replace the patches
    public class VKItemOre : ItemOre
    {
        public override void GetHeldItemInfo(ItemSlot inSlot, StringBuilder dsc, IWorldAccessor world, bool withDebugInfo)
        {
            if (this.CombustibleProps?.SmeltedStack?.ResolvedItemstack == null)
            {
                JsonObject attributes = this.Attributes;
                if ((attributes != null ? (attributes["metalUnits"].Exists ? 1 : 0) : 0) != 0)
                {
                    float num = (float)this.Attributes["metalUnits"].AsInt();
                    string str1 = this.LastCodePart(1);
                    if (str1.Contains("_"))
                        str1 = str1.Split('_')[1];
                    Item obj = this.api.World.GetItem(new AssetLocation("vintagekingdoms","nugget-" + str1));
                    if (obj?.CombustibleProps?.SmeltedStack?.ResolvedItemstack != null)
                    {
                        string str2 = obj.CombustibleProps.SmeltedStack.ResolvedItemstack.GetName().Replace(" ingot", "");
                        dsc.AppendLine(Lang.Get("{0} units of {1}", (object)num.ToString("0.#"), (object)str2));
                    }
                    dsc.AppendLine(Lang.Get("Parent Material: {0}", (object)Lang.Get("rock-" + this.LastCodePart())));
                    dsc.AppendLine();
                    dsc.AppendLine(Lang.Get("Crush with hammer to extract nuggets"));
                }
                base.GetHeldItemInfo(inSlot, dsc, world, withDebugInfo);
            }
            else
            {
                base.GetHeldItemInfo(inSlot, dsc, world, withDebugInfo);
                if (!this.CombustibleProps.SmeltedStack.ResolvedItemstack.GetName().Contains("ingot"))
                    return;
                string lowerInvariant = this.CombustibleProps.SmeltingType.ToString().ToLowerInvariant();
                float num = (float)this.CombustibleProps.SmeltedStack.ResolvedItemstack.StackSize * 100f / (float)this.CombustibleProps.SmeltedRatio;
                string str3 = this.CombustibleProps.SmeltedStack.ResolvedItemstack.GetName().Replace(" ingot", "");
                string str4 = Lang.Get($"game:smeltdesc-{lowerInvariant}ore-plural", (object)num.ToString("0.#"), (object)str3);
                dsc.AppendLine(str4);
            }
        }
    }
}
