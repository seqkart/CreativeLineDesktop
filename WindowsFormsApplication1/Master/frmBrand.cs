using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmBrand : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String BrandCode { get; set; }
        public frmBrand()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            try
            {
                ProjectFunctions.TextBoxVisualize(this);
                ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
                txtBrandName.Properties.MaxLength = 55;
                txtBrandAlias.Properties.MaxLength = 55;
                txtSysID.Enabled = false;
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }
        private void FrmBrand_Load(object sender, EventArgs e)
        {
            try
            {
                SetMyControls();
                if (s1 == "&Add")
                {
                    txtBrandName.Focus();
                }
                if (s1 == "Edit")
                {
                    DataSet ds = ProjectFunctions.GetDataSet("SELECT * FROM BRANDS Where BRSYSID='" + BrandCode + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtSysID.Text = ds.Tables[0].Rows[0]["BRSYSID"].ToString();
                        txtBrandName.Text = ds.Tables[0].Rows[0]["BRNAME"].ToString();
                        txtBrandAlias.Text = ds.Tables[0].Rows[0]["BRALIAS"].ToString();
                        txtBrandName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }
        private bool ValidateData()
        {
            try
            {
                if (txtBrandName.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid Brand Name");
                    txtBrandName.Focus();
                    return false;
                }
                if (txtBrandAlias.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid Brand Alias");
                    txtBrandAlias.Focus();
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
                return false;
            }
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
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
                            sqlcom.CommandText = " Insert into BRANDS"
                                                    + " (BRNAME,BRALIAS)values(@BRNAME,@BRALIAS)";

                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE BRANDS SET "
                                                + " BRNAME=@BRNAME,BRALIAS=@BRALIAS"
                                                + " Where BRSYSID=@BRSYSID";
                            sqlcom.Parameters.AddWithValue("@BRSYSID", txtSysID.Text.Trim());

                        }
                        sqlcom.Parameters.AddWithValue("@BRNAME", txtBrandName.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@BRALIAS", txtBrandAlias.Text.Trim());
                        sqlcom.ExecuteNonQuery();
                        transaction.Commit();
                        sqlcon.Close();
                        ProjectFunctions.SpeakError("Brand Data Saved Successfully");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        ProjectFunctions.SpeakError("Something Wrong. \n I am going to Roll Back." + ex.Message);
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception ex2)
                        {
                            ProjectFunctions.SpeakError("Something Wrong. \n Roll Back Failed." + ex2.Message);
                        }
                    }
                }
            }
        }

        private void FrmBrand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                System.Windows.Forms.SendKeys.Send("+{TAB}");
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}