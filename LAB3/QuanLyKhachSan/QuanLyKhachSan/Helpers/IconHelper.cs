using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace QuanLyKhachSan.Helpers
{
    public static class IconHelper
    {
        private static Bitmap Create(int size, Action<Graphics, float> draw)
        {
            var bmp = new Bitmap(size, size);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);
                draw(g, size);
            }
            return bmp;
        }

        public static Bitmap Clipboard(int size, Color color)
        {
            return Create(size, (g, s) =>
            {
                using (var pen = new Pen(color, s * 0.09f))
                using (var brush = new SolidBrush(color))
                {
                    float m = s * 0.16f;
                    g.DrawRectangle(pen, m, m, s - 2 * m, s - 2 * m);
                    float clipW = s * 0.3f, clipH = s * 0.12f;
                    g.FillRectangle(brush, s / 2f - clipW / 2, m - clipH / 2, clipW, clipH);
                    for (int i = 0; i < 3; i++)
                    {
                        float ly = m + (s - 2 * m) * (0.3f + i * 0.24f);
                        g.DrawLine(pen, m + s * 0.08f, ly, s - m - s * 0.08f, ly);
                    }
                }
            });
        }

        public static Bitmap Bed(int size, Color color)
        {
            return Create(size, (g, s) =>
            {
                using (var pen = new Pen(color, s * 0.09f))
                {
                    float y = s * 0.55f;
                    g.DrawLine(pen, s * 0.12f, s * 0.15f, s * 0.12f, s * 0.85f);
                    g.DrawLine(pen, s * 0.12f, y, s * 0.88f, y);
                    g.DrawLine(pen, s * 0.88f, y, s * 0.88f, s * 0.85f);
                    g.DrawRectangle(pen, s * 0.16f, s * 0.28f, s * 0.24f, s * 0.2f);
                    g.DrawLine(pen, s * 0.4f, s * 0.45f, s * 0.82f, s * 0.45f);
                }
            });
        }

        public static Bitmap Key(int size, Color color)
        {
            return Create(size, (g, s) =>
            {
                using (var pen = new Pen(color, s * 0.1f))
                {
                    g.DrawEllipse(pen, s * 0.1f, s * 0.28f, s * 0.36f, s * 0.36f);
                    g.DrawLine(pen, s * 0.43f, s * 0.46f, s * 0.85f, s * 0.46f);
                    g.DrawLine(pen, s * 0.68f, s * 0.46f, s * 0.68f, s * 0.66f);
                    g.DrawLine(pen, s * 0.83f, s * 0.46f, s * 0.83f, s * 0.6f);
                }
            });
        }

        public static Bitmap Gear(int size, Color color)
        {
            return Create(size, (g, s) =>
            {
                using (var pen = new Pen(color, s * 0.09f))
                {
                    g.DrawEllipse(pen, s * 0.28f, s * 0.28f, s * 0.44f, s * 0.44f);
                    g.DrawEllipse(pen, s * 0.42f, s * 0.42f, s * 0.16f, s * 0.16f);
                    for (int i = 0; i < 8; i++)
                    {
                        double ang = i * Math.PI / 4;
                        float cx = s / 2f, cy = s / 2f, r1 = s * 0.34f, r2 = s * 0.46f;
                        float x1 = cx + (float)(r1 * Math.Cos(ang)), y1 = cy + (float)(r1 * Math.Sin(ang));
                        float x2 = cx + (float)(r2 * Math.Cos(ang)), y2 = cy + (float)(r2 * Math.Sin(ang));
                        g.DrawLine(pen, x1, y1, x2, y2);
                    }
                }
            });
        }

        public static Bitmap Cash(int size, Color color)
        {
            return Create(size, (g, s) =>
            {
                using (var pen = new Pen(color, s * 0.08f))
                {
                    g.DrawRectangle(pen, s * 0.1f, s * 0.3f, s * 0.8f, s * 0.4f);
                    g.DrawEllipse(pen, s * 0.4f, s * 0.4f, s * 0.2f, s * 0.2f);
                }
            });
        }

        public static Bitmap BarChart(int size, Color color)
        {
            return Create(size, (g, s) =>
            {
                using (var brush = new SolidBrush(color))
                {
                    g.FillRectangle(brush, s * 0.15f, s * 0.55f, s * 0.15f, s * 0.3f);
                    g.FillRectangle(brush, s * 0.42f, s * 0.35f, s * 0.15f, s * 0.5f);
                    g.FillRectangle(brush, s * 0.68f, s * 0.2f, s * 0.15f, s * 0.65f);
                }
            });
        }

        public static Bitmap Door(int size, Color color)
        {
            return Create(size, (g, s) =>
            {
                using (var pen = new Pen(color, s * 0.08f))
                using (var brush = new SolidBrush(color))
                {
                    g.DrawRectangle(pen, s * 0.25f, s * 0.12f, s * 0.35f, s * 0.76f);
                    g.FillEllipse(brush, s * 0.48f, s * 0.48f, s * 0.05f, s * 0.05f);
                    g.DrawLine(pen, s * 0.65f, s * 0.5f, s * 0.9f, s * 0.5f);
                    g.DrawLine(pen, s * 0.8f, s * 0.4f, s * 0.9f, s * 0.5f);
                    g.DrawLine(pen, s * 0.8f, s * 0.6f, s * 0.9f, s * 0.5f);
                }
            });
        }
    }
}