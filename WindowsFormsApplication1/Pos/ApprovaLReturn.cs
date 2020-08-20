using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Transaction.Pos
{
    public partial class ApprovaLReturn : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        DataTable dt = new DataTable();
        public String ImNo { get; set; }
        public DateTime ImDate { get; set; }
        public String ImSeries { get; set; }
        public ApprovaLReturn()
        {

            InitializeComponent();
            dt.Columns.Add("SIDBARCODE", typeof(String));
            dt.Columns.Add("SIDARTNO", typeof(String));
            dt.Columns.Add("SIDARTDESC", typeof(String));
            dt.Columns.Add("SIDCOLN", typeof(String));
            dt.Columns.Add("SIDSIZN", typeof(String));
            dt.Columns.Add("SIDSCANQTY", typeof(Decimal));
            dt.Columns.Add("SIDARTMRP", typeof(Decimal));
            dt.Columns.Add("SIDARTWSP", typeof(Decimal));

            dt.Columns.Add("SIDBOXQTY", typeof(Decimal));

            dt.Columns.Add("SIDARTID", typeof(String));
            dt.Columns.Add("SIDCOLID", typeof(String));
            dt.Columns.Add("SIDSIZID", typeof(String));
        }

        private void TxtCustMobileNo_EditValueChanged(object sender, EventArgs e)
        {
            txtCustCode.Text = String.Empty;
            txtCustDetails.Text = String.Empty;
            txtCustName.Text = String.Empty;
        }

        private void TxtCustMobileNo_KeyDown(object sender, KeyEventArgs e)
        {
            try

            {
                if (e.KeyCode == Keys.Enter)
                {
                    HelpGridView.Columns.Clear();
                    HelpGrid.Text = "txtCustMobileNo";
                    if (txtCustMobileNo.Text.Trim().Length == 0)
                    {
                        frmCustomerMst frm = new frmCustomerMst() { s1 = "&Add", Text = "Customer Addition", CustMobileNo = txtCustMobileNo.Text };
                        var P = ProjectFunctions.GetPositionInForm(this);
                        frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                        frm.ShowDialog(Parent);
                        if (GlobalVariables.GlobalCustWindowCount == 0)
                        {
                            SendKeys.Send("{Enter}");
                        }

                    }
                    else
                    {
                        DataSet ds = ProjectFunctions.GetDataSet(" select CAFSYSID,CAFFNAME+' '+ CAFMNAME+' '+ CAFLNAME as CAFFNAME, CAFADD+', '+CAFADD1+', '+CAFADD2 as CAFADD,CAFMOBILE from CAFINFO Where  CAFMOBILE='" + txtCustMobileNo.Text.Trim() + "'");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            txtCustMobileNo.Text = ds.Tables[0].Rows[0]["CAFMOBILE"].ToString();
                            txtCustCode.Text = ds.Tables[0].Rows[0]["CAFSYSID"].ToString();
                            txtCustName.Text = ds.Tables[0].Rows[0]["CAFFNAME"].ToString();
                            txtCustDetails.Text = ds.Tables[0].Rows[0]["CAFADD"].ToString();

                            txtBarCode.Focus();
                        }

                        else
                        {
                            frmCustomerMst frm = new frmCustomerMst() { s1 = "&Add", Text = "Customer Addition", CustMobileNo = txtCustMobileNo.Text };
                            var P = ProjectFunctions.GetPositionInForm(this);
                            frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                            if (GlobalVariables.GlobalCustWindowCount == 0)
                            {
                                SendKeys.Send("{Enter}");
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            e.Handled = true;
        }

        private void HelpGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HelpGrid_DoubleClick(null, e);
            }
            if (e.KeyCode == Keys.Enter)
            {
                HelpGrid.Visible = false;
            }
        }

        private void HelpGrid_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                DataRow row = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);

                if (HelpGrid.Text == "txtCustMobileNo")
                {
                    txtCustMobileNo.Text = row["CAFMOBILE"].ToString();
                    txtCustCode.Text = row["CAFSYSID"].ToString();
                    txtCustName.Text = row["CAFFNAME"].ToString();
                    txtCustDetails.Text = row["CAFADD"].ToString();
                    HelpGrid.Visible = false;
                    txtBarCode.Focus();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private bool ValidateDataForSaving()
        {
            if (txtCustCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Customer");
                txtCustMobileNo.Focus();
                return false;
            }
            if (txtCustName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Customer");
                txtCustMobileNo.Focus();
                return false;
            }
            return true;
        }
        private void SaveInvoice()
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
                    sqlcom.Connection = sqlcon;
                    sqlcom.CommandType = CommandType.Text;
                    try
                    {
                        if (s1 == "&Add")
                        {
                            String BillNo = String.Empty;

                            BillNo = ProjectFunctions.GetDataSet("select isnull(max(SIMNO),0)+1 from SALEINVMAIN where SIMSERIES='AR' And SIMFNYR='" + GlobalVariables.FinancialYear + "'And UnitCode='" + GlobalVariables.CUnitID + "'").Tables[0].Rows[0][0].ToString();
                            txtReturnNo.Text = BillNo;
                            sqlcom.CommandText = "Insert into SALEINVMAIN(SIMSYSDATE,SIMFNYR,SIMDATE,SIMNO,SIMSERIES,CustCode,SIMRemarks,UnitCode)values(" +
                                "@SIMSYSDATE,@SIMFNYR,@SIMDATE,@SIMNO,@SIMSERIES,@CustCode,@SIMRemarks,@UnitCode)";
                            sqlcom.Parameters.Add("@SIMSYSDATE", SqlDbType.NVarChar).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            sqlcom.Parameters.Add("@SIMFNYR", SqlDbType.NVarChar).Value = GlobalVariables.FinancialYear;
                            sqlcom.Parameters.Add("@SIMDATE", SqlDbType.NVarChar).Value = Convert.ToDateTime(txtReturnDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@SIMNO", SqlDbType.NVarChar).Value = txtReturnNo.Text;
                            sqlcom.Parameters.Add("@SIMSERIES", SqlDbType.NVarChar).Value = "AR";
                            sqlcom.Parameters.Add("@CustCode", SqlDbType.NVarChar).Value = txtCustCode.Text;
                            sqlcom.Parameters.Add("@SIMRemarks", SqlDbType.NVarChar).Value = txtRemarks.Text;
                            sqlcom.Parameters.Add("@UnitCode", SqlDbType.NVarChar).Value = GlobalVariables.CUnitID;
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = "Update SALEINVMAIN Set SIMSYSDATE=@SIMSYSDATE,SIMFNYR=@SIMFNYR,SIMDATE=@SIMDATE,SIMNO=@SIMNO," +
                                " SIMSERIES=@SIMSERIES,CustCode=@CustCode,SIMRemarks=@SIMRemarks Where SIMDATE='" + Convert.ToDateTime(ImDate).ToString("yyyy-MM-dd") + "' And SIMNO='" + ImNo + "' And SIMSERIES='" + ImSeries + "' ANd UnitCode='" + GlobalVariables.CUnitID + "'";

                            sqlcom.Parameters.Add("@SIMSYSDATE", SqlDbType.NVarChar).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            sqlcom.Parameters.Add("@SIMFNYR", SqlDbType.NVarChar).Value = GlobalVariables.FinancialYear;
                            sqlcom.Parameters.Add("@SIMDATE", SqlDbType.NVarChar).Value = Convert.ToDateTime(txtReturnDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@SIMNO", SqlDbType.NVarChar).Value = txtReturnNo.Text;
                            sqlcom.Parameters.Add("@SIMSERIES", SqlDbType.NVarChar).Value = "AR";
                            sqlcom.Parameters.Add("@CustCode", SqlDbType.NVarChar).Value = txtCustCode.Text;
                            sqlcom.Parameters.Add("@SIMRemarks", SqlDbType.NVarChar).Value = txtRemarks.Text;
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();


                            sqlcom.CommandType = CommandType.Text;
                            sqlcom.CommandText = "update SFDET set Used='Y' Where SFDBARCODE in (Select SIDBARCODE  from SALEINVDET Where SIDSERIES=@SIDSERIES And SIDNO=@SIDNO And SIDDATE=@SIDDATE And UnitCode='" + GlobalVariables.FinancialYear + "') ANd UnitCode='" + GlobalVariables.CUnitID + "'";
                            sqlcom.Parameters.Add("@SIDSERIES", SqlDbType.NVarChar).Value = ImSeries;
                            sqlcom.Parameters.Add("@SIDNO", SqlDbType.NVarChar).Value = ImNo;
                            sqlcom.Parameters.Add("@SIDDATE", SqlDbType.NVarChar).Value = Convert.ToDateTime(ImDate).ToString("yyyy-MM-dd");
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();

                            sqlcom.CommandType = CommandType.Text;
                            sqlcom.CommandText = "Delete from SALEINVDET Where SIDSERIES=@SIDSERIES And SIDNO=@SIDNO And SIDDATE=@SIDDATE ANd UnitCode='" + GlobalVariables.CUnitID + "'";
                            sqlcom.Parameters.Add("@SIDSERIES", SqlDbType.NVarChar).Value = ImSeries;
                            sqlcom.Parameters.Add("@SIDNO", SqlDbType.NVarChar).Value = ImNo;
                            sqlcom.Parameters.Add("@SIDDATE", SqlDbType.NVarChar).Value = Convert.ToDateTime(ImDate).ToString("yyyy-MM-dd");
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();
                        }
                        for (var i = 0; i < MaxRow; i++)
                        {
                            sqlcom.CommandType = CommandType.Text;
                            var currentrow = InfoGridView.GetDataRow(i);
                            sqlcom.CommandText = " Insert into SALEINVDET "
                                                        + " (SIDSYSDATE,SIDFNYR,SIDDATE,SIDNO,SIDSERIES,"
                                                        + " SIDBARCODE,SIDARTNO,SIDARTID,SIDCOLID,"
                                                        + " SIDSIZID,SIDSCANQTY,SIDARTMRP,SIDARTWSP,CustCode,UnitCode  )"
                                                        + " values(@SIDSYSDATE,@SIDFNYR,@SIDDATE,@SIDNO,@SIDSERIES,@SIDBARCODE,@SIDARTNO,@SIDARTID,@SIDCOLID,"
                                                        + " @SIDSIZID,@SIDSCANQTY,@SIDARTMRP,@SIDARTWSP,@CustCode,@UnitCode)";
                            sqlcom.Parameters.Add("@SIDSYSDATE", SqlDbType.NVarChar).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            sqlcom.Parameters.Add("@SIDFNYR", SqlDbType.NVarChar).Value = GlobalVariables.FinancialYear;
                            sqlcom.Parameters.Add("@SIDDATE", SqlDbType.NVarChar).Value = Convert.ToDateTime(txtReturnDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@SIDNO", SqlDbType.NVarChar).Value = txtReturnNo.Text.Trim(); ;
                            sqlcom.Parameters.Add("@SIDSERIES", SqlDbType.NVarChar).Value = "AR";
                            sqlcom.Parameters.Add("@SIDBARCODE", SqlDbType.NVarChar).Value = currentrow["SIDBARCODE"].ToString();
                            sqlcom.Parameters.Add("@SIDARTNO", SqlDbType.NVarChar).Value = currentrow["SIDARTNO"].ToString();
                            sqlcom.Parameters.Add("@SIDARTID", SqlDbType.NVarChar).Value = currentrow["SIDARTID"].ToString();
                            sqlcom.Parameters.Add("@SIDCOLID", SqlDbType.NVarChar).Value = currentrow["SIDCOLID"].ToString();
                            sqlcom.Parameters.Add("@SIDSIZID", SqlDbType.NVarChar).Value = currentrow["SIDSIZID"].ToString();
                            sqlcom.Parameters.Add("@SIDSCANQTY", SqlDbType.NVarChar).Value = -Convert.ToDecimal(currentrow["SIDSCANQTY"]);
                            sqlcom.Parameters.Add("@SIDARTMRP", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDARTMRP"]);
                            sqlcom.Parameters.Add("@SIDARTWSP", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDARTWSP"]);
                            sqlcom.Parameters.Add("@CustCode", SqlDbType.NVarChar).Value = txtCustCode.Text;
                            sqlcom.Parameters.Add("@UnitCode", SqlDbType.NVarChar).Value = GlobalVariables.CUnitID;
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();

                            ProjectFunctions.GetDataSet("update SFDET set Used='N' Where SFDBARCODE='" + currentrow["SIDBARCODE"].ToString() + "' And UnitCode='" + GlobalVariables.CUnitID + "'");
                        }


                        ProjectFunctions.SpeakError("Approval Return Saved Successfully");
                        sqlcon.Close();

                        this.Close();
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }
                }
            }
        }
        private void ApprovaLReturn_Load(object sender, EventArgs e)
        {
            try

            {
                ProjectFunctions.TextBoxVisualize(this);
                ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
                if (s1 == "&Add")
                {
                    txtReturnDate.EditValue = DateTime.Now.ToString("dd-MM-yyyy");
                    txtCustMobileNo.Focus();
                }
                if (s1 == "Edit")
                {
                    DataSet ds = ProjectFunctions.GetDataSet("[sp_LoadArticleApprovalMstFEdit] '" + ImDate.Date.ToString("yyyy-MM-dd") + "','" + ImNo + "','" + ImSeries + "','" + GlobalVariables.CUnitID + "'");

                    txtReturnDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["BillDate"]).ToString("yyyy-MM-dd");
                    txtReturnNo.Text = ds.Tables[0].Rows[0]["BillNo"].ToString();
                    txtCustMobileNo.Text = ds.Tables[0].Rows[0]["CAFMOBILE"].ToString();
                    txtCustCode.Text = ds.Tables[0].Rows[0]["CustCode"].ToString();
                    txtCustName.Text = ds.Tables[0].Rows[0]["CAFFNAME"].ToString();
                    txtCustDetails.Text = ds.Tables[0].Rows[0]["CAFADD"].ToString();
                    txtRemarks.Text = ds.Tables[0].Rows[0]["SIMRemarks"].ToString();

                    dt = ds.Tables[1];
                    InfoGrid.DataSource = dt;
                    InfoGridView.BestFitColumns();
                    txtCustMobileNo.Focus();

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.KeyCode == Keys.F3)
                //{
                //    HelpGridView.Columns.Clear();
                //    HelpGrid.Text = "Load";
                //    DataSet ds = ProjectFunctions.GetDataSet("sp_LoadDataFromSFDet_F3 '" + GlobalVariables.CUnitID + "'");
                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        ds.Tables[0].Columns.Add("Select", typeof(bool));
                //        foreach (DataRow dr in ds.Tables[0].Rows)
                //        {
                //            dr["Select"] = false;
                //        }
                //        HelpGrid.DataSource = ds.Tables[0];
                //        HelpGrid.Show();
                //        HelpGrid.Focus();
                //        HelpGridView.BestFitColumns();

                //        HelpGridView.OptionsBehavior.Editable = true;
                //        foreach (DevExpress.XtraGrid.Columns.GridColumn col in HelpGridView.Columns)
                //        {
                //            if (col.FieldName == "Select")
                //            {
                //                col.VisibleIndex = 0;
                //                col.OptionsColumn.AllowEdit = true;
                //            }
                //            else
                //            {
                //                col.OptionsColumn.AllowEdit = false;
                //            }
                //        }
                //    }

                //}
                if (e.KeyCode == Keys.Enter)
                {

                    DataSet ds = ProjectFunctions.GetDataSet("sp_LoadDataFromSKUdetForApprovalReturn '" + txtBarCode.Text + "','" + txtCustCode.Text + "','" + GlobalVariables.CUnitID + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (ds.Tables[0].Rows[0]["Used"].ToString().ToUpper() == "N")
                        {
                            ProjectFunctions.SpeakError("BarCode Already Used In Some Other Document");
                            txtBarCode.Focus();
                            txtBarCode.SelectAll();
                            e.Handled = true;
                            return;
                        }
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["SIDBARCODE"].ToString().ToUpper() == txtBarCode.Text.Trim())
                            {
                                ProjectFunctions.SpeakError("BarCode Already Loaded In This Document");
                                txtBarCode.Focus();
                                txtBarCode.SelectAll();
                                e.Handled = true;
                                return;
                            }
                        }
                        //if (Convert.ToDecimal(ds.Tables[0].Rows[0]["SIDARTMRP"]) != Convert.ToDecimal(ds.Tables[0].Rows[0]["ARTMRP"]))
                        //{
                        //    ProjectFunctions.SpeakError("Difference In MRP( MRP In Articel is - " + ds.Tables[0].Rows[0]["ARTMRP"].ToString() + ")");
                        //    txtBarCode.Focus();
                        //    txtBarCode.SelectAll();
                        //    e.Handled = true;

                        //}



                        if (dt.Rows.Count == 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Merge(ds.Tables[0]);
                        }

                        ShowImage(Convert.ToDecimal(ds.Tables[0].Rows[0]["SIDARTID"]).ToString());
                    }
                    else
                    {
                        ProjectFunctions.SpeakError("No Approval Generated Against This BarCode Found");
                        txtBarCode.Focus();
                        txtBarCode.SelectAll();
                        e.Handled = true;
                        return;
                    }
                    if (dt.Rows.Count > 0)
                    {
                        InfoGrid.DataSource = dt;
                        InfoGridView.BestFitColumns();
                    }
                    else
                    {
                        InfoGrid.DataSource = null;
                    }
                    txtBarCode.Text = String.Empty;
                    txtBarCode.Focus();
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
            e.Handled = true;
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
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveInvoice();
        }

        private void InfoGridView_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.DeleteCurrentRowOnKeyDown(InfoGrid, InfoGridView, e);
        }

        private void InfoGridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Delete Current Record", (o1, e1) =>
                {
                    ProjectFunctions.DeleteCurrentRowOnRightClick(InfoGrid, InfoGridView);
                }));
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
        }

        private void ApprovaLReturn_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.SalePopUPForAllWindows(this, e);
        }
    }
}