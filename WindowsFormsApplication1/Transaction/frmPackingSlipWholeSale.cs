using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using System;
using System.Data;
using System.Data.SqlClient;

using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Transaction
{
    public partial class frmPackingSlipWholeSale : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();

        public String s1 { get; set; }

        public String PSWSNO { get; set; }

        public String PSWSTOTBOXES { get; set; }

        public String StkTransfer { get; set; }

        public String FixBarPartyTag { get; set; }

        public frmPackingSlipWholeSale()
        {
            InitializeComponent();
            dt.Columns.Add("SIDBOXNO", typeof(String));
            dt.Columns.Add("SIDBARCODE", typeof(String));
            dt.Columns.Add("SIDARTNO", typeof(String));
            dt.Columns.Add("SIDARTDESC", typeof(String));
            dt.Columns.Add("SIDCOLN", typeof(String));
            dt.Columns.Add("SIDSIZN", typeof(String));
            dt.Columns.Add("SIDSCANQTY", typeof(Decimal));
            dt.Columns.Add("SIDARTMRP", typeof(Decimal));
            dt.Columns.Add("SIDARTWSP", typeof(Decimal));
            dt.Columns.Add("SIDARTID", typeof(String));
            dt.Columns.Add("SIDCOLID", typeof(String));
            dt.Columns.Add("SIDSIZID", typeof(String));
            dt.Columns.Add("SIDPSNO", typeof(String));
        }

        private void BtnQuit_Click(object sender, EventArgs e) { this.Close(); }


        private void ShowImage(String ArticleID)
        {
            try
            {
                DataSet dsImage = ProjectFunctions.GetDataSet("Select ARTIMAGE from ARTICLE Where ARTSYSID='" +
                    ArticleID +
                    "'");
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
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
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

        private void Count()
        {
            Decimal QtySum = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dr["SIDBOXNO"] = Convert.ToDecimal(lblBox.Text);
                QtySum = QtySum + Convert.ToDecimal(dr["SIDSCANQTY"]);
            }
            lblTotQty.Text = QtySum.ToString("0");
        }

        private void HelpGrid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var row = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);
                if (HelpGrid.Text == "txtAccCode")
                {
                    txtAccCode.Text = row["AccCode"].ToString();
                    txtAccName.Text = row["AccName"].ToString();
                    txtGSTNo.Text = row["AccGSTNo"].ToString();
                    txtAddress.Text = row["AccAddress1"].ToString();
                    txtAddress2.Text = row["AccAddress2"].ToString();
                    txtAddress3.Text = row["AccAddress3"].ToString();
                    StkTransfer = row["AccStkTrf"].ToString();
                    txtCity.Text = row["CTNAME"].ToString();
                    txtState.Text = row["STNAME"].ToString();

                    FixBarPartyTag = row["AccFixBarCodeTag"].ToString();

                    txtPONo.Focus();
                    HelpGrid.Visible = false;
                    txtDANo.Focus();
                }
                if (HelpGrid.Text == "Load")
                {
                    int i = 0;
                    foreach (DataRow dr in (HelpGrid.DataSource as DataTable).Rows)
                    {
                        if (dr["Select"].ToString().ToUpper() == "TRUE")
                        {
                            DataSet ds = ProjectFunctions.GetDataSet("sp_LoadDataFromSKUdetForCashMemo '" +
                                dr["SIDBARCODE"].ToString() +
                                "','" +
                                GlobalVariables.CUnitID +
                                "'");
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
                        foreach (DataRow dr in dt.Rows)
                        {
                            dr["SIDBOXNO"] = lblBox.Text;
                        }
                        Count();
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

        private void BtnLoadDataFPackingSlip_Click(object sender, EventArgs e) { }

        private void FrmPackingSlipWholeSale_Load(object sender, EventArgs e)
        {
            try
            {
                ProjectFunctions.GirdViewVisualize(BarCodeGridView);
                ProjectFunctions.GirdViewVisualize(BarCodeGridView);
                ProjectFunctions.GirdViewVisualize(HelpGridView);
                ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
                ProjectFunctions.TextBoxVisualize(Panel1);
                ProjectFunctions.TextBoxVisualize(Panel2);
                ProjectFunctions.TextBoxVisualize(this);
                if (s1 == "&Add")
                {
                    txtPackingSLipDate.EditValue = DateTime.Now;
                    lblBox.Text = "1";
                    lblTotQty.Text = "0";
                    lblPackingSLipTot.Text = "0";
                    Panel1.Focus();
                    txtAccCode.Select();
                }
                if (s1 == "Edit")
                {
                    DataSet ds = ProjectFunctions.GetDataSet("sp_LoadPackingSLipMstFEDit '" +
                        PSWSNO +
                        "','" +
                        PSWSTOTBOXES +
                        "','" +
                        GlobalVariables.FinancialYear +
                        "','" +
                        GlobalVariables.CUnitID +
                        "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtPackingSLipDate.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["PSWSDATE"]);
                        txtPackingSlipNO.EditValue = PSWSNO;
                        txtAccCode.Text = ds.Tables[0].Rows[0]["PSWSPID"].ToString();
                        txtAccName.Text = ds.Tables[0].Rows[0]["AccName"].ToString();
                        txtGSTNo.Text = ds.Tables[0].Rows[0]["AccGSTNo"].ToString();
                        txtAddress.Text = ds.Tables[0].Rows[0]["AccAddress1"].ToString();
                        txtAddress2.Text = ds.Tables[0].Rows[0]["AccAddress2"].ToString();
                        txtAddress3.Text = ds.Tables[0].Rows[0]["AccAddress3"].ToString();
                        txtCity.Text = ds.Tables[0].Rows[0]["CTNAME"].ToString();
                        txtState.Text = ds.Tables[0].Rows[0]["STNAME"].ToString();
                        txtPONo.Text = ds.Tables[0].Rows[0]["PSWSPONO"].ToString();
                        txtDANo.Text = ds.Tables[0].Rows[0]["PSWSDANO"].ToString();
                        lblBox.Text = ds.Tables[0].Rows[0]["PSWSTOTBOXES"].ToString();

                        FixBarPartyTag = ds.Tables[0].Rows[0]["AccFixBarCodeTag"].ToString();
                        StkTransfer = ds.Tables[0].Rows[0]["AccStkTrf"].ToString();
                        dt = ds.Tables[1];
                        BarCodeGrid.DataSource = dt;
                        BarCodeGridView.BestFitColumns();

                        Count();


                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            lblPackingSLipTot.Text = (Convert.ToDecimal(ds.Tables[2].Rows[0][0]) +
                                Convert.ToDecimal(lblTotQty.Text)).ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }


        private void TxtAccCode_KeyDown_1(object sender, KeyEventArgs e)
        {
            try

            {
                if (e.KeyCode == Keys.Enter)
                {
                    HelpGridView.OptionsBehavior.Editable = false;
                    HelpGrid.Text = "txtAccCode";
                    HelpGridView.Columns.Clear();
                    if (txtAccCode.Text.Trim().Length == 0)
                    {
                        DataSet ds = ProjectFunctions.GetDataSet("sp_LoadActMstHelp");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            HelpGrid.DataSource = ds.Tables[0];
                            HelpGrid.Show();
                            HelpGrid.Focus();
                            HelpGridView.BestFitColumns();
                        }
                    }
                    else

                    {
                        DataSet ds1 = ProjectFunctions.GetDataSet("sp_LoadActMstHelpActWise '" +
                            txtAccCode.Text.Trim() +
                            "'");
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            txtAccCode.Text = ds1.Tables[0].Rows[0]["AccCode"].ToString();
                            txtAccName.Text = ds1.Tables[0].Rows[0]["AccName"].ToString();
                            txtGSTNo.Text = ds1.Tables[0].Rows[0]["AccGSTNo"].ToString();
                            txtAddress.Text = ds1.Tables[0].Rows[0]["AccAddress1"].ToString();
                            txtAddress2.Text = ds1.Tables[0].Rows[0]["AccAddress2"].ToString();
                            txtAddress3.Text = ds1.Tables[0].Rows[0]["AccAddress3"].ToString();
                            StkTransfer = ds1.Tables[0].Rows[0]["AccStkTrf"].ToString();
                            txtCity.Text = ds1.Tables[0].Rows[0]["CTNAME"].ToString();
                            txtState.Text = ds1.Tables[0].Rows[0]["STNAME"].ToString();

                            FixBarPartyTag = ds1.Tables[0].Rows[0]["AccFixBarCodeTag"].ToString();
                            txtDANo.Focus();
                        }
                        else
                        {
                            DataSet ds = ProjectFunctions.GetDataSet("sp_LoadActMstHelp");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                HelpGrid.DataSource = ds.Tables[0];
                                HelpGrid.Show();
                                HelpGrid.Focus();
                                HelpGridView.BestFitColumns();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
            e.Handled = true;
        }

        private bool ValidateDataForSaving()
        {
            try

            {
                if (txtAccCode.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid PartyName");
                    txtAccCode.Focus();
                    return false;
                }
                if (txtAccName.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid PartyName");
                    txtAccCode.Focus();
                    return false;
                }

                if (BarCodeGrid.DataSource == null)
                {
                    ProjectFunctions.SpeakError("No Data To Save");
                }
                //SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                //int i = 0;
                //foreach (DataRow dr in dt.Rows)
                //{
                //    i++;
                //    SplashScreenManager.Default.SetWaitFormDescription("Validating Item " + i.ToString() + " / " + dt.Rows.Count.ToString());
                //    if (ProjectFunctions.CheckAllPossible(dr["SIDARTID"].ToString(), Convert.ToDecimal(dr["SIDARTMRP"]), dr["SIDCOLID"].ToString(), dr["SIDSIZID"].ToString()))
                //    {

                //    }
                //    else
                //    {
                //        return false;
                //    }
                //}
                //SplashScreenManager.CloseForm(false);
                return true;
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
                return false;
            }
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
                        String PSWSID = String.Empty;
                        sqlcon.Open();
                        var sqlcom = sqlcon.CreateCommand();
                        sqlcom.Connection = sqlcon;
                        sqlcom.CommandType = CommandType.StoredProcedure;
                        sqlcom.CommandType = CommandType.Text;
                        if (s1 == "&Add")
                        {
                            if (txtPackingSlipNO.Text.Trim().Length == 0)
                            {
                                if (StkTransfer.ToUpper() == "Y")
                                {
                                    PSWSID = ProjectFunctions.GetDataSet("select isnull(max(cast( REPLACE(PSWSNO,'DCO-','') as int)),0)+1 from PSWSLMAIN where left( PSWSNO,3)='DCO' And PSWSFNYR='" +
                                        GlobalVariables.FinancialYear +
                                        "' And UnitCode='" +
                                        GlobalVariables.CUnitID +
                                        "'")
                                        .Tables[0].Rows[0][0].ToString();
                                    txtPackingSlipNO.Text = "DCO-" + PSWSID;
                                }
                                else
                                {
                                    PSWSID = ProjectFunctions.GetDataSet("select isnull(max(cast( REPLACE(PSWSNO,'P-','') as int)),0)+1 from PSWSLMAIN where left( PSWSNO,1)='P' And PSWSFNYR='" +
                                        GlobalVariables.FinancialYear +
                                        "' And UnitCode='" +
                                        GlobalVariables.CUnitID +
                                        "'")
                                        .Tables[0].Rows[0][0].ToString();
                                    txtPackingSlipNO.Text = "P-" + PSWSID;
                                }
                            }
                            else
                            {
                                PSWSID = ProjectFunctions.GetDataSet("select isnull(max(PSWSID),0) from PSWSLMAIN ")
                                    .Tables[0].Rows[0][0].ToString();
                            }
                            sqlcom.CommandText = " Insert into PSWSLMAIN " +
                                " (PSWSSYSDATE,PSWSFNYR,PSWSID,PSWSNO,PSWSDATE,PSWSPID,PSWSPONO," +
                                " PSWSTOTBOXES,PSWSTOTPCS,PSWSMRPVAL,PSWSWSPVAL,PSWSREMARKS,PSWSDANO,UnitCode)" +
                                " values(@PSWSSYSDATE,@PSWSFNYR,@PSWSID,@PSWSNO,@PSWSDATE,@PSWSPID,@PSWSPONO," +
                                " @PSWSTOTBOXES,@PSWSTOTPCS,@PSWSMRPVAL,@PSWSWSPVAL,@PSWSREMARKS,@PSWSDANO,@UnitCode)";
                            sqlcom.Parameters.Add("@PSWSSYSDATE", SqlDbType.NVarChar).Value = DateTime.Now
                                .ToString("yyyy-MM-dd HH:mm:ss");
                            sqlcom.Parameters.Add("@PSWSFNYR", SqlDbType.NVarChar).Value = GlobalVariables.FinancialYear;
                            sqlcom.Parameters.Add("@PSWSID", SqlDbType.NVarChar).Value = PSWSID;
                            sqlcom.Parameters.Add("@PSWSNO", SqlDbType.NVarChar).Value = txtPackingSlipNO.Text;
                            sqlcom.Parameters.Add("@PSWSDATE", SqlDbType.NVarChar).Value = Convert.ToDateTime(txtPackingSLipDate.Text)
                                .ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@PSWSPID", SqlDbType.NVarChar).Value = txtAccCode.Text;
                            sqlcom.Parameters.Add("@PSWSPONO", SqlDbType.NVarChar).Value = txtPONo.Text;
                            sqlcom.Parameters.Add("@PSWSTOTBOXES", SqlDbType.NVarChar).Value = Convert.ToDecimal(lblBox.Text);
                            sqlcom.Parameters.Add("@PSWSTOTPCS", SqlDbType.NVarChar).Value = Convert.ToDecimal(lblTotQty.Text);
                            sqlcom.Parameters.Add("@PSWSMRPVAL", SqlDbType.NVarChar).Value = Convert.ToDecimal("0");
                            sqlcom.Parameters.Add("@PSWSWSPVAL", SqlDbType.NVarChar).Value = Convert.ToDecimal("0");
                            sqlcom.Parameters.Add("@PSWSREMARKS", SqlDbType.NVarChar).Value = txtRemarks.Text.Trim();
                            sqlcom.Parameters.Add("@PSWSDANO", SqlDbType.NVarChar).Value = txtDANo.Text.Trim();
                            sqlcom.Parameters.Add("@UnitCode", SqlDbType.NVarChar).Value = GlobalVariables.CUnitID;
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();
                        }


                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " update PSWSLMAIN Set  " +
                                " PSWSPID=@PSWSPID,PSWSPONO=@PSWSPONO," +
                                " PSWSTOTBOXES=@PSWSTOTBOXES,PSWSTOTPCS=@PSWSTOTPCS,PSWSMRPVAL=@PSWSMRPVAL,PSWSWSPVAL=@PSWSWSPVAL,PSWSREMARKS=@PSWSREMARKS,PSWSDANO=@PSWSDANO where PSWSNO='" +
                                txtPackingSlipNO.Text +
                                "' And PSWSTOTBOXES='" +
                                lblBox.Text +
                                "' And UnitCode='" +
                                GlobalVariables.CUnitID +
                                "' And PSWSFNYR='" +
                                GlobalVariables.FinancialYear +
                                "'";
                            sqlcom.Parameters.Add("@PSWSPID", SqlDbType.NVarChar).Value = txtAccCode.Text;
                            sqlcom.Parameters.Add("@PSWSPONO", SqlDbType.NVarChar).Value = txtPONo.Text;
                            sqlcom.Parameters.Add("@PSWSTOTBOXES", SqlDbType.NVarChar).Value = Convert.ToDecimal(lblBox.Text);
                            sqlcom.Parameters.Add("@PSWSTOTPCS", SqlDbType.NVarChar).Value = Convert.ToDecimal(lblTotQty.Text);
                            sqlcom.Parameters.Add("@PSWSMRPVAL", SqlDbType.NVarChar).Value = Convert.ToDecimal("0");
                            sqlcom.Parameters.Add("@PSWSWSPVAL", SqlDbType.NVarChar).Value = Convert.ToDecimal("0");
                            sqlcom.Parameters.Add("@PSWSREMARKS", SqlDbType.NVarChar).Value = txtRemarks.Text.Trim();
                            sqlcom.Parameters.Add("@PSWSDANO", SqlDbType.NVarChar).Value = txtDANo.Text.Trim();
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();


                            if (FixBarPartyTag == "Y")
                            {
                                ProjectFunctions.GetDataSet("Delete from PSWSLDET Where SIDPSNO='" +
                                    txtPackingSlipNO.Text +
                                    "' And SIDBOXNO='" +
                                    lblBox.Text +
                                    "' And UnitCode='" +
                                    GlobalVariables.CUnitID +
                                    "' And SIDFNYR='" +
                                    GlobalVariables.FinancialYear +
                                    "'");
                            }
                            else
                            {
                                ProjectFunctions.GetDataSet("update SFDET set Used='N' where SFDBARCODE in (Select SIDBARCODE from PSWSLDET Where SIDPSNO='" +
                                    txtPackingSlipNO.Text +
                                    "' And SIDBOXNO='" +
                                    lblBox.Text +
                                    "' And UnitCode='" +
                                    GlobalVariables.CUnitID +
                                    "', And SIDFNYR='" +
                                    GlobalVariables.FinancialYear +
                                    "') And  UnitCode='" +
                                    GlobalVariables.CUnitID +
                                    "',SFDFNYR='" +
                                    GlobalVariables.FinancialYear +
                                    "'");
                                ProjectFunctions.GetDataSet("Delete from PSWSLDET Where SIDPSNO='" +
                                    txtPackingSlipNO.Text +
                                    "' And SIDBOXNO='" +
                                    lblBox.Text +
                                    "' And UnitCode='" +
                                    GlobalVariables.CUnitID +
                                    "' And SIDFNYR='" +
                                    GlobalVariables.FinancialYear +
                                    "'");
                            }
                        }



                        SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                        int i = 0;
                        foreach (DataRow dr in (BarCodeGrid.DataSource as DataTable).Rows)
                        {
                            i++;

                            SplashScreenManager.Default.SetWaitFormDescription("Saving Item " + i.ToString() + " / " + (BarCodeGrid.DataSource as DataTable).Rows.Count);

                            sqlcom.CommandText = " Insert into PSWSLDET " +
                                " (SIDSYSDATE,SIDPSDATE,SIDPSFNYR,SIDPSNO,SIDBOXNO,SIDBARCODE," +
                                " SIDARTNO,SIDARTID,SIDARTDESC,SIDCOLN,SIDCOLID,SIDSIZN,SIDSIZID,SIDSCANQTY," +
                                " SIDARTMRP,SIDARTWSP,SIDBOXQTY,SIDBOXMRPVAL,SIDBOXWSPVAL,SIDPONO,UnitCode,SIDFNYR,SIDPartyC)" +
                                " values(@SIDSYSDATE,@SIDPSDATE,@SIDPSFNYR,@SIDPSNO,@SIDBOXNO,@SIDBARCODE," +
                                " @SIDARTNO,@SIDARTID,@SIDARTDESC,@SIDCOLN,@SIDCOLID,@SIDSIZN,@SIDSIZID,@SIDSCANQTY," +
                                " @SIDARTMRP,@SIDARTWSP,@SIDBOXQTY,@SIDBOXMRPVAL,@SIDBOXWSPVAL,@SIDPONO,@UnitCode,@SIDFNYR,@SIDPartyC)";
                            sqlcom.Parameters.Add("@SIDSYSDATE", SqlDbType.NVarChar).Value = DateTime.Now
                                .ToString("yyyy-MM-dd HH:mm:ss");
                            sqlcom.Parameters.Add("@SIDPSDATE", SqlDbType.NVarChar).Value = Convert.ToDateTime(txtPackingSLipDate.Text)
                                .ToString("yyyy-MM-dd");

                            sqlcom.Parameters.Add("@SIDFNYR", SqlDbType.NVarChar).Value = GlobalVariables.FinancialYear;
                            sqlcom.Parameters.Add("@SIDPSFNYR", SqlDbType.NVarChar).Value = GlobalVariables.FinancialYear;
                            sqlcom.Parameters.Add("@SIDPSNO", SqlDbType.NVarChar).Value = txtPackingSlipNO.Text;
                            sqlcom.Parameters.Add("@SIDBOXNO", SqlDbType.NVarChar).Value = dr["SIDBOXNO"].ToString();
                            sqlcom.Parameters.Add("@SIDBARCODE", SqlDbType.NVarChar).Value = dr["SIDBARCODE"].ToString();
                            sqlcom.Parameters.Add("@SIDARTNO", SqlDbType.NVarChar).Value = dr["SIDARTNO"].ToString();
                            sqlcom.Parameters.Add("@SIDARTID", SqlDbType.NVarChar).Value = dr["SIDARTID"].ToString();
                            sqlcom.Parameters.Add("@SIDARTDESC", SqlDbType.NVarChar).Value = dr["SIDARTDESC"].ToString();
                            sqlcom.Parameters.Add("@SIDCOLN", SqlDbType.NVarChar).Value = dr["SIDCOLN"].ToString();
                            sqlcom.Parameters.Add("@SIDCOLID", SqlDbType.NVarChar).Value = dr["SIDCOLID"].ToString();
                            sqlcom.Parameters.Add("@SIDSIZN", SqlDbType.NVarChar).Value = dr["SIDSIZN"].ToString();
                            sqlcom.Parameters.Add("@SIDSIZID", SqlDbType.NVarChar).Value = dr["SIDSIZID"].ToString();
                            sqlcom.Parameters.Add("@SIDSCANQTY", SqlDbType.NVarChar).Value = dr["SIDSCANQTY"].ToString();
                            sqlcom.Parameters.Add("@SIDARTMRP", SqlDbType.NVarChar).Value = dr["SIDARTMRP"].ToString();
                            sqlcom.Parameters.Add("@SIDARTWSP", SqlDbType.NVarChar).Value = dr["SIDARTWSP"].ToString();
                            sqlcom.Parameters.Add("@SIDBOXQTY", SqlDbType.NVarChar).Value = dr["SIDSCANQTY"].ToString();
                            sqlcom.Parameters.Add("@SIDBOXMRPVAL", SqlDbType.NVarChar).Value = dr["SIDARTMRP"].ToString();
                            sqlcom.Parameters.Add("@SIDBOXWSPVAL", SqlDbType.NVarChar).Value = dr["SIDARTWSP"].ToString();
                            sqlcom.Parameters.Add("@SIDPONO", SqlDbType.NVarChar).Value = txtPONo.Text;
                            sqlcom.Parameters.Add("@UnitCode", SqlDbType.NVarChar).Value = GlobalVariables.CUnitID;
                            sqlcom.Parameters.Add("@SIDPartyC", SqlDbType.NVarChar).Value = txtAccCode.Text.Trim();
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();

                            if (FixBarPartyTag == "Y")
                            {
                            }
                            else
                            {
                                ProjectFunctions.GetDataSet("update SFDet set Used='Y' where SFDBARCODE='" +
                                    dr["SIDBARCODE"].ToString() +
                                    "' And SFDFNYR='" +
                                    GlobalVariables.FinancialYear +
                                    "' And UnitCode='" +
                                    GlobalVariables.CUnitID +
                                    "'");
                            }
                        }
                        SplashScreenManager.CloseForm(false);


                        //BarCodeGridView.ExportToCsv(AppDomain.CurrentDomain.BaseDirectory + @"\tempbarcode.txt");
                        ProjectFunctions.SpeakError(" Data Saved Successfully");
                        sqlcon.Close();
                        if (s1 == "&Add")
                        {
                            lblBox.Text = (Convert.ToInt32(lblBox.Text) + 1).ToString();
                            BarCodeGrid.DataSource = null;
                            dt.Clear();
                            lblTotQty.Text = "0";

                            DataSet ds = ProjectFunctions.GetDataSet("[sp_LoadPackingSLipMstCount] '" +
                                PSWSNO +
                                "','" +
                                PSWSTOTBOXES +
                                "','" +
                                GlobalVariables.FinancialYear +
                                "','" +
                                GlobalVariables.CUnitID +
                                "'");

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                lblPackingSLipTot.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0][0]) +
                                    Convert.ToDecimal(lblTotQty.Text)).ToString();
                            }
                        }
                        else
                        {
                            lblBox.Text = ProjectFunctions.GetDataSet("select isnull( max(PSWSTOTBOXES),0)+1 from PSWSLMAIN where PSWSNO='" +
                                txtPackingSlipNO.Text +
                                "' And PSWSFNYR='" +
                                GlobalVariables.FinancialYear +
                                "' And UnitCode='" +
                                GlobalVariables.CUnitID +
                                "'")
                                .Tables[0].Rows[0][0].ToString();
                            BarCodeGrid.DataSource = null;
                            dt.Clear();
                            lblTotQty.Text = "0";
                            s1 = "&Add";


                            DataSet ds = ProjectFunctions.GetDataSet("[sp_LoadPackingSLipMstCount] '" +
                                PSWSNO +
                                "','" +
                                PSWSTOTBOXES +
                                "','" +
                                GlobalVariables.FinancialYear +
                                "','" +
                                GlobalVariables.CUnitID +
                                "'");

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                lblPackingSLipTot.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0][0]) +
                                    Convert.ToDecimal(lblTotQty.Text)).ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void TxtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtAccCode.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid PartyName");
                    txtAccCode.Focus();
                    return;
                }
                if (txtAccName.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid PartyName");
                    txtAccCode.Focus();
                    return;
                }

                if (e.KeyCode == Keys.F3)
                {
                    HelpGrid.Text = "Load";
                    HelpGridView.Columns.Clear();
                    DataSet ds = ProjectFunctions.GetDataSet("sp_LoadDataFromSFDetFOrPackingSlip '" +
                        GlobalVariables.CUnitID +
                        "'");
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
                                col.VisibleIndex = 0;
                                col.OptionsColumn.AllowEdit = true;
                            }
                            else
                            {
                                col.OptionsColumn.AllowEdit = false;
                            }
                        }
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    DataSet ds = new DataSet();
                    if (FixBarPartyTag != "Y")
                    {
                        ds = ProjectFunctions.GetDataSet("sp_LoadDataFromSKUdetUsingBarCode '" +
                            txtBarCode.Text +
                            "','" +
                            GlobalVariables.CUnitID +
                            "'");
                    }
                    else
                    {
                        ds = ProjectFunctions.GetDataSet("[sp_LoadDataFromSKUFixBarCode] '" +
                            txtBarCode.Text +
                            "','" +
                            GlobalVariables.CUnitID +
                            "'");
                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (FixBarPartyTag != "Y")
                        {
                            if (ds.Tables[0].Rows[0]["Used"].ToString().ToUpper() == "Y")
                            {
                                ProjectFunctions.SpeakError("BarCode Already Used In Some Other PS");
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
                        }
                        if (Convert.ToDecimal(ds.Tables[0].Rows[0]["SIDARTMRP"]) !=
                            Convert.ToDecimal(ds.Tables[0].Rows[0]["ARTMRP"]))
                        {
                            ProjectFunctions.SpeakError("Difference In MRP( MRP In Article is - " +
                                ds.Tables[0].Rows[0]["ARTMRP"].ToString() +
                                ")");
                            txtBarCode.Focus();
                            txtBarCode.SelectAll();
                            e.Handled = true;
                            return;
                        }


                        if (dt.Rows.Count == 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            if (FixBarPartyTag == "Y")
                            {
                                int i = 0;
                                foreach (DataRow dr in (BarCodeGrid.DataSource as DataTable).Rows)
                                {
                                    if (dr["SIDBARCODE"].ToString() == txtBarCode.Text.Trim())
                                    {
                                        dr["SIDSCANQTY"] = Convert.ToDecimal(dr["SIDSCANQTY"]) +
                                            Convert.ToDecimal(ds.Tables[0].Rows[0]["SIDSCANQTY"]);
                                        i++;
                                        break;
                                    }
                                }
                                if (i == 0)
                                {
                                    DataRow row = dt.NewRow();
                                    row["SIDBOXNO"] = Convert.ToDecimal(lblBox.Text);
                                    row["SIDBARCODE"] = ds.Tables[0].Rows[0]["SIDBARCODE"].ToString();
                                    row["SIDARTNO"] = ds.Tables[0].Rows[0]["SIDARTNO"].ToString();
                                    row["SIDARTDESC"] = ds.Tables[0].Rows[0]["SIDARTDESC"].ToString();
                                    row["SIDCOLN"] = ds.Tables[0].Rows[0]["SIDCOLN"].ToString();
                                    row["SIDSIZN"] = ds.Tables[0].Rows[0]["SIDSIZN"].ToString();
                                    row["SIDSCANQTY"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["SIDSCANQTY"]);
                                    row["SIDARTMRP"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["SIDARTMRP"]);
                                    row["SIDARTWSP"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["SIDARTWSP"]);
                                    row["SIDARTID"] = ds.Tables[0].Rows[0]["SIDARTID"].ToString();
                                    row["SIDCOLID"] = ds.Tables[0].Rows[0]["SIDCOLID"].ToString();
                                    row["SIDSIZID"] = ds.Tables[0].Rows[0]["SIDSIZID"].ToString();
                                    dt.Rows.Add(row);
                                }
                            }
                            else
                            {
                                dt.Merge(ds.Tables[0]);
                            }
                        }

                        //ShowImage(Convert.ToDecimal(ds.Tables[0].Rows[0]["SIDARTID"]).ToString());
                    }
                    else
                    {
                        ProjectFunctions.SpeakError("No BarCode Found");
                        txtBarCode.Focus();
                        txtBarCode.SelectAll();
                        e.Handled = true;
                        return;
                    }
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            dr["SIDBOXNO"] = lblBox.Text;
                        }
                        Count();
                        BarCodeGrid.DataSource = dt;
                        BarCodeGridView.BestFitColumns();
                    }
                    else
                    {
                        BarCodeGrid.DataSource = null;
                    }
                    txtBarCode.Text = String.Empty;
                    txtBarCode.Focus();
                    lblTotQty.Text = Convert.ToDecimal(gridColumn7.SummaryItem.SummaryValue).ToString("0");
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
            e.Handled = true;
        }

        private void BarCodeGrid_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ProjectFunctions.DeleteCurrentRowOnKeyDown(BarCodeGrid, BarCodeGridView, e);
                dt.AcceptChanges();
                Decimal QtySum = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    QtySum = QtySum + Convert.ToDecimal(dr["SIDSCANQTY"]);
                }
                lblTotQty.Text = QtySum.ToString("0");

                DataSet ds = ProjectFunctions.GetDataSet("[sp_LoadPackingSLipMstCount] '" +
                    PSWSNO +
                    "','" +
                    PSWSTOTBOXES +
                    "','" +
                    GlobalVariables.FinancialYear +
                    "','" +
                    GlobalVariables.CUnitID +
                    "'");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblPackingSLipTot.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0][0]) +
                        Convert.ToDecimal(lblTotQty.Text)).ToString();
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void BarCodeGridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            try
            {
                BarCodeGridView.CloseEditor();
                BarCodeGridView.UpdateCurrentRow();
                e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Update Quantity", (o1, e1) =>
                {

                    DataRow currentrow = BarCodeGridView.GetDataRow(BarCodeGridView.FocusedRowHandle);
                    DataSet ds = ProjectFunctions.GetDataSet("select top 1 * from sku_fix where SKUPRODUCTCODE='" + currentrow["SIDBARCODE"].ToString() + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gridColumn7.OptionsColumn.AllowEdit = true;
                    }
                    else
                    {
                        gridColumn7.OptionsColumn.AllowEdit = false;
                    }
                }));

                e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Delete Current Row",
                                                              (o1, e1) =>
                {
                    BarCodeGridView.DeleteRow(BarCodeGridView.FocusedRowHandle);
                    dt.AcceptChanges();
                    Decimal QtySum = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        QtySum = QtySum + Convert.ToDecimal(dr["SIDSCANQTY"]);
                    }
                    lblTotQty.Text = QtySum.ToString("0");


                    DataSet ds = ProjectFunctions.GetDataSet("[sp_LoadPackingSLipMstCount] '" +
                        PSWSNO +
                        "','" +
                        PSWSTOTBOXES +
                        "','" +
                        GlobalVariables.FinancialYear +
                        "','" +
                        GlobalVariables.CUnitID +
                        "'");

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblPackingSLipTot.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0][0]) +
                            Convert.ToDecimal(lblTotQty.Text)).ToString();
                    }
                }));


                e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Paste",
                (o1, e1) =>
                {
                    dt.Clear();
                    String Text = Clipboard.GetText().Replace("\r", string.Empty);
                    String[] strlist = Text.Split('\n');

                    foreach (String str in strlist)
                    {
                        DataSet ds = ProjectFunctions.GetDataSet("sp_LoadDataFromSKUdetUsingBarCode '" +
                             str +
                             "','" +
                             GlobalVariables.CUnitID +
                             "'");
                        if (dt.Rows.Count == 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                dr["SIDBOXNO"] = lblBox.Text;
                            }
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt.Merge(ds.Tables[0]);
                        }
                    }
                    if (dt.Rows.Count > 0)
                    {
                        Count();
                        BarCodeGrid.DataSource = dt;
                        BarCodeGridView.BestFitColumns();

                    }
                    else
                    {
                        BarCodeGrid.DataSource = null;
                    }
                }));

            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void BarCodeGrid_Click(object sender, EventArgs e)
        {
            try
            {
                //DataRow currentrow = BarCodeGridView.GetDataRow(BarCodeGridView.FocusedRowHandle);
                //ShowImage(currentrow["SIDARTID"].ToString());
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                //ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void txtAccCode_EditValueChanged(object sender, EventArgs e)
        {
            txtAccName.Text = String.Empty;
            txtGSTNo.Text = String.Empty;
            txtAddress.Text = String.Empty;
            txtAddress2.Text = String.Empty;
            txtAddress3.Text = String.Empty;
            StkTransfer = String.Empty;
            txtCity.Text = String.Empty;
            txtState.Text = String.Empty;
        }

        private void HelpGridView_PopupMenuShowing(object sender,
                                                   DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {


            e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Select All Records", (o1, e1) =>
             {
                 var MaxRow = ((HelpGrid.KeyboardFocusView as GridView).RowCount);
                 for (var i = 0; i < MaxRow; i++)
                 {
                     HelpGridView.SetRowCellValue(i, HelpGridView.Columns["Select"], true);
                 }
             }));
        }

        private void FrmPackingSlipWholeSale_KeyDown(object sender, KeyEventArgs e)
        { ProjectFunctions.SalePopUPForAllWindows(this, e); }

        private void label5_Click(object sender, EventArgs e) { }

        private void labelControl4_Click(object sender, EventArgs e) { }

        private void BarCodeGrid_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}