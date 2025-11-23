namespace RISC_V_SIMULATOR.Components;

public class InstructionMemory
{
    public int Count => instructions.Count;
    private readonly List<uint> instructions = [];
    private uint startingAddress;

    public void LoadFromArray(uint[] program, uint startingAddress)
    {
        instructions.Clear();
        instructions.AddRange(program);
        this.startingAddress = startingAddress;
    }

    public uint GetInstruction(uint pc)
    {
        int index = (int)((pc - startingAddress) / 4);
        if (index < 0 || index >= instructions.Count)
            throw new Exception("Instruction out of bounds");

        return instructions[index];
    }
}