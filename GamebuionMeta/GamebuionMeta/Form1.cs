using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamebuionMeta
{
    public partial class Form1 : Form
    {
        const byte BTN_NONE = 0, BTN_A = 1, BTN_B = 2, BTN_C = 3, BTN_UP = 4, BTN_RIGHT = 5, BTN_DOWN = 6, BTN_LEFT = 7;
        byte button = 0;
        bool releaseButton = false;


        private void buttonD_MouseDown(object sender, MouseEventArgs e)
        {
            button = BTN_DOWN;
        }

        private void buttonD_MouseUp(object sender, MouseEventArgs e)
        {
            button = BTN_NONE;
        }

        private void buttonL_MouseDown(object sender, MouseEventArgs e)
        {
            button = BTN_LEFT;
        }

        private void buttonL_MouseUp(object sender, MouseEventArgs e)
        {
            button = BTN_NONE;
        }

        private void buttonR_MouseDown(object sender, MouseEventArgs e)
        {
            button = BTN_RIGHT;
        }

        private void buttonR_MouseUp(object sender, MouseEventArgs e)
        {
            button = BTN_NONE;
        }

        private void buttonU_MouseDown(object sender, MouseEventArgs e)
        {
            button = BTN_UP;
        }

        private void buttonU_MouseUp(object sender, MouseEventArgs e)
        {
            button = BTN_NONE;
        }

        private void buttonSelect_MouseDown(object sender, MouseEventArgs e)
        {
            button = BTN_C;
        }


        private void buttonSelect_MouseUp(object sender, MouseEventArgs e)
        {
            button = BTN_NONE;
        }

        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;

        protected override bool ProcessKeyPreview(ref Message m)
        {
            if (m.Msg == WM_KEYDOWN && (Keys)m.WParam == Keys.W)
            {
                button = BTN_UP;
            }
            if (m.Msg == WM_KEYDOWN && (Keys)m.WParam == Keys.A)
            {
                button = BTN_LEFT;
            }
            if (m.Msg == WM_KEYDOWN && (Keys)m.WParam == Keys.S)
            {
                button = BTN_DOWN;
            }
            if (m.Msg == WM_KEYDOWN && (Keys)m.WParam == Keys.D)
            {
                button = BTN_RIGHT;
            }
            if (m.Msg == WM_KEYDOWN && (Keys)m.WParam == Keys.Space)
            {
                button = BTN_A;
            }
            if (m.Msg == WM_KEYDOWN && (Keys)m.WParam == Keys.LShiftKey)
            {
                button = BTN_B;
            }
            if (m.Msg == WM_KEYDOWN && (Keys)m.WParam == Keys.C)
            {
                button = BTN_C;
            }
            else if (m.Msg == WM_KEYUP)
            {
                button = BTN_NONE;
            }

            return base.ProcessKeyPreview(ref m);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {

            refreshTimer.Interval = 1000/gbFPS;
            pictureBox1.Image = gb.display.getBuffer();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Refresh();
            gb.buttons.tempButton = button;
            loop();
        }






        /// <summary>
        /// Gamebuino API Start
        /// </summary>
        ///
        const int gbFPS = 60; // Gamebuino Meta FPS
        const int LCDWIDTH = 160;
        const int LCDHEIGHT = 128;

        class Buttons
        {
            public byte tempButton = 0;
            public bool pressed(int button)
            {
                if (button == tempButton)
                    return true;
                return false;
            }
        };

        class Display
        {
            private Bitmap Screen = new Bitmap(LCDWIDTH + 1, LCDHEIGHT + 1);
            public void drawPixel(int x, int y, Color color)
            {
                Screen.SetPixel(x, y, color);
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

            public void drawFastVLine(int x, int y, int h, Color color)
            {
                Graphics g = Graphics.FromImage(Screen);
                Pen myPen = new Pen(color);
                myPen.Width = h;
                g.DrawLine(myPen, new Point(x, y), new Point(x, LCDHEIGHT));
            }

            public void drawFastHLine(int x, int y,int w, Color color)
            {
                Graphics g = Graphics.FromImage(Screen);
                Pen myPen = new Pen(color);
                myPen.Width = w;
                g.DrawLine(myPen, new Point(x, y), new Point(LCDWIDTH, y));
            }

        };

        class Gamebuino
        {
            public Buttons buttons = new Buttons();
            public Display display = new Display();
            public void begin() { }
            public bool update() { return true; }
        };
        /// <summary>
        /// Gamebuino API END
        /// </summary>
        ///



        /// <summary>
        /// Your Arduino Code Here
        /// </summary>
        ///
        Gamebuino gb = new Gamebuino();

        int x = 0, y = 0;

        void setup()
        {
            gb.begin();
        }

        void loop()
        {
            if (gb.update())
            {
                if (x >= LCDWIDTH)
                    x = LCDWIDTH;
                if (x <= 0)
                    x = 0;

                if (y >= LCDHEIGHT)
                    y = LCDHEIGHT;
                if (y <= 0)
                    y = 0;

                if (gb.buttons.pressed(BTN_UP))
                {
                    gb.display.drawPixel(x, y--, Color.Red);
                }

                if (gb.buttons.pressed(BTN_DOWN))
                {
                    gb.display.drawPixel(x, y++, Color.Red);
                }

                if (gb.buttons.pressed(BTN_LEFT))
                {
                    gb.display.drawPixel(x--, y, Color.Red);
                }

                if (gb.buttons.pressed(BTN_RIGHT))
                {
                    gb.display.drawPixel(x++, y, Color.Red);
                }

                if (gb.buttons.pressed(BTN_C))
                {
                    gb.display.fillScreen(Color.Black);
                }
            }
        }
        /// <summary>
        /// End of Arduino Code
        /// </summary>
    }
}
