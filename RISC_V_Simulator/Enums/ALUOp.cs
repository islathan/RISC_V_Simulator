namespace RISC_V_Simulator.Enums;

enum ALUOp
{
    ADD = 0b00, // load, store, AUIPC, LUI
    BRANCH = 0b01,
    R_TYPE = 0b10,
    I_TYPE = 0b11
}