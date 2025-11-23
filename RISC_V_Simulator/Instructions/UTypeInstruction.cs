using RISC_V_SIMULATOR.Utils;

namespace RISC_V_SIMULATOR.Instructions;

class UTypeInstruction : BaseInstruction
{
    public override uint? Rd { get; }
    public int Imm { get; }
    public override string Mnemonic => Opcode switch
    {
        0x17 => "auipc",
        0x37 => "lui",
        _ => "Unknown U-Type"
    };
    public bool IsLui => Opcode == 0x37;

    public UTypeInstruction(uint binary) : base(binary)
    {
        Rd = BitDecoder.ExtractRegister(binary, 7);
        Imm = BitDecoder.ExtractImmediate(binary, 12, 20);
        if ((Imm & (1 << 20)) != 0) Imm |= unchecked((int)0xFFE00000);
    }

    public override string ToString()
    {
        return $"{Mnemonic} {Rd}, {Imm}";
    }
}