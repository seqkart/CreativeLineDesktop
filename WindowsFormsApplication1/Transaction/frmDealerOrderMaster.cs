using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApplication1.Transaction
{
    public partial class frmDealerOrderMaster : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        DataTable dt = new DataTable();
        public String OrderNo { get; set; }
        private void SetMyControls()
        {
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
        }
        public frmDealerOrderMaster()
        {
            InitializeComponent();
            dt.Columns.Add("OrdDPrdCode", typeof(Decimal));
            dt.Columns.Add("PrdAsgnCode", typeof(String));
            dt.Columns.Add("PrdName", typeof(String));
            dt.Columns.Add("OrdDPrdQuantity", typeof(Decimal));
        }
        private bool ValidateData()
        {



            if (dtOrderDate.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Order Date");
                dtOrderDate.Focus();
                return false;
            }
            if (dtOrderForDate.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Order For Date");
                dtOrderForDate.Focus();
                return false;
            }
            if (Convert.ToDateTime(dtOrderDate.EditValue) < Convert.ToDateTime(GlobalVariables.FinYearStartDate) || Convert.ToDateTime(dtOrderDate.EditValue) > Convert.ToDateTime(GlobalVariables.FinYearEndDate))
            {
                ProjectFunctions.SpeakError("Order Date Is Out Of The Financial Year");
                dtOrderDate.Focus();
                return false;
            }
            if (Convert.ToDateTime(dtOrderForDate.EditValue) < Convert.ToDateTime(GlobalVariables.FinYearStartDate) || Convert.ToDateTime(dtOrderForDate.EditValue) > Convert.ToDateTime(GlobalVariables.FinYearEndDate))
            {
                ProjectFunctions.SpeakError("Order For Date Is Out Of The Financial Year");
                dtOrderForDate.Focus();
                return false;
            }
            if (txtOrderNo.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Order No");
                txtOrderNo.Focus();
                return false;
            }
            if (txtDealerCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Dealer  Code");
                txtDealerCode.Focus();
                return false;
            }
            if (txtDealerName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Dealer  Code");
                txtDealerCode.Focus();
                return false;
            }
            return true;
        }

        private void txtDealerCode_EditValueChanged(object sender, EventArgs e)
        {
            txtDealerName.Text = string.Empty;
            dt = null;
        }
        private string getNewInvoiceDocumentNo()
        {
            var s2 = string.Empty;
            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(OrdNo as int)),00000000) from DealerOrderMst ");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString().Trim();
                s2 = (Convert.ToInt32(s2) + 1).ToString().Trim();
            }
            return s2;
        }
        private void frmDealerOrderMaster_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                dtOrderDate.EditValue = DateTime.Now;
                dtOrderForDate.EditValue = DateTime.Now;
                dtOrderForDate.Focus();
                txtOrderNo.Text = getNewInvoiceDocumentNo().PadLeft(8, '0');

                DataSet ds = ProjectFunctions.GetDataSet("SP_LoadPrdForOrder");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                    InfoGrid.DataSource = dt;
                    InfoGridView.BestFitColumns();
                }
                else
                {
                    InfoGrid.DataSource = null;
                }
            }
            if (s1 == "Edit")
            {
                txtDealerCode.Enabled = false;
                dtOrderForDate.Focus();
                DataSet ds = ProjectFunctions.GetDataSet("sp_LoadOrderDataFEditing '" + OrderNo + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dtOrderDate.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["OrdDate"]);
                    dtOrderForDate.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["OrdForDate"]);
                    txtOrderNo.Text = ds.Tables[0].Rows[0]["OrdNo"].ToString();
                    txtDealerCode.Text = ds.Tables[0].Rows[0]["OrdDealerCode"].ToString();
                    txtDealerName.Text = ds.Tables[0].Rows[0]["AccName"].ToString();
                    dt = ds.Tables[1];
                    InfoGrid.DataSource = dt;
                    InfoGridView.BestFitColumns();
                }
            }
        }

        private void frmDealerOrderMaster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                System.Windows.Forms.SendKeys.Send("+{TAB}");
            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                btnSave_Click(null, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void HelpGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HelpGrid_DoubleClick(null, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                HelpGrid.Visible = false;
            }
        }

        private void HelpGrid_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);
            if (HelpGrid.Text == "txtDealerCode")
            {
                txtDealerCode.Text = row["AccCode"].ToString();
                txtDealerName.Text = row["AccName"].ToString();
                HelpGrid.Visible = false;
                txtDealerCode.Focus();
            }
        }

        private void txtDealerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProjectFunctions.CreatePopUpForTwoBoxes("Select AccCode,AccName from ActMst Where AccActive='Y' And AccLedger='0001' ", " And AccCode ", txtDealerCode, txtDealerName, txtDealerCode, HelpGrid, HelpGridView, e);
            }
            e.Handled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                InfoGridView.CloseEditor();
                InfoGridView.UpdateCurrentRow();
                using (var sqlcon = new SqlConnection(ProjectFunctions.GetConnection()))
                {
                    sqlcon.Open();
                    var sqlcom = sqlcon.CreateCommand();
                    var transaction = sqlcon.BeginTransaction("SaveTransaction");
                    sqlcom.Connection = sqlcon;
                    sqlcom.Transaction = transaction;
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        sqlcom.CommandText = "sp_InsertOrderMst";
                        sqlcom.Parameters.AddWithValue("@OrdNo", txtOrderNo.Text.Trim());
                        sqlcom.Parameters["@OrdNo"].Direction = ParameterDirection.InputOutput;
                        sqlcom.Parameters.AddWithValue("@OrdDate", Convert.ToDateTime(dtOrderDate.Text).ToString("yyyy-MM-dd"));
                        sqlcom.Parameters.AddWithValue("@OrdForDate", Convert.ToDateTime(dtOrderForDate.Text).ToString("yyyy-MM-dd"));
                        sqlcom.Parameters.AddWithValue("@OrdDealerCode", txtDealerCode.Text.Trim());
                        if (s1 == "&Add")
                        {
                            sqlcom.Parameters.AddWithValue("@Tag", "&Add");
                        }
                        else
                        {
                            sqlcom.Parameters.AddWithValue("@Tag", "Edit");
                        }
                        sqlcom.ExecuteNonQuery();
                        txtOrderNo.Text = sqlcom.Parameters["@OrdNo"].Value.ToString();
                        sqlcom.Parameters.Clear();

                        if (s1 == "Edit")
                        {
                            sqlcom.CommandType = CommandType.Text;
                            sqlcom.CommandText = " Delete from DealerOrderData Where OrdDNo = @OrdDNo ";
                            sqlcom.Parameters.AddWithValue("@OrdDNo", txtOrderNo.Text.Trim());
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();
                        }



#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
                        for (var i = 0; i < ((InfoGrid.KeyboardFocusView as GridView).RowCount); i++)
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
                        {
                            sqlcom.CommandType = CommandType.Text;
                            var currentrow = InfoGridView.GetDataRow(i);
                            if (Convert.ToDecimal(currentrow["OrdDPrdQuantity"]) > 0)
                            {
                                sqlcom.CommandText = " Insert into DealerOrderData"
                                                           + " (OrdDNo,OrdDDate,OrdDDealerCode,OrdDPrdCode,OrdDPrdQuantity,OrdDForDate)"
                                                           + " values(@OrdDNo,@OrdDDate,@OrdDDealerCode,@OrdDPrdCode,@OrdDPrdQuantity,@OrdDForDate)";

                                sqlcom.Parameters.AddWithValue("@OrdDNo", txtOrderNo.Text.Trim());
                                sqlcom.Parameters.AddWithValue("@OrdDDate", Convert.ToDateTime(dtOrderDate.Text).ToString("yyyy-MM-dd"));
                                sqlcom.Parameters.AddWithValue("@OrdDDealerCode", txtDealerCode.Text.Trim());
                                sqlcom.Parameters.AddWithValue("@OrdDPrdCode", Convert.ToDecimal(currentrow["OrdDPrdCode"]));
                                sqlcom.Parameters.AddWithValue("@OrdDPrdQuantity", Convert.ToDecimal(currentrow["OrdDPrdQuantity"]));
                                sqlcom.Parameters.AddWithValue("@OrdDForDate", Convert.ToDateTime(dtOrderForDate.Text).ToString("yyyy-MM-dd"));

                                sqlcom.ExecuteNonQuery();
                                sqlcom.Parameters.Clear();
                            }
                        }
                        transaction.Commit();
                        ProjectFunctions.SpeakError("Order Data Saved Successfully");
                        sqlcon.Close();
                        if (s1 == "&Add")
                        {
                            txtDealerCode.Text = string.Empty;
                            txtDealerName.Text = string.Empty;
                            frmDealerOrderMaster_Load(null, e);
                        }
                        else
                        {
                            this.Close();
                        }
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

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InfoGridView_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            InfoGridView.CloseEditor();
            InfoGridView.UpdateCurrentRow();
        }

        private void InfoGridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            InfoGridView.CloseEditor();
            InfoGridView.UpdateCurrentRow();

        }
    }
}