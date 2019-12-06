namespace AdventOfCode2019.Puzzles.IntcodeComputer
{
    public enum Instruction
    {
        ADD = 1,
        MULTIPLY = 2,
        INPUT = 3,
        OUTPUT = 4,
        JUMP_IF_TRUE = 5,
        JUMP_IF_FALSE = 6,
        LESS_THAN = 7,
        EQUALS = 8,
        EXIT = 99
    }
}