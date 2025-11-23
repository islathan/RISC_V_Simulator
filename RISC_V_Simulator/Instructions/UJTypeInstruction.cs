using RISC_V_SIMULATOR.Utils;

namespace RISC_V_SIMULATOR.Instructions;

class UJTypeInstruction : BaseInstruction
{
    public override uint? Rd { get; }
    public int Imm { get; }
    public override string Mnemonic => Opcode switch
    {
        0x6F => "jal",
        _ => "Unknown UJ-Type",
    };

    public UJTypeInstruction(uint binary) : base(binary)
    {
        Rd = BitDecoder.ExtractRegister(binary, 7);

        int imm19_12 = BitDecoder.ExtractImmediate(binary, 12, 8);
        int imm11 = BitDecoder.ExtractImmediate(binary, 20, 1);
        int imm10_1 = BitDecoder.ExtractImmediate(binary, 21, 10);
        int imm20 = BitDecoder.ExtractImmediate(binary, 31, 1);
        Imm = (imm20 << 20) | (imm19_12 << 12) | (imm11 << 11) | (imm10_1 << 1);

        // Sign-extend 21-bit immediate
        if ((Imm & (1 << 20)) != 0) Imm |= unchecked((int)0xFFF00000);
    }

    public override string ToString()
    {
        return $"{Mnemonic} {Rd}, {Imm}";
    }
}
