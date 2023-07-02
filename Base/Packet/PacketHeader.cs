
using System;

namespace WooNet
{
    struct PacketHeader
    {
        //头共 15 个字节

        public UInt32 MainId { get; set; }

        public UInt32 SubId { get; set; }
        public byte pkgType { get; set; }
        public UInt16 pkgCount { get; set; } /*= 1;*/
        public UInt32 messageLen { get; internal set; }
    }
}
