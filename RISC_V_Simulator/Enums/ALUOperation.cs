namespace RISC_V_SIMULATOR.Enums;

enum ALUOperation
{
    AND = 0b0000,    // Bitwise AND (A & B)
    OR = 0b0001,     // Bitwise OR (A | B)
    ADD = 0b0010,    // Addition (A + B)
    XOR = 0b0011,    // Bitwise XOR (A ^ B)
    SUB = 0b0110,    // Subtraction (A - B)
    SLT = 0b0111,    // Set if less than (signed)
    SRL = 0b1000,    // Logical right shift
    SRA = 0b1001,    // Arithmetic right shift
    SLTU = 0b1010,   // Set if less than (unsigned)
    SLL = 0b1011,    // Logical left shift
    MUL = 0b1100,    // Multiplication (lower 32 bits)
    MULH = 0b1101,   // Multiplication high (signed × signed)
    MULHU = 0b1110,  // Multiplication high (unsigned × unsigned)
    MULHSU = 0b1111, // Multiplication high (signed × unsigned)
    DIV = 0b10000,   // Division (signed)
    DIVU = 0b10001,  // Division (unsigned)
    REM = 0b10010,   // Remainder (signed)
    REMU = 0b10011   // Remainder (unsigned)
};
