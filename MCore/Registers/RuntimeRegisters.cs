using System;

namespace MCore.Registers
{
    public class RuntimeRegisters : IRuntimeRegisters
    {
        private int[] _registers;
        public int Size => _registers.Length;
        public RuntimeRegisters()
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
                Console.WriteLine(string.Format("0x{0:X4}",(Read(i))));
            }
        }
    }
}