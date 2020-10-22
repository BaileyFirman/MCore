namespace MCore
{
    public class Stack
    {
        public Memory _memory;
        private int _stackPointer;
        private int _framePointer;
        private int _size;
        public int StackPointer => _stackPointer;
        public int FramePointer => _framePointer;

        public Stack(Memory memory, int size, int stackPointer)
        {
            _memory = memory;
            _stackPointer = stackPointer - 1;
            _framePointer = _stackPointer;
            _size = size;
        }

        public int Pop()
        {
            var value = _memory.Read(_stackPointer);
            _memory.Write(_stackPointer, 0);
            _stackPointer = _stackPointer - 1;
            return value;
        }

        public void Push(int value)
        {
            _stackPointer = _stackPointer + 1;
            _memory.Write(_stackPointer, value);
        }
    }
}