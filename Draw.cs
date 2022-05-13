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
            if (Program.drawMap)
            {
                Console.Clear();

                Program.drawPlayer = true;
                Program.drawEnemy = true;
                Program.drawBullet = true;

                Program.drawMap = false;
            }

            if (Program.drawPlayer)
            {
                Console.SetCursorPosition(Program.player.lastX, Program.player.lastY);
                Console.Write(' ');
                Console.SetCursorPosition(Program.player.x, Program.player.y);
                Console.Write('$');

                Program.player.lastX = Program.player.x;
                Program.player.lastY = Program.player.y;

                Program.drawPlayer = false;
            }

            if (Program.drawEnemy)
            {

                Program.drawEnemy = false;
            }

            if (Program.drawBullet)
            {

                Program.drawBullet = false;
            }
        }
    }
}
