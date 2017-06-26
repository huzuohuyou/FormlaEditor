using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.Wfcl
{
    public partial class CTreeView : TreeView
    {
        public static Color ACColor = Color.FromArgb(0, 122, 204);
        private int W;
        private int H;
       
        
        [Category("CTreeView")]
        public Color BaseColor
        {
            get { return _BaseColor; }
            set { _BaseColor = value; }
        }
        [Category("CTreeView")]
        public Color ActiveColor
        {
            get { return _ActiveColor; }
            set { _ActiveColor = value; }
        }
        private Color BGColor = Color.FromArgb(60, 70, 73);
        private Color _BaseColor = Color.FromArgb(45, 47, 49);
        private Color _ActiveColor = Color.FromArgb(145, 147, 49);
        public CTreeView()
        {

            SetStyle(
                ControlStyles.AllPaintingInWmPaint
                //| ControlStyles.UserPaint
                | ControlStyles.ResizeRedraw
                | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(45, 45, 48);
            Font = new Font("Segoe UI", 10);
            //SizeMode = TabSizeMode.Fixed;
            //ItemSize = new Size(120, 24);

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
