using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VintageKingdoms.Network.Packet
{
    public abstract class SingletonPacket<T>
    {
        public T Data;

        protected SingletonPacket(T data)
        {
            this.Data = data;
        }
    }
}
