namespace ToyRobot
{
    public interface ITable
    {
        void PlaceRobot(IRobot robot, int row, int column, Direction direction);
        void RemoveRobot(int row, int column);
        bool IsPositionValid(int row, int column);
        void Clear();
        void Print();
    }
}
