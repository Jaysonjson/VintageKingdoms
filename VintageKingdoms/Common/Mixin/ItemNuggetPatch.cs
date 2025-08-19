using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.API.Util;
using Vintagestory.Client.NoObf;
using Vintagestory.GameContent;

namespace VintageKingdoms.Common.Mixin
{
    [HarmonyPatch(typeof(ItemNugget), "OnCreatedByCrafting")]
    public class ItemNuggetPatch
    {
        public static bool Prefix(
            ItemSlot[] allInputslots,
            ItemSlot outputSlot,
            GridRecipe byRecipe)
        {
            ItemSlot itemSlot = ((IEnumerable<ItemSlot>)allInputslots).FirstOrDefault<ItemSlot>((System.Func<ItemSlot, bool>)(slot => slot.Itemstack?.Collectible is ItemOre));
            if (itemSlot != null && VKSystems.OreMap.Contains(itemSlot.Itemstack.Collectible.Variant["ore"]))
            {
                {
                    int num = itemSlot.Itemstack.ItemAttributes["metalUnits"].AsInt(5);
                    outputSlot.Itemstack = new ItemStack(VKSystems.Common.World.GetItem(new AssetLocation("vintagekingdoms","nugget-" + itemSlot.Itemstack.Collectible.Variant["ore"])))
                    {
                        StackSize = Math.Max(1, num / 5)
                    };
                }
                return false;
            }

            return true;
        }
    }
}
