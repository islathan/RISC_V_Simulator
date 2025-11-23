namespace RISC_V_SIMULATOR.Instructions;

class UnknownInstruction(uint binary) : BaseInstruction(binary)
{
    public override string Mnemonic => throw new NotImplementedException();
    public override string ToString()
    {
        return $"Unknown instruction: 0x{Binary:X8}";
    }
}