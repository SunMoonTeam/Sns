using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SunMoon.WindowsApplication {

    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.Height = this.Width = Screen.AllScreens.First().Bounds.Height - 100;
            this.Location.Offset(0, 0);
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            //this.DrawString(e.Graphics);
            //this.Corse1(e.Graphics);
            //this.Corse2(e.Graphics);
            //this.Corse3(e.Graphics);
            this.Corse4(e.Graphics);
        }

        private void Corse1(Graphics g) {
            Pen p = new Pen(Color.Green, 2);//定义了一个蓝色,宽度为的画笔

            int w = this.Width;

            g.DrawLine(p, 10, 10, w, w);//在画板上画直线,起始坐标为(10,10),终点坐标为(100,100)
            g.DrawRectangle(p, 10, 10, w, w);//在画板上画矩形,起始坐标为(10,10),宽为,高为
            g.DrawEllipse(p, 0, 0, w, w);//在画板上画椭圆,起始坐标为(10,10),外接矩形的宽为,高为
        }

        private void Corse2(Graphics g) {
            Pen p = new Pen(Color.Blue, 5);//设置笔的粗细为,颜色为蓝色

            //画虚线
            p.DashStyle = DashStyle.Dot;//定义虚线的样式为点
            g.DrawLine(p, 10, 10, 200, 10);

            //自定义虚线
            p.DashPattern = new float[] { 2, 1 };//设置短划线和空白部分的数组
            g.DrawLine(p, 10, 20, 200, 20);

            //画箭头,只对不封闭曲线有用
            p.DashStyle = DashStyle.Solid;//恢复实线
            p.EndCap = LineCap.ArrowAnchor;//定义线尾的样式为箭头
            g.DrawLine(p, 10, 30, 200, 30);

            g.Dispose();
            p.Dispose();
        }

        private void Corse3(Graphics g) {
            Rectangle rect = new Rectangle(10, 10, 50, 50);//定义矩形,参数为起点横纵坐标以及其长和宽

            //单色填充
            SolidBrush b1 = new SolidBrush(Color.Blue);//定义单色画刷
            g.FillRectangle(b1, rect);//填充这个矩形

            //字符串
            g.DrawString("字符串", new Font("宋体", 10), b1, new PointF(40, 10));

            //用图片填充
            TextureBrush b2 = new TextureBrush(Image.FromFile(@"E:\My Document\Image\将军.jpg"));
            rect.Location = new Point(10, 70);//更改这个矩形的起点坐标
            rect.Width = 200;//更改这个矩形的宽来
            rect.Height = 200;//更改这个矩形的高
            g.FillRectangle(b2, rect);

            //用渐变色填充
            rect.Location = new Point(10, 290);
            LinearGradientBrush b3 = new LinearGradientBrush(rect, Color.Yellow, Color.Black, LinearGradientMode.Horizontal);
            g.FillRectangle(b3, rect);
        }

        private void Corse4(Graphics g) {
            //单色填充
            //SolidBrush b1 = new SolidBrush(Color.Blue);//定义单色画刷
            Pen p = new Pen(Color.Blue, 1);

            //转变坐标轴角度
            //for (int i = 0; i < 90; i += 10) {
            //    g.RotateTransform(i);//每旋转一度就画一条线
            //    g.DrawLine(p, 0, 0, 100, 0);
            //    g.ResetTransform();//恢复坐标轴坐标
            //}
            g.RotateTransform(30);
            g.DrawString("I"
                , new Font("Times New Roman", 50)
                , Brushes.Green
                , new PointF(50, 1));
            g.ResetTransform();

            //平移坐标轴
            g.TranslateTransform(100, 100);
            g.DrawLine(p, 0, 0, 100, 0);
            g.ResetTransform();

            //先平移到指定坐标,然后进行度旋转
            g.TranslateTransform(100, 200);
            for (int i = 0; i < 8; i++) {
                g.RotateTransform(45);
                g.DrawLine(p, 0, 0, 100, 0);
            }

            g.Dispose();
        }

        private void DrawString(Graphics g) {
            Bitmap bmp = new System.Drawing.Bitmap(this.Width, this.Height);

            Brush b = new System.Drawing.SolidBrush(Color.FromArgb(4683611));

            //g.Clear(Color.FromArgb(237, 247, 255));
            g.Clear(Color.Black);

            Font f = new Font("Times New Roman", 50);

            SizeF size = g.MeasureString("test", f);

            g.DrawString(
                    "Hello gdi.",
                    f,
                    Brushes.Green,

                     new RectangleF(
                    0,

                    0,
                    this.Width,
                    this.Height),

                new StringFormat() {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center,
                    FormatFlags = StringFormatFlags.NoWrap
                });

            // Draw bmp to the screen.
            g.DrawImage(bmp, 0, 0, bmp.Width,
                bmp.Height);

            // Set each pixel in bmp to black.
            for (int Xcount = 0; Xcount < bmp.Width; Xcount++) {
                for (int Ycount = 0; Ycount < bmp.Height; Ycount++) {
                    bmp.SetPixel(Xcount, Ycount, Color.Black);
                }
            }

            // Draw bmp to the screen again.
            g.DrawImage(bmp, bmp.Width, 0,
                bmp.Width, bmp.Height);
        }
    }
}