using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Master
{
    public partial class frmCategoryMst : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String CatgCode { get; set; }
        public frmCategoryMst()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);

            txtCatgDesc.Properties.MaxLength = 100;

            txtCatgCode.Enabled = false;
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string GetNewDesgCode()
        {

            String s2 = String.Empty;
            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(CatgCode as int)),00000) from CatgMst");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString();
                s2 = (Convert.ToInt32(s2) + 1).ToString();
            }
            return s2;

        }
        private bool ValidateData()
        {
            if (txtCatgCode.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Invalid Category Code", "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtCatgCode.Focus();
                return false;
            }
            if (txtCatgDesc.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Invalid Category Description", "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtCatgDesc.Focus();
                return false;
            }

            return true;
        }
        private void frmCategoryMst_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtCatgDesc.Focus();
                txtCatgCode.Text = GetNewDesgCode().PadLeft(4, '0');
            }
            if (s1 == "Edit")
            {
                //txtCatgDesc.Enabled = false;
                DataSet ds = ProjectFunctions.GetDataSet("SELECT CatgCode,CatgDesc FROM CatgMst Where CatgCode='" + CatgCode + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtCatgCode.Text = ds.Tables[0].Rows[0]["CatgCode"].ToString();
                    txtCatgDesc.Text = ds.Tables[0].Rows[0]["CatgDesc"].ToString();
                    txtCatgDesc.Focus();
                }
            }
        }

        private void windowsUIButtonPanelMain_ButtonClick(object sender, ButtonEventArgs e)
        {

        }

        private void frmCategoryMst_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                System.Windows.Forms.SendKeys.Send("+{TAB}");
            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                btnSave_Click(null, e);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave_Click_1();

        }
        private void btnSave_Click_1()
        {
            if (ValidateData())
            {
                using (var sqlcon = new SqlConnection(ProjectFunctions.GetConnection()))
                {
                    sqlcon.Open();
                    var sqlcom = sqlcon.CreateCommand();
                    var transaction = sqlcon.BeginTransaction("SaveTransaction");
                    sqlcom.Connection = sqlcon;
                    sqlcom.Transaction = transaction;
                    sqlcom.CommandType = CommandType.Text;
                    try
                    {
                        if (s1 == "&Add")
                        {
                            sqlcom.CommandText = " SET TRANSACTION ISOLATION LEVEL SERIALIZABLE  Begin Transaction "
                                                    + " Insert into CatgMst"
                                                    + " (CatgCode,CatgDesc)"
                                                    + " values((SELECT RIGHT('0000'+ CAST( ISNULL( max(Cast(CatgCode as int)),0)+1 AS VARCHAR(4)),4)from CatgMst),@CatgDesc)"
                                                    + " Commit ";
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE CatgMst SET "
                                                + " CatgDesc=@CatgDesc"
                                                + " Where CatgCode=@CatgCode";

                        }
                        sqlcom.Parameters.AddWithValue("@CatgCode", txtCatgCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@CatgDesc", txtCatgDesc.Text.Trim());
                        sqlcom.ExecuteNonQuery();
                        transaction.Commit();
                        sqlcon.Close();
                        ProjectFunctions.SpeakError("Data Saved Successfully");



                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Something Wrong. \n I am going to Roll Back." + ex.Message, ex.GetType().ToString());
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception ex2)
                        {
                            XtraMessageBox.Show("Something Wrong. \n Roll Back Failed." + ex2.Message, ex2.GetType().ToString());
                        }
                    }
                }
            }
        }
    }
}