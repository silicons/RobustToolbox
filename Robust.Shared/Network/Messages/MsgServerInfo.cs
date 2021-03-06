﻿using Lidgren.Network;
using Robust.Shared.Interfaces.Network;

#nullable disable

namespace Robust.Shared.Network.Messages
{
    public class MsgServerInfo : NetMessage
    {
        #region REQUIRED
        public static readonly MsgGroups GROUP = MsgGroups.Core;
        public static readonly string NAME = nameof(MsgServerInfo);
        public MsgServerInfo(INetChannel channel) : base(NAME, GROUP) { }
        #endregion

        public string ServerName { get; set; }
        public int ServerMaxPlayers { get; set; }
        public byte TickRate { get; set; }

        public override void ReadFromBuffer(NetIncomingMessage buffer)
        {
            ServerName = buffer.ReadString();
            ServerMaxPlayers = buffer.ReadInt32();
            TickRate = buffer.ReadByte();
        }

        public override void WriteToBuffer(NetOutgoingMessage buffer)
        {
            buffer.Write(ServerName);
            buffer.Write(ServerMaxPlayers);
            buffer.Write(TickRate);
        }
    }
}
