﻿using System;
using System.IO;
using BitReader = CDP.Core.BitReader;
using BitWriter = CDP.Core.BitWriter;

namespace CDP.HalfLifeDemo.UserMessages
{
    public class TeamInfo : UserMessage
    {
        public override string Name
        {
            get { return "TeamInfo"; }
        }

        public override bool CanSkipWhenWriting
        {
            get { return true; }
        }

        public byte Slot { get; set; }
        public string TeamName { get; set; }

        public override void Read(BitReader buffer)
        {
            Slot = buffer.ReadByte();
            TeamName = buffer.ReadString();
        }

        public override byte[] Write()
        {
            BitWriter buffer = new BitWriter();
            buffer.WriteByte(Slot);
            buffer.WriteString(TeamName);
            return buffer.ToArray();
        }

        public override void Log(StreamWriter log)
        {
            log.WriteLine("Slot: {0}", Slot);
            log.WriteLine("TeamName: {0}", TeamName);
        }
    }
}
