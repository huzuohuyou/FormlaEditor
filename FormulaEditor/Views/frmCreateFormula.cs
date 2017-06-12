using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FormulaEditor
{
    public partial class frmCreateFormula : Form
    {
        IView view = null;
        PyFile currentPy = null;
        public Scintilla rtb_fun;
        public frmCreateFormula(IView view,PyFile p)
        {
            currentPy= p;
            this.view = view;
            InitializeComponent();
            InitCodeEditor();
            this.Text =string.Format("{0}_{1}",currentPy.Name.Substring(0, currentPy.Name.LastIndexOf('.')),this.Text);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            PyFunc pf = new PyFunc() { FunName = txt_name.Text.Trim(), listParam = GetParam(), FunBody = rtb_fun.Text ,FunNote = rtb_note.Text.Trim()};
            PyFile pyFile= currentPy.AddFunc(pf);
            view.RefreshData(pyFile);
            this.FindForm().Close();
        }

        public List<PyParam> GetParam()
        {
            List<PyParam> list = new List<PyParam>();
            list.Add(new PyParam() { Key = "p1", Note = txt_p1.Text != string.Empty ? txt_p1.Text : "None" });
            list.Add(new PyParam() { Key = "p2", Note = txt_p2.Text != string.Empty ? txt_p2.Text : "None" });
            list.Add(new PyParam() { Key = "p3", Note = txt_p3.Text != string.Empty ? txt_p3.Text : "None" });
            list.Add(new PyParam() { Key = "p4", Note = txt_p4.Text != string.Empty ? txt_p4.Text : "None" });
            list.Add(new PyParam() { Key = "p5", Note = txt_p5.Text != string.Empty ? txt_p5.Text : "None" });
            list.Add(new PyParam() { Key = "p6", Note = txt_p6.Text != string.Empty ? txt_p6.Text : "None" });
            list.Add(new PyParam() { Key = "p7", Note = txt_p7.Text != string.Empty ? txt_p7.Text : "None" });
            list.Add(new PyParam() { Key = "p8", Note = txt_p8.Text != string.Empty ? txt_p8.Text : "None" });
            return list;
        }

        private void btn_preview_Click(object sender, EventArgs e)
        {
            PyFunc pf = new PyFunc() { FunName = txt_name.Text.Trim(), listParam = GetParam(),FunBody=rtb_fun.Text ,FunNote=rtb_note.Text};
            MessageBox.Show(pf.CombineContent());
        }

        #region 文本编辑器初始化


        public void InitCodeEditor()
        {
            rtb_fun = new ScintillaNET.Scintilla();
            //TextArea.ContextMenuStrip = cms_code_manager;
            TextPanel.Controls.Add(rtb_fun);
            rtb_fun.TextChanged += TextArea_TextChanged;
            // BASIC CONFIG
            rtb_fun.Dock = System.Windows.Forms.DockStyle.Fill;
            rtb_fun.TextChanged += (this.OnTextChanged);

            // INITIAL VIEW CONFIG
            rtb_fun.WrapMode = WrapMode.None;
            rtb_fun.IndentationGuides = IndentView.LookBoth;

            // STYLING
            InitColors();
            InitSyntaxColoring();

            // NUMBER MARGIN
            InitNumberMargin();

            // BOOKMARK MARGIN
            InitBookmarkMargin();

            // CODE FOLDING MARGIN
            InitCodeFolding();

            // DRAG DROP
            //InitDragDropFile();

            // DEFAULT FILE
            //LoadDataFromFile("../../MainForm.cs");

            // INIT HOTKEYS
            //InitHotkeys();
        }

        private void TextArea_TextChanged(object sender, EventArgs e)
        {
            if (!TextPanel.Text.Contains("*"))
            {
                TextPanel.Text = TextPanel.Text + "*";
            }

        }

        private void InitColors()
        {

            rtb_fun.SetSelectionBackColor(true, IntToColor(0x114D9C));

        }

        private void InitHotkeys()
        {

            // register the hotkeys with the form
            //HotKeyManager.AddHotKey(this, OpenFindDialog, Keys.F, true, false, true);
            //HotKeyManager.AddHotKey(this, OpenReplaceDialog, Keys.R, true);
            //HotKeyManager.AddHotKey(this, OpenReplaceDialog, Keys.H, true);
            //HotKeyManager.AddHotKey(this, Uppercase, Keys.U, true);
            //HotKeyManager.AddHotKey(this, Lowercase, Keys.L, true);
            //HotKeyManager.AddHotKey(this, ZoomIn, Keys.Oemplus, true);
            //HotKeyManager.AddHotKey(this, ZoomOut, Keys.OemMinus, true);
            //HotKeyManager.AddHotKey(this, ZoomDefault, Keys.D0, true);
            //HotKeyManager.AddHotKey(this, CloseSearch, Keys.Escape);

            // remove conflicting hotkeys from scintilla
            rtb_fun.ClearCmdKey(Keys.Control | Keys.F);
            rtb_fun.ClearCmdKey(Keys.Control | Keys.R);
            rtb_fun.ClearCmdKey(Keys.Control | Keys.H);
            rtb_fun.ClearCmdKey(Keys.Control | Keys.L);
            rtb_fun.ClearCmdKey(Keys.Control | Keys.U);

        }

        public void InvokeIfNeeded(Action action)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(action);
            }
            else
            {
                action.Invoke();
            }
        }
        private void OpenFindDialog()
        {

        }
        private void OpenReplaceDialog()
        {


        }

        private void InitSyntaxColoring()
        {

            // Configure the default style
            rtb_fun.StyleResetDefault();
            rtb_fun.Styles[Style.Default].Font = "Consolas";
            rtb_fun.Styles[Style.Default].Size = 10;
            rtb_fun.Styles[Style.Default].BackColor = IntToColor(0x212121);
            rtb_fun.Styles[Style.Default].ForeColor = IntToColor(0xFFFFFF);
            rtb_fun.StyleClearAll();


            rtb_fun.Styles[Style.Python.Character].ForeColor = IntToColor(0xD0DAE2);
            //类名
            rtb_fun.Styles[Style.Python.ClassName].ForeColor = IntToColor(0x3c78d8);
            rtb_fun.Styles[Style.Python.CommentBlock].ForeColor = IntToColor(0x40BF57);
            rtb_fun.Styles[Style.Python.CommentLine].ForeColor = IntToColor(0x2FAE35);
            rtb_fun.Styles[Style.Python.Decorator].ForeColor = IntToColor(0xFFFF00);
            rtb_fun.Styles[Style.Python.Default].ForeColor = IntToColor(0xFFFF00);
            rtb_fun.Styles[Style.Python.DefName].ForeColor = IntToColor(0x4876FF);
            //参数
            rtb_fun.Styles[Style.Python.Identifier].ForeColor = IntToColor(0xf7f6f6);
            rtb_fun.Styles[Style.Python.Number].ForeColor = IntToColor(0xE0E0E0);
            //操作符
            rtb_fun.Styles[Style.Python.Operator].ForeColor = IntToColor(0xe8d7d7);
            rtb_fun.Styles[Style.Python.String].ForeColor = IntToColor(0x008B00);
            //注释
            rtb_fun.Styles[Style.Python.StringEol].ForeColor = IntToColor(0x32CD32);
            rtb_fun.Styles[Style.Python.Triple].ForeColor = IntToColor(0x11d211);
            rtb_fun.Styles[Style.Python.TripleDouble].ForeColor = IntToColor(0xB3D991);
            //关键词
            rtb_fun.Styles[Style.Python.Word].ForeColor = IntToColor(0x3d85c6);
            rtb_fun.Lexer = Lexer.Python;

            rtb_fun.SetKeywords(0, "def if elif class extends implements import interface new case do while else if for in switch throw get set function var try catch finally while with default break continue delete return each const namespace package include use is as instanceof typeof author copy default deprecated eventType example exampleText exception haxe inheritDoc internal link mtasc mxmlc param private return see serial serialData serialField since throws usage version langversion playerversion productversion dynamic private public partial static intrinsic internal native override protected AS3 final super this arguments null Infinity NaN undefined true false abstract as base bool break by byte case catch char checked class const continue decimal default delegate do double descending explicit event extern else enum false finally fixed float for foreach from goto group if implicit in int interface internal into is lock long new null namespace object operator out override orderby params private protected public readonly ref return switch struct sbyte sealed short sizeof stackalloc static string select this throw true try typeof uint ulong unchecked unsafe ushort using var virtual volatile void while where yield");
            rtb_fun.SetKeywords(1, "void Null ArgumentError arguments Array Boolean Class Date DefinitionError Error EvalError Function int Math Namespace Number Object RangeError ReferenceError RegExp SecurityError String SyntaxError TypeError uint XML XMLList Boolean Byte Char DateTime Decimal Double Int16 Int32 Int64 IntPtr SByte Single UInt16 UInt32 UInt64 UIntPtr Void Path File System Windows Forms ScintillaNET");

        }

        private void OnTextChanged(object sender, EventArgs e)
        {

        }



        /// <summary>
        /// the background color of the text area
        /// </summary>
        private const int BACK_COLOR = 0x2A211C;

        /// <summary>
        /// default text color of the text area
        /// </summary>
        private const int FORE_COLOR = 0xB7B7B7;

        /// <summary>
        /// change this to whatever margin you want the line numbers to show in
        /// </summary>
        private const int NUMBER_MARGIN = 1;

        /// <summary>
        /// change this to whatever margin you want the bookmarks/breakpoints to show in
        /// </summary>
        private const int BOOKMARK_MARGIN = 2;
        private const int BOOKMARK_MARKER = 2;

        /// <summary>
        /// change this to whatever margin you want the code folding tree (+/-) to show in
        /// </summary>
        private const int FOLDING_MARGIN = 3;

        /// <summary>
        /// set this true to show circular buttons for code folding (the [+] and [-] buttons on the margin)
        /// </summary>
        private const bool CODEFOLDING_CIRCULAR = true;

        public static Color IntToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }
        private void InitNumberMargin()
        {

            rtb_fun.Styles[Style.LineNumber].BackColor = IntToColor(BACK_COLOR);
            rtb_fun.Styles[Style.LineNumber].ForeColor = IntToColor(FORE_COLOR);
            rtb_fun.Styles[Style.IndentGuide].ForeColor = IntToColor(FORE_COLOR);
            rtb_fun.Styles[Style.IndentGuide].BackColor = IntToColor(BACK_COLOR);

            var nums = rtb_fun.Margins[NUMBER_MARGIN];
            nums.Width = 30;
            nums.Type = MarginType.Number;
            nums.Sensitive = true;
            nums.Mask = 0;

            rtb_fun.MarginClick += TextArea_MarginClick;
        }
        private void TextArea_MarginClick(object sender, MarginClickEventArgs e)
        {
            if (e.Margin == BOOKMARK_MARGIN)
            {
                // Do we have a marker for this line?
                const uint mask = (1 << BOOKMARK_MARKER);
                var line = rtb_fun.Lines[rtb_fun.LineFromPosition(e.Position)];
                if ((line.MarkerGet() & mask) > 0)
                {
                    // Remove existing bookmark
                    line.MarkerDelete(BOOKMARK_MARKER);
                }
                else
                {
                    // Add bookmark
                    line.MarkerAdd(BOOKMARK_MARKER);
                }
            }
        }

        private void InitBookmarkMargin()
        {

            //TextArea.SetFoldMarginColor(true, IntToColor(BACK_COLOR));

            var margin = rtb_fun.Margins[BOOKMARK_MARGIN];
            margin.Width = 20;
            margin.Sensitive = true;
            margin.Type = MarginType.Symbol;
            margin.Mask = (1 << BOOKMARK_MARKER);
            //margin.Cursor = MarginCursor.Arrow;

            var marker = rtb_fun.Markers[BOOKMARK_MARKER];
            marker.Symbol = MarkerSymbol.Circle;
            marker.SetBackColor(IntToColor(0xFF003B));
            marker.SetForeColor(IntToColor(0x000000));
            marker.SetAlpha(100);

        }

        private void InitCodeFolding()
        {

            rtb_fun.SetFoldMarginColor(true, IntToColor(BACK_COLOR));
            rtb_fun.SetFoldMarginHighlightColor(true, IntToColor(BACK_COLOR));

            // Enable code folding
            rtb_fun.SetProperty("fold", "1");
            rtb_fun.SetProperty("fold.compact", "1");

            // Configure a margin to display folding symbols
            rtb_fun.Margins[FOLDING_MARGIN].Type = MarginType.Symbol;
            rtb_fun.Margins[FOLDING_MARGIN].Mask = Marker.MaskFolders;
            rtb_fun.Margins[FOLDING_MARGIN].Sensitive = true;
            rtb_fun.Margins[FOLDING_MARGIN].Width = 20;

            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                rtb_fun.Markers[i].SetForeColor(IntToColor(BACK_COLOR)); // styles for [+] and [-]
                rtb_fun.Markers[i].SetBackColor(IntToColor(FORE_COLOR)); // styles for [+] and [-]
            }

            // Configure folding markers with respective symbols
            rtb_fun.Markers[Marker.Folder].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlus : MarkerSymbol.BoxPlus;
            rtb_fun.Markers[Marker.FolderOpen].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinus : MarkerSymbol.BoxMinus;
            rtb_fun.Markers[Marker.FolderEnd].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlusConnected : MarkerSymbol.BoxPlusConnected;
            rtb_fun.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            rtb_fun.Markers[Marker.FolderOpenMid].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinusConnected : MarkerSymbol.BoxMinusConnected;
            rtb_fun.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            rtb_fun.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            rtb_fun.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);

        }
        #endregion
    }
}
