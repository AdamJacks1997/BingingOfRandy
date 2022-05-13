using BingingOfRandy.Enums;

namespace BingingOfRandy
{
    public static class Program
    {
        public static States state = States.Start;
        public static Player player = new();
        public Room[,] rooms = new Room[100, 100];

        public static bool drawMap = true;
        public static bool drawPlayer = true;
        public static bool drawEnemy = true;
        public static bool drawBullet = true;

        public static void Main(string[] args)
        {
            Console.CursorVisible = false;
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

        public static int RandomBetween(int min, int max)
        {
            Random r = new Random();
            int newRand = r.Next(min, max);
            return newRand;
        }

        public static bool RandomBool()
        {
            return RandomBetween(0, 1) == 0 ? true : false;
        }
    }
}












