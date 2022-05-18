﻿using System;
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
                }
            }
        }
    }
}
