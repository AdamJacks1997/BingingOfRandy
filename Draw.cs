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

            if (Program.drawBullet)
            {
                DrawBullets();
            }
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

            Program.drawRoom = false;
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
