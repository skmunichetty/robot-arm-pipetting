using ConsoleApp4;
using ConsoleApp4.Enums;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Theory]
        [MemberData(nameof(GetMoveCommandInputAndOutput))]
        public void test_if_move_command_works_as_expected(int xLocation, int yLocation, Direction direction, string output)
        {
            CommandsHelper.ResetWells();
            CommandsHelper.Place(xLocation, yLocation);
            CommandsHelper.Move(direction);
            var report = CommandsHelper.Report();
            Assert.Equal(output, report);
        }

        public static IEnumerable<object[]> GetMoveCommandInputAndOutput()
        {
            return new List<object[]>
            {
                new object[]
                {
                    0,
                    0,
                    Direction.NORTH,
                    "Output: 0, 1, EMPTY"
                },
                new object[]
                {
                    4,
                    4,
                    Direction.WEST,
                    "Output: 3, 4, EMPTY"
                },
                // Test to make sure the ARM, does not place its position outside of the plate.
                new object[]
                {
                    4,
                    0,
                    Direction.EAST,
                    "Output: 4, 0, EMPTY"
                },
                new object[]
                {
                    2,
                    3,
                    Direction.SOUTH,
                    "Output: 2, 2, EMPTY"
                },
                new object[]
                {
                    3,
                    2,
                    Direction.WEST,
                    "Output: 2, 2, EMPTY"
                }
            };
        }

    }
}
