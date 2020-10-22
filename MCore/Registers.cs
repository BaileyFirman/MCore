using System;

namespace MCore
{
    public class Registers
    {
        private int[] _registers;
        public int Size => _registers.Length;
        public Registers()
        {
            _registers = new int[16];
        }

        public int Read(int address)
        {
            return _registers[address];
        }

        public void Write(int address, int value)
        {
            _registers[address] = value;
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
    }
}