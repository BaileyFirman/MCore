namespace MCore.Stack
{
    public interface IRuntimeStack
    {
        int Size { get; }
        int StackPointer { get; }
        int FramePointer { get; }
        void Push(int value);
        int Pop();
    }
}