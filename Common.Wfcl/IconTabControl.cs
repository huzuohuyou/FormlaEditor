using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.Wfcl
{
    public class IconTabControl : TabControl
    {
        public static Color ACColor = Color.FromArgb(0, 122, 204);
        private int W;
        private int H;
        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Top;
        }
        [Category("IconTabControl")]
        public string[] IconTexts
        {
            get { return _IconTexts; }
            set
            {
                if (value != null)
                {
                    if (value.Length == TabCount)
                    {
                        _IconTexts = value; Invalidate();
                    }
                    else
                    {
                        MessageBox.Show("IconTexts个数和Tab页个数不匹配");
                    }
                }
            }
        }
        [Category("IconTabControl")]
        public Color BaseColor
        {
            get { return _BaseColor; }
            set { _BaseColor = value; }
        }
        [Category("IconTabControl")]
        public Color ActiveColor
        {
            get { return _ActiveColor; }
            set { _ActiveColor = value; }
        }
        private string[] _IconTexts = null;
        private Color BGColor = Color.FromArgb(60, 70, 73);
        private Color _BaseColor = Color.FromArgb(45, 47, 49);
        private Color _ActiveColor = Color.FromArgb(145, 147, 49);
        public IconTabControl()
        {

            SetStyle(
                ControlStyles.AllPaintingInWmPaint 
                | ControlStyles.UserPaint 
                | ControlStyles.ResizeRedraw 
                | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(45, 45, 48);
            Font = new Font("Segoe UI", 10);
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(120, 24);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            _ActiveColor = ACColor;
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            W = Width - 1;
            H = Height - 1;
            var _withG = G;
            _withG.SmoothingMode = SmoothingMode.HighQuality;
            _withG.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _withG.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _withG.Clear(_BaseColor);

            Rectangle LineSize = new Rectangle(
                    new Point(4, 26),
                    new Size(Width - 8, 2));
            _withG.FillRectangle(new SolidBrush(_ActiveColor), LineSize);
            try
            {
                SelectedTab.BackColor = BGColor;
            }
            catch
            {
            }
            for (int i = 0; i <= TabCount - 1; i++)
            {
                Rectangle Base = new Rectangle(
                    new Point(GetTabRect(i).Location.X + 2, 
                    GetTabRect(i).Location.Y), 
                    new Size(GetTabRect(i).Width,
                    GetTabRect(i).Height));
                Rectangle BaseSize = new Rectangle(
                    Base.Location, 
                    new Size(Base.Width, Base.Height));
                if (i == SelectedIndex)
                {
                    _withG.FillRectangle(new SolidBrush(_BaseColor), BaseSize);
                    _withG.FillRectangle(new SolidBrush(_ActiveColor),BaseSize);
                    if (ImageList != null)
                    {
                        try
                        {
                            //有对应的ImageList，我们可以流出空间来绘制image 
                            if (ImageList.Images[TabPages[i].ImageIndex] != null)
                            {
                                _withG.DrawImage(
                                    ImageList.Images[TabPages[i].ImageIndex], 
                                    new Point(BaseSize.Location.X + 8, BaseSize.Location.Y + 6));
                                _withG.DrawString(
                                    "      " + TabPages[i].Text,
                                    Font, 
                                    Brushes.White,  
                                    BaseSize, 
                                    GDIHelpers.CenterSF);
                            }
                            else
                            {
                                //绘制页签标题 
                                _withG.DrawString(
                                    TabPages[i].Text, 
                                    Font,
                                    Brushes.White, 
                                    BaseSize, 
                                    GDIHelpers.CenterSF);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                    else if (IconTexts != null)
                    {
                        try
                        {
                            if (IconTexts[i] != "")
                            {
                                //绘制字符图标 
                                _withG.DrawString(
                                    IconTexts[i], 
                                    new Font("Wingdings",22), 
                                    new SolidBrush(_BaseColor), 
                                    new Point(BaseSize.Location.X + 8,
                                    BaseSize.Location.Y + 6));
                                //绘制页签标题 
                                _withG.DrawString(
                                    "      " + TabPages[i].Text, 
                                    Font,
                                    Brushes.White, 
                                    BaseSize, 
                                    GDIHelpers.CenterSF);
                            }
                            else
                            {
                                //只绘制页签标题 
                                _withG.DrawString(
                                    TabPages[i].Text, 
                                    Font,Brushes.White, 
                                    BaseSize, 
                                    GDIHelpers.CenterSF);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                    else
                    {
                        _withG.DrawString(
                            TabPages[i].Text, 
                            Font,Brushes.White, 
                            BaseSize, 
                            GDIHelpers.CenterSF);
                    }
                }
                else
                {
                    _withG.FillRectangle(new SolidBrush(_BaseColor), BaseSize);
                    if (ImageList != null)
                    {
                        try
                        {
                            if (ImageList.Images[TabPages[i].ImageIndex] != null)
                            {
                                _withG.DrawImage(
                                    ImageList.Images[TabPages[i].ImageIndex], 
                                    new Point(BaseSize.Location.X + 8, BaseSize.Location.Y + 6));
                                _withG.DrawString(
                                    "      " + TabPages[i].Text,
                                    Font, new SolidBrush(Color.White), 
                                    BaseSize, 
                                    new StringFormat
                                    {
                                        LineAlignment = StringAlignment.Center,
                                        Alignment = StringAlignment.Center
                                    });
                            }
                            else
                            {
                                _withG.DrawString(
                                    TabPages[i].Text, 
                                    Font, 
                                    new SolidBrush(Color.White), 
                                    BaseSize, 
                                    new StringFormat
                                    {
                                        LineAlignment = StringAlignment.Center,
                                        Alignment = StringAlignment.Center
                                    });
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                    else if (IconTexts != null)
                    {
                        try
                        {
                            if (IconTexts[i] != "")
                            {
                                _withG.DrawString(
                                    IconTexts[i], 
                                    new Font("Wingdings",22), 
                                    new SolidBrush(_ActiveColor), 
                                    new Point(BaseSize.Location.X + 8,
                                    BaseSize.Location.Y + 6));
                                _withG.DrawString(
                                    "      " + TabPages[i].Text, 
                                    Font,
                                    Brushes.White, 
                                    BaseSize, 
                                    GDIHelpers.CenterSF);
                            }
                            else
                            {
                                _withG.DrawString(
                                    TabPages[i].Text, 
                                    Font,
                                    Brushes.White, 
                                    BaseSize, 
                                    GDIHelpers.CenterSF);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                    else
                    {
                        _withG.DrawString(
                            TabPages[i].Text, 
                            Font, 
                            new
                            SolidBrush(Color.White), 
                            BaseSize, 
                            new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Center
                            });
                    }
                }
            }
            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
    }
}