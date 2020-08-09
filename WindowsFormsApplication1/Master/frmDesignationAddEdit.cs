using DevExpress.XtraEditors;
using SeqKartLibrary;
using SeqKartLibrary.CrudTask;
using System;
using System.Data;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public partial class frmDesignationAddEdit : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String DesgCode { get; set; }
        public frmDesignationAddEdit()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            txtDesc.Properties.MaxLength = 100;

            txtDesgCode.Enabled = false;
        }
        private void frmDesignationAddEdit_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtDesc.Focus();
                txtDesgCode.Text = ProjectFunctionsUtils.GetNewDesgCode();//.PadLeft(4, '0');
            }
            if (s1 == "Edit")
            {
                //txtDesc.Enabled = false;
                DataSet ds = ProjectFunctions.GetDataSet("SELECT DesgCode,DesgDesc FROM DesgMst Where DesgCode='" + DesgCode + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtDesgCode.Text = ds.Tables[0].Rows[0]["DesgCode"].ToString();
                    txtDesc.Text = ds.Tables[0].Rows[0]["DesgDesc"].ToString();
                    txtDesc.Focus();
                }
            }
        }
        private bool ValidateData()
        {
            if (txtDesgCode.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Invalid Desgination Code", "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtDesgCode.Focus();
                return false;
            }
            if (txtDesc.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Invalid Desgination Description", "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtDesc.Focus();
                return false;
            }

            return true;
        }
        //private string GetNewDesgCode()
        //{
        //    String s2 = String.Empty;
        //    DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(DesgCode as int)),00000) from DesgMst");
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        s2 = ds.Tables[0].Rows[0][0].ToString();
        //        s2 = (Convert.ToInt32(s2) + 1).ToString();
        //    }
        //    return s2;
        //}
        private void frmDesignationAddEdit_KeyDown(object sender, KeyEventArgs e)
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
            btnSave_Data();
        }

        private void btnSave_Data()
        {
            if (ValidateData())
            {
                PrintLogWin.PrintLog("btnSave_Data : " + txtDesgCode.Text.Trim());
                PrintLogWin.PrintLog("btnSave_Data : " + txtDesc.Text.Trim());
                PrintLogWin.PrintLog("btnSave_Data : " + s1);

                DesignationData designationData = new DesignationData();
                string intResult = designationData.InsertUpdate(txtDesgCode.Text.Trim(), txtDesc.Text.Trim(), s1);
                if (intResult.Equals("0"))
                {
                    ProjectFunctions.SpeakError("Data Saved Successfully");
                }
                else
                {
                    ProjectFunctions.SpeakError("Some Error in Save Data");
                }
                this.Close();

                /*
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
                            
                            //sqlcom.CommandText = " SET TRANSACTION ISOLATION LEVEL SERIALIZABLE  Begin Transaction "
                            //                        + " Insert into DesgMst"
                            //                        + " (DesgCode,DesgDesc)"
                            //                        + " values((SELECT RIGHT('0000'+ CAST( ISNULL( max(Cast(DesgCode as int)),0)+1 AS VARCHAR(4)),4) from DesgMst),@DesgDesc)"
                            //                        + " Commit ";
                        }
                        if (s1 == "Edit")
                        {                            
                            //sqlcom.CommandText = " UPDATE DesgMst SET "
                            //                    + " DesgDesc=@DesgDesc"
                            //                    + " Where DesgCode=@DesgCode";

                        }

                        string addEditTag = s1;

                        string sql = "sp_DesignationAddUpdate @DesgCode, @DesgDesc, @AddEditTag";
                        sqlcom.CommandText = sql;
                        sqlcom.Parameters.AddWithValue("@DesgCode", txtDesgCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@DesgDesc", txtDesc.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AddEditTag", addEditTag);
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
                */
            }
        }
    }
}