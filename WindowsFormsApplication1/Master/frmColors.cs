using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmColors : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String COLSYSID { get; set; }
        public frmColors()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.DatePickerVisualize(this);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            txtColorCode.Properties.MaxLength = 25;
            txtColorName.Properties.MaxLength = 25;

            txtSysColorID.Enabled = false;

        }
        private void BtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmColors_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtColorCode.Focus();
            }
            if (s1 == "Edit")
            {
                txtSysColorID.Enabled = false;
                DataSet ds = ProjectFunctions.GetDataSet("Select * from COLOURS Where COLSYSID= '" + COLSYSID + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtSysColorID.Text = ds.Tables[0].Rows[0]["COLSYSID"].ToString();
                    txtColorCode.Text = ds.Tables[0].Rows[0]["COLCODE"].ToString();
                    txtColorName.Text = ds.Tables[0].Rows[0]["COLNAME"].ToString();


                }
                txtColorCode.Focus();
            }
        }
        private bool ValidateData()
        {
            if (txtColorCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Para1Code");
                txtColorCode.Focus();
                return false;
            }
            if (txtColorName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Para1Name");
                txtColorName.Focus();
                return false;
            }

            return true;
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
                            sqlcom.CommandText = " Insert into COLOURS"
                                                 + " (COLNAME, COLCODE)"
                                                 + " values(@COLNAME, @COLCODE)";



                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE COLOURS SET "
                                                + " COLNAME=@COLNAME,COLCODE=@COLCODE "
                                                + " Where COLSYSID=@COLSYSID";
                            sqlcom.Parameters.AddWithValue("@COLSYSID", txtSysColorID.Text.Trim());
                        }

                        sqlcom.Parameters.AddWithValue("@COLCODE    ", txtColorCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COLNAME", txtColorName.Text.Trim());

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

        private void FrmColors_KeyDown(object sender, KeyEventArgs e)
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