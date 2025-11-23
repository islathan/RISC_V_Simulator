using RISC_V_SIMULATOR.Utils;

namespace RISC_V_SIMULATOR.Instructions;

public abstract class BaseInstruction
{
    public uint Binary { get; }
    public uint Opcode { get; }
    public virtual uint? Rs1 => null;
    public virtual uint? Rs2 => null;
    public virtual uint? Rd => null;
    public virtual uint? Funct3 => null;
    public virtual uint? Funct7 => null;
    public abstract string Mnemonic { get; }

    protected BaseInstruction(uint binary)
    {
        Binary = binary;
        Opcode = BitDecoder.ExtractOpcode(binary);
    }

    public abstract override string ToString();
}