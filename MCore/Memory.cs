using System;

namespace MCore
{
    public class Memory
    {
        private int[] _memory;
        public int Size => _memory.Length;
        public Memory()
        {
            _memory = new int[1024];
        }

        public int Read(int address)
        {
            return _memory[address];
        }

        public void Write(int address, int value)
        {
            _memory[address] = value;
        }

        public void Dump(int start, int length)
        {
            var end = start + length;
            for (var i = start; i < end; i++)
            {
                Console.WriteLine(GetHex(Read(i)));
            }
        }

        private string GetHex(int value)
        {
            return string.Format("0x{0:X4}", value);
        }

        public void Init(int[] instructions)
        {
            for (var i = 0; i < instructions.Length; i++)
            {
                Write(i, instructions[i]);
            }
        }
    }
}