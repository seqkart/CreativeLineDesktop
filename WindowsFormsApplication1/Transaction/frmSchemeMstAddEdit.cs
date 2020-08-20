using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public partial class frmSchemeMstAddEdit : XtraForm
    {
        public String s1 { get; set; }
        DataTable dt = new DataTable();
        int rowindex;
        public String ImNo { get; set; }
        public DateTime ImDate { get; set; }
        public frmSchemeMstAddEdit()
        {
            InitializeComponent();
            dt.Columns.Add("IdDealerCode", typeof(string));
            dt.Columns.Add("dealerName", typeof(string));
            dt.Columns.Add("IdPrdAsgnCode", typeof(string));
            dt.Columns.Add("PrdName", typeof(string));
            dt.Columns.Add("IdPrdQty", typeof(decimal));
            dt.Columns.Add("IdPrdQtyF", typeof(decimal));
            dt.Columns.Add("IdDtFrom", typeof(DateTime));
            dt.Columns.Add("IdDtUpto", typeof(DateTime));
            dt.Columns.Add("IdPrdCode", typeof(int));
        }
        private void SetMyControls()
        {
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);

            txtSerialNo.Enabled = false;
            DtfeedingDate.Enabled = false;

        }
        private bool ValidateDataForSaving()
        {
            if (InfoGrid.DataSource == null)
            {
            }
            else
            {
                ProjectFunctions.SpeakError("Blank Document Cannot Be Saved");
                txtPrdAsgnCode.Focus();
            }
            //if (txtVatInvoice.Text.Trim().Length == 0)
            //{
            //    ProjectFunctions.SpeakError("Invalid Invoice Tag");
            //    txtVatInvoice.Focus();
            //    return false;
            //}
            //if (txtLCTag.Text.Trim().Length == 0)
            //{
            //    ProjectFunctions.SpeakError("Invalid LCtag Value");
            //    txtLCTag.Focus();
            //    return false;
            //}

            return true;
        }
        private bool ValidateData()
        {

            if (txtDealerCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Dealer Name");
                txtDealerCode.Focus();
                return false;
            }
            if (txtDealerName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Dealer Name");
                txtDealerCode.Focus();
                return false;
            }
            if (txtPrdAsgnCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Product Code");
                txtPrdAsgnCode.Focus();
                return false;
            }
            if (txtProductName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Product Code");
                txtPrdAsgnCode.Focus();
                return false;
            }
            if (DtFrom.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid From Date");
                DtFrom.Focus();
                return false;
            }
            if (DtTo.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid To Date");
                DtTo.Focus();
                return false;
            }

            if (txtFor.Text.Length == 0)
            {
                txtFor.Text = "0";
            }

            if (txtFree.Text.Length == 0)
            {
                txtFree.Text = "0";
            }

            return true;
        }
        private string getNewInvoiceDocumentNo()
        {
            var s2 = string.Empty;
            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(imno as int)),000000) from SchmMst Where ImType='S'  And  ImFyear='" + ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear) + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString().Trim();
                s2 = (Convert.ToInt32(s2) + 1).ToString().Trim();
            }
            return s2;
        }
        private void frmSchemeMstAddEdit_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {

                DtfeedingDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                txtSerialNo.Text = getNewInvoiceDocumentNo().PadLeft(6, '0');
                txtDealerCode.Focus();
            }
        }

        private void frmSchemeMstAddEdit_KeyDown(object sender, KeyEventArgs e)
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


        private void clear()
        {
            BtnOK.Text = "&OK";
            txtPrdCode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtFree.Text = string.Empty;
            txtFor.Text = string.Empty;
            DtTo.Text = string.Empty;
            DtFrom.Text = string.Empty;
            txtPrdAsgnCode.Focus();
        }
        private void txtProductCode_EditValueChanged(object sender, EventArgs e)
        {

            txtPrdCode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtFree.Text = string.Empty;
            txtFor.Text = string.Empty;
            DtTo.Text = string.Empty;
            DtFrom.Text = string.Empty;

        }

        private void txtDealerCode_EditValueChanged(object sender, EventArgs e)
        {
            txtDealerName.Text = string.Empty;
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
        //private void clear()
        //{
        //    BtnOK.Text = "&OK";
        //    txtPrdCode.Text = "";
        //    txtProductName.Text = "";
        //    txtPrdAsgnCode.Text = "";
        //    txtFree.Text = "";
        //    txtFor.Text = "";
        //    DtTo.Text = "";
        //    DtFrom.Text = "";
        //    txtPrdAsgnCode.Focus();
        //}

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                if (BtnOK.Text.Trim().ToUpper() == "&OK")
                {
                    DataRow NewRow = dt.NewRow();
                    NewRow["IdDealerCode"] = txtDealerCode.Text.Trim();
                    NewRow["dealerName"] = txtDealerName.Text.Trim();
                    NewRow["IdPrdAsgnCode"] = txtPrdAsgnCode.Text.Trim();
                    NewRow["PrdName"] = txtProductName.Text.Trim();
                    NewRow["IdPrdQty"] = Convert.ToDecimal(txtFor.Text);
                    NewRow["IdPrdQtyF"] = Convert.ToDecimal(txtFree.Text);
                    NewRow["IdDtFrom"] = Convert.ToDateTime(DtFrom.Text);
                    NewRow["IdDtUpto"] = Convert.ToDateTime(DtTo.Text);
                    NewRow["IdPrdCode"] = Convert.ToDecimal(txtPrdCode.Text);
                    dt.Rows.Add(NewRow);
                    if (dt.Rows.Count > 0)
                    {
                        InfoGrid.DataSource = dt;
                        InfoGridView.BestFitColumns();
                    }
                    else
                    {
                        InfoGrid.DataSource = null;
                    }
                }
                if (BtnOK.Text.Trim().ToUpper() == "&UPDATE")
                {
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdDealerCode"], txtDealerCode.Text.Trim());
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["dealerName"], txtDealerName.Text.Trim());

                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdPrdCode"], Convert.ToDecimal(txtPrdCode.Text));
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdPrdAsgnCode"], txtPrdAsgnCode.Text.Trim());
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["PrdName"], txtProductName.Text.Trim());
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdPrdQty"], Convert.ToDecimal(txtFor.Text));
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdPrdQtyF"], Convert.ToDecimal(txtFree.Text));
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdDtFrom"], Convert.ToDateTime(DtFrom.Text));
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdDtUpto"], Convert.ToDateTime(DtTo.Text));
                    InfoGridView.RefreshData();
                    BtnUndo.PerformClick();
                }
                clear();
            }

        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void txtDealerCode_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForTwoBoxes("Select AccCode,AccName from ActMst", " Where AccCode", txtDealerCode, txtDealerName, txtPrdAsgnCode, HelpGrid, HelpGridView, e);
        }

        private void txtPrdAsgnCode_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForThreeBoxes("Select PrdAsgnCode,PrdCode,PrdName from PrdMst", " Where PrdAsgnCode", txtPrdAsgnCode, txtPrdCode, txtProductName, txtFor, HelpGrid, HelpGridView, e);

        }

        private void HelpGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                HelpGrid.Visible = false;
            }
            if (e.KeyCode == Keys.Enter)
            {
                HelpGrid_DoubleClick(null, e);
            }
        }

        private void HelpGrid_DoubleClick(object sender, EventArgs e)
        {
            DataRow CurrentRow = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);
            if (HelpGrid.Text == "txtDealerCode")
            {
                txtDealerCode.Text = CurrentRow[0].ToString();
                txtDealerName.Text = CurrentRow[1].ToString();
                HelpGrid.Visible = false;
                txtPrdAsgnCode.Focus();
            }
            if (HelpGrid.Text == "txtPrdAsgnCode")
            {
                txtPrdAsgnCode.Text = CurrentRow[0].ToString();
                txtPrdCode.Text = CurrentRow[1].ToString();
                txtProductName.Text = CurrentRow[2].ToString();
                HelpGrid.Visible = false;
                txtFor.Focus();
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFree_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumberOnly(e);
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

                txtDealerCode.Text = row["IdDealerCode"].ToString();
                txtDealerName.Text = row["dealerName"].ToString();
                txtPrdAsgnCode.Text = row["IdPrdAsgnCode"].ToString();
                txtProductName.Text = row["PrdName"].ToString();
                txtFor.Text = row["IdPrdQty"].ToString();
                txtFree.Text = row["IdPrdQtyF"].ToString();

                DtFrom.EditValue = Convert.ToDateTime(row["IdDtFrom"]);
                DtTo.EditValue = Convert.ToDateTime(row["IdDtUpto"]);

                txtPrdCode.Text = row["IdPrdCode"].ToString();
                txtPrdAsgnCode.Focus();
            }
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
                    sqlcom.CommandType = CommandType.Text;
                    try
                    {


                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = "Delete from SchmData Where IdNo=@IdNo And IdDate=@IdDate ";
                            sqlcom.Parameters.Add("@IdNo", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                            sqlcom.Parameters.Add("@IdDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(DtfeedingDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();
                        }


                        for (var i = 0; i < MaxRow; i++)
                        {
                            var currentrow = InfoGridView.GetDataRow(i);
                            sqlcom.CommandText = " Insert into SchmData "
                                                        + " (IdNo,IdDate,IdDealerCode,IdPrdAsgnCode,IdPrdCode, IdPrdQty,IdPrdQtyF,IdDtFrom,IdDtUpto)values("
                                                        + " @IdNo,@IdDate,@IdDealerCode,@IdPrdAsgnCode,@IdPrdCode, @IdPrdQty,@IdPrdQtyF,@IdDtFrom,@IdDtUpto)";

                            if (s1 == "Edit")
                            {

                                sqlcom.Parameters.Add("@IdNo", SqlDbType.NVarChar).Value = getNewInvoiceDocumentNo().PadLeft(6, '0');
                            }
                            else
                            {
                                sqlcom.Parameters.Add("@IdNo", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                            }
                            sqlcom.Parameters.Add("@IdDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(DtfeedingDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@IdDealerCode", SqlDbType.NVarChar).Value = currentrow["IdDealerCode"].ToString();
                            sqlcom.Parameters.Add("@IdPrdAsgnCode", SqlDbType.NVarChar).Value = currentrow["IdPrdAsgnCode"].ToString();
                            sqlcom.Parameters.Add("@IdPrdCode", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["IdPrdCode"]);
                            sqlcom.Parameters.Add("@IdPrdQty", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["IdPrdQty"]);
                            sqlcom.Parameters.Add("@IdPrdQtyF", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdPrdQtyF"]);
                            sqlcom.Parameters.Add("@IdDtFrom", SqlDbType.NVarChar).Value = Convert.ToDateTime(currentrow["IdDtFrom"]).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@IdDtUpto", SqlDbType.Decimal).Value = Convert.ToDateTime(currentrow["IdDtUpto"]).ToString("yyyy-MM-dd");
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
    }
}