using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace VintageKingdoms.Common.Items
{
    //TODO: Fix, so I can replace the patches
    public class VKItemNugget : ItemNugget
    {
        public override void OnCreatedByCrafting(ItemSlot[] allInputslots, ItemSlot outputSlot, GridRecipe byRecipe)
        {
            ItemSlot itemSlot = ((IEnumerable<ItemSlot>)allInputslots).FirstOrDefault<ItemSlot>((System.Func<ItemSlot, bool>)(slot => slot.Itemstack?.Collectible is ItemOre));
            if (itemSlot != null)
            {
                int num = itemSlot.Itemstack.ItemAttributes["metalUnits"].AsInt(5);
                outputSlot.Itemstack = new ItemStack(this.api.World.GetItem(new AssetLocation("vintagekingdoms", "nugget-" + itemSlot.Itemstack.Collectible.Variant["ore"])))
                {
                    StackSize = Math.Max(1, num / 5)
                };
            }
            //This calls ItemNugget instead of CollectibleObjects, but I guess its fine
            base.OnCreatedByCrafting(allInputslots, outputSlot, byRecipe);
        }
    }
}
