using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace magnifier
{
    public partial class Form1 : Form
    {
        double rate = 2.0;

        public Form1()
        {
            InitializeComponent();

            timer1.Enabled = true;

            this.MouseWheel += new MouseEventHandler(Form_MouseWheel);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "배율 : x" + rate;

            Size size = new Size(pictureBox1.Width, pictureBox1.Height);

            Bitmap bitmap = new Bitmap((int)(size.Width / rate), (int)(size.Height / rate));
            Graphics graphics = Graphics.FromImage(bitmap);

            graphics.CopyFromScreen((int)(MousePosition.X - size.Width / (rate * 2)), (int)(MousePosition.Y - size.Height / (rate * 2)), 0, 0, size, CopyPixelOperation.SourceCopy);

            pictureBox1.Image = bitmap;
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && rate < 5.0)
            {
                rate += 0.1;
            }
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && rate > 0.2)
            {
                rate -= 0.1;
            }
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '+' && rate < 5.0)
            {
                rate += 0.1;
            }
            else if (e.KeyChar == '-' && rate > 0.2)
            {
                rate -= 0.1;
            }
        }

        private void Form_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0 && rate > 0.2)
            {
                rate -= 0.1;
            }
            else if (e.Delta > 0 && rate < 5.0)
            {
                rate += 0.1;
            }
        }
    }
}
