using RISC_V_SIMULATOR.Instructions;
using RISC_V_Simulator.Enums;

namespace RISC_V_Simulator.Components;

class ControlUnit
{
    public uint Opcode { get; private set; }
    public ALUSrc1 AluSrc1 { get; private set; }
    public ALUSrc2 AluSrc2 { get; private set; }
    public MemToReg MemToReg { get; private set; }
    public bool RegWrite { get; private set; }
    public bool MemRead { get; private set; }
    public bool MemWrite { get; private set; }
    public bool Branch { get; private set; }
    public ALUOp AluOp { get; private set; }
    public MemoryAccessType AddressingControl { get; private set; }

    public void ExtractFromInstruction(BaseInstruction instruction)
    {
        switch (instruction)
        {
            case RTypeInstruction rType:
                Opcode = rType.Opcode;
                AluSrc1 = ALUSrc1.REGISTER;
                AluSrc2 = ALUSrc2.REGISTER;
                MemToReg = MemToReg.ALU_RESULT;
                RegWrite = true;
                MemRead = false;
                MemWrite = false;
                Branch = false;
                AluOp = ALUOp.R_TYPE;
                break;

            case ITypeInstruction iType:
                Opcode = iType.Opcode;
                AluSrc1 = ALUSrc1.REGISTER;
                AluSrc2 = ALUSrc2.IMMEDIATE;
                MemToReg = iType.IsLoad ? MemToReg.MEMORY_DATA : MemToReg.ALU_RESULT;
                RegWrite = true;
                MemRead = iType.IsLoad;
                MemWrite = false;
                Branch = false;
                AluOp = iType.IsLoad ? ALUOp.ADD : ALUOp.I_TYPE;
                AddressingControl = DecodeMemoryAccess(iType.Funct3 ?? 0);
                break;

            case STypeInstruction sType:
                Opcode = sType.Opcode;
                AluSrc1 = ALUSrc1.REGISTER;
                AluSrc2 = ALUSrc2.IMMEDIATE;
                MemToReg = MemToReg.ALU_RESULT; // Not used
                RegWrite = false;
                MemRead = false;
                MemWrite = true;
                Branch = false;
                AluOp = ALUOp.ADD;
                AddressingControl = DecodeMemoryAccess(sType.Funct3 ?? 0);
                break;

            case SBTypeInstruction bType:
                Opcode = bType.Opcode;
                AluSrc1 = ALUSrc1.REGISTER;
                AluSrc2 = ALUSrc2.REGISTER;
                MemToReg = MemToReg.ALU_RESULT; // Not used
                RegWrite = false;
                MemRead = false;
                MemWrite = false;
                Branch = true;
                AluOp = ALUOp.BRANCH;
                break;

            case UTypeInstruction uType:
                Opcode = uType.Opcode;
                AluSrc1 = uType.IsLui ? ALUSrc1.ZERO : ALUSrc1.PC;
                AluSrc2 = ALUSrc2.IMMEDIATE;
                MemToReg = MemToReg.ALU_RESULT;
                RegWrite = true;
                MemRead = false;
                MemWrite = false;
                Branch = false;
                AluOp = ALUOp.ADD;
                break;
        }
    }

    private static MemoryAccessType DecodeMemoryAccess(uint funct3)
    {
        return funct3 switch
        {
            0b000 => MemoryAccessType.BYTE_SIGNED,
            0b001 => MemoryAccessType.HALF_SIGNED,
            0b010 => MemoryAccessType.WORD_SIGNED,
            0b100 => MemoryAccessType.BYTE_UNSIGNED,
            0b101 => MemoryAccessType.HALF_UNSIGNED,
            _ => throw new Exception($"Invalid funct3 for memory access: {funct3}")
        };
    }

}