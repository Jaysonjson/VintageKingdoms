using ProtoBuf;
using System;
using System.Collections.Generic;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.GameContent;

namespace VintageKingdoms.Common
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class Kingdom
    {
        public int Id = 0;
        public String Monarch { get; set; } = "";
        public String Name { get; set; } = "";
        public List<String> Players { get; private set; } = new List<String>();

        public void AddPlayer(EntityPlayer player)
        {
            AddPlayer(player.PlayerUID);
        }

        //@player is the player Uid, not the playername
        public void AddPlayer(string player)
        {
            if (!Players.Contains(player))
            {
                Players.Add(player);
                VKSystems.KingdomManager.PlayerKingdomCache.Add(player, this);
                updatePlayerNameTags(player);
            }
        }

        public void updatePlayerNameTags(string player)
        {
            EntityPlayer entityPlayer = VKSystems.Common.World.PlayerByUid(player)?.Entity;
            //Force Display Update
            entityPlayer?.GetBehavior<EntityBehaviorNameTag>().SetName(entityPlayer?.GetName());
        }

        //@player is the player Uid, not the playername
        public void RemovePlayer(string player)
        {
            Players.Remove(player);
            VKSystems.KingdomManager.PlayerKingdomCache.Remove(player);
            updatePlayerNameTags(player);
        }

        public void RemovePlayer(EntityPlayer player)
        {
            RemovePlayer(player.PlayerUID);
        }
    }
}
