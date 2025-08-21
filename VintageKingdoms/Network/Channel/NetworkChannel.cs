using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using VintageKingdoms.Common;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Server;
using Vintagestory.API.Util;

namespace VintageKingdoms.Network.Channel
{
    public abstract class NetworkChannel<T>
    {
        public IClientNetworkChannel Client { get; private set; }
        public IServerNetworkChannel Server { get; private set; }

        public void RegisterClient()
        {
            Client = VKSystems.Client.Network.RegisterChannel(Id()).RegisterMessageType(typeof(T)).SetMessageHandler(new NetworkServerMessageHandler<T>(ServerMessageHandler));
        }

        public void RegisterServer()
        {
            Server = VKSystems.Server.Network.RegisterChannel(Id()).RegisterMessageType(typeof(T)).SetMessageHandler(new NetworkClientMessageHandler<T>(ClientMessageHandler));
        }

        public abstract string Id();

        //Executed on the Server - Coming from Client to Server
        public abstract void ClientMessageHandler(IServerPlayer fromPlayer, T packet);
        //Executed on the Client - Coming from the Server to the Client
        public abstract void ServerMessageHandler(T packet);

        public void ServerBroadcast(T packet)
        {
            Server?.BroadcastPacket(packet);
        }

        public void ServerSend(T packet, params IServerPlayer[] players)
        {
            Server?.SendPacket(packet, players);
        }

        //Skips packet if player isnt online
        public void ServerSend(T packet, params string[] players)
        {
            foreach (IServerPlayer player in VKSystems.Server.Server.Players)
            {
                if (!players.Contains(player.PlayerUID)) continue;
                ServerSend(packet, player);
                break;
            }
        }

        public void ClientSend(T packet)
        {
            Client?.SendPacket(packet);
        }
    }
}
