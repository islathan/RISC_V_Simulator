using RISC_V_SIMULATOR.Utils;

namespace RISC_V_SIMULATOR.Instructions;

static class InstructionFactory
{
    public static BaseInstruction Create(uint instruction)
    {
        uint opCode = BitDecoder.ExtractOpcode(instruction);
        return opCode switch
        {
            0x33 => new RTypeInstruction(instruction),
            0x13 or 0x03 or 0x67 or 0x73 => new ITypeInstruction(instruction),
            0x23 => new STypeInstruction(instruction),
            0x63 => new SBTypeInstruction(instruction),
            0x6F => new UJTypeInstruction(instruction),
            0x37 or 0x17 => new UTypeInstruction(instruction),
            _ => new UnknownInstruction(instruction),
        };
    }
}