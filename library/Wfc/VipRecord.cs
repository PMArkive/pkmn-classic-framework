using PkmnFoundations.Support;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PkmnFoundations.Wfc
{
    public class VipRecord : BinarySerializableBase
    {
        public VipRecord()
        {
            Pid = 0;
            WordPartA = 0;
            WordPartB = 0;
            WordPartC = 0;
            WordPartD = 0;
        }

        public VipRecord(uint pid)
        {
            Pid = pid;
            WordPartA = 0;
            WordPartB = 0;
            WordPartC = 0;
            WordPartD = 0;
        }

        public VipRecord(uint pid, byte wordA, byte wordB, byte wordC, byte wordD)
        {
            Pid = pid;
            WordPartA = wordA;
            WordPartB = wordB;
            WordPartC = wordC;
            WordPartD = wordD;
        }

        public VipRecord(byte[] data)
        {
            Load(data);
        }

        public uint Pid; // Profile id of the user who is a VIP.
        public byte WordPartA; // D + A creates first word, A + B creates second word.
        public byte WordPartB; // A + B creates second word, B + C creates third word.
        public byte WordPartC; // B + C creates third word, C + D creates fourth word.
        public byte WordPartD; // D + A creates first word, C + D creates fourth word.

        protected override void Load(BinaryReader reader)
        {
            Pid = reader.ReadUInt32();
            WordPartA = reader.ReadByte();
            WordPartB = reader.ReadByte();
            WordPartC = reader.ReadByte();
            WordPartD = reader.ReadByte();
        }

        protected override void Save(BinaryWriter writer)
        {
            writer.Write(Pid);
            writer.Write(WordPartA);
            writer.Write(WordPartB);
            writer.Write(WordPartC);
            writer.Write(WordPartD);
        }

        public override int Size
        {
            get
            {
                return 8;
            }
        }
    }
}
