using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Transaction
{
    public partial class frmIndentMst : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        public String s1 { get; set; }
        public String ImNo { get; set; }
        public DateTime ImDate { get; set; }
        int rowindex;

        public frmIndentMst()
        {
            InitializeComponent();
            dt.Columns.Add("PrdAsgnCode", typeof(String));
            dt.Columns.Add("PrdName", typeof(String));
            dt.Columns.Add("PrdCode", typeof(Decimal));
            dt.Columns.Add("Qty", typeof(Decimal));
            dt.Columns.Add("Amount", typeof(Decimal));

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
            txtAmount.Text = string.Empty;
            txtProductQty.Text = string.Empty;

            txtProductACode.Focus();
        }


        private void frmIndentMst_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                dtInvoiceDate.EditValue = DateTime.Now;
                txtSerialNo.Text = getNewInvoiceDocumentNo().PadLeft(5, '0');
                txtDeptCode.Focus();
            }
            if (s1 == "Edit")
            {
                dtInvoiceDate.Enabled = false;
                DataSet ds = ProjectFunctions.GetDataSet(String.Format("sp_LoadIndDataFEdit '{0}','{1}','{2}'", ImNo, ImDate.Date.ToString("yyyy-MM-dd"), GlobalVariables.CUnitID));
                txtSerialNo.Text = ds.Tables[0].Rows[0]["IndmNo"].ToString();
                dtInvoiceDate.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["IndmDate"]);
                txtDeptCode.Text = ds.Tables[0].Rows[0]["IndmDeptCode"].ToString();

                txtDeptName.Text = ds.Tables[0].Rows[0]["DeptDesc"].ToString();

                dt = ds.Tables[1];
                InfoGrid.DataSource = dt;
                txtDeptCode.Focus();
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateDataForSaving()
        {
            if (txtDeptCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Dept");
                txtDeptCode.Focus();
                return false;
            }
            if (txtDeptName.Text.Trim().Length == 0)
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


            return true;
        }

        private bool ValidateData()
        {
            if (txtDeptCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Dept");
                txtDeptCode.Focus();
                return false;
            }
            if (txtDeptName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Dept");
                txtDeptCode.Focus();
                return false;
            }
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

            if (txtAmount.Text.Trim().Length == 0)
            {
                txtAmount.Text = "0";
            }
            if (txtProductQty.Text.Trim().Length == 0)
            {
                txtProductQty.Text = "0";
            }


            if (Convert.ToDecimal(txtProductQty.Text) <= 0)
            {
                ProjectFunctions.SpeakError(" Qty Cannot Be Zero Or Less Than Zero");
                txtProductQty.Focus();
                return false;
            }
            if (Convert.ToDecimal(txtAmount.Text) <= 0)
            {
                ProjectFunctions.SpeakError(" Amount Cannot Be Zero Or Less Than Zero");
                txtAmount.Focus();
                return false;
            }

            return true;
        }

        private void txtProductACode_EditValueChanged(object sender, EventArgs e)
        {
            txtProductName.Text = string.Empty;
            txtProductCode.Text = string.Empty;

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
                    dr["PrdCode"] = Convert.ToDecimal(txtProductCode.Text);
                    dr["PrdAsgnCode"] = txtProductACode.Text;
                    dr["PrdName"] = txtProductName.Text;
                    dr["Qty"] = Convert.ToDecimal(txtProductQty.Text);
                    dr["Amount"] = Convert.ToDecimal(txtAmount.Text);
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


                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["PrdCode"], Convert.ToDecimal(txtProductCode.Text));
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["PrdAsgnCode"], txtProductACode.Text);
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["PrdName"], txtProductName.Text);
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["Qty"], Convert.ToDecimal(txtProductQty.Text));
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["Amount"], Convert.ToDecimal(txtAmount.Text));
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
        private string getNewInvoiceDocumentNo()
        {
            var s2 = string.Empty;
            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(IndmNo  as int)),00000) from IndMst Where IndmDate='" + dtInvoiceDate.DateTime.ToString("yyyy-MM-dd") + "' And UnitCode='" + GlobalVariables.CUnitID + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString().Trim();
                s2 = (Convert.ToInt32(s2) + 1).ToString().Trim();
            }
            return s2;
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
                txtProductQty.Text = row["Qty"].ToString();
                txtAmount.Text = row["Amount"].ToString();
                txtProductCode.Text = row["PrdCode"].ToString();


                txtProductACode.Focus();
            }

        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            clear();
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
                            sqlcom.CommandText = "[sp_IndMstAddEdit]";
                            sqlcom.Parameters.Add("@IndmNo", SqlDbType.NVarChar).Value = "000000";
                            sqlcom.Parameters["@IndmNo"].Direction = ParameterDirection.InputOutput;
                            sqlcom.Parameters.Add("@IndmDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@IndmDeptCode", SqlDbType.NVarChar).Value = txtDeptCode.Text.Trim();
                            sqlcom.Parameters.Add("@UnitCode", SqlDbType.NVarChar).Value = GlobalVariables.CUnitID;
                            sqlcom.Parameters.Add("@AddEditTag", SqlDbType.VarChar).Value = "ADD";
                            sqlcom.ExecuteNonQuery();
                            txtSerialNo.Text = sqlcom.Parameters["@IndmNo"].Value.ToString();
                            sqlcom.Parameters.Clear();
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = "[sp_IndMstAddEdit]";
                            sqlcom.Parameters.Add("@IndmNo", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                            sqlcom.Parameters.Add("@IndmDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@IndmDeptCode", SqlDbType.NVarChar).Value = txtDeptCode.Text.Trim();
                            sqlcom.Parameters.Add("@UnitCode", SqlDbType.NVarChar).Value = GlobalVariables.CUnitID;
                            sqlcom.Parameters.Add("@AddEditTag", SqlDbType.VarChar).Value = "EDIT";
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();


                            sqlcom.CommandType = CommandType.Text;
                            sqlcom.CommandText = "Delete from IndData Where InddNo=@InddNo And IndDDate=@IndDDate ANd UnitCode=@UnitCode ";
                            sqlcom.Parameters.Add("@InddNo", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                            sqlcom.Parameters.Add("@IndDDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@UnitCode", SqlDbType.NVarChar).Value = GlobalVariables.CUnitID;
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();


                        }


                        for (var i = 0; i < MaxRow; i++)
                        {
                            sqlcom.CommandType = CommandType.Text;
                            var currentrow = InfoGridView.GetDataRow(i);
                            sqlcom.CommandText = " Insert into IndData "
                                                        + " (InddNo,IndDDate,IndDItemCode,"
                                                        + " IndDItemQty,IndEstAmt,UnitCode)"
                                                        + " values(@InddNo,@IndDDate,@IndDItemCode,@IndDItemQty,"
                                                        + " @IndEstAmt,@UnitCode)";
                            sqlcom.Parameters.Add("@InddNo", SqlDbType.NVarChar).Value = txtSerialNo.Text;
                            sqlcom.Parameters.Add("@IndDDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("dd-MM-yyyy");
                            sqlcom.Parameters.Add("@IndDItemCode", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["PrdCode"]);
                            sqlcom.Parameters.Add("@IndDItemQty", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["Qty"]);
                            sqlcom.Parameters.Add("@IndEstAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["Amount"]);
                            sqlcom.Parameters.Add("@UnitCode", SqlDbType.NVarChar).Value = GlobalVariables.CUnitID;
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

                        txtProductQty.Focus();
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

        private void txtProductQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private void HelpGrid_DoubleClick(object sender, EventArgs e)
        {
            DataRow Row = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);
            if (HelpGrid.Text == "txtProductACode")
            {
                txtProductACode.Text = Row["PrdAsgnCode"].ToString();
                txtProductName.Text = Row["PrdName"].ToString();
                txtProductCode.Text = Row["PrdCode"].ToString();
                HelpGrid.Visible = false;
                txtProductQty.Focus();
            }
            if (HelpGrid.Text == "txtDeptCode")
            {
                txtDeptCode.Text = Row["DeptCode"].ToString();
                txtDeptName.Text = Row["DeptDesc"].ToString();
                HelpGrid.Visible = false;
                txtProductACode.Focus();
            }
        }

        private void txtDeptCode_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForTwoBoxes("Select DeptCode,DeptDesc from DeptMst", " Where DeptCode", txtDeptCode, txtDeptName, txtProductACode, HelpGrid, HelpGridView, e);

        }

        private void HelpGrid_Click(object sender, EventArgs e)
        {

        }
    }
}