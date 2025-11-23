using RISC_V_SIMULATOR.Enums;

class ALU
{
    private ALUOperation control;
    private int a;
    private int b;
    private int result;
    public bool Zero => result == 0;

    public ALU() { }
    public ALU(ALUOperation control) { this.control = control; }
    public ALU(ALUOperation control, int a)
    {
        this.control = control;
        this.a = a;
    }

    public int Execute()
    {
        result = control switch
        {
            ALUOperation.AND => a & b,
            ALUOperation.OR => a | b,
            ALUOperation.ADD => a + b,
            ALUOperation.XOR => a ^ b,
            ALUOperation.SUB => a - b,
            ALUOperation.SLT => (a < b) ? 1 : 0,
            ALUOperation.SLTU => ((uint)a < (uint)b) ? 1 : 0,
            ALUOperation.SLL => a << (b & 0x1F),
            ALUOperation.SRL => (int)((uint)a >> (b & 0x1F)),
            ALUOperation.SRA => a >> (b & 0x1F),
            ALUOperation.MUL => a * b,
            ALUOperation.MULH => (int)(((long)a * (long)b) >> 32),
            ALUOperation.MULHU => (int)(((ulong)(uint)a * (ulong)(uint)b) >> 32),
            ALUOperation.MULHSU => (int)(((long)a * (long)(uint)b) >> 32),
            ALUOperation.DIV => (b == 0) ? -1 : (a / b),
            ALUOperation.DIVU => (b == 0) ? -1 : (int)((uint)a / (uint)b),
            ALUOperation.REM => (b == 0) ? a : (a % b),
            ALUOperation.REMU => (b == 0) ? (int)(uint)a : (int)((uint)a % (uint)b),
            _ => throw new InvalidOperationException($"Unknown ALU operation: {control}"),
        };
        return result;
    }

    public void SetControl(ALUOperation control) => this.control = control;
    public void SetA(int value) => a = value;
    public void SetB(int value) => b = value;
}
