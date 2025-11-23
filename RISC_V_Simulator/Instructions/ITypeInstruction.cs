using RISC_V_SIMULATOR.Utils;

namespace RISC_V_SIMULATOR.Instructions;

public class ITypeInstruction : BaseInstruction
{
    public override uint? Rd { get; }
    public override uint? Funct3 { get; }
    public override uint? Rs1 { get; }
    public int Imm { get; }
    public override string Mnemonic => (Opcode, Funct3, Imm) switch
    {
        (0x3, 0x0, _) => "lb",
        (0x3, 0x1, _) => "lh",
        (0x3, 0x2, _) => "lw",
        (0x3, 0x4, _) => "lbu",
        (0x3, 0x5, _) => "lhu",
        (0x0F, 0x0, _) => "fence",
        (0x0F, 0x1, _) => "fence.i",
        (0x13, 0x0, _) => "addi",
        (0x13, 0x1, 0x00) => "slli",
        (0x13, 0x2, _) => "slti",
        (0x13, 0x3, _) => "sltiu",
        (0x13, 0x4, _) => "xori",
        (0x13, 0x5, 0x00) => "srli",
        (0x13, 0x5, 0x20) => "srai",
        (0x13, 0x6, _) => "ori",
        (0x13, 0x7, _) => "andi",
        (0x67, 0x0, _) => "jalr",
        (0x73, 0x0, 0x000) => "ecall",
        (0x73, 0x0, 0x001) => "ebreak",
        (0x73, 0x1, _) => "csrrw",
        (0x73, 0x2, _) => "csrrs",
        (0x73, 0x3, _) => "csrrc",
        (0x73, 0x5, _) => "csrrwi",
        (0x73, 0x6, _) => "csrrsi",
        (0x73, 0x7, _) => "csrrci",
        _ => "Unknown I-Type",
    };
    public bool IsLoad => Opcode == 0x03;

    public ITypeInstruction(uint binary) : base(binary)
    {
        Rd = BitDecoder.ExtractRegister(binary, 7);
        Funct3 = BitDecoder.ExtractFunct3(binary);
        Rs1 = BitDecoder.ExtractRegister(binary, 15);
        Imm = BitDecoder.ExtractImmediate(binary, 20, 12);

        if ((Imm & 0x800) != 0) // Sign-extend the 12-bit immediate
            Imm |= unchecked((int)0xFFFFF000); // fill upper 20 bits with 1s
    }

    public override string ToString()
    {
        return $"{Mnemonic} x{Rd}, x{Rs1}, {Imm}";
    }
}