using Newtonsoft.Json;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VintageKingdoms.Network;
using Vintagestory.API.Common;
using Vintagestory.API.Util;

namespace VintageKingdoms.Common
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class KingdomManager
    {
        public int LastId = 0;
        public Dictionary<int, Kingdom> Kingdoms { get; set; } = new();
        public Dictionary<string, Kingdom> PlayerKingdomCache { get; set; } = new();

        public static KingdomManager Load()
        {
            if (!File.Exists("kingdoms.json")) return new KingdomManager();
            return JsonConvert.DeserializeObject<KingdomManager>(File.ReadAllText("kingdoms.json"));
        }

        public void Save()
        {
            File.WriteAllText("kingdoms.json", JsonConvert.SerializeObject(this));
            Sync();
        }

        public void Sync()
        {
            KingdomNetwork.ServerKingdom?.BroadcastPacket<KingdomManager>(this);
        }

        public Kingdom Create(string name)
        {
            Kingdom kingdom = new Kingdom();
            kingdom.Name = name;
            kingdom.Id = LastId;
            ++LastId;
            Kingdoms.Add(kingdom.Id, kingdom);
            KingdomEvents.FireKingdomCreated(kingdom);
            return kingdom;
        }

        public bool Exists(string name)
        {
            foreach (var (key, kingdom) in Kingdoms)
            {
                if (kingdom.Name.EqualsFastIgnoreCase(name))
                {
                    return true;
                }
            }

            return false;
        }

        public Kingdom Get(int id)
        {
            return Kingdoms[id];
        }

        public Kingdom Get(string name)
        {
            foreach (var (i, kingdom) in Kingdoms)
            {
                if (kingdom.Name.EqualsFastIgnoreCase(name))
                {
                    return kingdom;
                }
            }

            return null;
        }

        public bool PlayerIsAlreadyInKingdom(string player)
        {
            return ResolvePlayerKingdom(player) != null;
        }

        public Kingdom ResolvePlayerKingdom(string player)
        {
            if (PlayerKingdomCache.ContainsKey(player)) return PlayerKingdomCache.Get(player);
            foreach (var (i, kingdom) in Kingdoms)
            {
                foreach (string s in kingdom.Players)
                {
                    if (s.EqualsFastIgnoreCase(player))
                    {
                        PlayerKingdomCache.Add(player, kingdom);
                        return kingdom;
                    }
                }
            }

            return null;
        }

        public Kingdom ResolvePlayerKingdom(EntityPlayer player)
        {
            return ResolvePlayerKingdom(player.PlayerUID);
        }

        public bool PlayerIsAlreadyInKingdom(EntityPlayer player)
        {
            return PlayerIsAlreadyInKingdom(player.PlayerUID);
        }
    }
}
