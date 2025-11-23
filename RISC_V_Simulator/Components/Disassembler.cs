using RISC_V_SIMULATOR.Instructions;

namespace RISC_V_SIMULATOR.Components;

class Disassembler
{
    public static BaseInstruction Decode(uint instruction)
    {
        return InstructionFactory.Create(instruction);
    }
}