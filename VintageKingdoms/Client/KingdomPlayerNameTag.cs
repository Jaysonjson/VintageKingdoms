using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VintageKingdoms.Common;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;

namespace VintageKingdoms.Client
{
    public class KingdomPlayerNameTag
    {
        public static void Init()
        {
            EntityNameTagRendererRegistry.DefaultNameTagRenderer = ((capi, entity) =>
            {
                string displayName = entity.GetBehavior<EntityBehaviorNameTag>()?.DisplayName;
                if (displayName == null || displayName.Length <= 0)
                    return null;
                if (entity is EntityPlayer player)
                {
                    Kingdom kingdom = player.GetKingdom();
                    if (kingdom != null) displayName += "\n" + kingdom.Name;
                }
                return capi.Gui.TextTexture.GenUnscaledTextTexture(Lang.GetIfExists("nametag-" + displayName.ToLowerInvariant()) ?? displayName, CairoFont.WhiteMediumText().WithColor(ColorUtil.WhiteArgbDouble), new TextBackground()
                {
                    FillColor = GuiStyle.DialogLightBgColor,
                    Padding = 3,
                    Radius = GuiStyle.ElementBGRadius,
                    Shade = true,
                    BorderColor = GuiStyle.DialogBorderColor,
                    BorderWidth = 3.0
                });
            });
        }

    }
}
