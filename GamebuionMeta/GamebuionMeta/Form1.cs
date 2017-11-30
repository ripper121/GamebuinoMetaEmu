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
        byte BTN_NONE = 0, BTN_A = 1, BTN_B = 2, BTN_C = 3, BTN_UP = 4, BTN_RIGHT = 5, BTN_DOWN = 6, BTN_LEFT = 7;
        byte button = 0;
        Bitmap Screen = new Bitmap(160, 128);

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

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            loop();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonU_MouseDown(object sender, MouseEventArgs e)
        {
            button = BTN_UP;
        }

        private void buttonU_MouseUp(object sender, MouseEventArgs e)
        {
            button = BTN_NONE;
        }

        byte gbButtonPressed()
        {
            if(button == BTN_UP)
                return BTN_UP;
            if (button == BTN_DOWN)
                return BTN_DOWN;
            if (button == BTN_LEFT)
                return BTN_LEFT;
            if (button == BTN_RIGHT)
                return BTN_RIGHT;
            return BTN_NONE;
        }

        void gbDisplayDrawPixel(int x, int y, Color color)
        {
            Screen.SetPixel(x, y, color);
            pictureBox1.Image = Screen;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Refresh();
        }



        /// <summary>
        /// Your Arduino Code Here
        /// </summary>
        /// 
        int x = 0, y = 0;

        void setup()
        {

        }


        void loop()
        {
            if (gbButtonPressed() == BTN_UP)
            {
                gbDisplayDrawPixel(x, y--, Color.Red);
            }

            if (gbButtonPressed() == BTN_DOWN)
            {
                gbDisplayDrawPixel(x, y++, Color.Red);
            }

            if (gbButtonPressed() == BTN_LEFT)
            {
                gbDisplayDrawPixel(x--, y, Color.Red);
            }

            if (gbButtonPressed() == BTN_RIGHT)
            {
                gbDisplayDrawPixel(x++, y, Color.Red);
            }
        }
        /// <summary>
        /// End of Arduino Code
        /// </summary>
    }
}
