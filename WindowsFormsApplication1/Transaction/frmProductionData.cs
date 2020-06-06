using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Transaction
{
    public partial class frmProductionData : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        DataTable dt = new DataTable();
        int rowindex;
        public String ImNo { get; set; }
        public DateTime ImDate { get; set; }

        public frmProductionData()
        {
            InitializeComponent();
            dt.Columns.Add("PrdCode", typeof(String));
            dt.Columns.Add("PrdAsgnCode", typeof(String));
            dt.Columns.Add("PrdName", typeof(String));
            dt.Columns.Add("Bags", typeof(Decimal));
            dt.Columns.Add("Production", typeof(Decimal));
            dt.Columns.Add("Wastage", typeof(Decimal));


        }
        private bool ValidateDataForSaving()
        {

            if (txtPlantRunHours.Text.Trim().Length == 0)
            {
                txtPlantRunHours.Text = "0";
            }

            if (Convert.ToDecimal(txtPlantRunHours.Text) <= 0)
            {
                ProjectFunctions.SpeakError("Plant Run Hours Should Be Greater Than Zero");
                txtPlantRunHours.Focus();
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
            if (txtBags.Text.Trim().Length == 0)
            {
                txtBags.Text = "0";
            }
            if (txtWastage.Text.Trim().Length == 0)
            {
                txtWastage.Text = "0";
            }
            if (txtProduction.Text.Trim().Length == 0)
            {
                txtProduction.Text = "0";
            }
            if (Convert.ToDecimal(txtBags.Text) <= 0)
            {
                ProjectFunctions.SpeakError("Bag Quantity Should Be Greater Than Zero");
                txtPrdAsgnCode.Focus();
                return false;
            }
            if (Convert.ToDecimal(txtProduction.Text) <= 0)
            {
                ProjectFunctions.SpeakError("Production Quantity Should Be Greater Than Zero");
                txtPrdAsgnCode.Focus();
                return false;
            }
            //DataSet dsBom = ProjectFunctions.GetDataSet(String.Format("SELECT   Top 1 BomMst.bomNo as BomNo,BomAplDate,BomRem FROM BomMst  where bomprdid={0}  Order By bomNo Desc", txtPrdCode.Text));
            //if (dsBom.Tables.Count > 0)
            //{
            //    if (dsBom.Tables[0].Rows.Count > 0)
            //    {

            //    }
            //    else
            //    {
            //        ProjectFunctions.SpeakError("No Bom For This Product");
            //    }
            //}
            //else
            //{
            //    ProjectFunctions.SpeakError("No Bom For This Product");
            //}
            return true;
        }
        private string getNewInvoiceDocumentNo()
        {
            var s2 = string.Empty;
            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(imno as int)),000000) from InvoiceMst Where ImType='PR'  And  ImDate='" + Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd") + "'");
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
            txtBags.Text = string.Empty;
            txtWastage.Text = string.Empty;
            txtProduction.Text = string.Empty;

            txtPrdAsgnCode.Focus();
        }
        private void SetMyControls()
        {
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
        }
        private void InfoGrid_Click(object sender, EventArgs e)
        {

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
                    NewRow["Bags"] = Convert.ToDecimal(txtBags.Text);
                    NewRow["Production"] = Convert.ToDecimal(txtProduction.Text);
                    NewRow["Wastage"] = Convert.ToDecimal(txtWastage.Text);
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
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["Bags"], Convert.ToDecimal(txtBags.Text));
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["Production"], Convert.ToDecimal(txtProduction.Text));
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["Wastage"], Convert.ToDecimal(txtWastage.Text));
                    InfoGridView.RefreshData();
                    BtnUndo.PerformClick();
                }
            }
        }


        private void BtnUndo_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void txtPrdAsgnCode_EditValueChanged(object sender, EventArgs e)
        {
            txtPrdCode.Text = string.Empty;
            txtProductName.Text = string.Empty;
        }

        private void frmProductionData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                System.Windows.Forms.SendKeys.Send("+{TAB}");
            }
        }

        private void txtWastage_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private void frmProductionData_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtInvoiceType.Text = "PR";
                dtInvoiceDate.EditValue = DateTime.Now;

                txtSerialNo.Text = getNewInvoiceDocumentNo().PadLeft(6, '0');
                txtPlant.Focus();

            }
            if (s1 == "Edit")
            {
                dtInvoiceDate.Enabled = false;
                DataSet ds = ProjectFunctions.GetDataSet(String.Format("sp_LoadPrdnDataFEdit '{0}','{1}'", ImNo, ImDate.Date.ToString("yyyy-MM-dd")));
                txtSerialNo.Text = ds.Tables[0].Rows[0]["ImNo"].ToString();
                txtPlant.Text = ds.Tables[0].Rows[0]["ImPlant"].ToString();
                txtPlantRunHours.Text = ds.Tables[0].Rows[0]["ImPlantRunHRs"].ToString();
                txtShift.Text = ds.Tables[0].Rows[0]["ImShift"].ToString();
                txtInvoiceType.Text = ds.Tables[0].Rows[0]["ImType"].ToString();
                dtInvoiceDate.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["ImDate"]);
                dt = ds.Tables[1];
                InfoGrid.DataSource = dt;



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
                txtPrdAsgnCode.Text = row["PrdAsgnCode"].ToString();
                txtPrdCode.Text = row["PrdCode"].ToString();
                txtProductName.Text = row["PrdName"].ToString();

                txtBags.Text = row["Bags"].ToString();
                txtProduction.Text = row["Production"].ToString();
                txtWastage.Text = row["Wastage"].ToString();
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
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        if (s1 == "&Add")
                        {
                            sqlcom.CommandText = "[sp_ProductionMstAdd]";
                            sqlcom.Parameters.Add("@ImNo", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                            sqlcom.Parameters["@ImNo"].Direction = ParameterDirection.InputOutput;
                            sqlcom.Parameters.Add("@ImFyear", SqlDbType.NVarChar).Value = ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear);
                            sqlcom.Parameters.Add("@ImDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@ImType", SqlDbType.NVarChar).Value = "PR";
                            sqlcom.Parameters.Add("@ImPlant", SqlDbType.NVarChar).Value = txtPlant.Text.Trim();
                            sqlcom.Parameters.Add("@ImShift", SqlDbType.NVarChar).Value = txtShift.Text.Trim();
                            sqlcom.Parameters.Add("@ImPlantRunHRs", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtPlantRunHours.Text);
                            sqlcom.Parameters.Add("@AddEditTag", SqlDbType.VarChar).Value = "&Add";
                            sqlcom.ExecuteNonQuery();
                            txtSerialNo.Text = sqlcom.Parameters["@ImNo"].Value.ToString();
                            sqlcom.Parameters.Clear();
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = "[sp_ProductionMstAdd]";
                            sqlcom.Parameters.Add("@ImNo", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                            sqlcom.Parameters.Add("@ImFyear", SqlDbType.NVarChar).Value = ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear);
                            sqlcom.Parameters.Add("@ImDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@ImType", SqlDbType.NVarChar).Value = "PR";
                            sqlcom.Parameters.Add("@ImPlant", SqlDbType.NVarChar).Value = txtPlant.Text.Trim();
                            sqlcom.Parameters.Add("@ImShift", SqlDbType.NVarChar).Value = txtShift.Text.Trim();
                            sqlcom.Parameters.Add("@ImPlantRunHRs", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtPlantRunHours.Text);
                            sqlcom.Parameters.Add("@AddEditTag", SqlDbType.VarChar).Value = "EDIT";

                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();


                            sqlcom.CommandType = CommandType.Text;
                            sqlcom.CommandText = "Delete from InvoiceData Where IdNo=@IdNo And IdDate=@IdDate And IdType='PR'";
                            sqlcom.Parameters.Add("@IdNo", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                            sqlcom.Parameters.Add("@IdDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();


                        }


                        for (var i = 0; i < MaxRow; i++)
                        {
                            var currentrow = InfoGridView.GetDataRow(i);


                            sqlcom.CommandType = CommandType.Text;
                            sqlcom.CommandText = " Insert into InvoiceData "
                                                        + " (IdFyear,IdType,IdNo,IdDate,IdPrdCode,IdQtyBag,"
                                                        + " IdPrdQtyW,IdPrdQty,IdPrdBomNo)"
                                                        + " values(@IdFyear,@IdType,@IdNo,@IdDate,@IdPrdCode,@IdQtyBag,"
                                                        + " @IdPrdQtyW,@IdPrdQty,@IdPrdBomNo)";


                            sqlcom.Parameters.Add("@IdFyear", SqlDbType.NVarChar).Value = ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear);
                            sqlcom.Parameters.Add("@IdType", SqlDbType.NVarChar).Value = "PR";
                            sqlcom.Parameters.Add("@IdNo", SqlDbType.NVarChar).Value = txtSerialNo.Text;
                            sqlcom.Parameters.Add("@IdDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("dd-MM-yyyy");
                            sqlcom.Parameters.Add("@IdPrdCode", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["PrdCode"]);
                            sqlcom.Parameters.Add("@IdQtyBag", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["Bags"]);
                            sqlcom.Parameters.Add("@IdPrdQtyW", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["Wastage"]);
                            sqlcom.Parameters.Add("@IdPrdQty", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["Production"]);
                            //sqlcom.Parameters.Add("@IdPrdBomNo", SqlDbType.NVarChar).Value = dsBom.Tables[0].Rows[0]["BomNo"].ToString();

                            sqlcom.Parameters.Add("@IdPrdBomNo", SqlDbType.NVarChar).Value = string.Empty;

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

                        txtBags.Focus();
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
            txtPrdAsgnCode.Text = Row["PrdAsgnCode"].ToString();
            txtProductName.Text = Row["PrdName"].ToString();
            txtPrdCode.Text = Row["PrdCode"].ToString();
            HelpGrid.Visible = false;
            txtBags.Focus();
        }

        private void txtProduction_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
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