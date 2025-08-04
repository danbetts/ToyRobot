using System.Data.Common;

namespace ToyRobot
{
    internal class Table : ITable
    {
        private IRobot?[,] Grid { get; set; }
        private int Rows { get; set; }
        private int Columns { get; set; }
        public Table(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0) throw new ArgumentException("Rows and columns must be greater than zero.");
            Rows = rows;
            Columns = columns;
            Grid = new IRobot[rows, columns];
        }
        public void Clear()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    var robot = Grid[row, column];

                    if (robot != null)
                    {
                        robot.Remove();
                        RemoveRobot(row, column);
                    }
                }
            }
        }
        public bool IsPositionValid(int row, int column)
        {
            // Check if position is within bounds and empty
            return row >= 0 && row < Rows &&
                column >= 0 && column < Columns
                && Grid[row, column] == null;
        }
        public void PlaceRobot(IRobot robot, int row, int column, Direction direction)
        {     
            if (IsPositionValid(row, column))
            {
                Grid[row, column] = robot;
                robot.Place(this, row, column, direction);
            }
        }
        public void RemoveRobot(int row, int column) => Grid[row, column] = null;
        public void Print()
        {
            for (int row = 0; row < Rows; row++)
            {
                Console.Write('|');
                for (int col = 0; col < Columns; col++)
                {
                    var robot = Grid[row, col];
                    if (robot != null)
                    {
                        Console.Write(robot.Print());
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    Console.Write('|');
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
