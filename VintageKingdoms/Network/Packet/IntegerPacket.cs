using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VintageKingdoms.Network.Packet
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class IntegerPacket
    {
        public int Integer;

        public IntegerPacket(int integer)
        {
            this.Integer = integer;
        }

    }
}
