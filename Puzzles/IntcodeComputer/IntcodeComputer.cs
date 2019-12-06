using System;
using System.Linq;

namespace AdventOfCode2019.Puzzles.IntcodeComputer
{
    public class IntcodeComputer
    {
        public int RunProgram(int[] programOpcodes, int input)
        {
            bool exit = false;
            int currentOpcodeIndex = 0;
            int output = -1;

            while (!exit)
            {
                Instruction instruction = DetermineInstruction(programOpcodes[currentOpcodeIndex]);
                ParameterMode firstParameterMode = GetFirstParameterMode(programOpcodes[currentOpcodeIndex]);
                ParameterMode secondParameterMode = GetSecondParameterMode(programOpcodes[currentOpcodeIndex]);
                ParameterMode thirdParameterMode = GetThirdParameterMode(programOpcodes[currentOpcodeIndex]);

                int dataToWrite;
                switch (instruction)
                {
                    case Instruction.ADD:
                        dataToWrite = ExecuteAdd(ReadData(programOpcodes, firstParameterMode, currentOpcodeIndex + 1), ReadData(programOpcodes, secondParameterMode, currentOpcodeIndex + 2));
                        WriteData(programOpcodes, thirdParameterMode, currentOpcodeIndex + 3, dataToWrite);
                        currentOpcodeIndex += 4;
                        break;
                    case Instruction.MULTIPLY:
                        dataToWrite = ExecuteMultiply(ReadData(programOpcodes, firstParameterMode, currentOpcodeIndex + 1), ReadData(programOpcodes, secondParameterMode, currentOpcodeIndex + 2));
                        WriteData(programOpcodes, thirdParameterMode, currentOpcodeIndex + 3, dataToWrite);
                        currentOpcodeIndex += 4;
                        break;
                    case Instruction.INPUT:
                        WriteData(programOpcodes, firstParameterMode, currentOpcodeIndex + 1, input);
                        currentOpcodeIndex += 2;
                        break;
                    case Instruction.OUTPUT:
                        output = ReadData(programOpcodes, firstParameterMode, currentOpcodeIndex + 1);
                        currentOpcodeIndex += 2;
                        break;
                    case Instruction.JUMP_IF_TRUE:
                        if (ReadData(programOpcodes, firstParameterMode, currentOpcodeIndex + 1) != 0)
                        {
                             currentOpcodeIndex = ReadData(programOpcodes, secondParameterMode, currentOpcodeIndex + 2);
                        }
                        else
                        {
                            currentOpcodeIndex += 3;
                        }
                        break;
                    case Instruction.JUMP_IF_FALSE:
                        if (ReadData(programOpcodes, firstParameterMode, currentOpcodeIndex + 1) == 0)
                        {
                             currentOpcodeIndex = ReadData(programOpcodes, secondParameterMode, currentOpcodeIndex + 2);
                        }
                        else
                        {
                            currentOpcodeIndex += 3;
                        }
                        break;
                    case Instruction.LESS_THAN:
                        dataToWrite = (ReadData(programOpcodes, firstParameterMode, currentOpcodeIndex + 1) < ReadData(programOpcodes, secondParameterMode, currentOpcodeIndex + 2)) 
                                        ? 1 : 0;
                        WriteData(programOpcodes, ParameterMode.POSITION, currentOpcodeIndex + 3, dataToWrite);
                        currentOpcodeIndex += 4;
                        break;
                    case Instruction.EQUALS:
                        dataToWrite = (ReadData(programOpcodes, firstParameterMode, currentOpcodeIndex + 1) == ReadData(programOpcodes, secondParameterMode, currentOpcodeIndex + 2)) 
                                        ? 1 : 0;
                        WriteData(programOpcodes, ParameterMode.POSITION, currentOpcodeIndex + 3, dataToWrite);
                        currentOpcodeIndex += 4;
                        break;
                    case Instruction.EXIT:
                        exit = true;
                        break;
                }
            }

            return output;
        }

        private Instruction DetermineInstruction(int opcode)
        {
            return (Instruction)(opcode % 100);
        }

        private ParameterMode GetFirstParameterMode(int opcode)
        {
            return (ParameterMode)((opcode / 100) % 10);
        }

        private ParameterMode GetSecondParameterMode(int opcode)
        {
            return (ParameterMode)((opcode / 1000) % 10);
        }

        private ParameterMode GetThirdParameterMode(int opcode)
        {
            return (ParameterMode)((opcode / 10000) % 10);
        }

        private int ReadData(int[] programOpcodes, ParameterMode mode, int opcodeIndex)
        {
            if (mode == ParameterMode.POSITION)
            {
                return programOpcodes[programOpcodes[opcodeIndex]];
            }
            else if (mode == ParameterMode.IMMEDIATE)
            {
                return programOpcodes[opcodeIndex];
            }
            else
            {
                throw new NotSupportedException("Parameter mode is not supported");
            }
        }

        private void WriteData(int[] programOpcodes, ParameterMode mode, int opcodeIndex, int dataToWrite)
        {
            if (mode == ParameterMode.POSITION)
            {
                programOpcodes[programOpcodes[opcodeIndex]] = dataToWrite;
            }
            else if (mode == ParameterMode.IMMEDIATE)
            {
                programOpcodes[opcodeIndex] = dataToWrite;
            }
            else
            {
                throw new NotSupportedException("Parameter mode is not supported");
            }
        }
    
        private int ExecuteAdd(int value1, int value2)
        {
            return value1 + value2;
        }

        private int ExecuteMultiply(int value1, int value2)
        {
            return value1 * value2;
        }
    }
}