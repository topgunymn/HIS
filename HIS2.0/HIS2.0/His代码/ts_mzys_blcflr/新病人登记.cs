using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenFrame.Forms;

namespace ts_mzys_blcflr
{
    public partial class Frmbrxx : Form
    {

        private Guid Brxxid = Guid.Empty;
        private Guid Kdjid = Guid.Empty;
        private string FunctionName = "";

        public string ReturnMzh = "";
        public Frmbrxx(string _FunctionName, Guid brxxid, Guid kdjid)
        {
            InitializeComponent();
            Brxxid = brxxid;
            Kdjid = kdjid;
            FunctionName = _FunctionName;

            if (kdjid != Guid.Empty)
            {
                string ssql = "select * from yy_kdjb where kdjid='" + kdjid + "'";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tb.Rows.Count > 0)
                {
                    lblklx.Text = Fun.SeekKlxmc(Convert.ToInt32(tb.Rows[0]["KLX"]), InstanceForm.BDatabase);
                    lblkh.Text = tb.Rows[0]["KH"].ToString();
                }
            }

            if (brxxid == Guid.Empty)
            {
                this.Text = "登记新病人";
                txtbrxm.Enabled = true;
            }
            else
            {
                string ssql = "select *,dbo.fun_zy_age(csrq,3,getdate()) nl from vi_yy_brxx where brxxid='" + brxxid + "'";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tb.Rows.Count > 0)
                {
                    txtbrxm.Text = Convertor.IsNull(tb.Rows[0]["brxm"], "");
                    cmbxb.Text = Convertor.IsNull(tb.Rows[0]["xb"], "");
                    txtnl.Text = Convertor.IsNull(tb.Rows[0]["nl"], "");
                    dtpcsrq.Value = Convert.ToDateTime(tb.Rows[0]["csrq"]);
                    txtcsdz.Text = Convertor.IsNull(tb.Rows[0]["csdz"], "");
                    txtjtdz.Text = Convertor.IsNull(tb.Rows[0]["jtdz"], "");
                    txtjtdh.Text = Convertor.IsNull(tb.Rows[0]["jtdh"], "");
                    txtbrlxfs.Text = Convertor.IsNull(tb.Rows[0]["brlxfs"], "");
                    txtdzyj.Text = Convertor.IsNull(tb.Rows[0]["dzyj"], "");
                    txtgzdw.Text = Convertor.IsNull(tb.Rows[0]["gzdw"], "");
                    txtdwdh.Text = Convertor.IsNull(tb.Rows[0]["gzdwdh"], "");
                    txtsfzh.Text = Convertor.IsNull(tb.Rows[0]["sfzh"], "");
                    cmbxb.SelectedValue = Convertor.IsNull(tb.Rows[0]["xb"], "");

                    txtbrxm.Enabled = false;
                    cmbxb.Enabled = false;
                    txtnl.Enabled = false;
                    dtpcsrq.Enabled = false;
                    txtcsdz.Enabled = false;
                    txtjtdz.Enabled = false;
                    txtjtdh.Enabled = false;
                    txtbrlxfs.Enabled = false;
                    txtdzyj.Enabled = false;
                    txtgzdw.Enabled = false;
                    txtdwdh.Enabled = false;
                    txtsfzh.Enabled = false;
                }
                this.Text = "无号登记";
                txtbrxm.Enabled = false;
            }
             
        }
        public Frmbrxx(string _FunctionName, Guid brxxid, Guid kdjid,string Sfshow)
        {
            InitializeComponent();
            Brxxid = brxxid;
            Kdjid = kdjid;
            FunctionName = _FunctionName;

            if (kdjid != Guid.Empty)
            {
                string ssql = "select * from yy_kdjb where kdjid='" + kdjid + "'";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tb.Rows.Count > 0)
                {
                    lblklx.Text = Fun.SeekKlxmc(Convert.ToInt32(tb.Rows[0]["KLX"]), InstanceForm.BDatabase);
                    lblkh.Text = tb.Rows[0]["KH"].ToString();
                }
            }

            if (brxxid == Guid.Empty)
            {
                this.Text = "登记新病人";
                txtbrxm.Enabled = true;
            }
            else
            {
                string ssql = "select *,dbo.fun_zy_age(csrq,3,getdate()) nl from vi_yy_brxx where brxxid='" + brxxid + "'";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tb.Rows.Count > 0)
                {
                    txtbrxm.Text = Convertor.IsNull(tb.Rows[0]["brxm"], "");
                    cmbxb.Text = Convertor.IsNull(tb.Rows[0]["xb"], "");
                    txtnl.Text = Convertor.IsNull(tb.Rows[0]["nl"], "");
                    dtpcsrq.Value = Convert.ToDateTime(tb.Rows[0]["csrq"]);
                    txtcsdz.Text = Convertor.IsNull(tb.Rows[0]["csdz"], "");
                    txtjtdz.Text = Convertor.IsNull(tb.Rows[0]["jtdz"], "");
                    txtjtdh.Text = Convertor.IsNull(tb.Rows[0]["jtdh"], "");
                    txtbrlxfs.Text = Convertor.IsNull(tb.Rows[0]["brlxfs"], "");
                    txtdzyj.Text = Convertor.IsNull(tb.Rows[0]["dzyj"], "");
                    txtgzdw.Text = Convertor.IsNull(tb.Rows[0]["gzdw"], "");
                    txtdwdh.Text = Convertor.IsNull(tb.Rows[0]["gzdwdh"], "");
                    txtsfzh.Text = Convertor.IsNull(tb.Rows[0]["sfzh"], "");

                    txtbrxm.Enabled = false;
                    cmbxb.Enabled = false;
                    txtnl.Enabled = false;
                    dtpcsrq.Enabled = false;
                    txtcsdz.Enabled = false;
                    txtjtdz.Enabled = false;
                    txtjtdh.Enabled = false;
                    txtbrlxfs.Enabled = false;
                    txtdzyj.Enabled = false;
                    txtgzdw.Enabled = false;
                    txtdwdh.Enabled = false;
                    txtsfzh.Enabled = false;
                }
                this.Text = "无号登记";
                txtbrxm.Enabled = false;
            }
            Frmhjsf_Load(null, null);
        }

        private void Frmhjsf_Load(object sender, EventArgs e)
        {
            //年龄单位
            DataTable tb = new DataTable();
            tb.Columns.Add("ID", Type.GetType("System.Int32"));
            tb.Columns.Add("NAME", Type.GetType("System.String"));
            DataRow row = tb.NewRow();
            row["ID"] = 0;
            row["NAME"] = "岁";
            tb.Rows.Add(row);
            row = tb.NewRow();
            row["ID"] = 1;
            row["NAME"] = "月";
            tb.Rows.Add(row);
            row = tb.NewRow();
            row["ID"] = 2;
            row["NAME"] = "天";
            tb.Rows.Add(row);
            row = tb.NewRow();
            row["ID"] = 3;
            row["NAME"] = "小时";
            tb.Rows.Add(row);
            cmbDW.DisplayMember = "NAME";
            cmbDW.ValueMember = "ID";
            cmbDW.DataSource = tb;
            cmbDW.SelectedIndex = 0;

            //ini文件读取
            string Bxm = ApiFunction.GetIniString("划价收费", "姓名处停留", Constant.ApplicationDirectory + "//ClientWindow.ini");
            FunAddComboBox.Addxb(false, cmbxb, InstanceForm.BDatabase);
        }

        public  void butsave_Click(object sender, EventArgs e)
        {

            try
            {
                string Stime = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd");
                string Etime = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd");
                //Add By Zj 2012-05-04
                string sqlcount = " select count(*) from mz_ghxx where djy=" + InstanceForm.BCurrentUser.EmployeeId + " and ghsj>='" + Stime + " 00:00:00' and ghsj<='" + Etime + " 23:59:59' ";
                int resultcount = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult(sqlcount));
                SystemCfg cfg3037 = new SystemCfg(3037);
                if (cfg3037.Config != "0")
                {
                    if (resultcount >= Convert.ToInt32(cfg3037.Config))
                    {
                        MessageBox.Show("由于系统限制,您不能再无号接诊病人,请让病人挂号!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                //修改病人姓名
                if (Brxxid != Guid.Empty)
                {
                    string ssql = "select brxm from yy_brxx where brxxid='" + Brxxid + "'";
                    string brxm = InstanceForm.BDatabase.GetDataTable(ssql).Rows[0][0].ToString();

                    if (txtbrxm.Text.Trim() != brxm.Trim())
                        Brxxid = Guid.Empty;
                }


                Guid _NewBrxxID = Guid.Empty;
                Guid _NewGhxxID = Guid.Empty;
                int _PDXH = 0;
                int err_code = -1;
                string err_text = "";

                InstanceForm.BDatabase.BeginTransaction();

                //病人信息保存
                if (Brxxid == Guid.Empty)
                {
                    if (txtbrxm.Text.Trim() == "")
                        throw new Exception("请输入病人姓名");
                    if (rdonl.Checked == true && txtnl.Text.Trim() == "")
                    {
                        throw new Exception("请输入病人年龄");
                    }

                    YY_BRXX.BrxxDj(Guid.Empty,
                        txtbrxm.Text.Trim(),
                        Convertor.IsNull(cmbxb.SelectedValue, "9"),
                        dtpcsrq.Value.ToShortDateString(),
                        "", "", "", "",
                        txtcsdz.Text.Trim(), txtjtdz.Text.Trim(), "", txtjtdh.Text.Trim(), "", txtbrlxfs.Text.Trim(), txtdzyj.Text.Trim(), txtgzdw.Text.Trim(), "", "", txtdwdh.Text.Trim(), "", txtsfzh.Text.Trim(), 0, 0, "", InstanceForm.BCurrentUser.EmployeeId, 0, out _NewBrxxID, out err_code, out err_text, InstanceForm.BDatabase);
                    if (_NewBrxxID == Guid.Empty || err_code != 0) throw new Exception(err_text);
                }
                else
                    _NewBrxxID = Brxxid;
                string Mzh = Fun.GetNewMzh(InstanceForm.BDatabase);

                int DocTypeId = 0;
                try
                {
                    Doctor doc = new Doctor(InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BDatabase);
                    DocTypeId = Convert.ToInt32(doc.TypeID);
                }
                catch (System.Exception err)
                {

                }

                int ghlx = 1;
                string djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                if (InstanceForm.BCurrentDept.Jz_Flag == 1)
                    ghlx = 2;
                //挂号信息保存
                mz_ghxx.GhxxDj(Guid.Empty, _NewBrxxID, ghlx, Kdjid, Mzh.Trim(), InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, DocTypeId,
                    0, InstanceForm.BCurrentUser.EmployeeId, 0, "", ref _PDXH, 0, "", TrasenFrame.Forms.FrmMdiMain.Jgbm, out _NewGhxxID, out err_code, out err_text, 0, 0, 0, "", "", "", 0, "", "", djsj, InstanceForm.BDatabase);
                if (_NewGhxxID == Guid.Empty || err_code != 0) throw new Exception(err_text);

                InstanceForm.BDatabase.CommitTransaction();

                ReturnMzh = Mzh;
                this.Close();
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar == 13)
            {
                //this.SelectNextControl(control, true,false, false,false);
                if (control.Name == "txtsfzh")
                    butsave.Focus();
                else
                    SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void rdocsrq_CheckedChanged(object sender, EventArgs e)
        {
            txtnl.Enabled = rdonl.Checked == true ? true : false;
            dtpcsrq.Enabled = rdocsrq.Checked == true ? true : false;
        }

        private void txtnl_Leave(object sender, EventArgs e)
        {
            //string ss = txtnl.Text;
            //ss = ss.Replace("岁", "");
            //ss = ss.Replace("月", "");
            //ss = ss.Replace("天", "");
            //if (txtnl.Text.Trim() != "" && Convertor.IsNumeric(ss) == false)
            //{
            //    MessageBox.Show("年龄请输入数字");
            //    return;
            //}
            //if (txtnl.Text.Trim() != "" && txtnl.Text.Contains("岁") == false && txtnl.Text.Contains("月") == false && txtnl.Text.Contains("天") == false)
            //{
            //    DateTime date = DateManager.AgeToDate(new Age(Convert.ToInt32(ss), AgeUnit.岁), InstanceForm.BDatabase);
            //    dtpcsrq.Value = date;
            //}
            //if (txtnl.Text.Trim() != "" && Convertor.IsNumeric(ss) == true && txtnl.Text.Contains("岁") == true)
            //{
            //    DateTime date = DateManager.AgeToDate(new Age(Convert.ToInt32(ss), AgeUnit.岁), InstanceForm.BDatabase);
            //    dtpcsrq.Value = date;
            //}
            if (txtnl.Text.Trim() != "" && Convertor.IsNumeric(txtnl.Text) == false)
            {
                MessageBox.Show("年龄请输入数字");
                return;
            }
            if (txtnl.Text.Trim() != "")
                dtpcsrq.Value = DateManager.AgeToDate(new Age(Convert.ToInt16(txtnl.Text), (AgeUnit)cmbDW.SelectedIndex), InstanceForm.BDatabase);
            else
                dtpcsrq.Value = DateManager.ServerDateTimeByDBType(TrasenFrame.Forms.FrmMdiMain.Database);
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frmbrxx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                txtnl_Leave(sender, e);
                butsave_Click(sender, e);
            }
        }

        private void dtpcsrq_ValueChanged(object sender, EventArgs e)
        {
            //txtnl.Text = DateManager.DateToAge(dtpcsrq.Value, InstanceForm.BDatabase).AgeNum.ToString() + DateManager.DateToAge(dtpcsrq.Value, InstanceForm.BDatabase).Unit.ToString();
            SetNlControl(dtpcsrq.Value);
        }

        private void SetNlControl(DateTime csrq)
        {
            Age age = DateManager.DateToAge(csrq, InstanceForm.BDatabase);
            txtnl.Text = age.AgeNum.ToString();
            cmbDW.SelectedIndex = (int)age.Unit;
        }

        private void txtnl_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == 39 || (int)e.KeyCode == 40)
            {
                rdocsrq.Checked = true;
                dtpcsrq.Focus();
            }
        }


    }
}