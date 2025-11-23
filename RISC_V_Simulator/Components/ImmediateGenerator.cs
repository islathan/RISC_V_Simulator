using RISC_V_SIMULATOR.Utils;

class ImmediateGenerator
{
    private uint instruction;

    public int Output => BitDecoder.ExtractOpcode(instruction) switch
    {
        0x33 => 0, // R-Type
        0x13 or 0x03 or 0x67 or 0x73 => GetITypeImmediate(), // I-Type
        0x23 => GetSTypeImmediate(), // S-Type
        0x63 => GetSBTypeImmediate(), // SB-Type
        0x6F => GetUJTypeImmediate(), // UJ-Type
        0x37 or 0x17 => GetUTypeImmediate(), // U-Type,
        _ => throw new Exception("Unknown instruction type in immediate gen!"),
    };

    private int GetITypeImmediate()
    {
        int Imm = BitDecoder.ExtractImmediate(instruction, 20, 12);
        if ((Imm & 0x800) != 0) // Sign-extend the 12-bit immediate
            Imm |= unchecked((int)0xFFFFF000); // fill upper 20 bits with 1s
        return Imm;
    }

    private int GetSTypeImmediate()
    {
        int imm4_0 = BitDecoder.ExtractImmediate(instruction, 7, 5);
        int imm11_5 = BitDecoder.ExtractImmediate(instruction, 25, 7);
        int Imm = (imm11_5 << 5) | imm4_0;

        if ((Imm & 0x800) != 0)
            Imm |= unchecked((int)0xFFFFF000);

        return Imm;
    }

    private int GetSBTypeImmediate()
    {
        int imm11 = BitDecoder.ExtractImmediate(instruction, 7, 1);
        int imm4_1 = BitDecoder.ExtractImmediate(instruction, 8, 4);
        int imm10_5 = BitDecoder.ExtractImmediate(instruction, 25, 5);
        int imm12 = BitDecoder.ExtractImmediate(instruction, 31, 1);

        int Imm = (imm12 << 12) | (imm11 << 11) | (imm10_5 << 5) | (imm4_1 << 1);

        if ((Imm & (1 << 12)) != 0)
            Imm |= unchecked((int)0xFFFFE000);

        return Imm;
    }

    private int GetUJTypeImmediate()
    {
        int imm19_12 = BitDecoder.ExtractImmediate(instruction, 12, 8);
        int imm11 = BitDecoder.ExtractImmediate(instruction, 20, 1);
        int imm10_1 = BitDecoder.ExtractImmediate(instruction, 21, 10);
        int imm20 = BitDecoder.ExtractImmediate(instruction, 31, 1);
        int Imm = (imm20 << 20) | (imm19_12 << 12) | (imm11 << 11) | (imm10_1 << 1);

        // Sign-extend 21-bit immediate
        if ((Imm & (1 << 20)) != 0)
            Imm |= unchecked((int)0xFFF00000);

        return Imm;
    }

    private int GetUTypeImmediate()
    {
        int Imm = BitDecoder.ExtractImmediate(instruction, 12, 20);
        if ((Imm & (1 << 20)) != 0)
            Imm |= unchecked((int)0xFFE00000);
        return Imm;
    }

    public void SetInstruction(uint instruction) { this.instruction = instruction; }
}