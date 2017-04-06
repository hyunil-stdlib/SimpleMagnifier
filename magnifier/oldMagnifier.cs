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
    class oldMagnifier
    {
private void pictureBox1_DoubleClick(object sender, EventArgs e)
{
    int curX = Cursor.Position.X;
    int curY = Cursor.Position.Y;

    int screenWidth = 50;
    int screeHeight = 50;

    Size size = new Size(screenWidth, screeHeight);
    Bitmap bitmap = new Bitmap(size.Width, size.Height);

    double rate = 2.0;

    Graphics graphic = Graphics.FromImage(bitmap);
    graphic.CopyFromScreen(curX - (screenWidth / 2), curY - (screeHeight / 2), 0, 0, size); // 화면 캡쳐

    int zoominWidth = (int)(screenWidth * rate);
    int zoominHeight = (int)(screeHeight * rate);

    Bitmap zoomin = new Bitmap(zoominWidth, zoominHeight);

    for (int i = 0; i < zoominWidth; i++)
    {
        for (int j = 0; j < zoominHeight; j++)
        {
            int row = (int)(i / rate);
            int col = (int)(j / rate);
            zoomin.SetPixel(i, j, bitmap.GetPixel(row, col));
        }
    }
}
    }
}
