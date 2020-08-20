using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Transaction
{
    public partial class frmPurchaseFromHO : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        public String s1 { get; set; }
        public String SFMTOTBOX { get; set; }
        public String SFDVNO { get; set; }

        public frmPurchaseFromHO()
        {

            InitializeComponent();
            dt.Columns.Add("SFDBOXNO", typeof(String));
            dt.Columns.Add("SFDBARCODE", typeof(String));
            dt.Columns.Add("SFDARTNO", typeof(String));
            dt.Columns.Add("SFDARTDESC", typeof(String));
            dt.Columns.Add("SFDCOLN", typeof(String));
            dt.Columns.Add("SFDSIZN", typeof(String));
            dt.Columns.Add("SFDSCANQTY", typeof(Decimal));
            dt.Columns.Add("SFDARTMRP", typeof(Decimal));
            dt.Columns.Add("SFDARTWSP", typeof(Decimal));
            dt.Columns.Add("SFDARTID", typeof(String));
            dt.Columns.Add("SFDCOLID", typeof(String));
            dt.Columns.Add("SFDSIZID", typeof(String));
        }
        private void ShowImage(String ArticleID)
        {
            try
            {
                DataSet dsImage = ProjectFunctions.GetDataSet("Select ARTIMAGE from ARTICLE Where ARTSYSID='" + ArticleID + "'");
                if (dsImage.Tables[0].Rows[0]["ARTIMAGE"].ToString().Trim() != string.Empty)
                {
                    Byte[] MyData = new byte[0];
                    MyData = (Byte[])dsImage.Tables[0].Rows[0]["ARTIMAGE"];
                    MemoryStream stream = new MemoryStream(MyData)
                    {
                        Position = 0
                    };

                    ArticleImageBox.Image = System.Drawing.Image.FromStream(stream);
                }
                else
                {
                    ArticleImageBox.Image = null;
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
        }
        private void FrmPurchaseFromHO_Load(object sender, EventArgs e)
        {
            try
            {
                ProjectFunctions.GirdViewVisualize(BarCodeGridView);
                ProjectFunctions.GirdViewVisualize(HelpGridView);
                ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
                ProjectFunctions.TextBoxVisualize(this);
                if (s1 == "&Add")
                {
                    String MemoNo = ProjectFunctions.GetDataSet("select isnull(max(SFMVNO),0)+1 from SFMAIN where SFMFNYR='" + GlobalVariables.FinancialYear + "' And UnitCode='" + GlobalVariables.CUnitID + "'").Tables[0].Rows[0][0].ToString();
                    txtMemoNo.Text = MemoNo;
                    lblBox.Text = "1";
                    txtMemoDate.EditValue = DateTime.Now;
                    lblTotQty.Text = "0";
                    txtBarCode.Focus();
                }
                if (s1 == "Edit")
                {
                    DataSet ds = ProjectFunctions.GetDataSet("SP_LoadBoxDataFEdit '" + SFDVNO + "' ,'" + SFMTOTBOX + "','" + GlobalVariables.FinancialYear + "','" + GlobalVariables.CUnitID + "' ");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtMemoDate.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["SFDVDATE"]);
                        txtMemoNo.EditValue = SFDVNO;
                        dt = ds.Tables[0];
                        BarCodeGrid.DataSource = dt;
                        BarCodeGridView.BestFitColumns();

                        Decimal QtySum = 0;
                        foreach (DataRow dr in dt.Rows)
                        {
                            lblBox.Text = Convert.ToDecimal(dr["SFDBOXNO"]).ToString("0");
                            QtySum = QtySum + Convert.ToDecimal(dr["SFDSCANQTY"]);
                        }
                        lblTotQty.Text = QtySum.ToString("0");
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }
        private bool ValidateDataForSaving()
        {
            if (BarCodeGrid.DataSource == null)
            {
                ProjectFunctions.SpeakError("No Data To Save");

            }

            foreach (DataRow dr in dt.Rows)
            {
                if (ProjectFunctions.CheckAllPossible(dr["SFDARTID"].ToString(), Convert.ToDecimal(dr["SFDARTMRP"]), dr["SFDCOLID"].ToString(), dr["SFDSIZID"].ToString()))
                {

                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        private void TxtBarCode_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                dt.AcceptChanges();
                if (ValidateDataForSaving())
                {

                    using (var sqlcon = new SqlConnection(ProjectFunctions.GetConnection()))
                    {


                        sqlcon.Open();
                        var sqlcom = sqlcon.CreateCommand();
                        sqlcom.Connection = sqlcon;
                        sqlcom.CommandType = CommandType.StoredProcedure;
                        sqlcom.CommandType = CommandType.Text;
                        if (s1 == "&Add")
                        {
                            sqlcom.CommandText = " Insert into SFMAIN "
                                                        + " (SFMSYSDATE,SFMFNYR,SFMVNO,SFMLOC,SFMTOTBOX,SFMREMARKS,"
                                                        + " SFMTOTQTY,SFMTOTMRPVAL,SFMTOTWSPVAL,SFMWRONGMRPQTY,SFMWCORRECTMRPQTY,UnitCode)"
                                                        + " values(@SFMSYSDATE,@SFMFNYR,@SFMVNO,@SFMLOC,@SFMTOTBOX,@SFMREMARKS,"
                                                        + " @SFMTOTQTY,@SFMTOTMRPVAL,@SFMTOTWSPVAL,@SFMWRONGMRPQTY,@SFMWCORRECTMRPQTY,@UnitCode)";
                            sqlcom.Parameters.Add("@SFMSYSDATE", SqlDbType.NVarChar).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            sqlcom.Parameters.Add("@SFMFNYR", SqlDbType.NVarChar).Value = GlobalVariables.FinancialYear;
                            sqlcom.Parameters.Add("@SFMVNO", SqlDbType.NVarChar).Value = txtMemoNo.Text;
                            sqlcom.Parameters.Add("@SFMLOC", SqlDbType.NVarChar).Value = txtLocation.Text;
                            sqlcom.Parameters.Add("@SFMTOTBOX", SqlDbType.NVarChar).Value = lblBox.Text;
                            sqlcom.Parameters.Add("@SFMREMARKS", SqlDbType.NVarChar).Value = txtRemarks.Text;
                            sqlcom.Parameters.Add("@SFMTOTQTY", SqlDbType.NVarChar).Value = Convert.ToDecimal(gridColumn7.SummaryItem.SummaryValue).ToString("0.00");
                            sqlcom.Parameters.Add("@SFMTOTMRPVAL", SqlDbType.NVarChar).Value = Convert.ToDecimal(gridColumn9.SummaryItem.SummaryValue).ToString("0.00");
                            sqlcom.Parameters.Add("@SFMTOTWSPVAL", SqlDbType.NVarChar).Value = Convert.ToDecimal(gridColumn10.SummaryItem.SummaryValue).ToString("0.00");
                            sqlcom.Parameters.Add("@SFMWRONGMRPQTY", SqlDbType.NVarChar).Value = "0";
                            sqlcom.Parameters.Add("@SFMWCORRECTMRPQTY", SqlDbType.NVarChar).Value = "0";
                            sqlcom.Parameters.Add("@UnitCode", SqlDbType.NVarChar).Value = GlobalVariables.CUnitID;
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " update SFMAIN Set  "
                                                        + "SFMLOC=@SFMLOC,SFMTOTBOX=@SFMTOTBOX,SFMREMARKS=@SFMREMARKS,"
                                                        + " SFMTOTQTY=@SFMTOTQTY,SFMTOTMRPVAL=@SFMTOTMRPVAL,SFMTOTWSPVAL=@SFMTOTWSPVAL,SFMWRONGMRPQTY=@SFMWRONGMRPQTY,SFMWCORRECTMRPQTY=@SFMWCORRECTMRPQTY where SFMVNO='" + txtMemoNo.Text + "' And SFMTOTBOX='" + lblBox.Text + "'";



                            sqlcom.Parameters.Add("@SFMLOC", SqlDbType.NVarChar).Value = txtLocation.Text;
                            sqlcom.Parameters.Add("@SFMTOTBOX", SqlDbType.NVarChar).Value = lblBox.Text;
                            sqlcom.Parameters.Add("@SFMREMARKS", SqlDbType.NVarChar).Value = txtRemarks.Text;
                            sqlcom.Parameters.Add("@SFMTOTQTY", SqlDbType.NVarChar).Value = Convert.ToDecimal(gridColumn7.SummaryItem.SummaryValue).ToString("0.00");
                            sqlcom.Parameters.Add("@SFMTOTMRPVAL", SqlDbType.NVarChar).Value = Convert.ToDecimal(gridColumn9.SummaryItem.SummaryValue).ToString("0.00");
                            sqlcom.Parameters.Add("@SFMTOTWSPVAL", SqlDbType.NVarChar).Value = Convert.ToDecimal(gridColumn10.SummaryItem.SummaryValue).ToString("0.00");
                            sqlcom.Parameters.Add("@SFMWRONGMRPQTY", SqlDbType.NVarChar).Value = "0";
                            sqlcom.Parameters.Add("@SFMWCORRECTMRPQTY", SqlDbType.NVarChar).Value = "0";
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();


                            ProjectFunctions.GetDataSet("update SKU set Used='N' where SKUPRODUCTCODE in (Select SFDBARCODE from SFDET Where SFDVNO='" + txtMemoNo.Text + "' And SFDBOXNO='" + lblBox.Text + "' And UnitCode='" + GlobalVariables.CUnitID + "' And SFDFNYR='" + GlobalVariables.FinancialYear + "') And UnitCode='" + GlobalVariables.CUnitID + "' And SKUFNYR='" + GlobalVariables.FinancialYear + "'");
                            ProjectFunctions.GetDataSet("Delete from SFDET Where SFDVNO='" + txtMemoNo.Text + "' And SFDBOXNO='" + lblBox.Text + "' And UnitCode='" + GlobalVariables.CUnitID + "' And SFDFNYR='" + GlobalVariables.FinancialYear + "'");

                            //foreach (DataRow dr in (BarCodeGrid.DataSource as DataTable).Rows)
                            //{

                            //}                                  
                        }


                        foreach (DataRow dr in dt.Rows)
                        {
                            sqlcom.CommandText = " Insert into SFDET "
                                                    + " (SFDSYSDATE,SFDFNYR,SFDVDATE,SFDVNO,SFDBOXNO,SFDBARCODE,"
                                                    + " SFDARTNO,SFDARTID,SFDARTDESC,SFDCOLN,SFDCOLID,SFDSIZN,SFDSIZID,SFDSCANQTY,"
                                                    + " SFDARTMRP,SFDARTWSP,SFDBOXQTY,SFDBOXMRPVAL,SFDBOXWSPVAL,SFDWRONGMRP,UnitCode)"
                                                    + " values(@SFDSYSDATE,@SFDFNYR,@SFDVDATE,@SFDVNO,@SFDBOXNO,@SFDBARCODE,"
                                                    + " @SFDARTNO,@SFDARTID,@SFDARTDESC,@SFDCOLN,@SFDCOLID,@SFDSIZN,@SFDSIZID,@SFDSCANQTY,"
                                                    + " @SFDARTMRP,@SFDARTWSP,@SFDBOXQTY,@SFDBOXMRPVAL,@SFDBOXWSPVAL,@SFDWRONGMRP,@UnitCode)";
                            sqlcom.Parameters.Add("@SFDSYSDATE", SqlDbType.NVarChar).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            sqlcom.Parameters.Add("@SFDFNYR", SqlDbType.NVarChar).Value = GlobalVariables.FinancialYear;
                            sqlcom.Parameters.Add("@SFDVDATE", SqlDbType.NVarChar).Value = Convert.ToDateTime(txtMemoDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@SFDVNO", SqlDbType.NVarChar).Value = txtMemoNo.Text;
                            sqlcom.Parameters.Add("@SFDBOXNO", SqlDbType.NVarChar).Value = dr["SFDBOXNO"].ToString();
                            sqlcom.Parameters.Add("@SFDBARCODE", SqlDbType.NVarChar).Value = dr["SFDBARCODE"].ToString();
                            sqlcom.Parameters.Add("@SFDARTNO", SqlDbType.NVarChar).Value = dr["SFDARTNO"].ToString();
                            sqlcom.Parameters.Add("@SFDARTID", SqlDbType.NVarChar).Value = dr["SFDARTID"].ToString();
                            sqlcom.Parameters.Add("@SFDARTDESC", SqlDbType.NVarChar).Value = dr["SFDARTDESC"].ToString();
                            sqlcom.Parameters.Add("@SFDCOLN", SqlDbType.NVarChar).Value = dr["SFDCOLN"].ToString();
                            sqlcom.Parameters.Add("@SFDCOLID", SqlDbType.NVarChar).Value = dr["SFDCOLID"].ToString();
                            sqlcom.Parameters.Add("@SFDSIZN", SqlDbType.NVarChar).Value = dr["SFDSIZN"].ToString();
                            sqlcom.Parameters.Add("@SFDSIZID", SqlDbType.NVarChar).Value = dr["SFDSIZID"].ToString();
                            sqlcom.Parameters.Add("@SFDSCANQTY", SqlDbType.NVarChar).Value = dr["SFDSCANQTY"].ToString();
                            sqlcom.Parameters.Add("@SFDARTMRP", SqlDbType.NVarChar).Value = dr["SFDARTMRP"].ToString();
                            sqlcom.Parameters.Add("@SFDARTWSP", SqlDbType.NVarChar).Value = dr["SFDARTWSP"].ToString();
                            sqlcom.Parameters.Add("@SFDBOXQTY", SqlDbType.NVarChar).Value = dr["SFDBOXNO"].ToString();
                            sqlcom.Parameters.Add("@SFDBOXMRPVAL", SqlDbType.NVarChar).Value = dr["SFDARTMRP"].ToString();
                            sqlcom.Parameters.Add("@SFDBOXWSPVAL", SqlDbType.NVarChar).Value = dr["SFDARTWSP"].ToString();
                            sqlcom.Parameters.Add("@SFDWRONGMRP", SqlDbType.NVarChar).Value = "0";
                            sqlcom.Parameters.Add("@UnitCode", SqlDbType.NVarChar).Value = GlobalVariables.CUnitID;
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();

                            ProjectFunctions.GetDataSet("update SKU set Used='Y' where SKUPRODUCTCODE='" + dr["SFDBARCODE"].ToString() + "' And UnitCode='" + GlobalVariables.CUnitID + "'");
                        }



                        BarCodeGridView.ExportToCsv(AppDomain.CurrentDomain.BaseDirectory + @"\tempbarcode.txt");
                        ProjectFunctions.SpeakError(" Box Saved Successfully");
                        sqlcon.Close();
                        if (s1 == "&Add")
                        {
                            lblBox.Text = (Convert.ToInt32(lblBox.Text) + 1).ToString();
                            BarCodeGrid.DataSource = null;
                            dt.Clear();
                            lblTotQty.Text = "0";
                        }
                        else
                        {
                            lblBox.Text = ProjectFunctions.GetDataSet("select isnull( max(SFMTOTBOX),0)+1 from SFMAIN where SFMVNO='" + txtMemoNo.Text + "' And SFMFNYR='" + GlobalVariables.FinancialYear + "' And UnitCode='" + GlobalVariables.CUnitID + "'").Tables[0].Rows[0][0].ToString();
                            BarCodeGrid.DataSource = null;
                            dt.Clear();
                            lblTotQty.Text = "0";
                            s1 = "&Add";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void BtnImportBarCodeForBranch_Click(object sender, EventArgs e)
        {
            try
            {
                HelpGridView.Columns.Clear();
                HelpGrid.Text = "Load";
                DataSet ds = ProjectFunctions.GetDataSet("sp_LoadDataFSKUFromHO '" + GlobalVariables.CUnitID + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds.Tables[0].Columns.Add("Select", typeof(bool));
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        dr["Select"] = false;
                    }
                    HelpGrid.DataSource = ds.Tables[0];
                    HelpGrid.Show();
                    HelpGrid.Focus();
                    HelpGridView.BestFitColumns();
                    HelpGridView.OptionsBehavior.Editable = true;
                    foreach (DevExpress.XtraGrid.Columns.GridColumn col in HelpGridView.Columns)
                    {
                        if (col.FieldName == "Select")
                        {
                            col.OptionsColumn.AllowEdit = true;
                        }
                        else
                        {
                            col.OptionsColumn.AllowEdit = false;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void HelpGridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Select All Records", (o1, e1) =>
            {
#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
                var MaxRow = ((HelpGrid.KeyboardFocusView as GridView).RowCount);
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
                for (var i = 0; i < MaxRow; i++)
                {
                    HelpGridView.SetRowCellValue(i, HelpGridView.Columns["Select"], true);
                }
            }));
        }

        private void BarCodeGrid_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow currentrow = BarCodeGridView.GetDataRow(BarCodeGridView.FocusedRowHandle);
                ShowImage(currentrow["SFDARTID"].ToString());
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void BarCodeGridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Delete Current Record", (o1, e1) =>
                {
                    ProjectFunctions.DeleteCurrentRowOnRightClick(BarCodeGrid, BarCodeGridView);
                    dt.AcceptChanges();
                    Decimal QtySum = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        QtySum = QtySum + Convert.ToDecimal(dr["SFDSCANQTY"]);
                    }
                    lblTotQty.Text = QtySum.ToString("0");
                }));
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }


        private void HelpGrid_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                if (HelpGrid.Text == "Load")
                {
                    int i = 0;
                    foreach (DataRow dr in (HelpGrid.DataSource as DataTable).Rows)
                    {
                        if (dr["Select"].ToString().ToUpper() == "TRUE")
                        {
                            DataSet ds = ProjectFunctions.GetDataSet("sp_LoadDataFSKUFGridFromHO '" + dr["SKUVOUCHNO"].ToString() + "','" + GlobalVariables.FinancialYear + "','" + GlobalVariables.CUnitID + "'");
                            if (i == 0)
                            {
                                dt.Clear();
                                dt = ds.Tables[0];
                                i++;
                            }
                            else
                            {
                                dt.Merge(ds.Tables[0]);
                            }
                        }
                    }
                    if (dt.Rows.Count > 0)
                    {
                        Decimal QtySum = 0;
                        foreach (DataRow dr in dt.Rows)
                        {
                            dr["SFDBOXNO"] = Convert.ToDecimal(lblBox.Text);
                            QtySum = QtySum + Convert.ToDecimal(dr["SFDSCANQTY"]);
                        }
                        lblTotQty.Text = QtySum.ToString("0");
                        BarCodeGrid.DataSource = dt;
                        BarCodeGridView.BestFitColumns();
                    }
                    else
                    {
                        BarCodeGrid.DataSource = null;
                    }
                    HelpGrid.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }

        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPurchaseFromHO_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.SalePopUPForAllWindows(this, e);
        }
    }
}