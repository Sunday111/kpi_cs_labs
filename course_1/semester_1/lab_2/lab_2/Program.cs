using System;
using System.Collections.Generic;

namespace lab_2
{
    public delegate void ConsoleCommandDelegate();

    class ConsoleCommand
    {
        public ConsoleCommand(string name, ConsoleCommandDelegate command)
        {
            Name = name;
            Command = command;
        }

        public string Name { get; private set; }

        public ConsoleCommandDelegate Command { get; private set; }
    }

    class Program
    {
        static uint ReadValue(string message)
        {
            while(true)
            {
                uint userInput;
                Console.WriteLine(message);
                if (uint.TryParse(Console.ReadLine(), out userInput))
                {
                    return userInput;
                }

                Console.WriteLine("Invalid input");
            }
        }

        static void SetWindowHeightCommand()
        {
            Console.Clear();
            uint windowHeight = ReadValue("Enter window height: ");
            Console.WindowHeight = (int)windowHeight;
        }

        static void SetWindowWidthCommand()
        {
            Console.Clear();
            uint windowWidth = ReadValue("Enter window width: ");
            Console.WindowWidth = (int)windowWidth;
        }

        static void Main(string[] args)
        {
            // Make commands
            var commands = new List<ConsoleCommand>();
            commands.Add(new ConsoleCommand("Set window width", SetWindowWidthCommand));
            commands.Add(new ConsoleCommand("Set window height", SetWindowHeightCommand));

            while (true)
            {
                // Print menu
                Console.WriteLine("Commands list:");
                for (int i = 0; i < commands.Count; ++i)
                {
                    Console.WriteLine("{0}: {1}", i + 1, commands[i].Name);
                }

                // Get command index
                Console.Write("Enter command number or 0 to quit: ");

                uint userInput;
                bool inputIsValid = uint.TryParse(Console.ReadLine(), out userInput);

                if (inputIsValid && userInput <= commands.Count)
                {
                    if(userInput == 0)
                    {
                        break;
                    }

                    var command = commands[(int)userInput - 1];
                    try
                    {
                        command.Command();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again");
                }
            }
        }
    }
}
