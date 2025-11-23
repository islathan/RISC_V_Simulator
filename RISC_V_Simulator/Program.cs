// See https://aka.ms/new-console-template for more information 
using RISC_V_SIMULATOR.Components;
using RISC_V_SIMULATOR.SamplePrograms;
class Program
{
    static void Main()
    {
        Console.WriteLine("RISC-V Simulator");

        var memory = new InstructionMemory();
        memory.LoadFromArray(SquareFct.Program, SquareFct.StartAddress);

        Console.WriteLine("Instructions loaded: " + memory.Count);

        uint pc = SquareFct.StartAddress;

        Console.WriteLine("\nDisassembly:");

        for (int i = 0; i < memory.Count; i++)
        {
            uint instruction = memory.GetInstruction(pc);
            Console.WriteLine($"0x{pc:X8}: {Disassembler.Decode(instruction)}");
            pc += 4;
        }
    }
}

