namespace RISC_V_SIMULATOR.Components;

public class RegisterFile
{
    private readonly int[] registers = new int[32];
    public uint ReadRegister1 { get; set; }
    public uint ReadRegister2 { get; set; }
    public uint WriteRegister { get; set; }
    public int WriteData { get; set; }
    public bool RegWrite { get; set; }

    public int ReadData1 => ReadRegister1 == 0 ? 0 : registers[ReadRegister1];
    public int ReadData2 => ReadRegister2 == 0 ? 0 : registers[ReadRegister2];

    public void Write()
    {
        if (WriteRegister == 0)
            return;

        if (RegWrite && WriteRegister != 0)
            registers[WriteRegister] = WriteRegister == 0 ? 0 : WriteData;
    }
}

