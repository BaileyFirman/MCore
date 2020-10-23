namespace MCore.Stack
{
    public interface IStack
    {
        int Size { get; }
        int StackPointer { get; }
        int FramePointer { get; }
        void Push(int value);
        int Pop();
    }
}