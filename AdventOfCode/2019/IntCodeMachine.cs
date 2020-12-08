using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2019
{    
    public enum OperationType
    {
        Add = 1,
        Multiply = 2,
        Input = 3,
        Output = 4,
        JumpIfTrue = 5,
        JumpIfFalse = 6,
        LessThan = 7,
        Equals = 8,
        //RelativeBaseOffset = 9,
        Halt = 99
    }

    public enum ParameterMode
    {
        Position = 0,
        Immediate = 1//,
        //Relative = 2
    }

    public enum State
    {
        NotStarted,
        WaitingForInput,
        Halted
    }

    class IntCodeMachine
    {
        private readonly IntcodeProgram _program;
        public Queue<int> Inputs { get; }
        public Queue<int> Outputs { get; } = new Queue<int>();

        public IntCodeMachine(IntcodeProgram program, params int[] parameters)
        {
            _program = program;
            Inputs = new Queue<int>(parameters.Select(x => x));
        }

        public int Run()
        {
            var programPosition = 0;
            while (true)
            {
                var statementRaw = _program.Memory[programPosition..Math.Min(programPosition + 4, _program.Memory.Length)];
                var statement = Statement.Parse(statementRaw);
                programPosition += statement.Length;

                switch (statement.Operation.Type)
                {
                    case OperationType.Add:
                        _program.Memory[statement.Parameter3.Value] = ReadParameter(statement.Parameter1) + ReadParameter(statement.Parameter2);
                        break;

                    case OperationType.Multiply:
                        _program.Memory[statement.Parameter3.Value] = ReadParameter(statement.Parameter1) * ReadParameter(statement.Parameter2);
                        break;

                    case OperationType.Input:
                        if (Inputs.TryDequeue(out var input))
                            _program.Memory[statement.Parameter1.Value] = input;
                        break;

                    case OperationType.Output:
                        Outputs.Enqueue(ReadParameter(statement.Parameter1));
                        break;

                    case OperationType.JumpIfTrue:
                        if (ReadParameter(statement.Parameter1) != 0)
                            programPosition = ReadParameter(statement.Parameter2);
                        break;

                    case OperationType.JumpIfFalse:
                        if (ReadParameter(statement.Parameter1) == 0)
                            programPosition = ReadParameter(statement.Parameter2);
                        break;

                    case OperationType.LessThan:
                        if (ReadParameter(statement.Parameter1) < ReadParameter(statement.Parameter2))
                            _program.Memory[statement.Parameter3.Value] = 1;
                        else
                            _program.Memory[statement.Parameter3.Value] = 0;
                        break;

                    case OperationType.Equals:
                        if(ReadParameter(statement.Parameter1) == ReadParameter(statement.Parameter2))
                            _program.Memory[statement.Parameter3.Value] = 1;
                        else
                            _program.Memory[statement.Parameter3.Value] = 0;
                        break;

                    case OperationType.Halt:
                        return _program.Memory[0];
                }
            }
        }

        public int ReadParameter(Parameter p) => p.Mode switch
        {
            ParameterMode.Immediate => p.Value,
            ParameterMode.Position => _program.Memory[p.Value]
        };
    }

    public class IntcodeProgram
    {
        public int[] Memory { get; }

        public IntcodeProgram(List<int> input)
        {
            Memory = input.ToArray();
        }

        public override string ToString() => string.Join(",", Memory);
    }
    public class Statement
    {
        public Operation Operation { get; private set; }
        public Parameter Parameter1 { get; private set; }
        public Parameter Parameter2 { get; private set; }
        public Parameter Parameter3 { get; private set; }

        public int Length => Operation.GetParameterCount() + 1;

        public static Statement Parse(int[] input)
        {
            var operationType = (OperationType)(ReadDigit(0, input[0]) + ReadDigit(1, input[0]) * 10);
            var operation = new Operation(operationType);

            var param1Mode = (ParameterMode)ReadDigit(2, input[0]);
            var param2Mode = (ParameterMode)ReadDigit(3, input[0]);
            var param3Mode = (ParameterMode)ReadDigit(4, input[0]);

            return new Statement
            {
                Operation = operation,
                Parameter1 = operation.GetParameterCount() >= 1 ? new Parameter(param1Mode, input[1]) : null,
                Parameter2 = operation.GetParameterCount() >= 2 ? new Parameter(param2Mode, input[2]) : null,
                Parameter3 = operation.GetParameterCount() >= 3 ? new Parameter(param3Mode, input[3]) : null,
            };
        }

        private static int ReadDigit(int pos, int num)
        {
            return num / (int)Math.Pow(10, pos) % 10;
        }

        public override string ToString() => $"{Operation}, P1: {Parameter1}, P2: {Parameter2}, P3: {Parameter3}";
    }

    public class Parameter
    {
        public Parameter(ParameterMode mode, int value)
        {
            Mode = mode;
            Value = value;
        }

        public ParameterMode Mode { get; }
        public int Value { get; }

        public override string ToString() => $"[{Mode}] {Value}";
    }
    public class Operation
    {
        public OperationType Type { get; }
        public Operation(OperationType operationType)
        {
            Type = operationType;
        }

        public int GetParameterCount() => Type switch
        {
            OperationType.Add => 3,
            OperationType.Multiply => 3,
            OperationType.Input => 1,
            OperationType.Output => 1,
            OperationType.JumpIfTrue => 2,
            OperationType.JumpIfFalse => 2,
            OperationType.LessThan => 3,
            OperationType.Equals => 3,
            OperationType.Halt => 0
        };

        public override string ToString() => $"{Type}";
    }

}

