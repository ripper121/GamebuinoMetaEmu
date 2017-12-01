using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GamebuionMeta.Form1;

namespace GamebuionMeta
{
    public class ArduinoCode
    {
        /// <summary>
        /// Your Arduino Code Here
        /// </summary>
        ///
        public Gamebuino gb = new Gamebuino();

        public void setup()
        {
            gb.begin();
            gb.titleScreen(F("timeHeld example"));
        }

        public void loop()
        {
            if (gb.update())
            {
                gb.display.println("Hello world");
                if (gb.buttons.pressed(BTN_C))
                {
                    gb.titleScreen(F("Example game"));
                }
            }
        }
        /// <summary>
        /// End of Arduino Code
        /// </summary>
        /// 


















        //Arduino Fuctions
        int max(int x, int y)
        {
            return Math.Max(x, y);
        }

        int min(int x, int y)
        {
            return Math.Min(x, y);
        }

        int random(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }

        int abs(int x)
        {
            return Math.Abs(x);
        }

        string F(string text)
        {
            return text;
        }
    }
}
