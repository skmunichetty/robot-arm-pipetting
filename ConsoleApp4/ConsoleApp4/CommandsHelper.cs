using ConsoleApp4.Enums;

namespace ConsoleApp4
{
    public static class CommandsHelper
    {
        public static int xLocation = 0;
        public static int yLocation = 0;
        private static string report = string.Empty;
        static string[,] wells = new string[5, 5];

        public static void Move(Direction direction)
        {
            var isValid = ValidateDirectionToBeMoved(direction, xLocation, yLocation);
            if (isValid)
            {
                switch (direction)
                {
                    case Direction.NORTH:
                        var nTemp = wells[xLocation, yLocation + 1];
                        wells[xLocation, yLocation + 1] = wells[xLocation, yLocation];
                        wells[xLocation, yLocation] = nTemp;
                        yLocation += 1;
                        SetReport(xLocation, yLocation);
                        break;
                    case Direction.EAST:
                        var eTemp = wells[xLocation + 1, yLocation];
                        wells[xLocation + 1, yLocation] = wells[xLocation, yLocation];
                        wells[xLocation, yLocation] = eTemp;
                        xLocation += 1;
                        SetReport(xLocation, yLocation);
                        break;
                    case Direction.WEST:
                        var wTemp = wells[xLocation - 1, yLocation];
                        wells[xLocation - 1, yLocation] = wells[xLocation, yLocation];
                        wells[xLocation, yLocation] = wTemp;
                        xLocation -= 1;
                        SetReport(xLocation, yLocation);
                        break;
                    case Direction.SOUTH:
                        var sTemp = wells[xLocation, yLocation - 1];
                        wells[xLocation, yLocation - 1] = wells[xLocation, yLocation];
                        wells[xLocation, yLocation] = sTemp;
                        yLocation -= 1;
                        SetReport(xLocation, yLocation);
                        break;
                }
            }
        }

        public static void Place(int x, int y)
        {
            xLocation = x;
            yLocation = y;
            SetReport(x, y);
        }

        public static void ResetWells()
        {
            for (int x = 0; x < wells.GetLength(0); x++)
            {
                for (int y = 0; y < wells.GetLength(1); y++)
                {
                    wells[x, y] = PipetteStatus.EMPTY.ToString();
                }
            }
        }

        public static string Detect()
        {
            // check if it is a valid coordinate
            if (IsValidCoordinate(xLocation, yLocation))
            {
                var result = wells[xLocation, yLocation];
                return result;
            }

            return PipetteStatus.ERR.ToString();
        }

        public static void Drop()
        {
            if (IsValidCoordinate(xLocation, yLocation))
            {
                var wellValue = GetPlaceValue(xLocation, yLocation);
                if (wellValue == "EMPTY")
                {
                    wells[xLocation, yLocation] = PipetteStatus.FULL.ToString();
                    SetReport(xLocation, yLocation);
                }
            }
        }

        public static string Report()
        {
            return report;
        }

        private static void SetReport(int x, int y)
        {
            var result = wells[x, y];
            report = $"Output: {x}, {y}, {result}";
        }

        public static bool IsValidCoordinate(int x, int y)
        {
            if (x < 0 || x > wells.GetLength(0) - 1 || y < 0 || y > wells.GetLength(1) - 1)
                return false;

            return true;
        }

        public static string GetPlaceValue(int x, int y)
        {
            var result = wells[x, y];
            return result;
        }

        public static bool ValidateDirectionToBeMoved(Direction direction, int x, int y)
        {
            // Also check if the x =4 and y =4 and Directtion beyonfd that is invalidated
            if ((y == 0 && direction == Direction.SOUTH) || (y > wells.GetLength(1) - 1 && direction == Direction.NORTH) ||
               (x == 0 && direction == Direction.WEST) || (x > wells.GetLength(0) - 1 && direction == Direction.EAST)
               || (x == wells.GetLength(0) - 1  && direction == Direction.EAST) || (y == wells.GetLength(0) - 1 && direction == Direction.NORTH))
                return false;

            return true;
        }

    }
}
