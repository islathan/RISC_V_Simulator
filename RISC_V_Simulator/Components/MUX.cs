namespace RISC_V_SIMULATOR.Components;

class MUX
{
    private readonly int[] inputs;
    private uint select;
    public int Output => inputs[select];

    public MUX(uint inputs)
    {
        this.inputs = new int[inputs];
    }

    public void SetSelect(uint select)
    {
        this.select = select;
    }

    public void SetInput(uint index, int value)
    {
        inputs[index] = value;
    }
}