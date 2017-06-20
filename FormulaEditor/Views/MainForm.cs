using FormulaEditor.Core;
using FormulaEditor.Core.Interfaces;
using FormulaEditor.Model;
using FormulaEditor.utils;
using FormulaEditor.Views;
using ScintillaNET;
using ScintillaNET.Demo.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FormulaEditor
{
    public partial class MainForm : Form, ICallBack, ICanInitKPIDict, ICanShowKpiScript, ICanShowKPIResult
    {
        IKPI controller;
        KPINode currentKpi;
        public Scintilla TextArea;

        public MainForm()
        {
            InitializeComponent();
            controller =new KPIByWebApiController(this);
            TextArea = new CodEditor(TextPanel, cms_code_manager).TextArea;
            controller.ShowKPIDict();
        }

        private void debug_pyfile_Click(object sender, EventArgs e)
        {
            try
            {
                frmTest frm = new frmTest(this);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                log(ex.ToString());
            }
            
        }

        private void tv_singal_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (tv_singal.SelectedNode.Nodes.Count == 0
                    &&  tv_singal.SelectedNode.Tag!=null)
                {
                    currentKpi = tv_singal.SelectedNode.Tag as KPINode;
                    TextArea.Text = currentKpi.ScriptString; 
                }
            }
            catch (Exception ex)
            {
                log(ex.ToString());
            }
            
        }

        private void create_fun_Click(object sender, EventArgs e)
        {
            frmCreateFormula frm = new frmCreateFormula(this,currentKpi);
            frm.ShowDialog();
            
        }

        private void cms_zb_manager_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //只有叶子节点才可以编辑指标算法
            if (tv_singal.SelectedNode != null
                && tv_singal.SelectedNode.Nodes.Count == 0)
            {
                新建ToolStripMenuItem.Enabled = true;
            }
            else
            {
                新建ToolStripMenuItem.Enabled = false;
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            TextPanel.Controls.Add(this.TextArea);
        }

        public void CallBackParams(List<Param> list)
        {
            UsingPython python = new UsingPython(currentKpi);
            log(python.ExcuteScriptFile(list).ToString());
        }

        public void InitKPIDict(List<KPINode> list)
        {
            TreeNode rootNode = null;
            TreeNode typeNode = null;
            foreach (var item in list)
            {
                if (!tv_singal.Nodes.ContainsKey(item.SD_CODE))
                {
                    rootNode = new TreeNode(item.SD_CODE);
                    rootNode.Name = item.SD_CODE;
                    tv_singal.Nodes.Add(rootNode);
                }
                if (!rootNode.Nodes.ContainsKey(item.KPI_TYPE_CODE))
                {
                    typeNode = new TreeNode(item.KPI_TYPE_CODE);
                    typeNode.Name = item.KPI_TYPE_CODE;
                    rootNode.Nodes.Add(typeNode);
                }
                if (typeNode != null)
                {
                    TreeNode kpiNode = new TreeNode(item.KPI_NAME);
                    kpiNode.Name = item.KPI_ID.ToString();
                    kpiNode.Tag = item;
                    if (item.Status == null||item.Status==1)
                    {
                        kpiNode.ForeColor = Color.Green;
                    }
                    else
                    {
                        kpiNode.ForeColor = Color.Red;
                    }
                    //kpiNode.ImageIndex = item.Status == null ? 1 : (int)item.Status;
                    typeNode.Nodes.Add(kpiNode);
                }
            }
        }

        private void tv_singal_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)//判断你点的是不是右键
            {
                Point ClickPoint = new Point(e.X, e.Y);
                TreeNode CurrentNode = tv_singal.GetNodeAt(ClickPoint);
                if (CurrentNode != null)//判断你点的是不是一个节点
                {
                    tv_singal.SelectedNode = CurrentNode;//选中这个节点
                }
            }
        }

        
        
        public void log(string msg)
        {
            rtb_log.Text = string.Format("{0} : {1}\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), msg) + rtb_log.Text;

        }

        private void rUN_KPI_Click(object sender, EventArgs e)
        {
            new RunKPIController(this).Run("YXA", new List<string>() { "16391862" });
        }

        public void ShowKpiScript(string script)
        {
            try
            {
                if (tv_singal.SelectedNode.Nodes.Count == 0)
                {
                    TextArea.Text = script;
                }
            }
            catch (Exception ex)
            {
                log(ex.ToString());
            }
        }

        public void RefreshKpiScript(int kpiid)
        {
            controller.RefreshKpiScript(kpiid);
        }

        public void ShowKPIResult(string result)
        {
            log(result);
        }
    }
}
