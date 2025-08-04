using System;

namespace ToyRobot
{
    public class Robot : IRobot
    {
        private ITable? Table { get; set; }
        public int Row { get; set; } = 0;
        public int Column { get; set; } = 0;

        private Dictionary<Direction, (int Row, int Column)> DirectionOffsets = new()
        {
            { Direction.North, (0, 1) },
            { Direction.East, (1, 0) },
            { Direction.South, (0, -1) },
            { Direction.West, (-1, 0) }
        };

        private Dictionary<Direction, char> DirectionAvatars = new()
        {
            { Direction.North, '^' },
            { Direction.East, '>' },
            { Direction.South, 'v' },
            { Direction.West, '<' }
        };

        public char Avatar { get; }
        public Direction Direction { get; set; } = Direction.North;

        public Robot(char avatar)
        {
            Avatar = avatar;
        }

        public void Left() => SetDirection((int)Direction - 1);
        public void Right() => SetDirection((int)Direction + 1);

        private void SetDirection(int newDirection)
        {

            if (Table == null) return;
            var count = Enum.GetValues(typeof(Direction)).Length;
            Direction = (Direction)((newDirection + count) % count);
        }

        public void Move()
        {
            if (Table == null) return;

            var offset = DirectionOffsets[Direction];
            var newRow = Row + offset.Row;
            var newColumn = Column + offset.Column;

            if (Table.IsPositionValid(newRow, newColumn))
            {
                Table.RemoveRobot(Row, Column);
                Table.PlaceRobot(this, newRow, newColumn, Direction);
            }
        }

        public void ActRandomly(Random random)
        {
            int action = random.Next(0, 3);

            switch(action)
            {
                case 0:
                    Left();
                    break;
                case 1:
                    Right();
                    break;
                case 2:
                    Move();
                    break;
            }
        }
        public void Place(ITable table, int row, int column, Direction direction)
        {
            Table = table ?? throw new ArgumentNullException(nameof(table));
            Row = row;
            Column = column;
        }

        public void Remove()
        {
            Table = null;
            Row = 0;
            Column = 0;
        }

        public string Print() => $"{DirectionAvatars[Direction]}{Avatar}";
    }
}
