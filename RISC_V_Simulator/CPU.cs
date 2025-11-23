using RISC_V_Simulator.Components;
using RISC_V_SIMULATOR.Components;
using RISC_V_SIMULATOR.Enums;
using RISC_V_SIMULATOR.Instructions;

class CPU
{
    private readonly ProgramCounter pc;
    private readonly InstructionMemory instructionMemory;
    private readonly RegisterFile registerFile;
    private readonly ControlUnit controlUnit;
    private readonly ALUControl aluControl;
    private readonly ImmediateGenerator immediateGenerator;
    private readonly ALU alu;
    private readonly ALU adder;
    private readonly MUX aluMUX;

    public CPU()
    {
        pc = new ProgramCounter();
        instructionMemory = new InstructionMemory();
        registerFile = new RegisterFile();
        controlUnit = new ControlUnit();
        aluControl = new ALUControl();
        immediateGenerator = new ImmediateGenerator();
        alu = new ALU();
        adder = new ALU(ALUOperation.ADD);
        aluMUX = new MUX(3);
    }

    public void Run()
    {
        uint instruction = InstructionFetch();
        InstructionDecode(instruction);
        Execute();
        MemoryAccess();
        WriteBack();
    }

    private uint InstructionFetch()
    {
        uint instruction = instructionMemory.GetInstruction(pc.CurrentAddress);
        adder.SetB((int)pc.CurrentAddress);
        adder.SetA(4);
        pc.SetNextAddress((uint)adder.Execute());
        return instruction;
    }

    private void InstructionDecode(uint instruction)
    {
        BaseInstruction decodedInstruction = Disassembler.Decode(instruction);
        controlUnit.ExtractFromInstruction(decodedInstruction);

        aluControl.SetAluOp(controlUnit.AluOp);
        aluControl.SetFunct3(decodedInstruction.Funct3 ?? 0);
        aluControl.SetFunct7(decodedInstruction.Funct7 ?? 0);

        registerFile.ReadRegister1 = decodedInstruction.Rs1 ?? 0;
        registerFile.ReadRegister2 = decodedInstruction.Rs2 ?? 0;
        registerFile.WriteRegister = decodedInstruction.Rd ?? 0;

        immediateGenerator.SetInstruction(instruction);
    }

    private void Execute()
    {

    }

    private void MemoryAccess()
    {

    }

    private void WriteBack()
    {

    }
}