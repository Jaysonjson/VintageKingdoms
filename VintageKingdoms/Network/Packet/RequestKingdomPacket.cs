using ProtoBuf;

namespace VintageKingdoms.Network.Packet
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class RequestKingdomPacket
    {
        public int KingdomId;
        public string Player;

        public RequestKingdomPacket(int kingdom, string player)
        {
            KingdomId = kingdom;
            Player = player;
        }
    }
}
