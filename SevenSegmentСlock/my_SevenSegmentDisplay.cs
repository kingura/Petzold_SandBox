using System;
using System.Drawing;

class my_SevenSegmentDisplay
{
    private Graphics grfx;

    private readonly byte[,] numberGrid =
    {
        {1,1,1,0,1,1,1}, // 0
        {0,0,1,0,0,1,0}, // 1
        {1,0,1,1,1,0,1}, // 2
        {1,0,1,1,0,1,1}, // 3
        {0,1,1,1,0,1,0}, // 4
        {1,1,0,1,0,1,1}, // 5
        {1,1,0,1,1,1,1}, // 6
        {1,0,1,0,0,1,0}, // 7
        {1,1,1,1,1,1,1}, // 8
        {1,1,1,1,0,1,1}  // 9
    };

    private readonly Point[][] apt = new Point[9][]
    {
        new Point[] { new Point(3,2), new Point(39,2), new Point(31,10), new Point(11,10)},
        new Point[] { new Point(2,3), new Point(10,11), new Point(10,31), new Point(2,35)},
        new Point[] { new Point(40,3), new Point(40,35), new Point(32,31), new Point(32,11)},
        new Point[] { new Point(3,36), new Point(11,32), new Point(31,32), new Point(39,36), new Point(31,40), new Point(11,40)},
        new Point[] { new Point(2,37), new Point(10,41), new Point(10,61), new Point(2,69)},
        new Point[] { new Point(40,37), new Point(40,69), new Point(32,61), new Point(32,41)},
        new Point[] { new Point(11,62), new Point(31,62), new Point(39,70), new Point(3,70)},
        new Point[] { new Point(2,18), new Point(6, 14), new Point(10, 18), new Point(6, 22)},
        new Point[] { new Point(2,48), new Point(6, 44), new Point(10, 48), new Point(6, 52)}
    };
    
    public my_SevenSegmentDisplay(Graphics grfx)
    {
        this.grfx = grfx;
         
    }

    public SizeF MeasureString(string str)
    {
        SizeF sizef = SizeF.Empty;

        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] != ':')
            {
                sizef.Width += 40 + 2;
            }
            else sizef.Width += 10 + 2;
        }

        sizef.Height = 70;

        return sizef;
    }

    public void DrawString(string str, Brush brush, float fScale, float sx, float sy)
    {
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] != ':')
            {
                Fill((byte)(str[i] - '0'), brush, fScale, sx, sy);
            }
            else
            {
                FillColon(brush, fScale, sx, sy);
            }

            sx += MeasureString(str[i].ToString()).Width * fScale;
        }
    }
    
    private void Fill(byte num, Brush brush, float fScale, float sx, float sy)
    {
        for (int i = 0; i <= numberGrid.GetUpperBound(1); i++)
        {
            if (numberGrid[num, i] == 1)
            {
                PointF[] pt = new PointF[apt[i].Length];
                for (int j = 0; j < pt.Length; j++)
                {
                    pt[j].X = apt[i][j].X * fScale + sx;
                    pt[j].Y = apt[i][j].Y * fScale + sy;
                }

                grfx.FillPolygon(brush, pt);
            }
        }
    }

    private void FillColon(Brush brush, float fScale, float sx, float sy)
    {
        for (int i = 7; i <= 8; i++)
        {
            PointF[] pt = new PointF[apt[i].Length];
            for (int j = 0; j < pt.Length; j++)
            {
                pt[j].X = apt[i][j].X * fScale + sx;
                pt[j].Y = apt[i][j].Y * fScale + sy;
            }

            grfx.FillPolygon(brush, pt);
        }
    }
}
