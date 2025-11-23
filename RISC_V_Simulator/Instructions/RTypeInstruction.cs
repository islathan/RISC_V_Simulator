using RISC_V_SIMULATOR.Utils;

namespace RISC_V_SIMULATOR.Instructions;

public class RTypeInstruction : BaseInstruction
{
    public override uint? Rd { get; }
    public override uint? Funct3 { get; }
    public override uint? Rs1 { get; }
    public override uint? Rs2 { get; }
    public override uint? Funct7 { get; }
    public override string Mnemonic => (Funct3, Funct7) switch
    {
        (0x0, 0x00) => "add",
        (0x0, 0x20) => "sub",
        (0x1, 0x00) => "sll",
        (0x2, 0x00) => "slt",
        (0x3, 0x00) => "sltu",
        (0x4, 0x00) => "xor",
        (0x5, 0x00) => "srl",
        (0x5, 0x20) => "sra",
        (0x6, 0x00) => "or",
        (0x7, 0x00) => "and",
        _ => "Unknown R-Type"
    };

    public RTypeInstruction(uint binary) : base(binary)
    {
        Rd = BitDecoder.ExtractRegister(binary, 7);
        Funct3 = BitDecoder.ExtractFunct3(binary);
        Rs1 = BitDecoder.ExtractRegister(binary, 15);
        Rs2 = BitDecoder.ExtractRegister(binary, 20);
        Funct7 = BitDecoder.ExtractFunct7(binary);
    }

    public override string ToString()
    {
        return $"{Mnemonic} x{Rd}, x{Rs1}, x{Rs2}";
    }
}