using RISC_V_Simulator.Enums;
using RISC_V_SIMULATOR.Enums;

namespace RISC_V_SIMULATOR.Components;

class ALUControl
{
    private ALUOp aluOp;
    private uint funct3;
    private uint funct7;
    public ALUOperation Operation => (aluOp, funct3, funct7) switch
    {
        (ALUOp.ADD, _, _) => ALUOperation.ADD,
        (ALUOp.BRANCH, 0b000, _) => ALUOperation.SUB,
        (ALUOp.BRANCH, 0b001, _) => ALUOperation.SUB,
        (ALUOp.BRANCH, 0b100, _) => ALUOperation.SLT,
        (ALUOp.BRANCH, 0b101, _) => ALUOperation.SLT,
        (ALUOp.BRANCH, 0b110, _) => ALUOperation.SLTU,
        (ALUOp.BRANCH, 0b111, _) => ALUOperation.SLTU,

        (ALUOp.R_TYPE, 0b000, 0b0000000) => ALUOperation.ADD,
        (ALUOp.R_TYPE, 0b001, 0b0000000) => ALUOperation.SLL,
        (ALUOp.R_TYPE, 0b010, 0b0000000) => ALUOperation.SLT,
        (ALUOp.R_TYPE, 0b011, 0b0000000) => ALUOperation.SLTU,
        (ALUOp.R_TYPE, 0b100, 0b0000000) => ALUOperation.XOR,
        (ALUOp.R_TYPE, 0b101, 0b0000000) => ALUOperation.SRL,
        (ALUOp.R_TYPE, 0b110, 0b0000000) => ALUOperation.OR,
        (ALUOp.R_TYPE, 0b111, 0b0000000) => ALUOperation.AND,
        (ALUOp.R_TYPE, 0b000, 0b0100000) => ALUOperation.SUB,
        (ALUOp.R_TYPE, 0b101, 0b0100000) => ALUOperation.SRA,
        (ALUOp.R_TYPE, 0b000, 0b0000001) => ALUOperation.MUL,
        (ALUOp.R_TYPE, 0b001, 0b0000001) => ALUOperation.MULH,
        (ALUOp.R_TYPE, 0b010, 0b0000001) => ALUOperation.MULHSU,
        (ALUOp.R_TYPE, 0b011, 0b0000001) => ALUOperation.MULHU,
        (ALUOp.R_TYPE, 0b100, 0b0000001) => ALUOperation.DIV,
        (ALUOp.R_TYPE, 0b101, 0b0000001) => ALUOperation.DIVU,
        (ALUOp.R_TYPE, 0b110, 0b0000001) => ALUOperation.REM,
        (ALUOp.R_TYPE, 0b111, 0b0000001) => ALUOperation.REMU,

        (ALUOp.I_TYPE, 0b000, _) => ALUOperation.ADD,
        (ALUOp.I_TYPE, 0b001, _) => ALUOperation.SLL,
        (ALUOp.I_TYPE, 0b010, _) => ALUOperation.SLT,
        (ALUOp.I_TYPE, 0b011, _) => ALUOperation.SLTU,
        (ALUOp.I_TYPE, 0b100, _) => ALUOperation.XOR,
        (ALUOp.I_TYPE, 0b101, 0b0000000) => ALUOperation.SRL,
        (ALUOp.I_TYPE, 0b101, 0b0100000) => ALUOperation.SRA,
        (ALUOp.I_TYPE, 0b110, _) => ALUOperation.OR,
        (ALUOp.I_TYPE, 0b111, _) => ALUOperation.AND,

        _ => throw new Exception("Unknown operation in ALU control!")
    };

    public void SetAluOp(ALUOp aluOp) { this.aluOp = aluOp; }
    public void SetFunct3(uint funct3) { this.funct3 = funct3; }
    public void SetFunct7(uint funct7) { this.funct7 = funct7; }
}