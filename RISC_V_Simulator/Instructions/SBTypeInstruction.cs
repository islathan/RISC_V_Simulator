using RISC_V_SIMULATOR.Utils;

namespace RISC_V_SIMULATOR.Instructions;

class SBTypeInstruction : BaseInstruction
{
    public override uint? Funct3 { get; }
    public override uint? Rs1 { get; }
    public override uint? Rs2 { get; }
    public int Imm { get; }
    public override string Mnemonic => (Opcode, Funct3) switch
    {
        (0x63, 0x0) => "beq",
        (0x63, 0x1) => "bne",
        (0x63, 0x4) => "blt",
        (0x63, 0x5) => "bge",
        (0x63, 0x6) => "bltu",
        (0x63, 0x7) => "bgeu",
        _ => "Unknown SB-Type",
    };

    public SBTypeInstruction(uint binary) : base(binary)
    {
        Funct3 = BitDecoder.ExtractFunct3(binary);
        Rs1 = BitDecoder.ExtractRegister(binary, 15);
        Rs2 = BitDecoder.ExtractRegister(binary, 20);
        int imm11 = BitDecoder.ExtractImmediate(binary, 7, 1);
        int imm4_1 = BitDecoder.ExtractImmediate(binary, 8, 4);
        int imm10_5 = BitDecoder.ExtractImmediate(binary, 25, 5);
        int imm12 = BitDecoder.ExtractImmediate(binary, 31, 1);

        Imm = (imm12 << 12) | (imm11 << 11) | (imm10_5 << 5) | (imm4_1 << 1);

        if ((Imm & (1 << 12)) != 0) Imm |= unchecked((int)0xFFFFE000);
    }

    public override string ToString()
    {
        return $"{Mnemonic} {Rs1}, {Rs2}, {Imm}";
    }
}