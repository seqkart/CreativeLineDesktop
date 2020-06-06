using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Transaction
{
    public partial class frmSupplierStock : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        public String s1 { get; set; }
        public String SCode { get; set; }
        public DateTime VerifyDate { get; set; }
#pragma warning disable CS0169 // The field 'frmSupplierStock.rowindex' is never used
        int rowindex;
#pragma warning restore CS0169 // The field 'frmSupplierStock.rowindex' is never used

        public frmSupplierStock()
        {
            InitializeComponent();

        }

        private void txtSCode_EditValueChanged(object sender, EventArgs e)
        {
            txtSName.Text = string.Empty;
        }

        private void frmSupplierStock_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                dtInvoiceDate.EditValue = DateTime.Now;
                txtSCode.Focus();
            }
            if (s1 == "Edit")
            {
                txtSCode.Enabled = false;
                txtProductACode.Focus();
                DataSet ds = ProjectFunctions.GetDataSet(String.Format("sp_LoadSupplierStockFEdit '{0}','{1}'", SCode, VerifyDate.Date.ToString("yyyy-MM-dd")));
                txtSCode.Text = ds.Tables[0].Rows[0]["SCode"].ToString();
                txtSName.Text = ds.Tables[0].Rows[0]["SName"].ToString();
                txtProductCode.Text = ds.Tables[0].Rows[0]["PrdCode"].ToString();
                txtProductName.Text = ds.Tables[0].Rows[0]["PrdAsgnCode"].ToString();
                txtProductACode.Text = ds.Tables[0].Rows[0]["PrdName"].ToString();
                txtQty.Text = ds.Tables[0].Rows[0]["Stock"].ToString();

                dtInvoiceDate.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["VerifyDate"]);
            }
        }
        private void SetMyControls()
        {
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
        }
        private bool ValidateData()
        {
            if (dtInvoiceDate.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Date");
                dtInvoiceDate.Focus();
                return false;
            }

            if (txtProductACode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Product");
                txtProductACode.Focus();
                return false;
            }
            if (txtProductCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Product");
                txtProductCode.Focus();
                return false;
            }
            if (txtProductName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Product");
                txtProductName.Focus();
                return false;
            }
            if (txtSCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Supplier");
                txtSCode.Focus();
                return false;
            }
            if (txtSName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Supplier");
                txtSCode.Focus();
                return false;
            }

            if (txtQty.Text.Length == 0)
            {
                txtQty.Text = "0";
            }
            if (Convert.ToDecimal(txtQty.Text) <= 0)
            {
                ProjectFunctions.SpeakError("Product Quantity Cannot Be Zero Or Less Than Zero");
                txtQty.Focus();
                return false;
            }
            return true;
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
                                                    + " Insert into SupplerStock"
                                                    + " (SCode,PrdCode,Stock,VerifyDate)"
                                                    + " values(@SCode,@PrdCode,@Stock,@VerifyDate)"
                                                    + " Commit ";
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE  SupplerStock Set  "
                                                + " SCode=@SCode,PrdCode=@PrdCode,Stock=@Stock,VerifyDate=@VerifyDate "
                                                + " Where SCode=@SCode And VerifyDate=@VerifyDate";

                        }
                        sqlcom.Parameters.AddWithValue("@SCode", txtSCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@PrdCode", Convert.ToDecimal(txtProductCode.Text));
                        sqlcom.Parameters.AddWithValue("@Stock", Convert.ToDecimal(txtQty.Text));
                        sqlcom.Parameters.AddWithValue("@VerifyDate", Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd"));
                        sqlcom.ExecuteNonQuery();
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
            if (HelpGrid.Text == "txtProductACode")
            {
                txtProductACode.Text = Row["PrdAsgnCode"].ToString();
                txtProductName.Text = Row["PrdName"].ToString();
                txtProductCode.Text = Row["PrdCode"].ToString();
                HelpGrid.Visible = false;
                txtQty.Focus();
            }
            if (HelpGrid.Text == "txtSCode")
            {
                txtSCode.Text = Row["SCode"].ToString();
                txtSName.Text = Row["SName"].ToString();
                HelpGrid.Visible = false;
                txtProductACode.Focus();
            }
        }

        private void txtSCode_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForTwoBoxes("Select SCode,SName from ActMst ", " Where  SCode ", txtSCode, txtSName, txtProductACode, HelpGrid, HelpGridView, e);
        }

        private void txtProductACode_EditValueChanged(object sender, EventArgs e)
        {
            txtProductCode.Text = string.Empty;
            txtProductName.Text = string.Empty;
        }
    }
}