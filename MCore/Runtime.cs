using System;

namespace MCore
{
    public class Runtime
    {
        private Memory _memory;
        private Stack _stack;
        private Registers _registers;
        private int _pc;

        public Runtime(Memory memory, Stack stack, Registers registers)
        {
            _memory = memory;
            _stack = stack;
            _registers = registers;
            _memory.Init(program);
        }

        public void Start()
        {
            Console.WriteLine("MCORE::RUNTIME::START");
            while (_pc < program.Length)
            {
                var opcode = _memory.Read(_pc);
                var offset = Operate(opcode);
                _pc += offset;
            }
            _memory.Dump(1024 - 128, 16);
            Console.WriteLine("MCORE::RUNTIME::FINISH");
        }

        private int Operate(int opcode)
        {
            return opcode switch
            {
                0x00 => Nop(),
                0x0A => Stloc_0(),
                0x0B => Stloc_1(),
                0x0C => Stloc_2(),
                0x0D => Stloc_3(),
                0x0E => Ldarg_S(),
                0x0F => LdargA_S(),
                0x1A => Ldc_I4_4(),
                0x1B => Ldc_I4_5(),
                0x1C => Ldc_I4_6(),
                0x1D => Ldc_I4_7(),
                0x1E => Ldc_I4_8(),
                0x1F => Ldc_I4_S(),
                _ => Nop()
            };
        }

        private int Nop() => 1;

        private int Stloc(int offset)
        {
            var value = _stack.Pop();
            var storeLocation = _stack.FramePointer + offset;
            _memory.Write(storeLocation, value);
            return 1;
        }
        private int Stloc_0() => Stloc(0);
        private int Stloc_1() => Stloc(1);
        private int Stloc_2() => Stloc(2);
        private int Stloc_3() => Stloc(3);

        private int Ldc_I4_S()
        {
            var next = _pc + 1;
            var value = _memory.Read(next);
            _stack.Push(value);
            return 2;
        }
        private int Ldc_I4(int value)
        {
            _stack.Push(value);
            return 1;
        }
        private int Ldc_I4_0() => Ldc_I4(0);
        private int Ldc_I4_1() => Ldc_I4(1);
        private int Ldc_I4_2() => Ldc_I4(2);
        private int Ldc_I4_3() => Ldc_I4(3);
        private int Ldc_I4_4() => Ldc_I4(4);
        private int Ldc_I4_5() => Ldc_I4(5);
        private int Ldc_I4_6() => Ldc_I4(6);
        private int Ldc_I4_7() => Ldc_I4(7);
        private int Ldc_I4_8() => Ldc_I4(8);
        
        private int Ldarg_S()
        {
            var next = _pc + 1;
            var argumentAddress = _registers.Read(next);
            var argument = _memory.Read(argumentAddress);
            _stack.Push(argument);
            return 2;
        }

        private int LdargA_S()
        {
            var next = _pc + 1;
            var argumentAddress = _registers.Read(next);
            _stack.Push(argumentAddress);
            return 2;
        }

        private int[] program = new int[]
        {
            0x0A,
            0x0B,
            0x0C,
            0x0D,
            0x0B,
        };
    }
}