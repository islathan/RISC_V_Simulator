namespace RISC_V_SIMULATOR.Utils;

class BitDecoder
{
    public static int ExtractBits(uint instruction, int start, int end)
    {
        // Mask and shift to get the bits from 'start' to 'end'
        int mask = ((1 << (end - start + 1)) - 1) << start;
        return (int)((instruction & (uint)mask) >> start);
    }

    // Method to extract a register (5 bits) from an instruction
    public static uint ExtractRegister(uint instruction, int startBit)
    {
        return (uint)ExtractBits(instruction, startBit, startBit + 4);
    }

    // Method to extract the immediate values
    public static int ExtractImmediate(uint instruction, int startBit, int bitLength)
    {
        return ExtractBits(instruction, startBit, startBit + bitLength - 1);
    }

    public static uint ExtractOpcode(uint instruction)
    {
        return (uint)ExtractBits(instruction, 0, 6);  // Bits 0-6
    }

    public static uint ExtractFunct3(uint instruction)
    {
        return (uint)ExtractBits(instruction, 12, 14);  // Bits 12-14
    }

    public static uint ExtractFunct7(uint instruction)
    {
        return (uint)ExtractBits(instruction, 25, 31);  // Bits 25-31
    }

    public static int ExtractITypeImmediate(uint instruction)
    {
        return ExtractBits(instruction, 20, 31);  // Bits 20-31
    }
}