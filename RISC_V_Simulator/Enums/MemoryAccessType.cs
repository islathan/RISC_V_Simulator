namespace RISC_V_Simulator.Enums;

enum MemoryAccessType
{
    BYTE_UNSIGNED = 0b000,
    BYTE_SIGNED = 0b100,
    HALF_UNSIGNED = 0b001,
    HALF_SIGNED = 0b101,
    WORD_UNSIGNED = 0b010,
    WORD_SIGNED = 0b110
}