using MCore.Memory;
using MCore.Registers;
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

            var runtime = new Runtime(memory, stack, registers);
            runtime.Start();
            Console.WriteLine("MCORE::MAIN::FINISH");
        }
    }
}
