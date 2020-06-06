using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
namespace WindowsFormsApplication1.Transaction
{
    public partial class frmPackingDespatch : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        public String s1 { get; set; }
        public String ImNo { get; set; }
        public DateTime ImDate { get; set; }
        int rowindex;


        public frmPackingDespatch()
        {
            InitializeComponent();
            dt.Columns.Add("PrdAsgnCode", typeof(String));
            dt.Columns.Add("PrdName", typeof(String));
            dt.Columns.Add("IdPrdCode", typeof(Decimal));
            dt.Columns.Add("IdPrdQty", typeof(Decimal));
            dt.Columns.Add("IdPrdQtyR", typeof(Decimal));

        }
        private void SetMyControls()
        {
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
        }
        private void clear()
        {
            BtnOK.Text = "&OK";
            txtProductACode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtRejection.Text = string.Empty;

            txtProductACode.Focus();
        }


        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPlant_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtProductACode_EditValueChanged(object sender, EventArgs e)
        {
            txtProductName.Text = string.Empty;
            txtProductCode.Text = string.Empty;

        }

        private void frmProductionMaster_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                dtInvoiceDate.EditValue = DateTime.Now;
                txtSerialNo.Text = getNewInvoiceDocumentNo().PadLeft(6, '0');
                txtProductACode.Focus();
            }
            if (s1 == "Edit")
            {
                dtInvoiceDate.Enabled = false;
                DataSet ds = ProjectFunctions.GetDataSet(String.Format("sp_LoadPKDMDataFEdit '{0}','{1}'", ImNo, ImDate.Date.ToString("yyyy-MM-dd")));
                txtSerialNo.Text = ds.Tables[0].Rows[0]["ImNo"].ToString();
                dtInvoiceDate.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["ImDate"]);
                dt = ds.Tables[1];
                InfoGrid.DataSource = dt;
            }

        }
        private bool ValidateDataForSaving()
        {

            if (InfoGrid.DataSource == null)
            {
                ProjectFunctions.SpeakError("Blank Bill Cannot Be Saved");
                return false;

            }
            else
            {

            }


            return true;
        }

        private bool ValidateData()
        {

            if (txtProductACode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Product Code");
                txtProductACode.Focus();
                return false;
            }
            if (txtProductName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Product Code");
                txtProductACode.Focus();
                return false;
            }
            if (txtProductCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Product Code");
                txtProductCode.Focus();
                return false;
            }

            if (txtQty.Text.Trim().Length == 0)
            {
                txtQty.Text = "0";
            }
            if (txtRejection.Text.Trim().Length == 0)
            {
                txtRejection.Text = "0";
            }


            if (Convert.ToDecimal(txtQty.Text) <= 0)
            {
                ProjectFunctions.SpeakError("Packed Qty Cannot Be Zero Or Less Than Zero");
                txtQty.Focus();
                return false;
            }

            return true;
        }
        private void BtnOK_Click(object sender, EventArgs e)
        {

            if (ValidateData())
            {
                InfoGrid.RefreshDataSource();

                if (BtnOK.Text.ToUpper() == "&OK")
                {
                    InfoGrid.RefreshDataSource();
                    var dr = dt.NewRow();
                    dr["IdPrdCode"] = Convert.ToDecimal(txtProductCode.Text);
                    dr["PrdAsgnCode"] = txtProductACode.Text;
                    dr["PrdName"] = txtProductName.Text;
                    dr["IdPrdQty"] = Convert.ToDecimal(txtQty.Text);
                    dr["IdPrdQtyR"] = Convert.ToDecimal(txtRejection.Text);
                    dt.Rows.Add(dr);
                    if (dt.Rows.Count > 0)
                    {
                        InfoGrid.DataSource = dt;
                        InfoGridView.BestFitColumns();
                    }
                    BtnUndo.PerformClick();
                }
                if (BtnOK.Text.ToUpper() == "&UPDATE")
                {


                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdPrdCode"], Convert.ToDecimal(txtProductCode.Text));
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["PrdAsgnCode"], txtProductACode.Text);
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["PrdName"], txtProductName.Text);
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdPrdQty"], Convert.ToDecimal(txtQty.Text));
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdPrdQtyR"], Convert.ToDecimal(txtRejection.Text));
                    InfoGridView.RefreshData();

                    BtnUndo.PerformClick();
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            var MaxRow = ((InfoGrid.KeyboardFocusView as GridView).RowCount);
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            if (MaxRow == 0)
            {
                ProjectFunctions.SpeakError("Invalid Operation");
            }
            else
            {
                InfoGridView.DeleteRow(rowindex);
                InfoGridView.RefreshData();
                dt.AcceptChanges();
                clear();
            }
        }

        private void InfoGrid_DoubleClick(object sender, EventArgs e)
        {
#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            var MaxRow = ((InfoGrid.KeyboardFocusView as GridView).RowCount);
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            if (MaxRow == 0)
            {
                ProjectFunctions.SpeakError("Invalid Operation");
            }
            else
            {
                BtnOK.Text = "&Update";
                rowindex = InfoGridView.FocusedRowHandle;
                var row = InfoGridView.GetDataRow(InfoGridView.FocusedRowHandle);
                txtProductACode.Text = row["PrdAsgnCode"].ToString();
                txtProductName.Text = row["PrdName"].ToString();
                txtQty.Text = row["IdPrdQty"].ToString();
                txtRejection.Text = row["IdPrdQtyR"].ToString();


                txtProductACode.Focus();
            }
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            clear();
        }

        private string getNewInvoiceDocumentNo()
        {
            var s2 = string.Empty;
            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(imno as int)),000000) from PKDMMst Where ImDate='" + dtInvoiceDate.DateTime.ToString("yyyy-MM-dd") + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString().Trim();
                s2 = (Convert.ToInt32(s2) + 1).ToString().Trim();
            }
            return s2;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateDataForSaving())
            {

                using (var sqlcon = new SqlConnection(ProjectFunctions.GetConnection()))
                {
#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
                    var MaxRow = ((InfoGrid.KeyboardFocusView as GridView).RowCount);
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'


                    sqlcon.Open();
                    var sqlcom = sqlcon.CreateCommand();
                    var transaction = sqlcon.BeginTransaction("SaveTransaction");
                    sqlcom.Connection = sqlcon;
                    sqlcom.Transaction = transaction;
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        if (s1 == "&Add")
                        {
                            sqlcom.CommandText = "[sp_PKDMMstAdd]";
                            sqlcom.Parameters.Add("@ImNo", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                            sqlcom.Parameters["@ImNo"].Direction = ParameterDirection.InputOutput;
                            sqlcom.Parameters.Add("@ImDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@AddEditTag", SqlDbType.VarChar).Value = "&Add";
                            sqlcom.ExecuteNonQuery();
                            txtSerialNo.Text = sqlcom.Parameters["@ImNo"].Value.ToString();
                            sqlcom.Parameters.Clear();
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = "[sp_PKDMMstAdd]";
                            sqlcom.Parameters.Add("@ImNo", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                            sqlcom.Parameters.Add("@ImDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@AddEditTag", SqlDbType.VarChar).Value = "EDIT";
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();


                            sqlcom.CommandType = CommandType.Text;
                            sqlcom.CommandText = "Delete from PKDMData Where IdNo=@IdNo And IdDate=@IdDate ";
                            sqlcom.Parameters.Add("@IdNo", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                            sqlcom.Parameters.Add("@IdDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();


                        }


                        for (var i = 0; i < MaxRow; i++)
                        {
                            sqlcom.CommandType = CommandType.Text;
                            var currentrow = InfoGridView.GetDataRow(i);
                            sqlcom.CommandText = " Insert into PKDMData "
                                                        + " (IdNo,IdDate,IdPrdCode,"
                                                        + " IdPrdQty,IdPrdQtyR)"
                                                        + " values(@IdNo,@IdDate,@IdPrdCode,@IdPrdQty,"
                                                        + " @IdPrdQtyR)";

                            sqlcom.Parameters.Add("@IdNo", SqlDbType.NVarChar).Value = txtSerialNo.Text;
                            sqlcom.Parameters.Add("@IdDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("dd-MM-yyyy");
                            sqlcom.Parameters.Add("@IdPrdCode", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdPrdCode"]);
                            sqlcom.Parameters.Add("@IdPrdQty", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdPrdQty"]);
                            sqlcom.Parameters.Add("@IdPrdQtyR", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdPrdQtyR"]);
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();
                        }

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

        private void txtProductACode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HelpGridView.Columns.Clear();
                HelpGrid.Text = "txtProductACode";
                if (txtProductACode.Text.Trim().Length == 0)
                {
                    DataSet ds = ProjectFunctions.GetDataSet("SELECT     PrdMst.PrdCode,PrdMst.PrdAsgnCode, PrdMst.PrdName From PrdMst Where PrdActive='Y'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        HelpGrid.DataSource = ds.Tables[0];
                        HelpGrid.Show();
                        HelpGrid.Visible = true;
                        HelpGrid.Focus();
                        HelpGridView.BestFitColumns();
                    }
                    else
                    {
                        ProjectFunctions.SpeakError("No Records To Display");
                    }
                }
                else
                {
                    DataSet ds = ProjectFunctions.GetDataSet("SELECT     PrdMst.PrdCode,PrdMst.PrdAsgnCode, PrdMst.PrdName From PrdMst Where PrdActive='Y' And PrdAsgnCode='" + txtProductACode.Text + "'");

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtProductACode.Text = ds.Tables[0].Rows[0]["PrdAsgnCode"].ToString();
                        txtProductName.Text = ds.Tables[0].Rows[0]["PrdName"].ToString();
                        txtProductCode.Text = ds.Tables[0].Rows[0]["PrdCode"].ToString();

                        txtQty.Focus();
                    }
                    else
                    {
                        DataSet ds1 = ProjectFunctions.GetDataSet("SELECT     PrdMst.PrdCode,PrdMst.PrdAsgnCode, PrdMst.PrdName From PrdMst Where PrdActive='Y'");
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            HelpGrid.DataSource = ds.Tables[0];
                            HelpGrid.Show();
                            HelpGrid.Visible = true;
                            HelpGrid.Focus();
                            HelpGridView.BestFitColumns();
                        }
                        else
                        {
                            ProjectFunctions.SpeakError("No Records To Display");
                        }
                    }
                }
            }
            e.Handled = true;
        }

        private void HelpGrid_DoubleClick(object sender, EventArgs e)
        {
            DataRow Row = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);
            txtProductACode.Text = Row["PrdAsgnCode"].ToString();
            txtProductName.Text = Row["PrdName"].ToString();
            txtProductCode.Text = Row["PrdCode"].ToString();
            HelpGrid.Visible = false;
            txtQty.Focus();
        }



        private void txtProduction_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
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
    }
}