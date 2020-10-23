namespace MCore.Memory
{
    public interface IRuntimeMemory
    {
        int Size { get; }
        int Read(int address);
        void Write(int address, int value);
        void Dump(int start, int length);
        void Init(int[] instructions);
    }
}