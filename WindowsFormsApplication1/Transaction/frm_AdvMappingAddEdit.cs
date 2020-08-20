using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class frm_AdvMappingAddEdit : DevExpress.XtraEditors.XtraForm
    {


        public string DealerCode { get; set; }
        public string DealerName { get; set; }
        public string s1 { get; set; }
#pragma warning disable CS0169 // The field 'frm_AdvMappingAddEdit.rowindex' is never used
        private int rowindex;
#pragma warning restore CS0169 // The field 'frm_AdvMappingAddEdit.rowindex' is never used

        public string AdvanceVNo { get; set; }
        public DateTime AdvanceVDate { get; set; }
        public string AdvanceVType { get; set; }
        public decimal AdvanceAmt { get; set; }

        public frm_AdvMappingAddEdit()
        {
            InitializeComponent();

        }
        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(this);
            //ProjectFunctions.GirdViewVisualize(InfoGridView);
            ProjectFunctions.ButtonVisualize(this);
            ProjectFunctions.DatePickerVisualize(this);

            AdvanceGridView.FocusRectStyle = DrawFocusRectStyle.CellFocus;

            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);

            HelpGrid.Height = this.Height - 10;
            HelpGrid.Left = this.Width - HelpGrid.Width;
            HelpGrid.Top = this.Height - HelpGrid.Height - 10;
            HelpGrid.BringToFront();


        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void txtReqQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private void HelpGrid_KeyDown(object sender, KeyEventArgs e)
        {

        }


        //private string getNewInvoiceDocumentNo()
        //{
        //    var s2 = string.Empty;
        //    var strsql = string.Empty;
        //    var ds = new DataSet();
        //    strsql = strsql + "select isnull(max(Cast(CAPamNo as int)),00000) from CapaMst  ";

        //    ds = ProjectFunctions.GetDataSet(strsql);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        s2 = ds.Tables[0].Rows[0][0].ToString().Trim();
        //        s2 = (Convert.ToInt32(s2) + 1).ToString().Trim();
        //    }
        //    return s2;
        //}
        private void frmBomMstAddEdit_Load(object sender, EventArgs e)
        {
            SetMyControls();
            Txt_DealerCode.Text = DealerCode;
            Txt_Dealer.Text = DealerName;

            DtEndDate.DateTime = DateTime.Today;

            Txt_AdvVoucherNo.Text = AdvanceVNo;
            Txt_AdvVoucherType.Text = AdvanceVType;
            DtAdvanceVuDt.EditValue = AdvanceVDate;
            Txt_AdvAmt.EditValue = AdvanceAmt;

            Txt_DealerCode.Enabled = false;
            Txt_AdvVoucherNo.Enabled = false;


            if (s1 == "Edit")
            {
                DataSet ds = ProjectFunctions.GetDataSet(string.Format("sp_LoadEditData4AdvVouchers '{0}','{1}','{2}'", AdvanceVNo, AdvanceVDate.ToString("yyyy-MM-dd"), AdvanceVType));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Txt_DealerCode.Text = ds.Tables[0].Rows[0]["AmdDealerCode"].ToString();
                    Txt_Dealer.Text = ds.Tables[0].Rows[0]["DealerName"].ToString();
                    Txt_AdvVoucherNo.Text = ds.Tables[0].Rows[0]["AmdAdvVutNo"].ToString();
                    DtAdvanceVuDt.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["AmdAdvVutDate"]);
                    Txt_AdvVoucherType.Text = ds.Tables[0].Rows[0]["AmdAdvVutType"].ToString();
                    Txt_AdvAmt.Text = ds.Tables[0].Rows[0]["AdvVutAmt"].ToString();
                    InvoiceGridCtrl.DataSource = ds.Tables[0];
                    Txt_DealerCode.Enabled = false;
                    Txt_AdvVoucherNo.Enabled = false;


                }

            }


        }

        private void txtProductionBag_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }
        private bool validateData()
        {
            //if(txtPoint.Text=="")
            //{
            //    txtPoint.Focus();
            //    return false;
            //}

            //if (txtFDRCode.Text == "")
            //{
            //    txtFDRCode.Focus();
            //    return false;
            //}


            return true;
        }

        private bool ValidateDataForSaving()
        {
            //var MaxRow = ((AdvanceGridCtrl.KeyboardFocusView as GridView).RowCount);
            //if (MaxRow == 0)
            //{
            //    ProjectFunctions.SpeakError("Empty Entry Cannot Be Saved");
            //    return false;
            //}
            btnSave.Enabled = false;

            InvoiceGridView.UpdateCurrentRow();
            InvoiceGridView.UpdateSummary();

            decimal TotAdjustment = Convert.ToDecimal(InvoiceGridView.Columns["AmdAdjustAmt"].Summary[0].SummaryValue);

            if (TotAdjustment > Convert.ToDecimal(Txt_AdvAmt.Text) || TotAdjustment == 0)
            {
                ProjectFunctions.SpeakError("Please verify adjustment amount");
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


                    con.Open();

                    DataRow[] drrows = (InvoiceGridCtrl.DataSource as DataTable).Select("Select=true");
                    if (drrows.Count() <= 0)
                    {
                        ProjectFunctions.SpeakError("Please Select Ant Invoice");
                        return;
                    }



                    SqlTransaction trans = con.BeginTransaction();
                    var cmd = new SqlCommand
                    {
                        Connection = con,
                        CommandType = CommandType.Text,
                        Transaction = trans
                    };


                    try
                    {
                        cmd.CommandText = string.Format("delete from AdvInvMapData where AmdDealerCode='{0}' and AmdAdvVutNo='{1}' and AmdAdvVutDate='{2}' and AmdAdvVutType='{3}' ",
                           Txt_DealerCode.Text, Txt_AdvVoucherNo.Text, DtAdvanceVuDt.DateTime.ToString("yyyy-MM-dd"), Txt_AdvVoucherType.Text);
                        cmd.ExecuteNonQuery();

                        foreach (DataRow dr in drrows)
                        {
                            cmd.CommandText = "insert into AdvInvMapData(AmdDealerCode,AmdAdvVutNo,AmdAdvVutDate,AmdAdvVutType,AmdImNo,AmdImDate,AmdImType,AmdImNetAmt,AmdAdjustAmt,AmdFedUser,AmdFedDt) " +
                                "values(@AmdDealerCode,@AmdAdvVutNo,@AmdAdvVutDate,@AmdAdvVutType,@AmdImNo,@AmdImDate,@AmdImType,@AmdImNetAmt,@AmdAdjustAmt,@AmdFedUser,getdate())";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@AmdDealerCode", Txt_DealerCode.Text);
                            cmd.Parameters.AddWithValue("@AmdAdvVutNo", Txt_AdvVoucherNo.Text);
                            cmd.Parameters.AddWithValue("@AmdAdvVutDate", DtAdvanceVuDt.DateTime.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@AmdAdvVutType", Txt_AdvVoucherType.Text);
                            cmd.Parameters.AddWithValue("@AmdImNo", dr["IdNo"].ToString());
                            cmd.Parameters.AddWithValue("@AmdImDate", Convert.ToDateTime(dr["Iddate"]).ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@AmdImType", dr["IdType"].ToString());
                            cmd.Parameters.AddWithValue("@AmdImNetAmt", dr["IdPrdAmt"].ToString());
                            cmd.Parameters.AddWithValue("@AmdAdjustAmt", dr["AmdAdjustAmt"].ToString());
                            cmd.Parameters.AddWithValue("@AmdFedUser", GlobalVariables.CurrentUser);
                            cmd.ExecuteNonQuery();


                        }


                        cmd.CommandText = string.Format("EXEC sp_UpdateAdvanceVoucher '{0}','{1}','{2}'", Txt_AdvVoucherNo.Text, DtAdvanceVuDt.DateTime.ToString("yyyy-MM-dd"), Txt_AdvVoucherType.Text);
                        cmd.ExecuteNonQuery();

                    }

                    catch (Exception ex)
                    {
                        trans.Rollback();
                        ProjectFunctions.SpeakError(ex.Message);
                        return;
                    }

                    trans.Commit();
                    ProjectFunctions.SpeakError("Data saved");

                    Close();
                }
            }
        }




        private void HelpGrid_KeyDown_1(object sender, KeyEventArgs e)
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
            switch (HelpGrid.Text)
            {
                case "Advance":
                    Txt_AdvVoucherNo.Text = row["AdvVutNo"].ToString();
                    DtAdvanceVuDt.EditValue = Convert.ToDateTime(row["AdvVutDate"]);
                    Txt_AdvVoucherType.Text = row["AdvVutType"].ToString();
                    Txt_AdvAmt.Text = row["AdvVutAmt"].ToString();
                    HelpGrid.Visible = false;
                    BtnRefreshGridData.Focus();
                    break;

                case "Dealer":
                    Txt_DealerCode.Text = row["DealerCode"].ToString();
                    Txt_Dealer.Text = row["DealerName"].ToString();

                    Txt_AdvVoucherNo.Text = string.Empty;
                    Txt_AdvVoucherType.Text = string.Empty;
                    Txt_AdvAmt.Text = string.Empty;

                    Txt_AdvVoucherNo.Focus();
                    break;

            }
            HelpGrid.Visible = false;
            btnSave.Enabled = false;

        }





        private void InfoGridView_RowStyle(object sender, RowStyleEventArgs e)
        {

            DataRow dr = AdvanceGridView.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                if (dr["EditMode"] == null) return;
                if (dr["EditMode"].ToString() == "1")
                    e.Appearance.BackColor = System.Drawing.Color.Lavender;//.FromArgb(224, 224, 224);
            }
        }

        private void txtRemarks_KeyDown(object sender, KeyEventArgs e)
        {

        }



        private bool CheckPass()
        {

            // string pass = (Convert.ToDecimal(txtBomNo.Text) + Convert.ToDecimal(DateTime.Now.Hour.ToString()) + Convert.ToDecimal(DateTime.Now.Date.Day.ToString()).ToString());
            //// pass = "CAPA123";
            //if(txtPassword.Text == pass)
            //{
            //    return true;
            //}
            return false;

        }

        private void BtnRefreshGridData_Click(object sender, EventArgs e)
        {
            DataSet ds = ProjectFunctions.GetDataSet(string.Format("sp_LoadAdvPenVouchers @Tag='Add',@DlrCode= '{2}',@from='{0}',@to='{1}',@Vuttype='{3}',@Vutno='{4}',@VutDate='{5}' ",
                DtAdvanceVuDt.DateTime.ToString("yyyy-MM-dd"), DtEndDate.DateTime.ToString("yyyy-MM-dd"), Txt_DealerCode.Text, Txt_AdvVoucherType.Text, Txt_AdvVoucherNo.Text, DtAdvanceVuDt.DateTime.ToString("yyyy-MM-dd")));


            InvoiceGridCtrl.DataSource = ds.Tables[0];

            btnSave.Enabled = false;

        }

        private void Txt_AdvVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HelpGrid.Text = "Advance";
                // if (Txt_AdvVoucherNo.Text.Length == 0)
                {
                    HelpGrid.DataSource = null;
                    HelpGridView.Columns.Clear();
                    var ds = ProjectFunctions.GetDataSet(string.Format("sp_LoadAdvPenVouchers @Tag='AdvRef',@DlrCode='{0}'", Txt_DealerCode.Text));
                    HelpGrid.DataSource = ds.Tables[0];
                    HelpGridView.BestFitColumns();
                    HelpGrid.Visible = true;
                    HelpGrid.Focus();
                }
                //else
                //{
                //    var ds = ProjectFunctions.GetDataSet("select distinct DeptDesc,DeptCode from deptnewmst  Where DeptCode='" + txtFDRCode.Text + "'");
                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        Txt_AdvVoucherNo.Text = ds.Tables[0].Rows[0]["DeptCode"].ToString();
                //        Txt_AdvVoucherNo.Text = ds.Tables[0].Rows[0]["DeptDesc"].ToString();

                //        Txt_AdvVoucherNo.Focus();
                //    }
                //    else
                //    {
                //        var ds1 = ProjectFunctions.GetDataSet("select distinct DeptDesc,DeptCode from deptnewmst order by DeptDesc  ");
                //        HelpGrid.DataSource = ds1.Tables[0];
                //        HelpGridView.BestFitColumns();
                //        HelpGrid.Visible = true;
                //        HelpGrid.Focus();
                //    }
                //  }
            }
            e.Handled = true;
        }

        private void Txt_DealerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HelpGrid.Text = "Dealer";
                HelpGrid.DataSource = null;
                HelpGridView.Columns.Clear();

                if (Txt_DealerCode.Text.Length == 0)
                {
                    var ds = ProjectFunctions.GetDataSet(string.Format("sp_LoadAdvPenVouchers @Tag='Dealer' "));
                    HelpGrid.DataSource = ds.Tables[0];
                    HelpGridView.BestFitColumns();
                    HelpGrid.Visible = true;
                    HelpGrid.Focus();
                }
                else
                {
                    var ds = ProjectFunctions.GetDataSet(string.Format("sp_LoadAdvPenVouchers @Tag='Dealer' ", Txt_DealerCode.Text));
                    DataRow[] drr = ds.Tables[0].Select(string.Format("DealerCode='{0}'", Txt_DealerCode.Text));
                    if (drr.Count() > 0)
                    {
                        Txt_Dealer.Text = drr[0]["DealerName"].ToString();
                        Txt_DealerCode.Text = drr[0]["DealerCode"].ToString();
                        Txt_AdvVoucherNo.Text = string.Empty;
                        Txt_AdvVoucherType.Text = string.Empty;
                        Txt_AdvAmt.Text = string.Empty;
                        Txt_AdvVoucherNo.Focus();
                    }
                    else
                    {
                        var ds1 = ProjectFunctions.GetDataSet("sp_LoadAdvPenVouchers @Tag='Dealer' ");
                        HelpGrid.DataSource = ds1.Tables[0];
                        HelpGridView.BestFitColumns();
                        HelpGrid.Visible = true;
                        HelpGrid.Focus();
                    }
                }
            }
            e.Handled = true;
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {

            if (ValidateDataForSaving() == false)
                return;

            btnSave.Enabled = true;
        }

        private void InvoiceGridView_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void InvoiceGridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void InvoiceGridView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == gridColumnSelect)
            {
                DataRow dr = InvoiceGridView.GetDataRow(e.RowHandle);
                if (Convert.ToBoolean(e.Value) == true)
                {

                    dr["AmdAdjustAmt"] = dr["IdPrdAmt"];
                    //InvoiceGridView.SetRowCellValue(e.RowHandle, gridColumnAdjustment, dr["IdPrdAmt"]);
                }
                else
                {

                    //InvoiceGridView.SetRowCellValue(e.RowHandle, gridColumnAdjustment, DBNull.Value);
                    dr["AmdAdjustAmt"] = DBNull.Value;
                }
                dr["Select"] = Convert.ToBoolean(e.Value);
                btnSave.Enabled = false;
                InvoiceGridView.UpdateCurrentRow();
                InvoiceGridView.UpdateSummary();

                if (Convert.ToBoolean(e.Value) == true)
                {
                    decimal TotAmt = Convert.ToDecimal(InvoiceGridView.Columns["AmdAdjustAmt"].Summary[0].SummaryValue);
                    if (TotAmt > Convert.ToDecimal(Txt_AdvAmt.EditValue))
                    {
                        if (XtraMessageBox.Show("Do you want to Adjust this bill as partial", "Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            decimal balamt;
                            balamt = Convert.ToDecimal(Txt_AdvAmt.EditValue) - (TotAmt - Convert.ToDecimal(dr["IdPrdAmt"]));
                            if (balamt < 0)
                                balamt = 0;

                            dr["AmdAdjustAmt"] = balamt;
                        }
                    }
                }
            }
        }

        private void InvoiceGridCtrl_Click(object sender, EventArgs e)
        {

        }
    }
}

