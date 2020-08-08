using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class frmUOMAddEdit : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String UomCode { get; set; }
        public frmUOMAddEdit()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);

            txtUnitDesc.Properties.MaxLength = 20;
            txtUnitCode.Enabled = false;
        }
        private void frmUnitAddEdit_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtUnitDesc.Focus();
                txtUnitCode.Text = GetNewUnitCode().PadLeft(4, '0');
            }
            if (s1 == "Edit")
            {
                txtUnitDesc.Enabled = false;
                DataSet ds = ProjectFunctions.GetDataSet("SELECT UomCode,UomDesc FROM UomMst Where UomCode='" + UomCode + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtUnitCode.Text = ds.Tables[0].Rows[0]["UomCode"].ToString();
                    txtUnitDesc.Text = ds.Tables[0].Rows[0]["UomDesc"].ToString();
                    txtUnitCode.Focus();
                }
            }
        }
        private bool ValidateData()
        {
            if (txtUnitCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Unit Code");
                txtUnitCode.Focus();
                return false;
            }
            if (txtUnitDesc.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Unit Description");
                txtUnitDesc.Focus();
                return false;
            }

            return true;
        }
        private string GetNewUnitCode()
        {
            String s2 = String.Empty;
            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(UomCode as int)),00000) from UomMst");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString();
                s2 = (Convert.ToInt32(s2) + 1).ToString();
            }
            return s2;
        }
        private void frmUnitAddEdit_KeyDown(object sender, KeyEventArgs e)
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

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
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
                                                    + " Insert into UomMst"
                                                    + " (UomCode,UomDesc)"
                                                    + " values((SELECT RIGHT('0000'+ CAST( ISNULL( max(Cast(UomCode as int)),0)+1 AS VARCHAR(4)),4)from UomMst),@UomDesc)"
                                                    + " Commit ";
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE UomMst SET "
                                                + " UomDesc=@UomDesc "
                                                + " Where UomCode=@UomCode";

                        }
                        sqlcom.Parameters.AddWithValue("@UomCode", txtUnitCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@UomDesc", txtUnitDesc.Text.Trim());
                        sqlcom.ExecuteNonQuery();
                        transaction.Commit();
                        sqlcon.Close();
                        ProjectFunctions.SpeakError("Data Saved Successfully");
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
    }
}