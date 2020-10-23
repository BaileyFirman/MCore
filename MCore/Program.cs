using MCore.Memory;
using MCore.Registers;
using MCore.Runtime;
using MCore.Stack;
using System;

namespace MCore
{
    class Program
    {
        private static int _stackSize = 128;
        private static int _stackStart = 1024 - 128;
        static void Main(string[] args)
        {
            Console.WriteLine("MCORE::MAIN::START");
            IRuntimeMemory memory = new RuntimeMemory();
            IRuntimeStack stack = new RuntimeStack(memory, _stackSize, _stackStart);
            IRuntimeRegisters registers = new RuntimeRegisters();

            int[] program = new int[]
            {
                0x00,
                0x20, 400,
                0x0A,
                0x20, 20,
                0x0B,
                0x06,
                0x07,
                0x5B,
                0x0C,
                0x08,
                0x1B,
                0x5A,
            };

            var runtime = new MCoreRuntime(memory, stack, registers, program);
            runtime.Start();
            Console.WriteLine("MCORE::MAIN::FINISH");
        }
    }
}
