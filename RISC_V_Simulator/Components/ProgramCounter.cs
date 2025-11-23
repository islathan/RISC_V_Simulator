namespace RISC_V_SIMULATOR.Components;

class ProgramCounter
{
    public uint CurrentAddress { get; private set; }
    public uint NextAddress { get; private set; }

    public ProgramCounter(uint startAddress = 0x00000000)
    {
        CheckAlignment(startAddress);
        CurrentAddress = startAddress;
        NextAddress = startAddress;
    }

    public void SetNextAddress(uint address)
    {
        CheckAlignment(address);
        NextAddress = address;
    }

    public void Increment(uint value = 4)
    {
        CheckAlignment(value);
        NextAddress = CurrentAddress + value;
    }

    // Commit the next PC at end of CPU cycle
    public void Step()
    {
        CurrentAddress = NextAddress;
    }

    private static void CheckAlignment(uint value)
    {
        if (value % 4 != 0)
            throw new Exception("Unaligned PC or PC increment!");
    }
}
