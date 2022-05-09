using BingingOfRandy.Enums;

namespace BingingOfRandy
{
    public static class Program
    {
        public static States state = States.Start;
        public static Player player = new();

        public static bool drawMap = true;
        public static bool drawPlayer = true;
        public static bool drawEnemy = true;
        public static bool drawBullet = true;

        public static void Main(string[] args)
        {
            Console.WriteLine("Started BOI");
            Console.WriteLine(drawMap);

            GameLoop();
        }

        public static void GameLoop()
        {
            state = States.Play; // REMOVE WHEN START GUI IS MADE

            while (true)
            {
                switch (state)
                {
                    case States.Start:
                        break;
                    case States.Play:
                        InputHandler.Refresh();
                        Draw.Refresh();
                        Thread.Sleep(100);
                        break;
                    case States.Dead:
                        break;
                    case States.Finish:
                        break;
                }
            }
        }
    }
}












