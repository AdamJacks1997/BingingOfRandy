using BingingOfRandy.Enums;
using BingingOfRandy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingingOfRandy
{
    public class InputHandler
    {
        public static void Refresh()
        {

            if (Console.KeyAvailable)
            {
                string pressedKey = Convert.ToString(Console.ReadKey(true).KeyChar);

                switch (pressedKey)
                {
                    case "w":
                        Program.player.Move(0, -1);
                        break;
                    case "s":
                        Program.player.Move(0, 1);
                        break;
                    case "a":
                        Program.player.Move(-1, 0);
                        break;
                    case "d":
                        Program.player.Move(1, 0);
                        break;
                    case "i":
                        BulletHandler.Shoot(Directions.Up, Program.player.x, Program.player.y);
                        break;
                    case "j":
                        BulletHandler.Shoot(Directions.Left, Program.player.x, Program.player.y);
                        break;
                    case "k":
                        BulletHandler.Shoot(Directions.Down, Program.player.x, Program.player.y);
                        break;
                    case "l":
                        BulletHandler.Shoot(Directions.Right, Program.player.x, Program.player.y);
                        break;
                }
            }
        }
    }
}
