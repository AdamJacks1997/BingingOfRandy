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

                Program.drawMap = false;
            }

            if (Program.drawPlayer)
            {
                Console.SetCursorPosition(Program.player.x, Program.player.y);
                Console.Write('$');

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
