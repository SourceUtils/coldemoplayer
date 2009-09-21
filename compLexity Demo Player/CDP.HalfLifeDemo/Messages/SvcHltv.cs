﻿using System;
using System.IO;
using BitReader = CDP.Core.BitReader;
using BitWriter = CDP.Core.BitWriter;

namespace CDP.HalfLifeDemo.Messages
{
    public class SvcHltv : EngineMessage
    {
        public override byte Id
        {
            get { return (byte)EngineMessageIds.svc_hltv; }
        }

        public override string Name
        {
            get { return "svc_hltv"; }
        }

        public override bool CanSkipWhenWriting
        {
            get { return true; }
        }

        public byte Command { get; set; }
        public byte[] CommandData { get; set; }

        public override void Skip(BitReader buffer)
        {
            byte command = buffer.ReadByte();

            if (command == 2)
            {
                buffer.SeekBytes(8);
            }
        }

        public override void Read(BitReader buffer)
        {
            Command = buffer.ReadByte();

            if (Command == 2)
            {
                CommandData = buffer.ReadBytes(8);
            }
        }

        public override byte[] Write()
        {
            BitWriter buffer = new BitWriter();
            buffer.WriteByte(Command);

            if (Command == 2)
            {
                buffer.WriteBytes(CommandData);
            }

            return buffer.ToArray();
        }

        public override void Log(StreamWriter log)
        {
            log.WriteLine("Command: {0}", Command);
        }
    }
}
