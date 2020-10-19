using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaikoHitSwitchHelper;

namespace TestButtonMonitoringWindowsForms
{
    public partial class Form1 : Form
    {
        private int index = 0;
        private Keys[] taikoLeftKeys = { Keys.D, Keys.F };
        private Keys[] taikoRightKeys = { Keys.J, Keys.K };
        private int oldKeyDirection = 0;
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "你好呀";
            KeyboardHook kh = new KeyboardHook(true);
            kh.KeyDown += Kh_KeyDown;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Kh_KeyDown(Keys key, bool Shift, bool Ctrl, bool Alt)
        {
            index++;
            textBox1.AppendText(index + ". The Key: " + key + "\r\n");
            int keyDirection = 0;
            foreach(Keys taikoLeftKey in taikoLeftKeys)
            {
                if (key == taikoLeftKey)
                {
                    keyDirection = 1;
                }
            }
            foreach (Keys taikoLeftKey in taikoRightKeys)
            {
                if (key == taikoLeftKey)
                {
                    keyDirection = 2;
                }
            }

            if (keyDirection != 0)
            {
                if (oldKeyDirection != 0 && keyDirection == oldKeyDirection)
                {
                    textBox2.AppendText("全换连击于“" + key + "”按键处中断。\r\n");
                }
                oldKeyDirection = keyDirection;
            }
            else
            {
                oldKeyDirection = 0;
            }
        }
    }
}