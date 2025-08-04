
namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var robots = new List<Robot>();
            var table = new Table(5, 5);
            robots.Add(new Robot('R'));
            robots.Add(new Robot('V'));
            robots.Add(new Robot('S'));

            foreach (var robot in robots)
            {
                var row = random.Next(0, 5);
                var column = random.Next(0, 5);
                var direction = (Direction)random.Next(0, 4);
                table.PlaceRobot(robot, row, column, direction);
            }

            while (true)
            {
                foreach(var robot in robots)
                {
                    robot.ActRandomly(random);
                }
                Console.Clear();
                table.Print();
                Thread.Sleep(500);
            }
        }
    }
}