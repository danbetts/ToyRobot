namespace ToyRobot
{
    public interface IRobot
    {
        char Avatar { get; }
        Direction Direction { get; set; }
        int Row { get; set; }
        int Column { get; set; }

        void Left();
        void Right();
        void Move();
        void Place(ITable table, int row, int column, Direction direction);
        void Remove();
        string Print();
    }
}