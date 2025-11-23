using RISC_V_SIMULATOR.Utils;

namespace RISC_V_SIMULATOR.Instructions;

class STypeInstruction : BaseInstruction
{
    public override uint? Funct3 { get; }
    public override uint? Rs1 { get; }
    public override uint? Rs2 { get; }
    public int Imm { get; }

    public override string Mnemonic => (Opcode, Funct3) switch
    {
        (0x23, 0x0) => "sb",
        (0x23, 0x1) => "sh",
        (0x23, 0x2) => "sw",
        _ => "Unknown S-Type"
    };

    public STypeInstruction(uint binary) : base(binary)
    {
        Funct3 = BitDecoder.ExtractFunct3(binary);
        Rs1 = BitDecoder.ExtractRegister(binary, 15);
        Rs2 = BitDecoder.ExtractRegister(binary, 20);

        int imm4_0 = BitDecoder.ExtractImmediate(binary, 7, 5);
        int imm11_5 = BitDecoder.ExtractImmediate(binary, 25, 7);
        Imm = (imm11_5 << 5) | imm4_0;

        if ((Imm & 0x800) != 0)
            Imm |= unchecked((int)0xFFFFF000);
    }

    public override string ToString()
    {
        return $"{Mnemonic} x{Rs2}, {Imm}(x{Rs1})";
    }
}