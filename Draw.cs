using BingingOfRandy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingingOfRandy
{
    public class Draw
    {
        public static int screenMiddleHorz = Console.WindowWidth / 2;
        public static int screenMiddleVert = Console.WindowHeight / 2;
        public static int guiStartX = 25;
        public static int guiStartY = 1;
        public static int guiWidth = 25;
        public static int guiHeight = 25;

        public static void Refresh()
        {
            if (Program.drawRoom)
            {
                DrawRoom();
            }

            if (Program.drawPlayer)
            {
                DrawPlayer();
            }

            if (Program.drawEnemy)
            {
                Program.drawEnemy = false;
            }

            if (Program.drawGui)
            {
                DrawGui();
            }

            DrawBullets();
        }

        public static void StartScreen()
        {
            Console.Clear();

            var bingingOfRandy = "The Binging of Randy";
            Console.SetCursorPosition(screenMiddleHorz - (bingingOfRandy.Length / 2), screenMiddleVert - 1);
            Console.Write(bingingOfRandy);

            var pressAnyKey = "Press any key to start!";
            Console.SetCursorPosition(screenMiddleHorz - (pressAnyKey.Length / 2), screenMiddleVert + 1);
            Console.Write(pressAnyKey);
        }

        public static void DeathScreen()
        {
            Console.Clear();

            var bingingOfRandy = "The Binging of Randy";
            Console.SetCursorPosition(screenMiddleHorz - (bingingOfRandy.Length / 2), screenMiddleVert - 2);
            Console.Write(bingingOfRandy);

            var youDeadMofo = "You dead mofo!";
            Console.SetCursorPosition(screenMiddleHorz - (youDeadMofo.Length / 2), screenMiddleVert);
            Console.Write(youDeadMofo);

            var pressAnyKey = "Press any key to restart!";
            Console.SetCursorPosition(screenMiddleHorz - (pressAnyKey.Length / 2), screenMiddleVert + 2);
            Console.Write(pressAnyKey);
        }

        public static void FinishScreen()
        {
            Console.Clear();

            var bingingOfRandy = "The Binging of Randy";
            Console.SetCursorPosition(screenMiddleHorz - (bingingOfRandy.Length / 2), screenMiddleVert - 2);
            Console.Write(bingingOfRandy);

            var youWinMofo = "You win mofo!";
            Console.SetCursorPosition(screenMiddleHorz - (youWinMofo.Length / 2), screenMiddleVert);
            Console.Write(youWinMofo);

            var pressAnyKey = "Press any key to play again!";
            Console.SetCursorPosition(screenMiddleHorz - (pressAnyKey.Length / 2), screenMiddleVert + 2);
            Console.Write(pressAnyKey);
        }

        public static void DrawRoom()
        {
            Console.Clear();

            var roomLayout = Program.rooms[Program.player.mapX, Program.player.mapY].layout;

            for (int i = 0; i < roomLayout.GetLength(0); i++)
            {
                for (int j = 0; j < roomLayout.GetLength(1); j++)
                {
                    Console.Write(roomLayout[i, j]);
                }
                Console.WriteLine();
            }

            DrawPlayer(false);
            DrawEnemy();
            DrawBullets();
            DrawGui();

            Program.drawRoom = false;
        }

        public static void DrawGui()
        {
            for (int y = guiStartY; y < guiHeight; y++)
            {
                for (int x = guiStartX; x < guiWidth; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(' ');
                }
            }

            Console.SetCursorPosition(guiStartX, guiStartY);
            Console.Write("The Binging of Randy");

            Console.SetCursorPosition(guiStartX, guiStartY + 2);
            Console.Write("Health: " + Program.player.health);
        }

        public static void DrawPlayer(bool removeLastPosition = true)
        {
            if (removeLastPosition)
            {
                Console.SetCursorPosition(Program.player.lastX, Program.player.lastY);
                Console.Write(' ');
            }

            Console.SetCursorPosition(Program.player.x, Program.player.y);
            Console.Write('$');

            Program.player.lastX = Program.player.x;
            Program.player.lastY = Program.player.y;

            Program.drawPlayer = false;
        }

        public static void DrawEnemy()
        {

        }
        public static void DrawBullets()
        {
            foreach(var bullet in BulletHandler.bullets)
            {
                Console.SetCursorPosition(bullet.x, bullet.y);
                Console.Write('o');

                Console.SetCursorPosition(bullet.lastX, bullet.lastY);
                Console.Write(bullet.crossedOver);
            }
        }
    }
}
