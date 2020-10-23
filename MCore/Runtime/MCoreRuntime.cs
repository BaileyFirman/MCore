using MCore.Memory;
using MCore.Registers;
using MCore.Stack;
using System;

namespace MCore.Runtime
{
    public class MCoreRuntime : IMCoreRuntime
    {
        private IRuntimeMemory _memory;
        private IRuntimeStack _stack;
        private IRuntimeRegisters _registers;
        private int _pc;
        private int[] _program;

        public MCoreRuntime(
            IRuntimeMemory memory,
            IRuntimeStack stack,
            IRuntimeRegisters registers,
            int[] program)
        {
            _memory = memory;
            _stack = stack;
            _registers = registers;
            _program = program;
            _memory.Init(_program);
        }

        public void Start()
        {
            Console.WriteLine("MCORE::RUNTIME::START");
            while (_pc < _program.Length)
            {
                var opcode = _memory.Read(_pc);
                Operate(opcode);
            }
            _memory.Dump(1024 - 128, 8);
            Console.WriteLine("MCORE::RUNTIME::FINISH");
        }

        private void Operate(int opcode)
        {
            Action operation = opcode switch
            {
                _ => () => {}
            };
            operation.Invoke();
        }

        private void IncrementPc()
        {
            _pc = _pc + 1;
        }

        private void SetPc(int value)
        {
            _pc = value;
        }

        private void Add()
        {
            var value2 = _stack.Pop();
            var value1 = _stack.Pop();
            _stack.Push(value2 + value1);
            IncrementPc();
        }

        // private void Add_Ovf(){}
        // private void Add_Ovf_Un(){}

        private void And()
        {
            var value2 = _stack.Pop();
            var value1 = _stack.Pop();
            _stack.Push(value2 & value1);
            IncrementPc();
        }

        // private void Arglist(){}

        private void Beq()
        {
            var target = _memory.Read(_pc + 1);
            var value2 = _stack.Pop();
            var value1 = _stack.Pop();
            if(value1 == value2)
            {
                SetPc(target);
            }
            else
            {
               SetPc(_pc + 2); 
            }
        }

        // private void Beq_S(){}

        private void Bge()
        {
            var target = _memory.Read(_pc + 1);
            var value2 = _stack.Pop();
            var value1 = _stack.Pop();
            if(value1 >= value2)
            {
                SetPc(target);
            }
            else
            {
               SetPc(_pc + 2); 
            }
        }

        // private void Bge_S(){}
        // private void Bge_Un(){}
        // private void Bge_Un_S(){}
    }
}