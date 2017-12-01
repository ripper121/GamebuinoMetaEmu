using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamebuionMeta
{
    public partial class Form1 : Form
    {
        ArduinoCode arduinoCode = new ArduinoCode();
        bool[] buttons = new bool[7];

        private void buttonD_MouseDown(object sender, MouseEventArgs e)
        {
            buttons[BTN_DOWN] = true;
        }

        private void buttonD_MouseUp(object sender, MouseEventArgs e)
        {
            buttons[BTN_DOWN] = false;
        }

        private void buttonL_MouseDown(object sender, MouseEventArgs e)
        {
            buttons[BTN_LEFT] = true;
        }

        private void buttonL_MouseUp(object sender, MouseEventArgs e)
        {
            buttons[BTN_LEFT] = false;
        }

        private void buttonR_MouseDown(object sender, MouseEventArgs e)
        {
            buttons[BTN_RIGHT] = true;
        }

        private void buttonR_MouseUp(object sender, MouseEventArgs e)
        {
            buttons[BTN_RIGHT] = false;
        }

        private void buttonU_MouseDown(object sender, MouseEventArgs e)
        {
            buttons[BTN_UP] = true; 
        }

        private void buttonU_MouseUp(object sender, MouseEventArgs e)
        {
            buttons[BTN_UP] = false;
        }

        private void buttonSelect_MouseDown(object sender, MouseEventArgs e)
        {
            buttons[BTN_C] = true;
        }

        private void buttonSelect_MouseUp(object sender, MouseEventArgs e)
        {
            buttons[BTN_C] = false;
        }

        private void buttonB_MouseDown(object sender, MouseEventArgs e)
        {
            buttons[BTN_B] = true;
        }

        private void buttonB_MouseUp(object sender, MouseEventArgs e)
        {
            buttons[BTN_B] = false;
        }

        private void buttonA_MouseDown(object sender, MouseEventArgs e)
        {
            buttons[BTN_A] = true;
        }

        private void buttonA_MouseUp(object sender, MouseEventArgs e)
        {
            buttons[BTN_A] = false;
        }

        private void buttonStart_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void buttonStart_MouseUp(object sender, MouseEventArgs e)
        {

        }

        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;

        protected override bool ProcessKeyPreview(ref Message m)
        {
            if (m.Msg == WM_KEYDOWN && (Keys)m.WParam == Keys.W)
            {
                buttons[BTN_UP] = true;
            }
            else if (m.Msg == WM_KEYUP && (Keys)m.WParam == Keys.W)
            {
                buttons[BTN_UP] = false;
            }

            if (m.Msg == WM_KEYDOWN && (Keys)m.WParam == Keys.A)
            {
                buttons[BTN_LEFT] = true;
            }
            else if (m.Msg == WM_KEYUP && (Keys)m.WParam == Keys.A)
            {
                buttons[BTN_LEFT] = false;
            }

            if (m.Msg == WM_KEYDOWN && (Keys)m.WParam == Keys.S)
            {
                buttons[BTN_DOWN] = true;
            }
            else if (m.Msg == WM_KEYUP && (Keys)m.WParam == Keys.S)
            {
                buttons[BTN_DOWN] = false;
            }

            if (m.Msg == WM_KEYDOWN && (Keys)m.WParam == Keys.D)
            {
                buttons[BTN_RIGHT] = true;
            }
            else if (m.Msg == WM_KEYUP && (Keys)m.WParam == Keys.D)
            {
                buttons[BTN_RIGHT] = false;
            }

            if (m.Msg == WM_KEYDOWN && (Keys)m.WParam == Keys.Space)
            {
                buttons[BTN_A] = true;
            }
            else if (m.Msg == WM_KEYUP && (Keys)m.WParam == Keys.Space)
            {
                buttons[BTN_A] = false;
            }

            if (m.Msg == WM_KEYDOWN && (Keys)m.WParam == Keys.LShiftKey)
            {
                buttons[BTN_B] = true;
            }
            else if (m.Msg == WM_KEYUP && (Keys)m.WParam == Keys.LShiftKey)
            {
                buttons[BTN_B] = false;
            }

            if (m.Msg == WM_KEYDOWN && (Keys)m.WParam == Keys.C)
            {
                buttons[BTN_C] = true;
            }
            else if (m.Msg == WM_KEYUP && (Keys)m.WParam == Keys.C)
            {
                buttons[BTN_C] = false;
            }

            return base.ProcessKeyPreview(ref m);
        }

        public const int LCDWIDTH = Gamebuino.LCDWIDTH;
        public const int LCDHEIGHT = Gamebuino.LCDHEIGHT;

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

        public Form1()
        {
            InitializeComponent();
            arduinoCode.setup();
            for (byte i = 0; i < 7; i++)
                buttons[i] = false;
        }

        bool toggle = false;

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            refreshTimer.Interval = 1000/ arduinoCode.gb.gbFPS;

            pictureBox1.Image = arduinoCode.gb.display.getBuffer();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Refresh();
            arduinoCode.gb.buttons.tempButtons = buttons;
            if (toggle)
            {
                labelDebug.Text = "*";                
            }
            else
            {
                labelDebug.Text = " ";
            }
            toggle = !toggle;
            arduinoCode.loop();
        }
    }
}
