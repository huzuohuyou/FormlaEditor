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
    public partial class frmCreateFormula : Form, ICanClear, ICanInitDataItemDict, ICanInitKPIParam,ICanInitFormulaBody, ICanShowSaveResult
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

        IFormula controller;
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
            controller = new FormulaByWebApiController(this);
            controller.ShowDataItemDict(kpi.SD_CODE);
            controller.ShowKPIForParams(kpi.KPI_ID);
            controller.ShowKPIForBody(kpi.KPI_ID);

            rtb_numerator = new CodEditor(gb_fz, null).TextArea;
            rtb_denominator = new CodEditor(gb_fm, null).TextArea;
            panel_param.VerticalScroll.Visible = true;
            panel_param.AutoScroll = true;
        }

        public void InitFormulaBody(FormulaBody eks)
        {
            rtb_denominator.Text = eks?.FenMu;
            rtb_numerator.Text = eks?.FenZi ;
            rtb_note.Text = eks?.Note;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                Tuple<string,bool> checkInfo=controller.CheckFormula(TempScript, ParamList);
                if (checkInfo.Item2)
                {
                    List<Param> list = new List<Param>();
                    ucList.ForEach(r =>
                    {
                        r.param.KPIId = kpi.KPI_ID;
                        list.Add(r.param);
                    }
                    );
                    controller.SavaFormulaBody(new FormulaBody() { KPIId = kpi?.KPI_ID.ToString(), Note = rtb_note.Text.Trim(), FenMu = rtb_denominator.Text.Trim(), FenZi = rtb_numerator.Text.Trim() });


                    controller.SaveFormulaParam(list);
                    callback.RefreshKpiScript(kpi.KPI_ID);
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

        public void InitDataItemDict(List<Param> list)
        {
            try
            {
                TreeNode typeNode = null;
                list.ForEach(r =>
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

        public void InitKPIParam(List<Param> list)
        {
            list.ForEach(
                r =>
                {
                    ucList.Add(new ucDataItem(this, r));
                }
                );
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

        

        public void ShowResult(string msg)
        {
            callback.log(msg);
        }
    }
}
