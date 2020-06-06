using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmSizeMMaster : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String SZSYSID { get; set; }
        public frmSizeMMaster()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            txtDescription.Properties.MaxLength = 55;
            txtSizeName.Properties.MaxLength = 15;
            txtSysID.Enabled = false;
        }
        private bool ValidateData()
        {
            if (txtSizeName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Size Name");
                txtSizeName.Focus();
                return false;
            }
            if (txtDescription.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Size Description");
                txtDescription.Focus();
                return false;
            }
            if (txtIndex.Text.Trim().Length == 0)
            {
                txtIndex.Text = "0";
            }
            return true;
        }
        private void FrmSizeMMaster_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtSizeName.Focus();
            }
            if (s1 == "Edit")
            {
                DataSet ds = ProjectFunctions.GetDataSet("SELECT * FROM SIZEMAST Where SZSYSID='" + SZSYSID + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtSysID.Text = ds.Tables[0].Rows[0]["SZSYSID"].ToString();
                    txtSizeName.Text = ds.Tables[0].Rows[0]["SZNAME"].ToString();
                    txtDescription.Text = ds.Tables[0].Rows[0]["SZDESC"].ToString();
                    txtIndex.Text = ds.Tables[0].Rows[0]["SZINDEX"].ToString();
                    txtSizeName.Focus();
                }
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
                            sqlcom.CommandText = " Insert into SIZEMAST"
                                                    + " (SZNAME,SZINDEX,SZDESC)values(@SZNAME,@SZINDEX,@SZDESC)";

                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE SIZEMAST SET "
                                                + " SZNAME=@SZNAME,SZINDEX=@SZINDEX,SZDESC=@SZDESC"
                                                + " Where SZSYSID=@SZSYSID";
                            sqlcom.Parameters.AddWithValue("@SZSYSID", txtSysID.Text.Trim());

                        }
                        sqlcom.Parameters.AddWithValue("@SZDESC", txtDescription.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@SZNAME", txtSizeName.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@SZINDEX", Convert.ToDecimal(txtIndex.Text));
                        sqlcom.ExecuteNonQuery();
                        transaction.Commit();
                        sqlcon.Close();

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

        private void FrmSizeMMaster_KeyDown(object sender, KeyEventArgs e)
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