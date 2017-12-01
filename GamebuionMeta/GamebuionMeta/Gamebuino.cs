using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace GamebuionMeta
{
    /// <summary>
    /// Gamebuino API Start
    /// </summary>
    ///
    public class Buttons
    {
        public const int NUM_BTN = 7;


        //buttons pins
        public const int BTN_UP_PIN = 1;
        public const int BTN_UP = 1;

        public const int BTN_RIGHT_PIN = 2;
        public const int BTN_RIGHT = 2;

        public const int BTN_DOWN_PIN = 3;
        public const int BTN_DOWN = 3;

        public const int BTN_LEFT_PIN = 0;
        public const int BTN_LEFT = 0;

        public const int BTN_A_PIN = 4;
        public const int BTN_A = 4;

        public const int BTN_B_PIN = 5;
        public const int BTN_B = 5;

        public const int BTN_C_PIN = 6;
        public const int BTN_C = 6;
        

        public int[] pins = new int[NUM_BTN];
        public int[] states = new int[NUM_BTN];
        public bool[] tempButtons = new bool[NUM_BTN];

        public bool pressed(int button)
        {
            if (states[button] == 1)
                return true;
            else
                return false;
        }

        public void begin()
        {
            pins[BTN_LEFT] = BTN_LEFT_PIN;
            pins[BTN_UP] = BTN_UP_PIN;
            pins[BTN_RIGHT] = BTN_RIGHT_PIN;
            pins[BTN_DOWN] = BTN_DOWN_PIN;
            pins[BTN_A] = BTN_A_PIN;
            pins[BTN_B] = BTN_B_PIN;
            pins[BTN_C] = BTN_C_PIN;
        }

        public void update()
        {
            for (int thisButton = 0; thisButton < NUM_BTN; thisButton++)
            {
                if (tempButtons[thisButton] == true)
                { //if button pressed
                    states[thisButton]++; //increase button hold time
                }
                else
                {
                    if (states[thisButton] == 0)//button idle
                        continue;
                    if (states[thisButton] == 0xFF)//if previously released
                        states[thisButton] = 0; //set to idle
                    else
                        states[thisButton] = 0xFF; //button just released
                }
            }
        }

        public bool released(int button)
        {
            if (states[button] == 0xFF)
                return true;
            else
                return false;
        }

        public bool held(int button, int time)
        {
            if (states[button] >= (time + 1))
                return true;
            else
                return false;
        }

        public bool repeat(int button, int period)
        {
            if (period <= 1)
            {
                if ((states[button] != 0xFF) && (states[button]==1))
                    return true;
            }
            else
            {
                if ((states[button] != 0xFF) && ((states[button] % period) == 1))
                    return true;
            }
            return false;
        }

        public int timeHeld(int button)
        {
            if (states[button] != 0xFF)
                return states[button];
            else
                return 0;
        }
    };

    public class Sound
    {
        public void playTick()
        {
            //SystemSounds.Asterisk.Play();
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\ding.wav");
            simpleSound.Play();
        }
    };

    public class Display
    {
        
        private Bitmap Screen = new Bitmap(Gamebuino.LCDWIDTH, Gamebuino.LCDHEIGHT);
        public int fontSize;
        public int cursorX, cursorY;

        private void swap(int a, int b)
        {
            int t = a; a = b; b = t;
        }

        public void begin()
        {
            cursorX=cursorY=0;
            fontSize = 5;
        }

        public void drawPixel(int x, int y, Color color)
        {
            try
            {
                Screen.SetPixel(x, y, color);
            }
            catch (Exception ex)
            {

            }
        }

        public void drawPixel(int x, int y)
        {
            try
            {
                Screen.SetPixel(x, y, Color.Red);
            }
            catch (Exception ex)
            {

            }
        }

        public Color getPixel(int x, int y)
        {
            return Screen.GetPixel(x, y);
        }

        public Bitmap getBuffer()
        {
            return Screen;
        }

        public void clear()
        {
            Graphics g = Graphics.FromImage(Screen);
            g.Clear(Color.Black);
            cursorY = cursorX = 0;
        }

        public void fillScreen(Color color)
        {
            Graphics g = Graphics.FromImage(Screen);
            g.Clear(color);
        }

        public void drawLine(int x0, int y0, int x1, int y1, int width, Color color)
        {
            Graphics g = Graphics.FromImage(Screen);
            Pen myPen = new Pen(color);
            myPen.Width = width;
            g.DrawLine(myPen, new Point(x0, y0), new Point(x1, y1));
        }

        public void drawLine(int x0, int y0, int x1, int y1, int width)
        {
            Graphics g = Graphics.FromImage(Screen);
            Pen myPen = new Pen(Color.Red);
            myPen.Width = width;
            g.DrawLine(myPen, new System.Drawing.Point(x0, y0), new Point(x1, y1));
        }

        public void drawLine(int x0, int y0, int x1, int y1)
        {
            Graphics g = Graphics.FromImage(Screen);
            Pen myPen = new Pen(Color.Red);
            myPen.Width = 1;
            g.DrawLine(myPen, new Point(x0, y0), new Point(x1, y1));
        }

        public void drawFastVLine(int x, int y, int h, Color color)
        {
            for (int i = 0; i < h; i++)
            {
                drawPixel(x, y + i, color);
            }
        }

        public void drawFastVLine(int x, int y, int h)
        {
            for (int i = 0; i < h; i++)
            {
                drawPixel(x, y + i);
            }
        }

        public void drawFastHLine(int x, int y, int w, Color color)
        {
            for (int i = 0; i < w; i++)
            {
                drawPixel(x + i, y, color);
            }
        }

        public void drawFastHLine(int x, int y, int w)
        {
            for (int i = 0; i < w; i++)
            {
                drawPixel(x + i, y);
            }
        }

        public void drawRect(int x, int y, int w, int h, Color color)
        {
            drawFastHLine(x, y, w, color);
            drawFastHLine(x, y + h - 1, w, color);
            drawFastVLine(x, y, h, color);
            drawFastVLine(x + w - 1, y, h, color);
        }

        public void fillRect(int x, int y, int w, int h, Color color)
        {
            for (int i = y; i < y + h; i++)
            {
                drawFastHLine(x, i, w, color);
            }
        }

        public void fillRect(int x, int y, int w, int h)
        {
            for (int i = y; i < y + h; i++)
            {
                drawFastHLine(x, i, w);
            }
        }

        public void drawCircle(int x0, int y0, int r)
        {
            int f = 1 - r;
            int ddF_x = 1;
            int ddF_y = -2 * r;
            int x = 0;
            int y = r;

            drawPixel(x0, y0 + r);
            drawPixel(x0, y0 - r);
            drawPixel(x0 + r, y0);
            drawPixel(x0 - r, y0);

            while (x < y)
            {
                if (f >= 0)
                {

                    y--;
                    ddF_y += 2;
                    f += ddF_y;
                }
                x++;
                ddF_x += 2;
                f += ddF_x;

                drawPixel(x0 + x, y0 + y);
                drawPixel(x0 - x, y0 + y);
                drawPixel(x0 + x, y0 - y);
                drawPixel(x0 - x, y0 - y);
                drawPixel(x0 + y, y0 + x);
                drawPixel(x0 - y, y0 + x);
                drawPixel(x0 + y, y0 - x);
                drawPixel(x0 - y, y0 - x);

            }
        }

        public void drawCircleHelper(int x0, int y0, int r, int cornername)
        {
            int f = 1 - r;
            int ddF_x = 1;
            int ddF_y = -2 * r;
            int x = 0;
            int y = r;

            while (x < y)
            {
                if (f >= 0)
                {
                    y--;
                    ddF_y += 2;
                    f += ddF_y;
                }
                x++;
                ddF_x += 2;
                f += ddF_x;
                if ((cornername & 0x4) == 1)
                {
                    drawPixel(x0 + x, y0 + y);
                    drawPixel(x0 + y, y0 + x);
                }
                if ((cornername & 0x2) == 1)
                {
                    drawPixel(x0 + x, y0 - y);
                    drawPixel(x0 + y, y0 - x);
                }
                if ((cornername & 0x8) == 1)
                {
                    drawPixel(x0 - y, y0 + x);
                    drawPixel(x0 - x, y0 + y);
                }
                if ((cornername & 0x1) == 1)
                {

                    drawPixel(x0 - y, y0 - x);
                    drawPixel(x0 - x, y0 - y);
                }
            }
        }

        public void fillCircle(int x0, int y0, int r)
        {
            drawFastVLine(x0, y0 - r, 2 * r + 1);
            fillCircleHelper(x0, y0, r, 3, 0);
        }

        public void fillCircleHelper(int x0, int y0, int r, int cornername, int delta)
        {
            int f = 1 - r;
            int ddF_x = 1;
            int ddF_y = -2 * r;
            int x = 0;
            int y = r;

            while (x < y)
            {
                if (f >= 0)
                {
                    y--;
                    ddF_y += 2;
                    f += ddF_y;
                }
                x++;
                ddF_x += 2;
                f += ddF_x;

                if ((cornername & 0x1) == 1)
                {
                    drawFastVLine(x0 + x, y0 - y, 2 * y + 1 + delta);
                    drawFastVLine(x0 + y, y0 - x, 2 * x + 1 + delta);
                }
                if ((cornername & 0x2) == 1)
                {

                    drawFastVLine(x0 - x, y0 - y, 2 * y + 1 + delta);
                    drawFastVLine(x0 - y, y0 - x, 2 * x + 1 + delta);
                }
            }
        }

        public void drawRoundRect(int x, int y, int w, int h, int r)
        {
            // smarter version
            drawFastHLine(x + r, y, w - 2 * r); // Top
            drawFastHLine(x + r, y + h - 1, w - 2 * r); // Bottom
            drawFastVLine(x, y + r, h - 2 * r); // Left
            drawFastVLine(x + w - 1, y + r, h - 2 * r); // Right
                                                        // draw four corners
            drawCircleHelper(x + r, y + r, r, 1);
            drawCircleHelper(x + w - r - 1, y + r, r, 2);
            drawCircleHelper(x + w - r - 1, y + h - r - 1, r, 4);
            drawCircleHelper(x + r, y + h - r - 1, r, 8);
        }

        public void fillRoundRect(int x, int y, int w, int h, int r)
        {
            fillRect(x + r, y, w - 2 * r, h);
            // draw four corners
            fillCircleHelper(x + w - r - 1, y + r, r, 1, h - 2 * r - 1);
            fillCircleHelper(x + r, y + r, r, 2, h - 2 * r - 1);
        }

        public void drawTriangle(int x0, int y0, int x1, int y1, int x2, int y2)
        {
            drawLine(x0, y0, x1, y1);
            drawLine(x1, y1, x2, y2);
            drawLine(x2, y2, x0, y0);
        }

        public void fillTriangle(int x0, int y0, int x1, int y1, int x2, int y2)
        {
            int a, b, y, last;

            // Sort coordinates by Y order (y2 >= y1 >= y0)
            if (y0 > y1)
            {
                swap(y0, y1);
                swap(x0, x1);
            }
            if (y1 > y2)
            {
                swap(y2, y1);
                swap(x2, x1);
            }
            if (y0 > y1)
            {
                swap(y0, y1);
                swap(x0, x1);
            }

            if (y0 == y2)
            { // Handle awkward all-on-same-line case as its own thing
                a = b = x0;
                if (x1 < a) a = x1;
                else if (x1 > b) b = x1;
                if (x2 < a) a = x2;
                else if (x2 > b) b = x2;
                drawFastHLine(a, y0, b - a + 1);
                return;
            }

            int dx01 = x1 - x0,
                    dy01 = y1 - y0,
                    dx02 = x2 - x0,
                    dy02 = y2 - y0,
                    dx12 = x2 - x1,
                    dy12 = y2 - y1,
                    sa = 0,
                    sb = 0;

            // For upper part of triangle, find scanline crossings for segments
            // 0-1 and 0-2.  If y1=y2 (flat-bottomed triangle), the scanline y1
            // is included here (and second loop will be skipped, avoiding a /0
            // error there), otherwise scanline y1 is skipped here and handled
            // in the second loop...which also avoids a /0 error here if y0=y1
            // (flat-topped triangle).
            if (y1 == y2) last = y1; // Include y1 scanline
            else last = y1 - 1; // Skip it

            for (y = y0; y <= last; y++)
            {
                a = x0 + sa / dy01;
                b = x0 + sb / dy02;
                sa += dx01;
                sb += dx02;
                /* longhand:
                a = x0 + (x1 - x0) * (y - y0) / (y1 - y0);
                b = x0 + (x2 - x0) * (y - y0) / (y2 - y0);
                 */
                if (a > b) swap(a, b);
                drawFastHLine(a, y, b - a + 1);
            }

            // For lower part of triangle, find scanline crossings for segments
            // 0-2 and 1-2.  This loop is skipped if y1=y2.
            sa = dx12 * (y - y1);
            sb = dx02 * (y - y0);
            for (; y <= y2; y++)
            {
                a = x1 + sa / dy12;
                b = x0 + sb / dy02;
                sa += dx12;
                sb += dx02;

                /* longhand:
                        a = x1 + (x2 - x1) * (y - y1) / (y2 - y1);
                        b = x0 + (x2 - x0) * (y - y0) / (y2 - y0);
                 */
                if (a > b) swap(a, b);
                drawFastHLine(a, y, b - a + 1);
            }
        }

        public void println(String text)
        {
            Graphics g = Graphics.FromImage(Screen);
            g.DrawString(text, new Font("Tahoma", fontSize), Brushes.Red,new PointF(cursorX,cursorY));
            cursorY += fontSize;
        }

        public void println(String text, Brush color)
        {
            Graphics g = Graphics.FromImage(Screen);
            g.DrawString(text, new Font("Tahoma", fontSize), color, new PointF(cursorX, cursorY));
            cursorY += fontSize;
        }

        public void println()
        {
            cursorY += fontSize;
        }

        public void print(int x, int y,String text, Brush color)
        {
            cursorY = y;
            cursorX = x;
            Graphics g = Graphics.FromImage(Screen);
            g.DrawString(text, new Font("Tahoma", fontSize), color, new PointF(cursorX, cursorY));
            cursorY += fontSize;
        }

        public void print(int x, int y, String text)
        {
            cursorY = y;
            cursorX = x;
            Graphics g = Graphics.FromImage(Screen);
            g.DrawString(text, new Font("Tahoma", fontSize), Brushes.Red, new PointF(cursorX, cursorY));
            cursorY += fontSize;
        }

        public void print(String text)
        {
            Graphics g = Graphics.FromImage(Screen);
            g.DrawString(text, new Font("Tahoma", fontSize), Brushes.Red, new PointF(cursorX, cursorY));
            cursorY += fontSize;
        }

    };



    public class Gamebuino
    {
        public Random random;
        public int gbFPS = 60; // Gamebuino Meta FPS
        public const int LCDWIDTH = 160;
        public const int LCDHEIGHT = 128;

        public Buttons buttons = new Buttons();
        public Display display = new Display();
        public Sound sound = new Sound();
        public void begin() {
            buttons.begin();
            display.begin();
            //sound.begin();
        }
        public bool update() {
            buttons.update();
            //display.update();
            //sound.update();
            return true;
        }

        public void pickRandomSeed()
        {
            random = new Random();

        }

        public bool collideRectRect(int x1, int y1, int w1, int h1, int x2, int y2, int w2, int h2)
        {
            return !(x2 >= x1 + w1 ||
                      x2 + w2 <= x1 ||
                      y2 >= y1 + h1 ||
                      y2 + h2 <= y1);
        }

        
        public void titleScreen(string text)
        {
            display.clear();
            int tempFontSize = display.fontSize;
            display.fontSize = 15;
            display.println(text);
            display.fontSize = tempFontSize;
            display.cursorX = display.cursorY = 0;
            display.clear();
        }
        public void setFrameRate(int rate) {
            gbFPS = rate;
        }

    };
    /// <summary>
    /// Gamebuino API END
    /// </summary>
    ///
}
