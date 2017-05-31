using FormulaEditor.Core;
using FormulaEditor.utils;
using ScintillaNET;
using ScintillaNET.Demo.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FormulaEditor
{
    public partial class MainForm : Form, IView
    {
        UsingPython penigne = null;
        ILog loger = null;
        PyFiles pyFiles = null;
        PyFile currentPy = null;
        public Scintilla TextArea;
        public MainForm()
        {
            InitializeComponent();
            loger = new ConsoleLog(rtb_log);
            InitData();
            InitCodeEditor();
            
        }

       


        public void InitData()
        {
            pyFiles = new PyFiles();
            foreach (var item in pyFiles.PyList)
            {
                if (!tv_singal.Nodes.ContainsKey(item.Name))
                {
                    tv_singal.Nodes.Add(item.Name, item.Name);
                }
            }
            foreach (TreeNode item in tv_singal.Nodes)
            {
                if (item != null && pyFiles.PyList.Find(p => p.Name == item.Name) == null)
                {
                    tv_singal.Nodes.Remove(item);
                }
            }

        }

        private void debug_pyfile_Click(object sender, EventArgs e)
        {
            try
            {
                loger.log(penigne.ExcutePython(txt_func.Text,
                    txt_p1.Text,
                    txt_p2.Text,
                    txt_p3.Text,
                    txt_p4.Text,
                    txt_p5.Text,
                    txt_p6.Text,
                    txt_p7.Text,
                    txt_p8.Text).ToString());
            }
            catch (Exception ex)
            {
                loger.log(ex.ToString());
            }
            
        }

        private void lv_py_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPy = pyFiles.PyList.Find(p=> p.Name == tv_singal.SelectedNode.Text);
            TextArea.Text = currentPy.Content;
        }

        private void tv_singal_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (tv_singal.SelectedNode.Parent == null)
                {
                    SelectPyFle();
                }
                else
                {
                    SelectFunc();
                }
            }
            catch (Exception ex)
            {
                loger.log(ex.ToString());
            }
            
        }

        public void SelectPyFle() {
            try
            {
                currentPy = pyFiles.PyList.Find(p => p.Name == tv_singal.SelectedNode.Text);
                TextArea.Text = currentPy.Content;
                penigne = new UsingPython(currentPy.Name);
                List<string> list = penigne.GetFunctions();
                foreach (var item in list)
                {
                    TreeNode tn = new TreeNode(item);
                    tn.Name = item;
                    if (!tv_singal.SelectedNode.Nodes.ContainsKey(tn.Name))
                        tv_singal.SelectedNode.Nodes.Add(tn);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void SelectFunc() {
            try
            {
                //string funcName = tv_singal.SelectedNode.Text;
                //int funIndex = currentPy.Content.Replace("\r","").IndexOf(funcName);

                //rtb_code.Select(funIndex , funcName.Length);
                //bool b = rtb_code.Focus();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void create_fun_Click(object sender, EventArgs e)
        {
            frmCreateFormula frm = new frmCreateFormula(this,currentPy);
            frm.ShowDialog();
            
        }

        private void cms_zb_manager_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (tv_singal.SelectedNode!=null&&tv_singal.SelectedNode.Parent==null)
            {
                新建ToolStripMenuItem.Visible = true;
            }
            else if (tv_singal.SelectedNode != null && tv_singal.SelectedNode.Parent != null)
            {
                新建ToolStripMenuItem.Visible = true;
            }
        }

        public void RefreshData(IEntity entity)
        {
            try
            {
                TextArea.Text = ((PyFile)entity).Content;
                pyFiles.Refresh();
                SelectPyFle();
            }
            catch (Exception ex)
            {
                loger.log(ex.Message);
            }
           
        }

        private void Save_Singel_Click(object sender, EventArgs e)
        {
            try
            {
                currentPy.Content = TextArea.Text;
                currentPy = currentPy.Update();
                pyFiles.Refresh();
                SelectPyFle();
                //TextArea.Text = currentPy.Content;
                //pyFiles.Refresh();
                TextPanel.Text = "代码";
            }
            catch (Exception ex)
            {
                loger.log(ex.Message);
            }
            
        }

        private void create_singel_Click(object sender, EventArgs e)
        {
            try
            {
                frmCreateSingel frm = new frmCreateSingel(this);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                loger.log(ex.ToString());
            }
           
        }

        private void clear_console_Click(object sender, EventArgs e)
        {
            rtb_log.Text = string.Empty;
        }

        private void close_frm_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void del_pyfile_Click(object sender, EventArgs e)
        {
            currentPy.Del();
            InitData();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TextPanel.Controls.Add(this.TextArea);
        }

        #region 文本编辑器初始化


        public void InitCodeEditor()
        {
            TextArea = new ScintillaNET.Scintilla();
            TextArea.ContextMenuStrip = cms_code_manager;
            TextPanel.Controls.Add(TextArea);
            TextArea.TextChanged += TextArea_TextChanged;
            // BASIC CONFIG
            TextArea.Dock = System.Windows.Forms.DockStyle.Fill;
            TextArea.TextChanged += (this.OnTextChanged);

            // INITIAL VIEW CONFIG
            TextArea.WrapMode = WrapMode.None;
            TextArea.IndentationGuides = IndentView.LookBoth;

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

            TextArea.SetSelectionBackColor(true, IntToColor(0x114D9C));

        }

        private void InitHotkeys()
        {

            // register the hotkeys with the form
            HotKeyManager.AddHotKey(this, OpenFindDialog, Keys.F, true, false, true);
            HotKeyManager.AddHotKey(this, OpenReplaceDialog, Keys.R, true);
            HotKeyManager.AddHotKey(this, OpenReplaceDialog, Keys.H, true);
            //HotKeyManager.AddHotKey(this, Uppercase, Keys.U, true);
            //HotKeyManager.AddHotKey(this, Lowercase, Keys.L, true);
            //HotKeyManager.AddHotKey(this, ZoomIn, Keys.Oemplus, true);
            //HotKeyManager.AddHotKey(this, ZoomOut, Keys.OemMinus, true);
            //HotKeyManager.AddHotKey(this, ZoomDefault, Keys.D0, true);
            //HotKeyManager.AddHotKey(this, CloseSearch, Keys.Escape);

            // remove conflicting hotkeys from scintilla
            TextArea.ClearCmdKey(Keys.Control | Keys.F);
            TextArea.ClearCmdKey(Keys.Control | Keys.R);
            TextArea.ClearCmdKey(Keys.Control | Keys.H);
            TextArea.ClearCmdKey(Keys.Control | Keys.L);
            TextArea.ClearCmdKey(Keys.Control | Keys.U);

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
            TextArea.StyleResetDefault();
            TextArea.Styles[Style.Default].Font = "Consolas";
            TextArea.Styles[Style.Default].Size = 10;
            TextArea.Styles[Style.Default].BackColor = IntToColor(0x212121);
            TextArea.Styles[Style.Default].ForeColor = IntToColor(0xFFFFFF);
            TextArea.StyleClearAll();


            TextArea.Styles[Style.Python.Character].ForeColor = IntToColor(0xD0DAE2);
            //类名
            TextArea.Styles[Style.Python.ClassName].ForeColor = IntToColor(0x3c78d8);
            TextArea.Styles[Style.Python.CommentBlock].ForeColor = IntToColor(0x40BF57);
            TextArea.Styles[Style.Python.CommentLine].ForeColor = IntToColor(0x2FAE35);
            TextArea.Styles[Style.Python.Decorator].ForeColor = IntToColor(0xFFFF00);
            TextArea.Styles[Style.Python.Default].ForeColor = IntToColor(0xFFFF00);
            TextArea.Styles[Style.Python.DefName].ForeColor = IntToColor(0x4876FF);
            //参数
            TextArea.Styles[Style.Python.Identifier].ForeColor = IntToColor(0xf7f6f6);
            TextArea.Styles[Style.Python.Number].ForeColor = IntToColor(0xE0E0E0);
            //操作符
            TextArea.Styles[Style.Python.Operator].ForeColor = IntToColor(0xe8d7d7);
            TextArea.Styles[Style.Python.String].ForeColor = IntToColor(0x008B00);
            //注释
            TextArea.Styles[Style.Python.StringEol].ForeColor = IntToColor(0x32CD32);
            TextArea.Styles[Style.Python.Triple].ForeColor = IntToColor(0x11d211);
            TextArea.Styles[Style.Python.TripleDouble].ForeColor = IntToColor(0xB3D991);
            //关键词
            TextArea.Styles[Style.Python.Word].ForeColor = IntToColor(0x3d85c6);
            TextArea.Lexer = Lexer.Python;

            TextArea.SetKeywords(0, "def if elif class extends implements import interface new case do while else if for in switch throw get set function var try catch finally while with default break continue delete return each const namespace package include use is as instanceof typeof author copy default deprecated eventType example exampleText exception haxe inheritDoc internal link mtasc mxmlc param private return see serial serialData serialField since throws usage version langversion playerversion productversion dynamic private public partial static intrinsic internal native override protected AS3 final super this arguments null Infinity NaN undefined true false abstract as base bool break by byte case catch char checked class const continue decimal default delegate do double descending explicit event extern else enum false finally fixed float for foreach from goto group if implicit in int interface internal into is lock long new null namespace object operator out override orderby params private protected public readonly ref return switch struct sbyte sealed short sizeof stackalloc static string select this throw true try typeof uint ulong unchecked unsafe ushort using var virtual volatile void while where yield");
            TextArea.SetKeywords(1, "void Null ArgumentError arguments Array Boolean Class Date DefinitionError Error EvalError Function int Math Namespace Number Object RangeError ReferenceError RegExp SecurityError String SyntaxError TypeError uint XML XMLList Boolean Byte Char DateTime Decimal Double Int16 Int32 Int64 IntPtr SByte Single UInt16 UInt32 UInt64 UIntPtr Void Path File System Windows Forms ScintillaNET");

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

            TextArea.Styles[Style.LineNumber].BackColor = IntToColor(BACK_COLOR);
            TextArea.Styles[Style.LineNumber].ForeColor = IntToColor(FORE_COLOR);
            TextArea.Styles[Style.IndentGuide].ForeColor = IntToColor(FORE_COLOR);
            TextArea.Styles[Style.IndentGuide].BackColor = IntToColor(BACK_COLOR);

            var nums = TextArea.Margins[NUMBER_MARGIN];
            nums.Width = 30;
            nums.Type = MarginType.Number;
            nums.Sensitive = true;
            nums.Mask = 0;

            TextArea.MarginClick += TextArea_MarginClick;
        }
        private void TextArea_MarginClick(object sender, MarginClickEventArgs e)
        {
            if (e.Margin == BOOKMARK_MARGIN)
            {
                // Do we have a marker for this line?
                const uint mask = (1 << BOOKMARK_MARKER);
                var line = TextArea.Lines[TextArea.LineFromPosition(e.Position)];
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

            var margin = TextArea.Margins[BOOKMARK_MARGIN];
            margin.Width = 20;
            margin.Sensitive = true;
            margin.Type = MarginType.Symbol;
            margin.Mask = (1 << BOOKMARK_MARKER);
            //margin.Cursor = MarginCursor.Arrow;

            var marker = TextArea.Markers[BOOKMARK_MARKER];
            marker.Symbol = MarkerSymbol.Circle;
            marker.SetBackColor(IntToColor(0xFF003B));
            marker.SetForeColor(IntToColor(0x000000));
            marker.SetAlpha(100);

        }

        private void InitCodeFolding()
        {

            TextArea.SetFoldMarginColor(true, IntToColor(BACK_COLOR));
            TextArea.SetFoldMarginHighlightColor(true, IntToColor(BACK_COLOR));

            // Enable code folding
            TextArea.SetProperty("fold", "1");
            TextArea.SetProperty("fold.compact", "1");

            // Configure a margin to display folding symbols
            TextArea.Margins[FOLDING_MARGIN].Type = MarginType.Symbol;
            TextArea.Margins[FOLDING_MARGIN].Mask = Marker.MaskFolders;
            TextArea.Margins[FOLDING_MARGIN].Sensitive = true;
            TextArea.Margins[FOLDING_MARGIN].Width = 20;

            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                TextArea.Markers[i].SetForeColor(IntToColor(BACK_COLOR)); // styles for [+] and [-]
                TextArea.Markers[i].SetBackColor(IntToColor(FORE_COLOR)); // styles for [+] and [-]
            }

            // Configure folding markers with respective symbols
            TextArea.Markers[Marker.Folder].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlus : MarkerSymbol.BoxPlus;
            TextArea.Markers[Marker.FolderOpen].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinus : MarkerSymbol.BoxMinus;
            TextArea.Markers[Marker.FolderEnd].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlusConnected : MarkerSymbol.BoxPlusConnected;
            TextArea.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            TextArea.Markers[Marker.FolderOpenMid].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinusConnected : MarkerSymbol.BoxMinusConnected;
            TextArea.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            TextArea.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            TextArea.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);

        }
        #endregion
    }
}
