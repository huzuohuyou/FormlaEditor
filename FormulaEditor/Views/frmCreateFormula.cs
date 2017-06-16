using FormulaEditor.Model;
using FormulaEditor.Core;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FormulaEditor.Views;

namespace FormulaEditor
{
    public partial class frmCreateFormula : Form, ICanClear
    {
        KPINode kpi;
        ICallBack callback;
        List<ucDataItem> ucList = new List<ucDataItem>();
        List<Param> ParamList
        {
            get
            {
                List<Param> temp = new List<Param>();
                ucList.ForEach(r =>
                {
                    r.param.Value = "1";
                    temp.Add(r.param);
                });
                return temp;
            }
        }
        string TempScript
        {
            get
            {
                string body = string.Empty, param = string.Empty;
                if (rtb_denominator.Text.Trim() == string.Empty)
                {
                    body += string.Format(@"result={0}", rtb_numerator.Text.Trim());
                }
                else
                {
                    body = string.Format(@"if(({0})==1):
    result={1}", rtb_denominator.Text.Trim(), rtb_numerator.Text.Trim());
                }
                ucList.ForEach(r =>
                {
                    param += r.param.Code + "\n";
                });
                return string.Format("{1}{0}", body, param);
            }
        }

        EditFormulaController controller;
        /// <summary>
        /// 分子公式
        /// </summary>
        public Scintilla rtb_numerator;
        /// <summary>
        /// 分母公式
        /// </summary>
        public Scintilla rtb_denominator;
        public frmCreateFormula(ICallBack cb, KPINode p)
        {
            
            kpi = p;
            callback = cb;
            InitializeComponent();
            panel_param.AllowDrop = true;
            controller = new EditFormulaController();
            InitLeftDataItems();
            InitCodeEditor();
            panel_param.VerticalScroll.Visible = true;
            panel_param.AutoScroll = true;
            
        }

        public void InitLeftDataItems()
        {
            try
            {
                TreeNode typeNode = null;
                controller.GetDataItemList(kpi.SD_CODE).ForEach(r =>
                {
                    if (!tv_dataItems.Nodes.ContainsKey(r.Type))
                    {
                        typeNode = new TreeNode(r.Type);
                        typeNode.Name = r.Type;
                        tv_dataItems.Nodes.Add(typeNode);
                    }
                    if (typeNode != null)
                    {
                        TreeNode node = new TreeNode(r.Name);
                        node.Name = r.Name;
                        node.Tag = r;
                        typeNode.Nodes.Add(node);
                    }

                });
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public void InitKpiFormulaInfo(int kpiId)
        {
            List<Param> list = controller.GetKPIDataItemList(kpiId);
            EP_KPI_SET eks = controller.GetKPIFormulaBody(kpiId);
            list.ForEach(
                r =>
                {
                    ucList.Add(new ucDataItem(this, r));
                }
                );
            rtb_denominator.Text = eks?.NUM_FORMULA;
            rtb_numerator.Text = eks?.FRA_FORMULA ;
            rtb_note.Text = eks?.KPI_DESC;
            LoadKPIDataItem();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                Tuple<string,bool> checkInfo=controller.CheckFormula(TempScript, ParamList);
                if (checkInfo.Item2)
                {
                    List<EP_KPI_PARAM> list = new List<EP_KPI_PARAM>();
                    ucList.ForEach(r =>
                    {
                        list.Add(new EP_KPI_PARAM() { KPI_ID = kpi.KPI_ID, SD_ITEM_ID = r.param.DataItemId, KPI_PARAM_NAME = r.param.Code.Trim() });
                    }
                    );
                    controller.SavaFormulaBody(new EP_KPI_SET() { KPI_ID = kpi.KPI_ID, KPI_DESC = rtb_note.Text, NUM_FORMULA = rtb_denominator.Text, FRA_FORMULA = rtb_numerator.Text });
                    controller.SaveFormulaParam(list);
                    callback.RefreshData(kpi);
                    callback.log("保存成功！！！");
                    this.FindForm().Close();
                    
                }
                else
                {
                    callback.log("存在语法错误请校验修正后保存！！！");
                    callback.log(checkInfo.Item1);
                    return;
                }
                
            }
            catch (Exception ex)
            {
                callback.log(ex.Message);
            }
            
        }



        private void btn_preview_Click(object sender, EventArgs e)
        {
            //PyFunc pf = new PyFunc() { FunName = txt_name.Text.Trim(), listParam = GetParam(),FunBody=rtb_numerator.Text ,FunNote=rtb_note.Text};
            //MessageBox.Show(pf.CombineContent());
        }

        #region 分子文本编辑器初始化


        public void InitCodeEditor()
        {
            #region 分子
            rtb_numerator = new ScintillaNET.Scintilla();
            //TextArea.ContextMenuStrip = cms_code_manager;
            gb_fz.Controls.Add(rtb_numerator);
            rtb_numerator.TextChanged += TextArea_TextChanged;
            // BASIC CONFIG
            rtb_numerator.Dock = System.Windows.Forms.DockStyle.Fill;
            rtb_numerator.TextChanged += (this.OnTextChanged);

            // INITIAL VIEW CONFIG
            rtb_numerator.WrapMode = WrapMode.None;
            rtb_numerator.IndentationGuides = IndentView.LookBoth;
            #endregion

            #region 分母
            rtb_denominator = new ScintillaNET.Scintilla();
            //TextArea.ContextMenuStrip = cms_code_manager;
            gb_fm.Controls.Add(rtb_denominator);
            rtb_denominator.TextChanged += TextArea_TextChanged;
            // BASIC CONFIG
            rtb_denominator.Dock = System.Windows.Forms.DockStyle.Fill;
            rtb_denominator.TextChanged += (this.OnTextChanged);

            // INITIAL VIEW CONFIG
            rtb_denominator.WrapMode = WrapMode.None;
            rtb_denominator.IndentationGuides = IndentView.LookBoth;
            #endregion
            // STYLING
            InitColors();
            InitSyntaxColoring();
            // NUMBER MARGIN
            InitNumberMargin();
            // BOOKMARK MARGIN
            InitBookmarkMargin();
            InitCodeFolding();
            
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

            rtb_numerator.SetSelectionBackColor(true, IntToColor(0x114D9C));
            rtb_denominator.SetSelectionBackColor(true, IntToColor(0x114D9C));

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
            rtb_numerator.ClearCmdKey(Keys.Control | Keys.F);
            rtb_numerator.ClearCmdKey(Keys.Control | Keys.R);
            rtb_numerator.ClearCmdKey(Keys.Control | Keys.H);
            rtb_numerator.ClearCmdKey(Keys.Control | Keys.L);
            rtb_numerator.ClearCmdKey(Keys.Control | Keys.U);

            rtb_denominator.ClearCmdKey(Keys.Control | Keys.F);
            rtb_denominator.ClearCmdKey(Keys.Control | Keys.R);
            rtb_denominator.ClearCmdKey(Keys.Control | Keys.H);
            rtb_denominator.ClearCmdKey(Keys.Control | Keys.L);
            rtb_denominator.ClearCmdKey(Keys.Control | Keys.U);

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
            rtb_numerator.StyleResetDefault();
            rtb_numerator.Styles[Style.Default].Font = "Consolas";
            rtb_numerator.Styles[Style.Default].Size = 10;
            rtb_numerator.Styles[Style.Default].BackColor = IntToColor(0x212121);
            rtb_numerator.Styles[Style.Default].ForeColor = IntToColor(0xFFFFFF);
            rtb_numerator.StyleClearAll();


            rtb_numerator.Styles[Style.Python.Character].ForeColor = IntToColor(0xD0DAE2);
            //类名
            rtb_numerator.Styles[Style.Python.ClassName].ForeColor = IntToColor(0x3c78d8);
            rtb_numerator.Styles[Style.Python.CommentBlock].ForeColor = IntToColor(0x40BF57);
            rtb_numerator.Styles[Style.Python.CommentLine].ForeColor = IntToColor(0x2FAE35);
            rtb_numerator.Styles[Style.Python.Decorator].ForeColor = IntToColor(0xFFFF00);
            rtb_numerator.Styles[Style.Python.Default].ForeColor = IntToColor(0xFFFF00);
            rtb_numerator.Styles[Style.Python.DefName].ForeColor = IntToColor(0x4876FF);
            //参数
            rtb_numerator.Styles[Style.Python.Identifier].ForeColor = IntToColor(0xf7f6f6);
            rtb_numerator.Styles[Style.Python.Number].ForeColor = IntToColor(0xE0E0E0);
            //操作符
            rtb_numerator.Styles[Style.Python.Operator].ForeColor = IntToColor(0xe8d7d7);
            rtb_numerator.Styles[Style.Python.String].ForeColor = IntToColor(0x008B00);
            //注释
            rtb_numerator.Styles[Style.Python.StringEol].ForeColor = IntToColor(0x32CD32);
            rtb_numerator.Styles[Style.Python.Triple].ForeColor = IntToColor(0x11d211);
            rtb_numerator.Styles[Style.Python.TripleDouble].ForeColor = IntToColor(0xB3D991);
            //关键词
            rtb_numerator.Styles[Style.Python.Word].ForeColor = IntToColor(0x3d85c6);
            rtb_numerator.Lexer = Lexer.Python;

            rtb_numerator.SetKeywords(0, "def if elif class extends implements import interface new case do while else if for in switch throw get set function var try catch finally while with default break continue delete return each const namespace package include use is as instanceof typeof author copy default deprecated eventType example exampleText exception haxe inheritDoc internal link mtasc mxmlc param private return see serial serialData serialField since throws usage version langversion playerversion productversion dynamic private public partial static intrinsic internal native override protected AS3 final super this arguments null Infinity NaN undefined true false abstract as base bool break by byte case catch char checked class const continue decimal default delegate do double descending explicit event extern else enum false finally fixed float for foreach from goto group if implicit in int interface internal into is lock long new null namespace object operator out override orderby params private protected public readonly ref return switch struct sbyte sealed short sizeof stackalloc static string select this throw true try typeof uint ulong unchecked unsafe ushort using var virtual volatile void while where yield");
            rtb_numerator.SetKeywords(1, "void Null ArgumentError arguments Array Boolean Class Date DefinitionError Error EvalError Function int Math Namespace Number Object RangeError ReferenceError RegExp SecurityError String SyntaxError TypeError uint XML XMLList Boolean Byte Char DateTime Decimal Double Int16 Int32 Int64 IntPtr SByte Single UInt16 UInt32 UInt64 UIntPtr Void Path File System Windows Forms ScintillaNET");
            
            rtb_denominator.StyleResetDefault();
            rtb_denominator.Styles[Style.Default].Font = "Consolas";
            rtb_denominator.Styles[Style.Default].Size = 10;
            rtb_denominator.Styles[Style.Default].BackColor = IntToColor(0x212121);
            rtb_denominator.Styles[Style.Default].ForeColor = IntToColor(0xFFFFFF);
            rtb_denominator.StyleClearAll();


            rtb_denominator.Styles[Style.Python.Character].ForeColor = IntToColor(0xD0DAE2);
            //类名
            rtb_denominator.Styles[Style.Python.ClassName].ForeColor = IntToColor(0x3c78d8);
            rtb_denominator.Styles[Style.Python.CommentBlock].ForeColor = IntToColor(0x40BF57);
            rtb_denominator.Styles[Style.Python.CommentLine].ForeColor = IntToColor(0x2FAE35);
            rtb_denominator.Styles[Style.Python.Decorator].ForeColor = IntToColor(0xFFFF00);
            rtb_denominator.Styles[Style.Python.Default].ForeColor = IntToColor(0xFFFF00);
            rtb_denominator.Styles[Style.Python.DefName].ForeColor = IntToColor(0x4876FF);
            //参数
            rtb_denominator.Styles[Style.Python.Identifier].ForeColor = IntToColor(0xf7f6f6);
            rtb_denominator.Styles[Style.Python.Number].ForeColor = IntToColor(0xE0E0E0);
            //操作符
            rtb_denominator.Styles[Style.Python.Operator].ForeColor = IntToColor(0xe8d7d7);
            rtb_denominator.Styles[Style.Python.String].ForeColor = IntToColor(0x008B00);
            //注释
            rtb_denominator.Styles[Style.Python.StringEol].ForeColor = IntToColor(0x32CD32);
            rtb_denominator.Styles[Style.Python.Triple].ForeColor = IntToColor(0x11d211);
            rtb_denominator.Styles[Style.Python.TripleDouble].ForeColor = IntToColor(0xB3D991);
            //关键词
            rtb_denominator.Styles[Style.Python.Word].ForeColor = IntToColor(0x3d85c6);
            rtb_denominator.Lexer = Lexer.Python;

            rtb_denominator.SetKeywords(0, "def if elif class extends implements import interface new case do while else if for in switch throw get set function var try catch finally while with default break continue delete return each const namespace package include use is as instanceof typeof author copy default deprecated eventType example exampleText exception haxe inheritDoc internal link mtasc mxmlc param private return see serial serialData serialField since throws usage version langversion playerversion productversion dynamic private public partial static intrinsic internal native override protected AS3 final super this arguments null Infinity NaN undefined true false abstract as base bool break by byte case catch char checked class const continue decimal default delegate do double descending explicit event extern else enum false finally fixed float for foreach from goto group if implicit in int interface internal into is lock long new null namespace object operator out override orderby params private protected public readonly ref return switch struct sbyte sealed short sizeof stackalloc static string select this throw true try typeof uint ulong unchecked unsafe ushort using var virtual volatile void while where yield");
            rtb_denominator.SetKeywords(1, "void Null ArgumentError arguments Array Boolean Class Date DefinitionError Error EvalError Function int Math Namespace Number Object RangeError ReferenceError RegExp SecurityError String SyntaxError TypeError uint XML XMLList Boolean Byte Char DateTime Decimal Double Int16 Int32 Int64 IntPtr SByte Single UInt16 UInt32 UInt64 UIntPtr Void Path File System Windows Forms ScintillaNET");

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

        public EP_KPI_SET Model
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public static Color IntToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }
        private void InitNumberMargin()
        {

            rtb_numerator.Styles[Style.LineNumber].BackColor = IntToColor(BACK_COLOR);
            rtb_numerator.Styles[Style.LineNumber].ForeColor = IntToColor(FORE_COLOR);
            rtb_numerator.Styles[Style.IndentGuide].ForeColor = IntToColor(FORE_COLOR);
            rtb_numerator.Styles[Style.IndentGuide].BackColor = IntToColor(BACK_COLOR);
            var nums = rtb_numerator.Margins[NUMBER_MARGIN];
            nums.Width = 30;
            nums.Type = MarginType.Number;
            nums.Sensitive = true;
            nums.Mask = 0;
            rtb_numerator.MarginClick += TextArea_MarginClick;


            rtb_denominator.Styles[Style.LineNumber].BackColor = IntToColor(BACK_COLOR);
            rtb_denominator.Styles[Style.LineNumber].ForeColor = IntToColor(FORE_COLOR);
            rtb_denominator.Styles[Style.IndentGuide].ForeColor = IntToColor(FORE_COLOR);
            rtb_denominator.Styles[Style.IndentGuide].BackColor = IntToColor(BACK_COLOR);
            var nums2 = rtb_denominator.Margins[NUMBER_MARGIN];
            nums2.Width = 30;
            nums2.Type = MarginType.Number;
            nums2.Sensitive = true;
            nums2.Mask = 0;
            rtb_denominator.MarginClick += TextArea_MarginClick2;
        }
        private void TextArea_MarginClick(object sender, MarginClickEventArgs e)
        {
            if (e.Margin == BOOKMARK_MARGIN)
            {
                // Do we have a marker for this line?
                const uint mask = (1 << BOOKMARK_MARKER);
                var line = rtb_numerator.Lines[rtb_numerator.LineFromPosition(e.Position)];
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
        private void TextArea_MarginClick2(object sender, MarginClickEventArgs e)
        {
            if (e.Margin == BOOKMARK_MARGIN)
            {
                // Do we have a marker for this line?
                const uint mask = (1 << BOOKMARK_MARKER);
                var line = rtb_denominator.Lines[rtb_denominator.LineFromPosition(e.Position)];
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

            var margin = rtb_numerator.Margins[BOOKMARK_MARGIN];
            margin.Width = 20;
            margin.Sensitive = true;
            margin.Type = MarginType.Symbol;
            margin.Mask = (1 << BOOKMARK_MARKER);
            //margin.Cursor = MarginCursor.Arrow;

            var marker = rtb_numerator.Markers[BOOKMARK_MARKER];
            marker.Symbol = MarkerSymbol.Circle;
            marker.SetBackColor(IntToColor(0xFF003B));
            marker.SetForeColor(IntToColor(0x000000));
            marker.SetAlpha(100);
            
            var margin2 = rtb_denominator.Margins[BOOKMARK_MARGIN];
            margin2.Width = 20;
            margin2.Sensitive = true;
            margin2.Type = MarginType.Symbol;
            margin2.Mask = (1 << BOOKMARK_MARKER);
            //margin.Cursor = MarginCursor.Arrow;

            var marker2 = rtb_denominator.Markers[BOOKMARK_MARKER];
            marker2.Symbol = MarkerSymbol.Circle;
            marker2.SetBackColor(IntToColor(0xFF003B));
            marker2.SetForeColor(IntToColor(0x000000));
            marker2.SetAlpha(100);
        }

        private void InitCodeFolding()
        {

            rtb_numerator.SetFoldMarginColor(true, IntToColor(BACK_COLOR));
            rtb_numerator.SetFoldMarginHighlightColor(true, IntToColor(BACK_COLOR));

            // Enable code folding
            rtb_numerator.SetProperty("fold", "1");
            rtb_numerator.SetProperty("fold.compact", "1");

            // Configure a margin to display folding symbols
            rtb_numerator.Margins[FOLDING_MARGIN].Type = MarginType.Symbol;
            rtb_numerator.Margins[FOLDING_MARGIN].Mask = Marker.MaskFolders;
            rtb_numerator.Margins[FOLDING_MARGIN].Sensitive = true;
            rtb_numerator.Margins[FOLDING_MARGIN].Width = 20;

            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                rtb_numerator.Markers[i].SetForeColor(IntToColor(BACK_COLOR)); // styles for [+] and [-]
                rtb_numerator.Markers[i].SetBackColor(IntToColor(FORE_COLOR)); // styles for [+] and [-]
            }

            // Configure folding markers with respective symbols
            rtb_numerator.Markers[Marker.Folder].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlus : MarkerSymbol.BoxPlus;
            rtb_numerator.Markers[Marker.FolderOpen].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinus : MarkerSymbol.BoxMinus;
            rtb_numerator.Markers[Marker.FolderEnd].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlusConnected : MarkerSymbol.BoxPlusConnected;
            rtb_numerator.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            rtb_numerator.Markers[Marker.FolderOpenMid].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinusConnected : MarkerSymbol.BoxMinusConnected;
            rtb_numerator.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            rtb_numerator.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            rtb_numerator.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);

            rtb_denominator.SetFoldMarginColor(true, IntToColor(BACK_COLOR));
            rtb_denominator.SetFoldMarginHighlightColor(true, IntToColor(BACK_COLOR));

            // Enable code folding
            rtb_denominator.SetProperty("fold", "1");
            rtb_denominator.SetProperty("fold.compact", "1");

            // Configure a margin to display folding symbols
            rtb_denominator.Margins[FOLDING_MARGIN].Type = MarginType.Symbol;
            rtb_denominator.Margins[FOLDING_MARGIN].Mask = Marker.MaskFolders;
            rtb_denominator.Margins[FOLDING_MARGIN].Sensitive = true;
            rtb_denominator.Margins[FOLDING_MARGIN].Width = 20;

            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                rtb_denominator.Markers[i].SetForeColor(IntToColor(BACK_COLOR)); // styles for [+] and [-]
                rtb_denominator.Markers[i].SetBackColor(IntToColor(FORE_COLOR)); // styles for [+] and [-]
            }

            // Configure folding markers with respective symbols
            rtb_denominator.Markers[Marker.Folder].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlus : MarkerSymbol.BoxPlus;
            rtb_denominator.Markers[Marker.FolderOpen].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinus : MarkerSymbol.BoxMinus;
            rtb_denominator.Markers[Marker.FolderEnd].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlusConnected : MarkerSymbol.BoxPlusConnected;
            rtb_denominator.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            rtb_denominator.Markers[Marker.FolderOpenMid].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinusConnected : MarkerSymbol.BoxMinusConnected;
            rtb_denominator.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            rtb_denominator.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            rtb_denominator.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);

        }



        #endregion

        private void tv_dataItems_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Right|| e.Button == MouseButtons.Left)//判断你点的是不是右键
            {
                Point ClickPoint = new Point(e.X, e.Y);
                TreeNode CurrentNode = tv_dataItems.GetNodeAt(ClickPoint);
                if (CurrentNode != null)//判断你点的是不是一个节点
                {
                    tv_dataItems.SelectedNode = CurrentNode;//选中这个节点
                }
            }

        }

        private void gb_param_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Param)) == true)
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        public Point GetNextLocation()
        {
            int x = 10, y = 2;
            ucList.ForEach(
                r =>
                {
                    y = ucList.Count * 36;
                }
                );
            return new Point(x, y);
        }

        private void gb_param_DragDrop(object sender, DragEventArgs e)
        {
            Param p = (Param)(e.Data.GetData(typeof(Param)));
            ucDataItem uc = new ucDataItem(this, p);
            uc.Location = GetNextLocation();
            ucList.Add(uc);
            panel_param.Controls.Add(uc);
            DelDataItemRefresh();
            Invalidate();
        }

        private void tv_dataItems_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)) == true)
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void tv_dataItems_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                TreeNode node = tv_dataItems.SelectedNode;
                if (node != null)
                {
                    DoDragDrop((Param)node.Tag, DragDropEffects.All);
                }
            }
        }

        public void RemoveDataItem(ucDataItem uc)
        {
            ucList.Remove(uc);
            panel_param.Controls.Remove(uc);
            DelDataItemRefresh();
        }

        public void DelDataItemRefresh() {
            int x = 10, y = 2;
            ucList.ForEach(
                r =>
                {
                    y= ucList.IndexOf(r)* 36 ;
                    r.Location = new Point(x,y);
                }
                );
            Invalidate();
        }

        public void LoadKPIDataItem() {
            int x = 10, y = 2;
            ucList.ForEach(
                r =>
                {
                    y = ucList.IndexOf(r) * 36;
                    r.Location = new Point(x, y);
                    panel_param.Controls.Add(r);
                }
                );
            Invalidate();
        }

        private void frmCreateFormula_Load(object sender, EventArgs e)
        {
            InitKpiFormulaInfo(kpi.KPI_ID);
        }

        
        
        private void btn_test_Click(object sender, EventArgs e)
        {

            try
            {
                callback.log(controller.CheckFormula(TempScript, ParamList).Item1);
            }
            catch (Exception ex)
            {
                callback.log(ex.ToString());
            }
            
        }
    }
}
