using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Transaction.challans
{
    public partial class frm_ChallanOutward : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String ImNo { get; set; }
        public DateTime ImDate { get; set; }
        DataTable dt = new DataTable();
        DataSet dsPopUps = new DataSet();
        int RowIndex = 0;
        String UpdateTag = "N";

        public frm_ChallanOutward()
        {
            InitializeComponent();
            dt.Columns.Add("CHOPrdCode", typeof(String));
            dt.Columns.Add("CHOPrdName", typeof(String));
            dt.Columns.Add("CHOManualDesc", typeof(String));
            dt.Columns.Add("CHOArtNo", typeof(String));
            dt.Columns.Add("CHOArtDesc", typeof(String));
            dt.Columns.Add("CHOArtID", typeof(String));
            dt.Columns.Add("CHOColID", typeof(String));
            dt.Columns.Add("CHOColName", typeof(String));
            dt.Columns.Add("CHOSizeID", typeof(String));
            dt.Columns.Add("CHOSizeName", typeof(String));
            dt.Columns.Add("CHOLotNo", typeof(String));
            dt.Columns.Add("CHOTotQtyKgs", typeof(String));
            dt.Columns.Add("CHOUom", typeof(String));
            dt.Columns.Add("CHORemarks", typeof(String));
            dt.Columns.Add("CHOKgsType", typeof(String));
            dt.Columns.Add("CHOTotQty", typeof(String));




            dsPopUps = ProjectFunctions.GetDataSet("sp_LoadBarPrintPopUps");
        }

        private void TxtDebitPartyCode_EditValueChanged(object sender, EventArgs e)
        {
            txtDebitPartyName.Text = String.Empty;
            txtBillingAddress1.Text = String.Empty;
            txtBillingAddress2.Text = String.Empty;
            txtBillingAddress3.Text = String.Empty;
            txtBillingCity.Text = String.Empty;
            txtBillingAddress1.Text = String.Empty;

        }

        private void TxtDebitPartyCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                PrepareActMstHelpGrid();
                HelpGrid.Text = "txtDebitPartyCode";
                if (txtDebitPartyCode.Text.Trim().Length == 0)
                {
                    DataSet ds = ProjectFunctions.GetDataSet("sp_LoadActMstHelp");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        HelpGrid.DataSource = ds.Tables[0];
                        HelpGrid.Show();
                        panelControl1.Visible = true;
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
                    DataSet ds = ProjectFunctions.GetDataSet(" sp_LoadActMstHelpWithCode '" + txtDebitPartyCode.Text.Trim() + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtDebitPartyCode.Text = ds.Tables[0].Rows[0]["AccCode"].ToString();
                        txtDebitPartyName.Text = ds.Tables[0].Rows[0]["AccName"].ToString();
                        txtBillingAddress1.Text = ds.Tables[0].Rows[0]["AccAddress1"].ToString();
                        txtBillingAddress2.Text = ds.Tables[0].Rows[0]["AccAddress2"].ToString();
                        txtBillingAddress3.Text = ds.Tables[0].Rows[0]["AccAddress3"].ToString();

                        txtBillingCity.Text = ds.Tables[0].Rows[0]["CTNAME"].ToString();
                        txtContactDetails.Focus();
                        panelControl1.Visible = false;
                    }

                    else
                    {
                        DataSet ds1 = ProjectFunctions.GetDataSet("sp_LoadActMstHelp");
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            HelpGrid.DataSource = ds.Tables[0];
                            HelpGrid.Show();
                            panelControl1.Visible = true;
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


        private void PrepareActMstHelpGrid()
        {
            HelpGridView.Columns.Clear();
            DevExpress.XtraGrid.Columns.GridColumn col1 = new DevExpress.XtraGrid.Columns.GridColumn();
            col1.FieldName = "AccName";
            col1.Visible = true;
            col1.VisibleIndex = 0;
            HelpGridView.Columns.Add(col1);

            DevExpress.XtraGrid.Columns.GridColumn col2 = new DevExpress.XtraGrid.Columns.GridColumn();
            col2.FieldName = "AccCode";
            col2.Visible = true;
            col2.VisibleIndex = 1;
            HelpGridView.Columns.Add(col2);

            DevExpress.XtraGrid.Columns.GridColumn col3 = new DevExpress.XtraGrid.Columns.GridColumn();
            col3.FieldName = "AccAddress1";
            col3.Visible = false;
            //col3.VisibleIndex = 2;
            HelpGridView.Columns.Add(col3);

            DevExpress.XtraGrid.Columns.GridColumn col4 = new DevExpress.XtraGrid.Columns.GridColumn();
            col4.FieldName = "AccAddress2";
            col4.Visible = false;
            //col4.VisibleIndex = 3;
            HelpGridView.Columns.Add(col4);

            DevExpress.XtraGrid.Columns.GridColumn col5 = new DevExpress.XtraGrid.Columns.GridColumn();
            col5.FieldName = "AccAddress3";
            col5.Visible = false;
            //col5.VisibleIndex = 4;
            HelpGridView.Columns.Add(col5);


            DevExpress.XtraGrid.Columns.GridColumn col6 = new DevExpress.XtraGrid.Columns.GridColumn();
            col6.FieldName = "CTNAME";
            col6.Visible = false;
            //col6.VisibleIndex = 5;
            HelpGridView.Columns.Add(col6);

        }

        private void HelpGrid_DoubleClick(object sender, EventArgs e)
        {
            HelpGridView.CloseEditor();
            HelpGridView.UpdateCurrentRow();
            DataRow row = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);

            if (HelpGrid.Text == "txtTransporterCode")
            {
                txtTransporterCode.Text = row["TRPRSYSID"].ToString();
                txtTransporterName.Text = row["TRPRNAME"].ToString();
                HelpGrid.Visible = false;
                panelControl1.Visible = false;
                txtTransporterCode.Focus();
            }

            if (HelpGrid.Text == "txtDebitPartyCode")
            {
                txtDebitPartyCode.Text = row["AccCode"].ToString();
                txtDebitPartyName.Text = row["AccName"].ToString();
                txtBillingAddress1.Text = row["AccAddress1"].ToString();
                txtBillingAddress2.Text = row["AccAddress2"].ToString();
                txtBillingAddress3.Text = row["AccAddress3"].ToString();

                txtBillingCity.Text = row["CTNAME"].ToString();

                HelpGrid.Visible = false;
                panelControl1.Visible = false;
                txtContactDetails.Focus();
            }
            if (HelpGridView.RowCount > 0)
            {

                if (HelpGrid.Text == "CHOPrdName")
                {
                    DataRow dtNewRow = dt.NewRow();
                    dtNewRow["CHOPrdCode"] = row["PrdCode"].ToString();
                    dtNewRow["CHOPrdName"] = row["PrdName"].ToString();

                    dt.Rows.Add(dtNewRow);
                    if (dt.Rows.Count > 0)
                    {
                        BarCodeGrid.DataSource = dt;
                        BarCodeGridView.BestFitColumns();
                    }
                    panelControl1.Visible = false;
                    BarCodeGridView.Focus();
                    BarCodeGridView.MoveLast();
                    BarCodeGridView.FocusedColumn = BarCodeGridView.Columns["CHOManualDesc"];
                    txtSearchBox.Text = String.Empty;
                }
                if (HelpGrid.Text == "CHOArtNo")
                {
                    BarCodeGridView.UpdateCurrentRow();
                    BarCodeGridView.SetRowCellValue(RowIndex, BarCodeGridView.Columns["CHOArtNo"], row["ARTNO"].ToString());
                    BarCodeGridView.SetRowCellValue(RowIndex, BarCodeGridView.Columns["CHOArtDesc"], row["ARTDESC"].ToString());
                    BarCodeGridView.SetRowCellValue(RowIndex, BarCodeGridView.Columns["CHOArtID"], row["ARTSYSID"].ToString());
                    BarCodeGridView.Focus();
                    panelControl1.Visible = false;
                    BarCodeGridView.FocusedColumn = BarCodeGridView.Columns["CHOColName"];
                    BarCodeGridView.FocusedRowHandle = RowIndex;
                    txtSearchBox.Text = String.Empty;
                    dt.AcceptChanges();
                }


                if (HelpGrid.Text == "CHOColName")
                {

                    BarCodeGridView.UpdateCurrentRow();

                    BarCodeGridView.SetRowCellValue(RowIndex, BarCodeGridView.Columns["CHOColID"], row["COLSYSID"].ToString());
                    BarCodeGridView.SetRowCellValue(RowIndex, BarCodeGridView.Columns["CHOColName"], row["COLNAME"].ToString());
                    BarCodeGridView.Focus();
                    panelControl1.Visible = false;
                    BarCodeGridView.FocusedColumn = BarCodeGridView.Columns["CHOSizeName"];
                    BarCodeGridView.FocusedRowHandle = RowIndex;
                    txtSearchBox.Text = String.Empty;
                    dt.AcceptChanges();
                }
                if (HelpGrid.Text == "CHOSizeName")
                {

                    UpdateTag = "N";
                    BarCodeGridView.SetRowCellValue(RowIndex, BarCodeGridView.Columns["CHOSizeID"], row["SZSYSID"].ToString());
                    BarCodeGridView.SetRowCellValue(RowIndex, BarCodeGridView.Columns["CHOSizeName"], row["SZNAME"].ToString());
                    panelControl1.Visible = false;
                    BarCodeGridView.Focus();
                    BarCodeGridView.FocusedColumn = BarCodeGridView.Columns["CHOLotNo"];
                    BarCodeGridView.FocusedRowHandle = RowIndex;
                    txtSearchBox.Text = String.Empty;
                    dt.AcceptChanges();
                    BarCodeGridView.ShowEditor();
                }
            }
        }

        private void TxtTransporterCode_EditValueChanged(object sender, EventArgs e)
        {
            txtTransporterName.Text = String.Empty;
        }

        private void TxtTransporterCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                HelpGridView.Columns.Clear();
                HelpGrid.Text = "txtTransporterCode";
                if (txtTransporterCode.Text.Trim().Length == 0)
                {
                    DataSet ds = ProjectFunctions.GetDataSet("select TRPRSYSID,TRPRNAME,TRPRADD from TRANSPORTMASTER");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        HelpGrid.DataSource = ds.Tables[0];
                        HelpGrid.Show();
                        panelControl1.Visible = true;
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
                    DataSet ds = ProjectFunctions.GetDataSet(" select TRPRSYSID,TRPRNAME,TRPRADD from TRANSPORTMASTER Where  TRPRSYSID='" + txtTransporterCode.Text.Trim() + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtTransporterCode.Text = ds.Tables[0].Rows[0]["TRPRSYSID"].ToString();
                        txtTransporterName.Text = ds.Tables[0].Rows[0]["TRPRNAME"].ToString();

                        txtTransporterCode.Focus();
                        panelControl1.Visible = false;
                    }

                    else
                    {
                        DataSet ds1 = ProjectFunctions.GetDataSet("select TRPRSYSID,TRPRNAME,TRPRADD from TRANSPORTMASTER");
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            HelpGrid.DataSource = ds.Tables[0];
                            HelpGrid.Show();
                            panelControl1.Visible = true;
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

        private void GroupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
        private bool ValidateDataForSaving()
        {
            try

            {
                if (BarCodeGrid.DataSource == null)
                {
                    ProjectFunctions.SpeakError("No Data To Save");
                }

                return true;
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
                return false;
            }
        }
        private void Frm_ChallanOutward_Load(object sender, EventArgs e)
        {
            try
            {
                panelControl1.Visible = false;
                ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
                ProjectFunctions.TextBoxVisualize(groupControl1);
                ProjectFunctions.GirdViewVisualize(HelpGridView);

                ProjectFunctions.GirdViewVisualize(BarCodeGridView);

                ProjectFunctions.TextBoxVisualize(this);

                PrintLogWin.PrintLog(s1);

                if (s1 == "&Add")
                {
                    groupControl1.Focus();
                    txtChallanType.Select();
                    txtChallanDate.EditValue = DateTime.Now;
                }
                if (s1 == "Edit")
                {
                    string loadChallan_Query = "sp_LoadChallanOutMstFEdit '" + ImNo + "' ,'" + ImDate.ToString("yyyy-MM-dd") + "','" + GlobalVariables.CUnitID + "' ";
                    PrintLogWin.PrintLog("sp_LoadChallanOutMstFEdit => " + loadChallan_Query);

                    DataSet ds = ProjectFunctions.GetDataSet(loadChallan_Query);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtChallanNo.Text = ds.Tables[0].Rows[0]["CHONO"].ToString();
                        txtChallanDate.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["CHODATE"]);
                        txtDebitPartyCode.Text = ds.Tables[0].Rows[0]["CHOPARTYCODE"].ToString();
                        txtDebitPartyName.Text = ds.Tables[0].Rows[0]["AccName"].ToString();
                        txtBillingAddress1.Text = ds.Tables[0].Rows[0]["AccAddress1"].ToString();
                        txtBillingAddress2.Text = ds.Tables[0].Rows[0]["AccAddress2"].ToString();
                        txtBillingAddress3.Text = ds.Tables[0].Rows[0]["AccAddress3"].ToString();
                        txtApprovedBy.Text = ds.Tables[0].Rows[0]["CHOAPPROVEDBY"].ToString();
                        txtIssuedBy.Text = ds.Tables[0].Rows[0]["CHOISSUEDBY"].ToString();
                        txtContactDetails.Text = ds.Tables[0].Rows[0]["CHOCONTDETAILS"].ToString();
                        txtMainRemarks.Text = ds.Tables[0].Rows[0]["CHOREMARKS"].ToString();
                        txtTransporterCode.Text = ds.Tables[0].Rows[0]["CHOTRPID"].ToString();
                        txtTransporterName.Text = ds.Tables[0].Rows[0]["TRPRNAME"].ToString();
                        txtChallanType.Text = ds.Tables[0].Rows[0]["CHOTYPE"].ToString();
                        groupControl1.Focus();
                        txtDebitPartyCode.Focus();
                        dt = ds.Tables[1];
                        BarCodeGrid.DataSource = dt;
                        BarCodeGridView.BestFitColumns();
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
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
                            txtChallanNo.Text = ProjectFunctions.GetDataSet("Select isnull(Max(CHONO),0)+1 from CHOUTMain WHere CHOFYR='" + GlobalVariables.FinancialYear + "' ANd UnitCode='" + GlobalVariables.CUnitID + "' And CHOTYPE='" + txtChallanType.Text + "'").Tables[0].Rows[0][0].ToString();
                            sqlcom.CommandText = " Insert into CHOUTMain "
                                                        + " (CHOFYR,CHONO,CHOTYPE,CHODATE,CHOPARTYCODE,CHOCONTDETAILS,CHOISSUEDBY,CHOAPPROVEDBY,CHOREMARKS,UnitCode,CHOTRPID)values("
                                                        + " @CHOFYR,@CHONO,@CHOTYPE,@CHODATE,@CHOPARTYCODE,@CHOCONTDETAILS,@CHOISSUEDBY,@CHOAPPROVEDBY,@CHOREMARKS,@UnitCode,@CHOTRPID)";
                            sqlcom.Parameters.Add("@CHOFYR", SqlDbType.NVarChar).Value = GlobalVariables.FinancialYear;
                            sqlcom.Parameters.Add("@CHONO", SqlDbType.NVarChar).Value = txtChallanNo.Text;
                            sqlcom.Parameters.Add("@CHOTYPE", SqlDbType.NVarChar).Value = txtChallanType.Text;
                            sqlcom.Parameters.Add("@CHODATE", SqlDbType.NVarChar).Value = Convert.ToDateTime(txtChallanDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@CHOPARTYCODE", SqlDbType.NVarChar).Value = txtDebitPartyCode.Text;
                            sqlcom.Parameters.Add("@CHOCONTDETAILS", SqlDbType.NVarChar).Value = txtContactDetails.Text;
                            sqlcom.Parameters.Add("@CHOISSUEDBY", SqlDbType.NVarChar).Value = txtIssuedBy.Text;
                            sqlcom.Parameters.Add("@CHOAPPROVEDBY", SqlDbType.NVarChar).Value = txtApprovedBy.Text;
                            sqlcom.Parameters.Add("@CHOREMARKS", SqlDbType.NVarChar).Value = txtMainRemarks.Text;
                            sqlcom.Parameters.Add("@UnitCode", SqlDbType.NVarChar).Value = GlobalVariables.CUnitID;
                            sqlcom.Parameters.Add("@CHOTRPID", SqlDbType.NVarChar).Value = txtTransporterCode.Text;
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " update CHOUTMain Set  "
                                                        + "CHOFYR=@CHOFYR,CHONO=@CHONO,CHOTYPE=@CHOTYPE,"
                                                        + " CHODATE=@CHODATE,CHOPARTYCODE=@CHOPARTYCODE,CHOCONTDETAILS=@CHOCONTDETAILS,CHOISSUEDBY=@CHOISSUEDBY,CHOAPPROVEDBY=@CHOAPPROVEDBY,CHOREMARKS=@CHOREMARKS,UnitCode=@UnitCode,CHOTRPID=@CHOTRPID where CHONO='" + txtChallanNo.Text + "' And CHODATE='" + Convert.ToDateTime(txtChallanDate.Text).ToString("yyyy-MM-dd") + "' And UnitCode='" + GlobalVariables.CUnitID + "'";
                            sqlcom.Parameters.Add("@CHOFYR", SqlDbType.NVarChar).Value = GlobalVariables.FinancialYear;
                            sqlcom.Parameters.Add("@CHONO", SqlDbType.NVarChar).Value = txtChallanNo.Text;
                            sqlcom.Parameters.Add("@CHOTYPE", SqlDbType.NVarChar).Value = txtChallanType.Text;
                            sqlcom.Parameters.Add("@CHODATE", SqlDbType.NVarChar).Value = Convert.ToDateTime(txtChallanDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@CHOPARTYCODE", SqlDbType.NVarChar).Value = txtDebitPartyCode.Text;
                            sqlcom.Parameters.Add("@CHOCONTDETAILS", SqlDbType.NVarChar).Value = txtContactDetails.Text;
                            sqlcom.Parameters.Add("@CHOISSUEDBY", SqlDbType.NVarChar).Value = txtIssuedBy.Text;
                            sqlcom.Parameters.Add("@CHOAPPROVEDBY", SqlDbType.NVarChar).Value = txtApprovedBy.Text;
                            sqlcom.Parameters.Add("@CHOREMARKS", SqlDbType.NVarChar).Value = txtMainRemarks.Text;
                            sqlcom.Parameters.Add("@UnitCode", SqlDbType.NVarChar).Value = GlobalVariables.CUnitID;
                            sqlcom.Parameters.Add("@CHOTRPID", SqlDbType.NVarChar).Value = txtTransporterCode.Text;
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();
                            ProjectFunctions.GetDataSet("Delete from CHOUT Where CHONO='" + txtChallanNo.Text + "' And CHODATE='" + Convert.ToDateTime(txtChallanDate.Text).ToString("yyyy-MM-dd") + "' And UnitCode='" + GlobalVariables.CUnitID + "'");
                        }

                        BarCodeGridView.CloseEditor();
                        BarCodeGridView.UpdateCurrentRow();

                        foreach (DataRow dr in dt.Rows)
                        {
                            sqlcom.CommandText = " Insert into CHOUT "
                                                    + " (CHOFYR,CHONO,CHOTYPE,CHODATE,CHOPrdCode,CHOManualDesc,"
                                                    + " CHOArtID,CHOColID,CHOSizeID,CHOLotNo,CHOTotQtyKgs,CHOUom,CHORemarks,CHOKgsType,CHOTotQty,UnitCode)"
                                                    + " values(@CHOFYR,@CHONO,@CHOTYPE,@CHODATE,@CHOPrdCode,@CHOManualDesc,"
                                                    + " @CHOArtID,@CHOColID,@CHOSizeID,@CHOLotNo,@CHOTotQtyKgs,@CHOUom,@CHORemarks,@CHOKgsType,@CHOTotQty,@UnitCode)";
                            sqlcom.Parameters.Add("@CHOFYR", SqlDbType.NVarChar).Value = GlobalVariables.FinancialYear;
                            sqlcom.Parameters.Add("@CHONO", SqlDbType.NVarChar).Value = txtChallanNo.Text;
                            sqlcom.Parameters.Add("@CHOTYPE", SqlDbType.NVarChar).Value = txtChallanType.Text;
                            sqlcom.Parameters.Add("@CHODATE", SqlDbType.NVarChar).Value = Convert.ToDateTime(txtChallanDate.Text).ToString("yyyy-MM-dd");
                            if (dr["CHOPrdCode"].ToString() == string.Empty)
                            {
                                dr["CHOPrdCode"] = "0";
                            }
                            sqlcom.Parameters.Add("@CHOPrdCode", SqlDbType.NVarChar).Value = dr["CHOPrdCode"].ToString();
                            sqlcom.Parameters.Add("@CHOManualDesc", SqlDbType.NVarChar).Value = dr["CHOManualDesc"].ToString();

                            if (dr["CHOArtID"].ToString() == string.Empty)
                            {
                                dr["CHOArtID"] = "0";
                            }


                            sqlcom.Parameters.Add("@CHOArtID", SqlDbType.NVarChar).Value = dr["CHOArtID"].ToString();
                            if (dr["CHOColID"].ToString() == string.Empty)
                            {
                                dr["CHOColID"] = "0";
                            }
                            sqlcom.Parameters.Add("@CHOColID", SqlDbType.NVarChar).Value = dr["CHOColID"].ToString();
                            if (dr["CHOSizeID"].ToString() == string.Empty)
                            {
                                dr["CHOSizeID"] = "0";
                            }
                            sqlcom.Parameters.Add("@CHOSizeID", SqlDbType.NVarChar).Value = dr["CHOSizeID"].ToString();
                            sqlcom.Parameters.Add("@CHOLotNo", SqlDbType.NVarChar).Value = dr["CHOLotNo"].ToString();
                            if (dr["CHOTotQtyKgs"].ToString() == string.Empty)
                            {
                                dr["CHOTotQtyKgs"] = "0";
                            }
                            sqlcom.Parameters.Add("@CHOTotQtyKgs", SqlDbType.NVarChar).Value = dr["CHOTotQtyKgs"].ToString();
                            sqlcom.Parameters.Add("@CHOUom", SqlDbType.NVarChar).Value = dr["CHOUom"].ToString();
                            sqlcom.Parameters.Add("@CHOKgsType", SqlDbType.NVarChar).Value = dr["CHOKgsType"].ToString();

                            sqlcom.Parameters.Add("@CHORemarks", SqlDbType.NVarChar).Value = dr["CHORemarks"].ToString();
                            if (dr["CHOTotQty"].ToString() == string.Empty)
                            {
                                dr["CHOTotQty"] = "0";
                            }
                            sqlcom.Parameters.Add("@CHOTotQty", SqlDbType.NVarChar).Value = dr["CHOTotQty"].ToString();
                            sqlcom.Parameters.Add("@UnitCode", SqlDbType.NVarChar).Value = GlobalVariables.CUnitID;
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();


                        }

                        ProjectFunctions.SpeakError(" Challan Saved Successfully");
                        sqlcon.Close();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void HelpGrid_KeyDown(object sender, KeyEventArgs e)
        {
            try

            {
                if (e.KeyCode == Keys.Enter)
                {
                    HelpGrid_DoubleClick(null, e);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    panelControl1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void BarCodeGrid_KeyDown(object sender, KeyEventArgs e)
        {


            try
            {
                HelpGridView.Columns.Clear();
                DataRow currentrow = BarCodeGridView.GetDataRow(BarCodeGridView.FocusedRowHandle);

                if (e.KeyCode != Keys.Up)
                {
                    if (e.KeyCode != Keys.Down)
                    {
                        if (e.KeyCode != Keys.Left)
                        {
                            if (e.KeyCode != Keys.Right)
                            {
                                if (e.KeyCode != Keys.F12)
                                {
                                    if (e.KeyCode != Keys.Enter)
                                    {

                                        if (BarCodeGridView.FocusedColumn.FieldName == "CHOPrdName")
                                        {
                                            if (currentrow == null)
                                            {
                                                HelpGrid.Text = "CHOPrdName";

                                                txtSearchBox.Text = txtSearchBox.Text + ProjectFunctions.ValidateKeysForSearchBox(e);
                                                panelControl1.Visible = true;
                                                panelControl1.Select();
                                                txtSearchBox.Focus();
                                                txtSearchBox.SelectionStart = txtSearchBox.Text.Length;
                                                txtSearchBox.SelectionLength = 0;
                                            }
                                            else
                                            {
                                                DataSet dsCheck = ProjectFunctions.GetDataSet("Select * from PrdMst where PrdCode='" + ProjectFunctions.CheckNull(currentrow["CHOPrdCode"].ToString()) + "'");
                                                if (dsCheck.Tables[0].Rows.Count > 0)
                                                {

                                                    UpdateTag = "Y";


                                                    HelpGrid.Text = "CHOPrdName";
                                                    txtSearchBox.Text = txtSearchBox.Text + ProjectFunctions.ValidateKeysForSearchBox(e);
                                                    panelControl1.Visible = true;
                                                    panelControl1.Select();
                                                    txtSearchBox.Focus();
                                                    txtSearchBox.SelectionStart = txtSearchBox.Text.Length;
                                                    txtSearchBox.SelectionLength = 0;
                                                    RowIndex = BarCodeGridView.FocusedRowHandle;
                                                }
                                                else
                                                {
                                                    HelpGrid.Text = "CHOPrdName";
                                                    txtSearchBox.Text = txtSearchBox.Text + ProjectFunctions.ValidateKeysForSearchBox(e);
                                                    panelControl1.Visible = true;
                                                    panelControl1.Select();
                                                    txtSearchBox.Focus();
                                                    txtSearchBox.SelectionStart = txtSearchBox.Text.Length;
                                                    txtSearchBox.SelectionLength = 0;
                                                    RowIndex = BarCodeGridView.FocusedRowHandle;
                                                }
                                            }
                                        }
                                        if (BarCodeGridView.FocusedColumn.FieldName == "CHOArtNo")
                                        {
                                            if (currentrow == null)
                                            {
                                                HelpGrid.Text = "CHOArtNo";

                                                txtSearchBox.Text = txtSearchBox.Text + ProjectFunctions.ValidateKeysForSearchBox(e);
                                                panelControl1.Visible = true;
                                                panelControl1.Select();
                                                txtSearchBox.Focus();
                                                txtSearchBox.SelectionStart = txtSearchBox.Text.Length;
                                                txtSearchBox.SelectionLength = 0;
                                            }
                                            else
                                            {
                                                DataSet dsCheck = ProjectFunctions.GetDataSet("Select * from ARTICLE where ARTNO='" + ProjectFunctions.CheckNull(currentrow["CHOArtNo"].ToString()) + "'");
                                                if (dsCheck.Tables[0].Rows.Count > 0)
                                                {

                                                    UpdateTag = "Y";


                                                    HelpGrid.Text = "CHOArtNo";
                                                    txtSearchBox.Text = txtSearchBox.Text + ProjectFunctions.ValidateKeysForSearchBox(e);
                                                    panelControl1.Visible = true;
                                                    panelControl1.Select();
                                                    txtSearchBox.Focus();
                                                    txtSearchBox.SelectionStart = txtSearchBox.Text.Length;
                                                    txtSearchBox.SelectionLength = 0;
                                                    RowIndex = BarCodeGridView.FocusedRowHandle;
                                                }
                                                else
                                                {
                                                    HelpGrid.Text = "CHOArtNo";
                                                    txtSearchBox.Text = txtSearchBox.Text + ProjectFunctions.ValidateKeysForSearchBox(e);
                                                    panelControl1.Visible = true;
                                                    panelControl1.Select();
                                                    txtSearchBox.Focus();
                                                    txtSearchBox.SelectionStart = txtSearchBox.Text.Length;
                                                    txtSearchBox.SelectionLength = 0;
                                                    RowIndex = BarCodeGridView.FocusedRowHandle;
                                                }
                                            }
                                        }
                                        if (BarCodeGridView.FocusedColumn.FieldName == "CHOColName")
                                        {

                                            if (currentrow == null)
                                            {
                                                HelpGrid.Text = "CHOColName";
                                                txtSearchBox.Text = txtSearchBox.Text + ProjectFunctions.ValidateKeysForSearchBox(e);
                                                panelControl1.Visible = true;
                                                panelControl1.Select();
                                                txtSearchBox.Focus();
                                                txtSearchBox.SelectionStart = txtSearchBox.Text.Length;
                                                txtSearchBox.SelectionLength = 0;
                                            }
                                            else
                                            {
                                                DataSet dsCheck = ProjectFunctions.GetDataSet("Select * from COLOURS where COLSYSID='" + ProjectFunctions.CheckNull(currentrow["CHOColID"].ToString()) + "'");
                                                if (dsCheck.Tables[0].Rows.Count > 0)
                                                {

                                                    UpdateTag = "Y";

                                                    HelpGrid.Text = "CHOColName";
                                                    txtSearchBox.Text = txtSearchBox.Text + ProjectFunctions.ValidateKeysForSearchBox(e);
                                                    panelControl1.Visible = true;
                                                    panelControl1.Select();
                                                    txtSearchBox.Focus();
                                                    txtSearchBox.SelectionStart = txtSearchBox.Text.Length;
                                                    txtSearchBox.SelectionLength = 0;

                                                    RowIndex = BarCodeGridView.FocusedRowHandle;
                                                }
                                                else
                                                {
                                                    HelpGrid.Text = "CHOColName";
                                                    txtSearchBox.Text = txtSearchBox.Text + ProjectFunctions.ValidateKeysForSearchBox(e);
                                                    panelControl1.Visible = true;
                                                    panelControl1.Select();
                                                    txtSearchBox.Focus();
                                                    txtSearchBox.SelectionStart = txtSearchBox.Text.Length;
                                                    txtSearchBox.SelectionLength = 0;

                                                    RowIndex = BarCodeGridView.FocusedRowHandle;
                                                }
                                            }
                                        }

                                        if (BarCodeGridView.FocusedColumn.FieldName == "CHOSizeName")
                                        {
                                            if (currentrow == null)
                                            {
                                                HelpGrid.Text = "CHOSizeName";
                                                txtSearchBox.Text = txtSearchBox.Text + ProjectFunctions.ValidateKeysForSearchBox(e);
                                                panelControl1.Visible = true;
                                                panelControl1.Select();
                                                txtSearchBox.Focus();
                                                txtSearchBox.SelectionStart = txtSearchBox.Text.Length;
                                                txtSearchBox.SelectionLength = 0;


                                            }
                                            else
                                            {
                                                DataSet dsCheck = ProjectFunctions.GetDataSet("Select * from SIZEMAST where SZSYSID='" + ProjectFunctions.CheckNull(currentrow["CHOSizeID"].ToString()) + "' ORDER BY SZINDEX,SZSYSID");
                                                if (dsCheck.Tables[0].Rows.Count > 0)
                                                {
                                                    UpdateTag = "Y";

                                                    HelpGrid.Text = "CHOSizeName";
                                                    txtSearchBox.Text = txtSearchBox.Text + ProjectFunctions.ValidateKeysForSearchBox(e);
                                                    panelControl1.Visible = true;
                                                    panelControl1.Select();
                                                    txtSearchBox.Focus();
                                                    txtSearchBox.SelectionStart = txtSearchBox.Text.Length;
                                                    txtSearchBox.SelectionLength = 0;

                                                    RowIndex = BarCodeGridView.FocusedRowHandle;
                                                }
                                                else
                                                {
                                                    HelpGrid.Text = "CHOSizeName";
                                                    txtSearchBox.Text = txtSearchBox.Text + ProjectFunctions.ValidateKeysForSearchBox(e);
                                                    panelControl1.Visible = true;
                                                    panelControl1.Select();
                                                    txtSearchBox.Focus();
                                                    txtSearchBox.SelectionStart = txtSearchBox.Text.Length;
                                                    txtSearchBox.SelectionLength = 0;

                                                    RowIndex = BarCodeGridView.FocusedRowHandle;
                                                }
                                            }
                                        }


                                        dt.AcceptChanges();
                                    }
                                }
                            }
                        }
                    }
                }


                ProjectFunctions.DeleteCurrentRowOnKeyDown(BarCodeGrid, BarCodeGridView, e);

                if (BarCodeGridView.FocusedColumn.FieldName == "CHOTotQtyKgs" || BarCodeGridView.FocusedColumn.FieldName == "CHOLotNo" || BarCodeGridView.FocusedColumn.FieldName == "CHOTotQtyKgs" || BarCodeGridView.FocusedColumn.FieldName == "CHOTotQty")
                {
                    BarCodeGridView.ShowEditor();
                }

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
                }));

            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
        }

        private void txtSearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtSearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            try

            {
                HelpGridView.CloseEditor();
                HelpGridView.UpdateCurrentRow();
                if (e.KeyCode == Keys.Enter)
                {
                    HelpGrid_DoubleClick(null, e);
                }
                if (e.KeyCode == Keys.Down)
                {
                    HelpGrid.Focus();
                }
                if (e.KeyCode == Keys.Escape)
                {
                    panelControl1.Visible = false;
                }
                e.Handled = true;
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void txtSearchBox_EditValueChanged(object sender, EventArgs e)
        {
            try
            {

                HelpGrid.Show();
                if (HelpGrid.Text == "CHOPrdName")
                {
                    DataTable dtNew = dsPopUps.Tables[3].Clone();
                    DataRow[] dtRow = dsPopUps.Tables[3].Select("PrdName like '" + txtSearchBox.Text + "%'");
                    foreach (DataRow dr in dtRow)
                    {
                        DataRow NewRow = dtNew.NewRow();
                        NewRow["PrdCode"] = dr["PrdCode"];
                        NewRow["PrdName"] = dr["PrdName"];
                        dtNew.Rows.Add(NewRow);
                    }
                    if (dtNew.Rows.Count > 0)
                    {
                        HelpGrid.DataSource = dtNew;
                        HelpGridView.BestFitColumns();
                    }
                    else
                    {
                        HelpGrid.DataSource = null;
                        HelpGridView.BestFitColumns();
                    }
                }
                if (HelpGrid.Text == "CHOArtNo")
                {
                    DataTable dtNew = dsPopUps.Tables[0].Clone();
                    DataRow[] dtRow = dsPopUps.Tables[0].Select("ARTNO like '" + txtSearchBox.Text + "%'");
                    foreach (DataRow dr in dtRow)
                    {
                        DataRow NewRow = dtNew.NewRow();
                        NewRow["ARTNO"] = dr["ARTNO"];
                        NewRow["ARTDESC"] = dr["ARTDESC"];
                        NewRow["ARTMRP"] = dr["ARTMRP"];
                        NewRow["ARTWSP"] = dr["ARTWSP"];
                        NewRow["ARTSYSID"] = dr["ARTSYSID"];
                        dtNew.Rows.Add(NewRow);
                    }
                    if (dtNew.Rows.Count > 0)
                    {
                        HelpGrid.DataSource = dtNew;
                        HelpGridView.BestFitColumns();
                    }
                    else
                    {
                        HelpGrid.DataSource = null;
                        HelpGridView.BestFitColumns();
                    }
                }
                if (HelpGrid.Text == "CHOColName")
                {
                    DataTable dtNew = dsPopUps.Tables[1].Clone();
                    DataRow[] dtRow = dsPopUps.Tables[1].Select("COLNAME like '" + txtSearchBox.Text + "%'");
                    foreach (DataRow dr in dtRow)
                    {
                        DataRow NewRow = dtNew.NewRow();
                        NewRow["COLNAME"] = dr["COLNAME"];
                        NewRow["COLSYSID"] = dr["COLSYSID"];
                        dtNew.Rows.Add(NewRow);
                    }
                    if (dtNew.Rows.Count > 0)
                    {
                        HelpGrid.DataSource = dtNew;
                        HelpGridView.BestFitColumns();
                    }
                    else
                    {
                        HelpGrid.DataSource = null;
                        HelpGridView.BestFitColumns();
                    }
                }
                if (HelpGrid.Text == "CHOSizeName")
                {
                    DataTable dtNew = dsPopUps.Tables[2].Clone();
                    DataRow[] dtRow = dsPopUps.Tables[2].Select("SZNAME like '" + txtSearchBox.Text + "%'");
                    foreach (DataRow dr in dtRow)
                    {
                        DataRow NewRow = dtNew.NewRow();
                        NewRow["SZNAME"] = dr["SZNAME"];
                        NewRow["SZSYSID"] = dr["SZSYSID"];
                        NewRow["SZINDEX"] = dr["SZINDEX"];
                        dtNew.Rows.Add(NewRow);
                    }
                    if (dtNew.Rows.Count > 0)
                    {
                        HelpGrid.DataSource = dtNew;
                        HelpGridView.BestFitColumns();

                        HelpGridView.Columns[2].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                        HelpGridView.FocusedRowHandle = 0;
                    }
                    else
                    {
                        HelpGrid.DataSource = null;
                        HelpGridView.BestFitColumns();
                    }
                }
            }

            catch (Exception ex)
            {

            }
        }
    }
}