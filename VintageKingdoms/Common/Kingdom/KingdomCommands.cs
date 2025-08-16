using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VintageKingdoms.Common;
using Vintagestory.API.Common;
using Vintagestory.API.Server;

namespace VintageKingdoms.Common
{
    public class KingdomCommands
    {
        public static void Register()
        {
            VKSystems.Server.ChatCommands.Create("kingdom")
                .WithDescription("Kingdom Commands")
                .RequiresPrivilege(Privilege.claimland)
                .RequiresPlayer()
                .BeginSubCommand("create").WithArgs(new StringArgParser("name", true))
                .WithDescription("Create a new Kingdom").HandleWith(OnCreateCommand).EndSubCommand()
                .BeginSubCommand("leave").WithDescription("Leave your current Kingdom").HandleWith(OnLeaveCommand)
                .WithDescription("Leave your Kingdom").EndSubCommand()
                .BeginSubCommand("disband").WithDescription("Disband your Kingdom").HandleWith(OnDisbandCommand);
        }

        private static TextCommandResult OnCreateCommand(TextCommandCallingArgs textCommandCallingArgs)
        {
            if (textCommandCallingArgs.Caller.Player is IPlayer player)
            {
                if (player.IsInsideKingdom()) return TextCommandResult.Error("You are already in a Kingdom");
                string name = (string)textCommandCallingArgs.LastArg;
                if (VKSystems.KingdomManager.Exists(name)) return TextCommandResult.Error("Kingdom already exists");
                Kingdom kingdom = VKSystems.KingdomManager.Create(name);
                kingdom.AddPlayer(player.PlayerUID);
                kingdom.Monarch = player.PlayerUID;
                VKSystems.KingdomManager.Save();
                return TextCommandResult.Success("Kingdom " + name + " created with " + player.PlayerName + " as the monarch");
            }
            return TextCommandResult.Error("Could not leave Kingdom");
        }

        private static TextCommandResult OnDisbandCommand(TextCommandCallingArgs textCommandCallingArgs)
        {
            if (textCommandCallingArgs.Caller.Player is IPlayer player)
            {
                if (!player.IsInsideKingdom()) return TextCommandResult.Error("You arent in a Kingdom");
                if (!player.IsMonarch()) return TextCommandResult.Error("Only the Monarch can disband a Kingdom");
                VKSystems.KingdomManager.Kingdoms.Remove(player.GetKingdom().Id);
                VKSystems.KingdomManager.Save();
                return TextCommandResult.Success("You have left your Kingdom.");
            }
            return TextCommandResult.Error("Could not disband Kingdom");
        }

        private static TextCommandResult OnLeaveCommand(TextCommandCallingArgs textCommandCallingArgs)
        {
            if (textCommandCallingArgs.Caller.Player is IPlayer player)
            {
                if (!player.IsInsideKingdom()) return TextCommandResult.Error("You arent in a Kingdom");
                if (player.IsMonarch()) return TextCommandResult.Error("You are the current monarch, please assign another monarch before leaving");
                player.LeaveKingdom();
                VKSystems.KingdomManager.Save();
                return TextCommandResult.Success("You have left your Kingdom.");
            }
            return TextCommandResult.Error("Could not create Kingdom");
        }
    }
}
