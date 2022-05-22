using BingingOfRandy.Enums;
using BingingOfRandy.Models;

namespace BingingOfRandy
{
    public static class Program
    {
        public static States state = States.Start;
        public static Room[,] rooms = new Room[100, 100];
        public static Map map = new Map();
        public static Player player;
        

        public static bool drawRoom = true;
        public static bool drawPlayer = true;
        public static bool drawEnemy = true;
        public static bool drawGui = true;

        public static void Main(string[] args)
        {
            Console.CursorVisible = false;

            map.Generate();

            player = new Player();

            GameLoop();
        }

        public static void GameLoop()
        {
            while (true)
            {
                switch (state)
                {
                    case States.Start:
                        Draw.StartScreen();
                        Console.ReadKey(true);
                        restart();
                        break;
                    case States.Play:
                        InputHandler.Refresh();
                        EnemyHandler.MoveNShoot();
                        BulletHandler.MoveBullets();
                        Draw.Refresh();
                        BulletHandler.ClearBullets();
                        Thread.Sleep(100);
                        if (player.health <= 0)
                            state = States.Dead;
                        break;
                    case States.Dead:
                        Draw.DeathScreen();
                        Console.ReadKey(true);
                        restart();
                        break;
                    case States.Finish:
                        Draw.FinishScreen();
                        Console.ReadKey(true);
                        restart();
                        break;
                }
            }
        }

        public static void restart()
        {
            rooms = new Room[100, 100];
            map = new Map();
            map.Generate();
            player = new Player();
            Thread.Sleep(1000);
            state = States.Play;
            drawRoom = true;
        }

        public static int RandomBetween(int min, int max, bool isOdd = false)
        {
            Random r = new Random();
            int newRand = r.Next(min, max);
            if (isOdd && newRand % 2 == 0)
                newRand = newRand == max ? newRand -= 1 : newRand += 1;

            return newRand;
        }

        public static bool RandomBool()
        {
            return RandomBetween(0, 2) == 0 ? true : false;
        }
    }
}











