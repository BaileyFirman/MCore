namespace MCore.Stack
{
    public class Stack : IStack
    {
        public Memory _memory;
        public int Size { get; private set; }
        public int StackPointer { get; private set; }
        public int FramePointer { get; private set; }

        public Stack(Memory memory, int size, int stackPointer)
        {
            _memory = memory;
            Size = size;
            StackPointer = stackPointer - 1;
            FramePointer = StackPointer;
        }

        public int Pop()
        {
            var value = _memory.Read(StackPointer);
            _memory.Write(StackPointer, 0);
            DecrementStackPointer();
            return value;
        }

        public void Push(int value)
        {
            IncrementStackPointer();
            _memory.Write(StackPointer, value);
        }

        private void DecrementStackPointer() => StackPointer = StackPointer - 1;
        private void IncrementStackPointer() => StackPointer = StackPointer + 1;
    }
}