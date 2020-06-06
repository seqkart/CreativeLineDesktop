using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
namespace WindowsFormsApplication1.Transaction
{
    public partial class frmStockOutData : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        DataTable dt = new DataTable();
        int rowindex;
        public String ImNo { get; set; }
        public DateTime ImDate { get; set; }

        public frmStockOutData()
        {
            InitializeComponent();
            dt.Columns.Add("PrdCode", typeof(String));
            dt.Columns.Add("PrdAsgnCode", typeof(String));
            dt.Columns.Add("PrdName", typeof(String));
            dt.Columns.Add("Quantity", typeof(Decimal));
        }
        private bool ValidateDataForSaving()
        {
            if (txtDeptCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Dept");
                txtDeptCode.Focus();
                return false;
            }
            if (txtDeptDesc.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Dept");
                txtDeptCode.Focus();
                return false;
            }
            if (InfoGrid.DataSource == null)
            {
                ProjectFunctions.SpeakError("Blank Bill Cannot Be Saved");
                return false;

            }
            else
            {

            }
            if (txtPlant.Text.Trim() == "A" || txtPlant.Text.Trim() == "B" || txtPlant.Text.Trim() == "C" || txtPlant.Text.Trim() == "D")
            {
            }
            else
            {
                ProjectFunctions.SpeakError("Invalid Values Are A/B/C/D");
                txtPlant.Focus();
                return false;

            }
            if (txtShift.Text.Trim() == "D" || txtShift.Text == "N")
            {
            }
            else
            {
                ProjectFunctions.SpeakError("Invalid Values Are Day - D / Night - N");
                txtShift.Focus();
                return false;
            }

            return true;
        }
        private bool ValidateData()
        {
            if (txtPrdCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Product");
                txtPrdCode.Focus();
                return false;
            }
            if (txtProductName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Product");
                txtProductName.Focus();
                return false;
            }
            if (txtPrdAsgnCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Product");
                txtPrdAsgnCode.Focus();
                return false;
            }
            if (txtQty.Text.Trim().Length == 0)
            {
                txtQty.Text = "0";
            }
            if (Convert.ToDecimal(txtQty.Text) <= 0)
            {
                ProjectFunctions.SpeakError("Quantity Should Be Greater Than Zero");
                txtPrdAsgnCode.Focus();
                return false;
            }

            return true;
        }
        private string getNewInvoiceDocumentNo()
        {
            var s2 = string.Empty;
            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(MmDocNo as int)),0000) from MrMst Where MmDocDate='" + dtInvoiceDate.DateTime.Date.ToString("yyyy-MM-dd") + "' And MmDocType='SO'");

            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString().Trim();
                s2 = (Convert.ToInt32(s2) + 1).ToString().Trim();
            }
            return s2;
        }
        private void clear()
        {
            BtnOK.Text = "&OK";
            txtPrdCode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtPrdAsgnCode.Text = string.Empty;
            txtQty.Text = string.Empty;

            txtPrdAsgnCode.Focus();
        }
        private void SetMyControls()
        {
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
        }
        private void frmStockOutData_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtInvoiceType.Text = "SO";
                dtInvoiceDate.EditValue = DateTime.Now;
                txtSerialNo.Text = getNewInvoiceDocumentNo().ToString().PadLeft(6, '0');
                txtPlant.Focus();

            }
            if (s1 == "Edit")
            {
                DataSet ds = ProjectFunctions.GetDataSet("[sp_LoadStockOutDataFEdit] '" + ImDate.Date.ToString("yyyy-MM-dd") + "',@DocNo='" + ImNo + "'");
                txtSerialNo.Text = ds.Tables[0].Rows[0]["MmDocNo"].ToString();
                dtInvoiceDate.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["MmDocDate"]);
                txtInvoiceType.Text = ds.Tables[0].Rows[0]["MmDocType"].ToString();
                txtDeptCode.Text = ds.Tables[0].Rows[0]["MmDeptCode"].ToString();
                txtDeptDesc.Text = ds.Tables[0].Rows[0]["DeptDesc"].ToString();
                txtPlant.Text = ds.Tables[0].Rows[0]["MMPlant"].ToString();
                txtShift.Text = ds.Tables[0].Rows[0]["MMShift"].ToString();

                dt = ds.Tables[1];
                InfoGrid.DataSource = dt;
                txtPlant.Focus();
            }
        }

        private void txtDeptCode_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtPrdAsgnCode_EditValueChanged(object sender, EventArgs e)
        {
            txtProductName.Text = string.Empty;
            txtPrdCode.Text = string.Empty;

        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
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

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                if (BtnOK.Text.Trim().ToUpper() == "&OK")
                {
                    DataRow NewRow = dt.NewRow();

                    NewRow["PrdCode"] = Convert.ToDecimal(txtPrdCode.Text);
                    NewRow["PrdAsgnCode"] = txtPrdAsgnCode.Text.Trim();
                    NewRow["PrdName"] = txtProductName.Text.Trim();
                    NewRow["Quantity"] = Convert.ToDecimal(txtQty.Text);
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
                    BtnUndo.PerformClick();
                }
                if (BtnOK.Text.Trim().ToUpper() == "&UPDATE")
                {
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["PrdCode"], Convert.ToDecimal(txtPrdCode.Text));
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["PrdAsgnCode"], txtPrdAsgnCode.Text.Trim());
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["PrdName"], txtProductName.Text.Trim());
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["Quantity"], Convert.ToDecimal(txtQty.Text));
                    InfoGridView.RefreshData();
                    BtnUndo.PerformClick();
                }
            }

        }

        private void InfoGrid_DragDrop(object sender, DragEventArgs e)
        {

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
                txtPrdAsgnCode.Text = row["PrdAsgnCode"].ToString();
                txtPrdCode.Text = row["PrdCode"].ToString();
                txtProductName.Text = row["PrdName"].ToString();

                txtQty.Text = row["Quantity"].ToString();
                txtPrdAsgnCode.Focus();
            }
        }

        private void txtPrdAsgnCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HelpGridView.Columns.Clear();
                HelpGrid.Text = "txtPrdAsgnCode";
                if (txtPrdAsgnCode.Text.Trim().Length == 0)
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
                    DataSet ds = ProjectFunctions.GetDataSet("SELECT     PrdMst.PrdCode,PrdMst.PrdAsgnCode, PrdMst.PrdName From PrdMst Where PrdActive='Y' And PrdAsgnCode='" + txtPrdAsgnCode.Text + "'");

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtPrdAsgnCode.Text = ds.Tables[0].Rows[0]["PrdAsgnCode"].ToString();
                        txtProductName.Text = ds.Tables[0].Rows[0]["PrdName"].ToString();
                        txtPrdCode.Text = ds.Tables[0].Rows[0]["PrdCode"].ToString();

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
            if (HelpGrid.Text == "txtPrdAsgnCode")
            {
                txtPrdAsgnCode.Text = Row["PrdAsgnCode"].ToString();
                txtProductName.Text = Row["PrdName"].ToString();
                txtPrdCode.Text = Row["PrdCode"].ToString();
                HelpGrid.Visible = false;
                txtQty.Focus();
            }
            if (HelpGrid.Text == "txtDeptCode")
            {
                txtDeptCode.Text = Row["DeptCode"].ToString();
                txtDeptDesc.Text = Row["DeptDesc"].ToString();
                HelpGrid.Visible = false;
                txtPrdAsgnCode.Focus();
            }

        }

        private void txtDeptCode_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForTwoBoxes("Select DeptCode,DeptDesc from DeptMst", " Where DeptCode", txtDeptCode, txtDeptDesc, txtPrdAsgnCode, HelpGrid, HelpGridView, e);
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
                            sqlcom.CommandText = "[sp_Ins_StockOutMst]";
                            sqlcom.Parameters.Add("@MmDocNo", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                            sqlcom.Parameters["@MmDocNo"].Direction = ParameterDirection.InputOutput;
                            sqlcom.Parameters.Add("@MmDocDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@MmDocType", SqlDbType.NVarChar).Value = "SO";
                            sqlcom.Parameters.Add("@MMPlant", SqlDbType.NVarChar).Value = txtPlant.Text.Trim();
                            sqlcom.Parameters.Add("@MMShift", SqlDbType.NVarChar).Value = txtShift.Text.Trim();
                            sqlcom.Parameters.Add("@MmDeptCode", SqlDbType.NVarChar).Value = txtDeptCode.Text.Trim();
                            sqlcom.Parameters.Add("@AddEditTag", SqlDbType.VarChar).Value = "&Add";
                            sqlcom.ExecuteNonQuery();
                            txtSerialNo.Text = sqlcom.Parameters["@MmDocNo"].Value.ToString();
                            sqlcom.Parameters.Clear();
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = "[sp_Ins_StockOutMst]";
                            sqlcom.Parameters.Add("@MmDocNo", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                            sqlcom.Parameters["@MmDocNo"].Direction = ParameterDirection.InputOutput;
                            sqlcom.Parameters.Add("@MmDocDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@MmDocType", SqlDbType.NVarChar).Value = "SO";
                            sqlcom.Parameters.Add("@MMPlant", SqlDbType.NVarChar).Value = txtPlant.Text.Trim();
                            sqlcom.Parameters.Add("@MMShift", SqlDbType.NVarChar).Value = txtShift.Text.Trim();
                            sqlcom.Parameters.Add("@MmDeptCode", SqlDbType.NVarChar).Value = txtDeptCode.Text.Trim();
                            sqlcom.Parameters.Add("@AddEditTag", SqlDbType.VarChar).Value = "EDIT";
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();

                            sqlcom.CommandType = CommandType.Text;
                            sqlcom.CommandText = "Delete from MrData Where MdDocNo=@MdDocNo And MdDocDate=@MdDocDate And MdDocType='SO'";
                            sqlcom.Parameters.Add("@MdDocNo", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                            sqlcom.Parameters.Add("@MdDocDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();


                        }


                        for (var i = 0; i < MaxRow; i++)
                        {
                            sqlcom.CommandType = CommandType.Text;
                            var currentrow = InfoGridView.GetDataRow(i);
                            sqlcom.CommandText = " Insert into MrData "
                                                        + " (MdDocType,MdDocNo,MdDocDate,MdPrdCode,MdPrdQty,MdDeptCode,MdPlant,MdShift)"

                                                        + " values(@MdDocType,@MdDocNo,@MdDocDate,@MdPrdCode,@MdPrdQty,@MdDeptCode,@MdPlant,@MdShift)";


                            sqlcom.Parameters.Add("@MdDocType", SqlDbType.NVarChar).Value = "SO";
                            sqlcom.Parameters.Add("@MdDocNo", SqlDbType.NVarChar).Value = txtSerialNo.Text;
                            sqlcom.Parameters.Add("@MdDocDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("dd-MM-yyyy");
                            sqlcom.Parameters.Add("@MdPrdCode", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["PrdCode"]);
                            sqlcom.Parameters.Add("@MdPrdQty", SqlDbType.Decimal).Value = -Convert.ToDecimal(currentrow["Quantity"]);
                            sqlcom.Parameters.Add("@MdDeptCode", SqlDbType.NVarChar).Value = txtDeptCode.Text.Trim();
                            sqlcom.Parameters.Add("@MdPlant", SqlDbType.NVarChar).Value = txtPlant.Text.Trim();
                            sqlcom.Parameters.Add("@MdShift", SqlDbType.NVarChar).Value = txtShift.Text.Trim();

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

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}