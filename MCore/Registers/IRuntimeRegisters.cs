namespace MCore.Registers
{
    public interface IRuntimeRegisters
    {
        int Size { get; }
        int Read(int address);
        void Write(int address, int value);
        void Dump(int start, int length);
    }
}