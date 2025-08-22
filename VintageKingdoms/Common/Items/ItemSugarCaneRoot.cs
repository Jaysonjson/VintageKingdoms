using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace VintageKingdoms.Common.Items
{
    public class ItemSugarCaneRoot : ItemCattailRoot
    {
        public override void OnHeldInteractStart(ItemSlot itemslot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handHandling)
        {
            if (blockSel == null || byEntity?.World == null || !byEntity.Controls.ShiftKey)
            {
                base.OnHeldInteractStart(itemslot, byEntity, blockSel, entitySel, firstEvent, ref handHandling);
            }
            else
            {
                Block block = byEntity.World.GetBlock(new AssetLocation("vintagekingdoms","tallplant-sugarcane-land-harvested-free"));
                if (block == null)
                {
                    base.OnHeldInteractStart(itemslot, byEntity, blockSel, entitySel, firstEvent, ref handHandling);
                }
                else
                {
                    IPlayer player = null;
                    if (byEntity is EntityPlayer player1)
                        player = byEntity.World.PlayerByUid(player1.PlayerUID);
                    blockSel = blockSel.Clone();
                    blockSel.Position.Add(blockSel.Face);
                    string failureCode = "";
                    if (!block.TryPlaceBlock(byEntity.World, player, itemslot.Itemstack, blockSel, ref failureCode))
                        return;
                    byEntity.World.PlaySoundAt(block.Sounds.GetBreakSound(player), blockSel.Position, 0.0, player);
                    itemslot.TakeOut(1);
                    itemslot.MarkDirty();
                    handHandling = EnumHandHandling.PreventDefaultAction;
                }
            }
        }
    }
}
