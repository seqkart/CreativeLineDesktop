using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmVehicleAddEdit : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String VehicleCode { get; set; }
        public frmVehicleAddEdit()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            txtVehicleDesc.Properties.MaxLength = 50;
            txtRegNo.Properties.MaxLength = 15;
        }
        private void frmVehicleAddEdit_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtVehicleDesc.Focus();
                txtVehicleCode.Text = GetNewVehicleCode().PadLeft(4, '0');
            }
            if (s1 == "Edit")
            {
                txtRegNo.Enabled = false;
                DataSet ds = ProjectFunctions.GetDataSet("SELECT VehicleCode,VehicleDesc,VehicleRegNo,VehicleCrates FROM VehicleMst Where VehicleCode='" + VehicleCode + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtVehicleCode.Text = ds.Tables[0].Rows[0]["VehicleCode"].ToString();
                    txtVehicleDesc.Text = ds.Tables[0].Rows[0]["VehicleDesc"].ToString();
                    txtRegNo.Text = ds.Tables[0].Rows[0]["VehicleRegNo"].ToString();

                    txtCrates.Text = ds.Tables[0].Rows[0]["VehicleCrates"].ToString();

                    txtVehicleDesc.Focus();
                }
            }
        }
        private bool ValidateData()
        {
            if (txtVehicleCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Vehicle Code");
                txtVehicleCode.Focus();
                return false;
            }
            if (txtVehicleDesc.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Vehicle Description");
                txtVehicleDesc.Focus();
                return false;
            }
            if (txtRegNo.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Vehicle Reg No");
                txtRegNo.Focus();
                return false;
            }
            if (txtCrates.Text.Trim().Length == 0)
            {
                txtCrates.Text = "0";
            }
            return true;
        }

        private void frmVehicleAddEdit_KeyDown(object sender, KeyEventArgs e)
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
        private string GetNewVehicleCode()
        {
            String s2 = String.Empty;
            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(VehicleCode as int)),00000) from VehicleMst");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString();
                s2 = (Convert.ToInt32(s2) + 1).ToString();
            }
            return s2;
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
                                                    + " Insert into VehicleMst"
                                                    + " (VehicleCode,VehicleDesc,VehicleRegNo,VehicleCrates)"
                                                    + " values((SELECT RIGHT('0000'+ CAST( ISNULL( max(Cast(VehicleCode as int)),0)+1 AS VARCHAR(4)),4)from VehicleMst),@VehicleDesc,@VehicleRegNo,@VehicleCrates)"
                                                    + " Commit ";
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE VehicleMst SET "
                                                + " VehicleDesc=@VehicleDesc,VehicleRegNo=@VehicleRegNo,VehicleCrates=@VehicleCrates "
                                                + " Where VehicleCode=@VehicleCode";

                        }
                        sqlcom.Parameters.AddWithValue("@VehicleCode", txtVehicleCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@VehicleDesc", txtVehicleDesc.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@VehicleRegNo", txtRegNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@VehicleCrates", txtCrates.Text.Trim());
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

        private void txtCrates_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }
    }
}