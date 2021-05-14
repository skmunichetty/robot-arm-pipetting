using System;
using ConsoleApp4.Enums;

namespace ConsoleApp4
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProcessCommands();
        }

        private static void ProcessCommands()
        {
            CommandsHelper.ResetWells();
            while (true)
            {
                var command = GetIntValue("command", false);
                switch (command)
                {
                    case 1:
                        var (x, y) = GetValidXAndYCoordinates();
                        CommandsHelper.Place(x, y);
                        break;
                    case 2:
                        var direction = GetDirection();
                        CommandsHelper.Move(direction);
                        break;
                    case 3:
                        Console.WriteLine(CommandsHelper.Detect());
                        break;
                    case 4:
                        CommandsHelper.Drop();
                        break;
                    case 5:
                        var report = CommandsHelper.Report();
                        Console.WriteLine(report + "\n");
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("The option you have entered is invalid. Please try again \n");
                        break;
                }
            }
        }

        public static int GetIntValue(string propertyName, bool isCoordinate)
        {
            int result;

            while (true)
            {
                Console.WriteLine(isCoordinate
                    ? $"Please enter {propertyName}: "
                    : "Select a command \n 1. PLACE \n 2. MOVE \n 3. DETECT \n 4. DROP \n 5. REPORT \n 6. EXIT \n");

                var isValid = int.TryParse(Console.ReadLine(), out var value);
                if (isValid)
                {
                    result = value;
                    break;
                }
                Console.WriteLine("Please enter a valid integer value");
            }

            return result;
        }

        public static (int, int) GetValidXAndYCoordinates()
        {
            int xLocation;
            int yLocation;
            while (true)
            {
                var x = GetIntValue("x", true);
                var y = GetIntValue("y", true);

                var isValid = CommandsHelper.IsValidCoordinate(x, y);
                if (isValid)
                {
                    xLocation = x;
                    yLocation = y;
                    break;
                }
                Console.WriteLine("Entered x or y coordinate is out of range. Please try again \n");
            }


            return (xLocation, yLocation);
        }

        public static Direction GetDirection()
        {
            Direction result;

            while (true)
            {
                Console.WriteLine("Select the direction to be moved \n 1. North \n 2. West \n 3. South \n 4. East \n");
                var isValid = int.TryParse(Console.ReadLine(), out var direction);
                if (isValid && (direction >= 0 && direction < 5))
                {
                    result = (Direction)direction;
                    break;
                }

                Console.WriteLine("Please enter a valid direction option \n");
            }

            return result;
        }
    }
}