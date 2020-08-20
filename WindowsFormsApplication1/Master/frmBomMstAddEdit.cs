using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class frmBomMstAddEdit : DevExpress.XtraEditors.XtraForm
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FinancialYear { get; set; }
        public string CurrentUser { get; set; }
        public string Company { get; set; }
        public DateTime CFinStart { get; set; }
        public DateTime CFinEnd { get; set; }
        public string CAdd { get; set; }
        public string CCode { get; set; }


        private DataTable dt = new DataTable();
        public string _s1 = null;
        public string _bomPrdId = null;
        public string _bomno = null;
        private int rowindex;
        public string bomno
        {
            get
            {
                return _bomno;
            }
            set
            {
                _bomno = value;
            }
        }
        public string bomPrdId
        {
            get
            {
                return _bomPrdId;
            }
            set
            {
                _bomPrdId = value;
            }
        }
        public string s1
        {
            get
            {
                return _s1;
            }
            set
            {
                _s1 = value;
            }
        }

        public frmBomMstAddEdit()
        {
            InitializeComponent();
            dt.Columns.Add("bomPartCode", typeof(string));
            dt.Columns.Add("bomPartId", typeof(decimal));
            dt.Columns.Add("PartName", typeof(string));
            dt.Columns.Add("bomPartQty", typeof(decimal));
        }
        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtPadAsgnCode1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HelpGrid.Text = "Product1";
                if (txtPrdAsgnCode1.Text.Length == 0)
                {
                    var ds = ProjectFunctions.GetDataSet("Select PrdAsgnCode,PrdName,PrdCode from PrdMst ");
                    HelpGrid.DataSource = ds.Tables[0];
                    HelpGridView.BestFitColumns();
                    HelpGrid.Visible = true;
                    HelpGrid.Focus();
                }
                else
                {
                    var ds = ProjectFunctions.GetDataSet("Select PrdAsgnCode,PrdName,PrdCode from PrdMst Where PrdAsgnCode='" + txtPrdAsgnCode1.Text + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtPrdAsgnCode1.Text = ds.Tables[0].Rows[0]["PrdAsgnCode"].ToString();
                        txtProductName1.Text = ds.Tables[0].Rows[0]["PrdName"].ToString();
                        txtProductCode1.Text = ds.Tables[0].Rows[0]["PrdCode"].ToString();
                        if (s1 == "&Add")
                        {
                            txtBomNo.Text = getNewInvoiceDocumentNo().PadLeft(4, '0');
                        }
                        txtPrdAsgnCode2.Focus();
                    }
                    else
                    {
                        var ds1 = ProjectFunctions.GetDataSet("Select PrdAsgnCode,PrdName,PrdCode from PrdMst ");
                        HelpGrid.DataSource = ds1.Tables[0];
                        HelpGridView.BestFitColumns();
                        HelpGrid.Visible = true;
                        HelpGrid.Focus();
                    }
                }
            }
            e.Handled = true;
        }

        private void txtPrdAsgnCode2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HelpGrid.Text = "Product2";
                if (txtPrdAsgnCode2.Text.Length == 0)
                {
                    var ds = ProjectFunctions.GetDataSet("Select PrdAsgnCode,PrdName,PrdCode from PrdMst ");
                    HelpGrid.DataSource = ds.Tables[0];
                    HelpGridView.BestFitColumns();
                    HelpGrid.Visible = true;
                    HelpGrid.Focus();
                }
                else
                {
                    var ds = ProjectFunctions.GetDataSet("Select PrdAsgnCode,PrdName,PrdCode from PrdMst Where PrdAsgnCode='" + txtPrdAsgnCode2.Text + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtPrdAsgnCode2.Text = ds.Tables[0].Rows[0]["PrdAsgnCode"].ToString();
                        txtProductName2.Text = ds.Tables[0].Rows[0]["PrdName"].ToString();
                        txtProductCode2.Text = ds.Tables[0].Rows[0]["PrdCode"].ToString();
                        txtReqQuantity.Focus();
                    }
                    else
                    {
                        var ds1 = ProjectFunctions.GetDataSet("Select PrdAsgnCode,PrdName,PrdCode from PrdMst ");
                        HelpGrid.DataSource = ds1.Tables[0];
                        HelpGridView.BestFitColumns();
                        HelpGrid.Visible = true;
                        HelpGrid.Focus();
                    }
                }
            }
            e.Handled = true;
        }

        private void txtReqQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void HelpGrid_DoubleClick(object sender, EventArgs e)
        {
            var row = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);
            if (HelpGrid.Text == "Product1")
            {
                txtPrdAsgnCode1.Text = row["PrdAsgnCode"].ToString();
                txtProductName1.Text = row["PrdName"].ToString();
                txtProductCode1.Text = row["PrdCode"].ToString();
                if (s1 == "&Add")
                {
                    txtBomNo.Text = getNewInvoiceDocumentNo().PadLeft(4, '0');
                }
                txtPrdAsgnCode2.Focus();
                HelpGrid.Visible = false;
            }
            if (HelpGrid.Text == "Product2")
            {
                txtPrdAsgnCode2.Text = row["PrdAsgnCode"].ToString();
                txtProductName2.Text = row["PrdName"].ToString();
                txtProductCode2.Text = row["PrdCode"].ToString();
                txtReqQuantity.Focus();
                HelpGrid.Visible = false;
            }
        }

        private void txtPrdAsgnCode1_EditValueChanged(object sender, EventArgs e)
        {
            txtProductCode1.Text = string.Empty;
            txtProductName1.Text = string.Empty;
        }

        private void txtPrdAsgnCode2_EditValueChanged(object sender, EventArgs e)
        {
            txtProductCode2.Text = string.Empty;
            txtProductName2.Text = string.Empty;
        }
        private string getNewInvoiceDocumentNo()
        {
            var s2 = string.Empty;
            var strsql = string.Empty;
            var ds = new DataSet();
            strsql = strsql + "select isnull(max(Cast(bomno as int)),0000) from bommst Where bomPrdId='" + txtProductCode1.Text + "'";

            ds = ProjectFunctions.GetDataSet(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString().Trim();
                s2 = (Convert.ToInt32(s2) + 1).ToString().Trim();
            }
            return s2;
        }
        private void frmBomMstAddEdit_Load(object sender, EventArgs e)
        {
            SetMyControls();
            txtBomNo.Properties.ReadOnly = true;

            if (s1 == "&Add")
            {
                txtProductionBag.Focus();
            }
            if (s1 == "Edit")
            {
                txtPrdAsgnCode1.Properties.ReadOnly = true;
                txtPrdAsgnCode1.TabStop = false;
                txtProductionBag.Focus();
                var str = "sp_LoadBomMstDataFEditing '" + bomno + "','" + bomPrdId + "'";
                var ds = ProjectFunctions.GetDataSet(str);
                txtBomNo.Text = ds.Tables[0].Rows[0]["bomNo"].ToString();
                txtPrdAsgnCode1.Text = ds.Tables[0].Rows[0]["bomPrdCode"].ToString();
                txtProductCode1.Text = ds.Tables[0].Rows[0]["bomPrdId"].ToString();
                txtProductionBag.Text = ds.Tables[0].Rows[0]["bomBPQty"].ToString();
                txtProductName1.Text = ds.Tables[0].Rows[0]["PrdName"].ToString();
                txtRemarks.Text = ds.Tables[0].Rows[0]["BomRem"].ToString();
                txtActive.Text = ds.Tables[0].Rows[0]["BomActive"].ToString();
                dt = ds.Tables[0];
                InfoGrid.DataSource = dt;
            }
        }

        private void HelpGrid_Click(object sender, EventArgs e)
        {
        }

        private void txtProductionBag_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }
        private bool validateData()
        {
            if (txtPrdAsgnCode2.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Product Code");
                txtPrdAsgnCode2.Focus();
                return false;
            }
            if (txtProductName2.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Product Code");
                txtPrdAsgnCode2.Focus();
                return false;
            }
            if (txtProductCode2.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Product Code");
                txtPrdAsgnCode2.Focus();
                return false;
            }
            if (txtReqQuantity.Text.Trim().Length == 0)
            {
                txtReqQuantity.Text = "0";
            }
            return true;
        }
        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (validateData())
            {
                if (BtnOK.Text.ToUpper() == "&OK")
                {
                    InfoGrid.RefreshDataSource();
                    var dr = dt.NewRow();
                    dr["bomPartCode"] = txtPrdAsgnCode2.Text.Trim();
                    dr["bomPartId"] = Convert.ToDecimal(txtProductCode2.Text);
                    dr["PartName"] = txtProductName2.Text;
                    dr["bomPartQty"] = Convert.ToDecimal(txtReqQuantity.Text);
                    dt.Rows.Add(dr);
                    if (dt.Rows.Count > 0)
                    {
                        InfoGrid.DataSource = dt;
                    }
                    BtnUndo.PerformClick();
                }
                if (BtnOK.Text.ToUpper() == "&UPDATE")
                {
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["bomPartCode"], txtPrdAsgnCode2.Text.Trim());
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["bomPartId"], Convert.ToDecimal(txtProductCode2.Text));
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["PartName"], txtProductName2.Text);
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["bomPartQty"], Convert.ToDecimal(txtReqQuantity.Text));
                    InfoGridView.RefreshData();
                    BtnUndo.PerformClick();
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (validateData())
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
                    BtnUndo.PerformClick();
                }
            }
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            BtnOK.Text = "&OK";
            txtReqQuantity.Text = string.Empty;
            txtProductName2.Text = string.Empty;
            txtProductCode2.Text = string.Empty;
            txtPrdAsgnCode2.Text = string.Empty;
            txtPrdAsgnCode2.Focus();
        }

        private void InfoGrid_DoubleClick(object sender, EventArgs e)
        {
            try
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
                    txtPrdAsgnCode2.Text = row["bomPartCode"].ToString().Trim();
                    txtProductCode2.Text = row["bomPartId"].ToString().Trim();
                    txtProductName2.Text = row["PartName"].ToString().Trim();
                    txtReqQuantity.Text = row["bomPartQty"].ToString().Trim();
                    txtPrdAsgnCode2.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool ValidateDataForSaving()
        {
#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            var MaxRow = ((InfoGrid.KeyboardFocusView as GridView).RowCount);
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            if (MaxRow == 0)
            {
                ProjectFunctions.SpeakError("Empty Entry Cannot Be Saved");
                return false;
            }
            if (txtPrdAsgnCode1.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Product Code");
                txtPrdAsgnCode1.Focus();
                return false;
            }
            if (txtProductName1.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Product Code");
                txtPrdAsgnCode1.Focus();
                return false;
            }
            if (txtProductCode1.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Product Code");
                txtPrdAsgnCode1.Focus();
                return false;
            }
            if (txtReqQuantity.Text.Trim().Length == 0)
            {
                txtReqQuantity.Text = "0";
            }
            if (txtProductionBag.Text.Trim().Length == 0)
            {
                txtProductionBag.Text = "0";
            }
            if (txtBomNo.Text.Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid BommNo ");
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateDataForSaving())
            {
                using (var con = new SqlConnection(ProjectFunctions.ConnectionString))
                {
                    if (s1 == "&Add")
                    {
                        txtBomNo.Text = getNewInvoiceDocumentNo().PadLeft(4, '0');
                    }
                    con.Open();
                    var cmd = new SqlCommand
                    {
                        Connection = con
                    };
#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
                    var MaxRow = ((InfoGrid.KeyboardFocusView as GridView).RowCount);
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
                    cmd.CommandType = CommandType.Text;
                    var str = "Delete from bommst where bomno='" + txtBomNo.Text + "' And bomPrdId='" + txtProductCode1.Text + "'";
                    cmd.CommandText = str;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    for (var i = 0; i < MaxRow; i++)
                    {
                        var currentrow = InfoGridView.GetDataRow(i);
                        var str2 = "Insert into bommst(bomPrdCode,bomPrdId,bomNo,bomPartCode,bomPartQty,bomPartId,bomBPQty,BomRem,BomActive)values(";
                        str2 = str2 + "'" + txtPrdAsgnCode1.Text + "',";
                        str2 = str2 + "'" + Convert.ToDecimal(txtProductCode1.Text) + "',";
                        str2 = str2 + "'" + txtBomNo.Text + "',";
                        str2 = str2 + "'" + currentrow["bomPartCode"].ToString() + "',";
                        str2 = str2 + "'" + Convert.ToDecimal(currentrow["bomPartQty"]) + "',";
                        str2 = str2 + "'" + Convert.ToDecimal(currentrow["bomPartId"]) + "',";
                        str2 = str2 + "'" + Convert.ToDecimal(txtProductionBag.Text) + "',";
                        str2 = str2 + "'" + txtRemarks.Text.Trim() + "',";
                        str2 = str2 + "'" + txtActive.Text.Trim() + "')";
                        cmd.CommandText = str2;
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        ProjectFunctions.SpeakError("Data Saved Successfully");
                    }
                }
                Close();
            }
        }

        private void txtPrdAsgnCode1_Enter(object sender, EventArgs e)
        {
            if (s1 == "&Add")
            {
#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
                var MaxRow = ((InfoGrid.KeyboardFocusView as GridView).RowCount);
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
                if (MaxRow == 0)
                {
                    txtPrdAsgnCode1.Properties.ReadOnly = false;
                }
                else
                {
                    txtPrdAsgnCode1.Properties.ReadOnly = true;
                }
            }
        }

        private void txtActive_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtActive.Text == "Y" || txtActive.Text == "N")
            {

            }
            else
            {
                ProjectFunctions.SpeakError("Valid Values are Y,N");
                txtActive.Focus();
            }
        }
    }
}