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
                        Program.player.y -= 1;
                        break;
                    case "s":
                        Program.player.y += 1;
                        break;
                    case "a":
                        Program.player.x -= 1;
                        break;
                    case "d":
                        Program.player.x += 1;
                        break;
                }
            }
        }
    }
}
