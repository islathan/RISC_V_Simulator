namespace RISC_V_SIMULATOR.SamplePrograms
{
    public static class SquareFct
    {
        public static readonly uint[] Program =
        [
            0xFE010113, 0x00112E23, 0x00812C23, 0x02010413,
            0xFEA42623, 0xFEC42783, 0x02F787B3, 0x00078513,
            0x01C12083, 0x01812403, 0x02010113, 0x00008067
        ];

        public const uint StartAddress = 0x00000000;
    }
}
