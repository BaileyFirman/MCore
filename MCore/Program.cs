using System;

namespace MCore
{
    class Program
    {
        private static int _stackSize = 128;
        private static int _stackStart = 1024 - 128;
        static void Main(string[] args)
        {
            var memory = new Memory();
            var stack = new Stack(memory, _stackSize, _stackStart);
            var registers = new Registers();
            var runtime = new Runtime(memory, stack, registers);

            runtime.Start();
        }
    }
}
