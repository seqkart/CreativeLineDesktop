using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmRouteMstAddEdit : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String RouteCode { get; set; }
        public frmRouteMstAddEdit()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);

            txtRouteName.Properties.MaxLength = 30;
            txtRouteCode.Enabled = false;
        }
        private void frmRouteMstAddEdit_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtRouteName.Focus();
                txtRouteCode.Text = GetNewRouteCode().PadLeft(4, '0');
            }
            if (s1 == "Edit")
            {
                txtRouteName.Enabled = false;
                DataSet ds = ProjectFunctions.GetDataSet("SELECT RouteCode,RouteDesc,RouteKMs,RouteTagLC FROM RouteMst Where RouteCode='" + RouteCode + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtRouteCode.Text = ds.Tables[0].Rows[0]["RouteCode"].ToString();
                    txtRouteName.Text = ds.Tables[0].Rows[0]["RouteDesc"].ToString();
                    txtCoverage.Text = ds.Tables[0].Rows[0]["RouteKMs"].ToString();
                    txtLcTag.Text = ds.Tables[0].Rows[0]["RouteTagLC"].ToString();
                    txtCoverage.Focus();
                }
            }
        }
        private bool ValidateData()
        {
            if (txtRouteCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Route Code");
                txtRouteCode.Focus();
                return false;
            }
            if (txtRouteName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Route Description");
                txtRouteName.Focus();
                return false;
            }
            if (txtLcTag.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Route LCTag");
                txtLcTag.Focus();
                return false;
            }
            if (txtCoverage.Text.Trim().Length == 0)
            {
                txtCoverage.Text = "0";
            }
            //if (txtStatusTag.Text.Trim() == "Y")
            //{

            //}
            //else
            //{
            //    if (txtStatusTag.Text.Trim() == "N")
            //    {

            //    }
            //    else
            //    {
            //        ProjectFunctions.SpeakError("Valid Values Are Y/N");
            //        txtStatusTag.Focus();
            //    }
            //}
            if (txtLcTag.Text.Trim() == "L")
            {

            }
            else
            {
                if (txtLcTag.Text.Trim() == "C")
                {

                }
                else
                {
                    ProjectFunctions.SpeakError("Valid Values Are L-Local/C-Central");
                    txtLcTag.Focus();
                    return false;
                }
            }
            return true;
        }
        private string GetNewRouteCode()
        {
            String s2 = String.Empty;
            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(RouteCode as int)),00000) from RouteMst");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString();
                s2 = (Convert.ToInt32(s2) + 1).ToString();
            }
            return s2;
        }
        private void frmRouteMstAddEdit_KeyDown(object sender, KeyEventArgs e)
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
                                                    + " Insert into RouteMst"
                                                    + " (RouteCode,RouteDesc,RouteKMs,RouteTagLC)"
                                                    + " values((SELECT RIGHT('0000'+ CAST( ISNULL( max(Cast(RouteCode as int)),0)+1 AS VARCHAR(4)),4)from RouteMst),@RouteDesc,@RouteKMs,@RouteTagLC)"
                                                    + " Commit ";
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE RouteMst SET "
                                                + " RouteDesc=@RouteDesc,RouteKMs=@RouteKMs,RouteTagLC=@RouteTagLC "
                                                + " Where RouteCode=@RouteCode";

                        }
                        sqlcom.Parameters.AddWithValue("@RouteCode", txtRouteCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@RouteDesc", txtRouteName.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@RouteKMs", Convert.ToDecimal(txtCoverage.Text.Trim()));
                        sqlcom.Parameters.AddWithValue("@RouteTagLC", txtLcTag.Text.Trim());
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

        private void txtCoverage_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private void txtLcTag_Validated(object sender, EventArgs e)
        {
            if (txtLcTag.Text.Trim() == "L")
            {

            }
            else
            {
                if (txtLcTag.Text.Trim() == "C")
                {

                }
                else
                {
                    ProjectFunctions.SpeakError("Valid Values Are L-Local/C-Central");
                    txtLcTag.Focus();
                }
            }
        }

        private void txtStatusTag_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtStatusTag_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if (txtStatusTag.Text.Trim() == "Y")
            //{

            //}
            //else
            //{
            //    if (txtStatusTag.Text.Trim() == "N")
            //    {

            //    }
            //    else
            //    {
            //        ProjectFunctions.SpeakError("Valid Values Are Y/N");
            //        txtStatusTag.Focus();
            //    }
            //}
        }
    }
}