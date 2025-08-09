using VintageKingdoms.Common;
using Vintagestory.API.Common;

namespace VintageKingdoms.Common
{
    public static class KingdomTypeExtensions
    {
        public static Kingdom GetKingdom(this EntityPlayer player)
        {
            return VKSystems.KingdomManager.ResolvePlayerKingdom(player);
        }

        public static bool IsInsideKingdom(this EntityPlayer player)
        {
            return VKSystems.KingdomManager.PlayerIsAlreadyInKingdom(player);
        }

        public static void LeaveKingdom(this EntityPlayer player)
        {
            VKSystems.KingdomManager.ResolvePlayerKingdom(player).RemovePlayer(player);
        }


        public static Kingdom GetKingdom(this IPlayer player)
        {
            return VKSystems.KingdomManager.ResolvePlayerKingdom(player.PlayerUID);
        }

        public static bool IsInsideKingdom(this IPlayer player)
        {
            return VKSystems.KingdomManager.PlayerIsAlreadyInKingdom(player.PlayerUID);
        }

        public static void LeaveKingdom(this IPlayer player)
        {
            VKSystems.KingdomManager.ResolvePlayerKingdom(player.PlayerUID)?.RemovePlayer(player.PlayerUID);
        }

        public static bool IsMonarch(this EntityPlayer player)
        {
            return GetKingdom(player)?.Monarch == player.PlayerUID;
        }

        public static bool IsMonarch(this IPlayer player)
        {
            return GetKingdom(player)?.Monarch == player.PlayerUID;
        }
    }
}
