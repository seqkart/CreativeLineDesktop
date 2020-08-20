using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public partial class frm_Asset_AddUpd : XtraForm
    {
        public string AMUpDateDt;
        public string MMDocNo { get; set; }
        public string CurrentControl { get; set; }
        private string AssetLocation;
        private string DocID;
        private string DocLoc;
        private int id;
        private bool IsUpdateLo;
        private int selected_Record;
        private DataRow ThisRecord;
        public string AssetCode { get; set; }
        public bool IsUpdate { get; set; }


        public frm_Asset_AddUpd()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var Connection = new SqlConnection(ProjectFunctions.ConnectionString))
            {
                var cmd = Connection.CreateCommand();
                cmd.Connection = Connection;

                var sql = string.Empty;
                var str = string.Empty;
                if (IsUpdate)
                {
                    sql = "UPDATE [AssetMst] set " +
                            "[AssetDesc]=@AssetDesc,[AssetCategoryCd]=@AssetCategoryCd, " +
                            "[AssetCategorySubCd]=@AssetCategorySubCd,[AssetRegNo]=@AssetRegNo,[AssetValue]=@AssetValue " +
                            ",[AssetType]=@AssetType,[AssetLocation]=@AssetLocation,[AssetManufacturer]=@AssetManufacturer, " +
                            "[AssetBrand]=@AssetBrand,[AssetModel]=@AssetModel,[AssetSrNo]=@AssetSrNo,[AssetSrNo1]=@AssetSrNo1 " +
                            ",[AssetStatus]=@AssetStatus,[AssetCondition]=@AssetCondition, " +
                            "[AssetNotes]=@AssetNotes,[AssetAccCode]=@AssetAccCode,[AssetPONo]=@AssetPONo " +
                            ",[AssetPurParyCode]=@AssetPurParyCode,[AssetPurDocNo]=@AssetPurDocNo,[AssetPurDocDate]=@AssetPurDocDate, " +
                            "[AssetPurDocAmt]=@AssetPurDocAmt,[AssetInServiceDate]=@AssetInServiceDate " +
                            ",[AssetCurrentValue]=@AssetCurrentValue,[AssetScrapValue]=@AssetScrapValue, " +
                            "[AssetWarrantyExp]=@AssetWarrantyExp,[AssetSplTag]=@AssetSplTag,[UpDtUser]=@UpDtUser " +
                            ",[UpDateDt]=@UpDateDt,[AssetFinPartyCode]=@AssetFinPartyCode,[AssetLoanAmt]=@AssetLoanAmt, " +
                            "[AssetLoanDownPymt]=@AssetLoanDownPymt,[AssetEMIDate]=@AssetEMIDate " +
                            ",[AssetLoanEMI]=@AssetLoanEMI,[AssetLoanNoOfEMI]=@AssetLoanNoOfEMI, " +
                            "[AssetPODate]=@AssetPODate,[AssetImageLoc]=@AssetImageLoc " +
                            " Where AssetCode=@AssetCode";
                }
                else
                {
                    sql = "INSERT INTO [dbo].[AssetMst] " +
                    "([AssetCode],[AssetDesc],[AssetCategoryCd],[AssetCategorySubCd],[AssetRegNo],[AssetValue] " +
                    ",[AssetType],[AssetLocation],[AssetManufacturer],[AssetBrand],[AssetModel],[AssetSrNo],[AssetSrNo1] " +
                    ",[AssetStatus],[AssetCondition],[AssetNotes],[AssetAccCode],[AssetPONo] " +
                    ",[AssetPurParyCode],[AssetPurDocNo],[AssetPurDocDate],[AssetPurDocAmt],[AssetInServiceDate] " +
                    ",[AssetCurrentValue],[AssetScrapValue],[AssetWarrantyExp],[AssetSplTag],[UpDtUser],[FeedDt] " +
                    ",[AssetFinPartyCode],[AssetLoanAmt],[AssetLoanDownPymt],[AssetEMIDate] " +
                    ",[AssetLoanEMI],[AssetLoanNoOfEMI],[AssetPODate],[AssetImageLoc],[AssetFinTag]) " +
                    "VALUES " +
                    "(@AssetCode,@AssetDesc,@AssetCategoryCd,@AssetCategorySubCd,@AssetRegNo,@AssetValue " +
                    ",@AssetType,@AssetLocation,@AssetManufacturer,@AssetBrand,@AssetModel,@AssetSrNo,@AssetSrNo1 " +
                    ",@AssetStatus,@AssetCondition,@AssetNotes,@AssetAccCode,@AssetPONo " +
                    ",@AssetPurParyCode,@AssetPurDocNo,@AssetPurDocDate,@AssetPurDocAmt,@AssetInServiceDate " +
                    ",@AssetCurrentValue,@AssetScrapValue,@AssetWarrantyExp,@AssetSplTag,@UpDtUser,@FeedDt " +
                    ",@AssetFinPartyCode,@AssetLoanAmt,@AssetLoanDownPymt,@AssetEMIDate " +
                    ",@AssetLoanEMI,@AssetLoanNoOfEMI,@AssetPODate,@AssetImageLoc,@AssetFinTag) ";
                }

                Connection.Open();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@AssetCode", TextAssetCode.Text);
                cmd.Parameters.AddWithValue("@AssetDesc", TextDesc.Text);
                cmd.Parameters.AddWithValue("@AssetCategoryCd", TextAssetCategory.Text);
                cmd.Parameters.AddWithValue("@AssetCategorySubCd", TextAstSubCat.Text);
                cmd.Parameters.AddWithValue("@AssetRegNo", TextAssetNumber.Text);
                cmd.Parameters.AddWithValue("@AssetValue", SqlDbType.Decimal).Value = Convert.ToDecimal(TextAssPriIncAllTaxes.Text);
                cmd.Parameters.AddWithValue("@AssetType", TextAssetType.Text);
                cmd.Parameters.AddWithValue("@AssetLocation", TextAssetLocation.Text);
                cmd.Parameters.AddWithValue("@AssetManufacturer", TextManufacturer.Text);
                cmd.Parameters.AddWithValue("@AssetBrand", TextBrand.Text);
                cmd.Parameters.AddWithValue("@AssetModel", TextModel.Text);
                cmd.Parameters.AddWithValue("@AssetSrNo", TextSerialNumber.Text);
                cmd.Parameters.AddWithValue("@AssetSrNo1", TextOtherNumber.Text);

                cmd.Parameters.AddWithValue("@AssetStatus", ComboBoxStatus.Text);
                cmd.Parameters.AddWithValue("@AssetCondition", ComboBoxCondition.Text
                    );

                cmd.Parameters.AddWithValue("@AssetNotes", TextNotes.Text);
                cmd.Parameters.AddWithValue("@AssetAccCode", TextAcCode.Text);
                cmd.Parameters.AddWithValue("@AssetPONo", TextPONumber.Text);
                cmd.Parameters.AddWithValue("@AssetPurParyCode", TextSupplier.Text);
                cmd.Parameters.AddWithValue("@AssetPurDocNo", TextBillNo.Text);

                if (DtPurchased.Text == string.Empty)
                {
                    cmd.Parameters.Add("@AssetPurDocDate", SqlDbType.SmallDateTime).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@AssetPurDocDate", SqlDbType.SmallDateTime).Value = DtPurchased.DateTime.Date;
                }
                cmd.Parameters.AddWithValue("@AssetPurDocAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(TextPurchasePrice.Text);

                if (DtInService.Text == string.Empty)
                {
                    cmd.Parameters.Add("@AssetInServiceDate", SqlDbType.SmallDateTime).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@AssetInServiceDate", SqlDbType.SmallDateTime).Value = DtInService.DateTime.Date;
                }
                cmd.Parameters.AddWithValue("@AssetCurrentValue", SqlDbType.Decimal).Value = Convert.ToDecimal(TextCurrentValue.Text);
                cmd.Parameters.AddWithValue("@AssetScrapValue", SqlDbType.Decimal).Value = Convert.ToDecimal(TextScrapValue.Text);

                if (DtWarrantyExpires.Text == string.Empty)
                {
                    cmd.Parameters.Add("@AssetWarrantyExp", SqlDbType.SmallDateTime).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@AssetWarrantyExp", SqlDbType.SmallDateTime).Value = DtWarrantyExpires.DateTime.Date;
                }
                cmd.Parameters.AddWithValue("@AssetSplTag", "S");
                cmd.Parameters.AddWithValue("@UpDtUser", GlobalVariables.CurrentUser);
                if (IsUpdate)
                {
                    cmd.Parameters.Add("@UpDateDt", SqlDbType.SmallDateTime).Value = DateTime.Now.Date;
                }
                else
                {
                    cmd.Parameters.Add("@FeedDt", SqlDbType.SmallDateTime).Value = DateTime.Now.Date;
                }
                if (TextFinanceBy.Enabled)
                {
                    cmd.Parameters.AddWithValue("@AssetFinPartyCode", TextFinanceBy.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@AssetFinPartyCode", DBNull.Value);
                }
                if (TextLoanAmt.Enabled)
                {
                    cmd.Parameters.AddWithValue("@AssetLoanAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(TextLoanAmt.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@AssetLoanAmt", SqlDbType.Decimal).Value = DBNull.Value;
                }
                if (TextDownPymt.Enabled)
                {
                    cmd.Parameters.AddWithValue("@AssetLoanDownPymt", SqlDbType.Decimal).Value = Convert.ToDecimal(TextDownPymt.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@AssetLoanDownPymt", SqlDbType.Decimal).Value = DBNull.Value;
                }
                if (DtEMI.Enabled)
                {
                    cmd.Parameters.AddWithValue("@AssetEMIDate", SqlDbType.SmallDateTime).Value = DtEMI.DateTime.Date;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@AssetEMIDate", SqlDbType.SmallDateTime).Value = DBNull.Value;
                }
                if (TextEMI.Enabled)
                {
                    cmd.Parameters.AddWithValue("@AssetLoanEMI", SqlDbType.Decimal).Value = Convert.ToDecimal(TextEMI.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@AssetLoanEMI", SqlDbType.Decimal).Value = DBNull.Value;
                }
                if (TextNoofEMI.Enabled)
                {
                    cmd.Parameters.AddWithValue("@AssetLoanNoOfEMI", SqlDbType.Decimal).Value = Convert.ToDecimal(TextNoofEMI.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@AssetLoanNoOfEMI", SqlDbType.Decimal).Value = DBNull.Value;
                }
                if (DtPoDate.Text == string.Empty)
                {
                    cmd.Parameters.Add("@AssetPODate", SqlDbType.SmallDateTime).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@AssetPODate", SqlDbType.SmallDateTime).Value = DtPoDate.DateTime.Date;
                }
                cmd.Parameters.AddWithValue("@AssetImageLoc", AssetLocation ?? string.Empty);

                if (rdbYes.Checked)
                {
                    str = "1";
                }
                else
                {
                    if (rdbNo.Checked)
                    {
                        str = "0";
                    }
                }
                cmd.Parameters.Add("@AssetFinTag", SqlDbType.NVarChar).Value = str;
                cmd.ExecuteNonQuery();
                XtraMessageBox.Show("Data Saved. ");
            }


            if (IsUpdate)
            {
                Close();
                Dispose();
            }
            else
            {
                TextAssetCode.Text = string.Empty;
                TextDesc.Text = string.Empty;
                TextAssetNumber.Text = string.Empty;
                TextAssetType.Text = string.Empty;
                TextAssetCategory.Text = string.Empty;
                TextAstSubCat.Text = string.Empty;
                TextAssetLocation.Text = string.Empty;
                TextSerialNumber.Text = string.Empty;
                ComboBoxStatus.EditValue = string.Empty;
                ComboBoxCondition.EditValue = string.Empty;
                TextOtherNumber.Text = string.Empty;
                TextNotes.Text = string.Empty;
                TextAcCode.Text = string.Empty;
                TextPONumber.Text = string.Empty;
                DtPoDate.EditValue = string.Empty;
                TextBillNo.Text = string.Empty;
                TextSupplier.Text = string.Empty;
                TextFinanceBy.Text = string.Empty;
                TextLoanAmt.Text = string.Empty;
                TextDownPymt.Text = string.Empty;
                TextEMI.Text = string.Empty;
                DtEMI.EditValue = string.Empty;
                TextNoofEMI.Text = string.Empty;
                DtPurchased.EditValue = string.Empty;
                DtInService.EditValue = string.Empty;
                TextPurchasePrice.Text = string.Empty;
                TextCurrentValue.Text = string.Empty;
                TextScrapValue.Text = string.Empty;
                DtWarrantyExpires.EditValue = string.Empty;
                TextAssetTypeDesc.Text = string.Empty;
                TextAssetCategoryDesc.Text = string.Empty;
                TextSubCatDesc.Text = string.Empty;
                AssetLocDesc.Text = string.Empty;
                TextManufacturer.Text = string.Empty;
                TextBrand.Text = string.Empty;
                TextModel.Text = string.Empty;
                TextSupplierDesc.Text = string.Empty;
                TextFinByDesc.Text = string.Empty;
                TextAcCodeDesc.Text = string.Empty;
                TextAssPriIncAllTaxes.EditValue = 0;

                using (var Ds = ProjectFunctions.GetDataSet("select right('000000' +cast(isnull(max(assetCode),0)+1 as varchar(6)),6) from AssetMst;"))
                {
                    if (Ds.Tables[0].Rows.Count > 0)
                    {
                        TextAssetCode.Text = Ds.Tables[0].Rows[0][0].ToString();
                        TextDesc.Focus();
                    }
                }
            }
        }

        private void btn_Validate_Click(object sender, EventArgs e)
        {
            if (TextDesc.Text == string.Empty)
            {
                XtraMessageBox.Show("Error! Description Field blank", "Validation Failed");
                TextDesc.Focus();
                return;
            }
            else
            {
                if (TextManufacturer.Text == string.Empty)
                {
                    XtraMessageBox.Show("Error! Manufacturer Field blank", "Validation Failed");
                    TextManufacturer.Focus();
                    return;
                }
                else
                {
                    if (TextBrand.Text == string.Empty)
                    {
                        XtraMessageBox.Show("Error! Brand Field blank", "Validation Failed");
                        TextBrand.Focus();
                        return;
                    }
                    else
                    {
                        if (TextModel.Text == string.Empty)
                        {
                            XtraMessageBox.Show("Error! Model Field blank", "Validation Failed");
                            TextModel.Focus();
                            return;
                        }
                        else
                        {
                            if (TextAssetNumber.Text == string.Empty)
                            {
                                XtraMessageBox.Show("Error! Asset Number Field blank", "Validation Failed");
                                TextAssetNumber.Focus();
                                return;
                            }
                            else
                            {
                                if (TextSerialNumber.Text == string.Empty)
                                {
                                    XtraMessageBox.Show("Error! Serial Number Field blank", "Validation Failed");
                                    TextSerialNumber.Focus();
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            btnSave.Enabled = true;
        }

        private void frm_Assetmanager_Load(object sender, EventArgs e)
        {
            SetMyControls();

            if (IsUpdate)
            {
                var Connection = new SqlConnection(ProjectFunctions.ConnectionString);
                Connection.Open();
                var DS = ProjectFunctions.GetDataSet(String.Format("SELECT   * From V_AssetMst4Upd   where AssetCode='{0}'", AssetCode));

                if (DS.Tables[0].Rows.Count > 0)
                {
                    TextAssetCode.Text = DS.Tables[0].Rows[0]["AssetCode"].ToString();
                    TextDesc.Text = DS.Tables[0].Rows[0]["AssetDesc"].ToString();
                    TextAssetNumber.Text = DS.Tables[0].Rows[0]["AssetRegNo"].ToString();

                    TextAssetType.Text = DS.Tables[0].Rows[0]["ComplaintTypeCode"].ToString();
                    TextAssetTypeDesc.Text = DS.Tables[0].Rows[0]["ComplaintType"].ToString();

                    TextAssetCategory.Text = DS.Tables[0].Rows[0]["AssetCategoryCd"].ToString();
                    TextAssetCategoryDesc.Text = DS.Tables[0].Rows[0]["CCDesc"].ToString();

                    TextAstSubCat.Text = DS.Tables[0].Rows[0]["AssetCategorySubCd"].ToString();
                    TextSubCatDesc.Text = DS.Tables[0].Rows[0]["CCSubDesc"].ToString();

                    TextAssetLocation.Text = DS.Tables[0].Rows[0]["AssetLocation"].ToString();
                    AssetLocDesc.Text = DS.Tables[0].Rows[0]["Cityname"].ToString();

                    TextManufacturer.Text = DS.Tables[0].Rows[0]["AssetManufacturer"].ToString();
                    TextBrand.Text = DS.Tables[0].Rows[0]["AssetBrand"].ToString();
                    TextModel.Text = DS.Tables[0].Rows[0]["AssetModel"].ToString();
                    TextSerialNumber.Text = DS.Tables[0].Rows[0]["AssetSrNo"].ToString();
                    TextOtherNumber.Text = DS.Tables[0].Rows[0]["AssetSrNo1"].ToString();

                    ComboBoxStatus.EditValue = DS.Tables[0].Rows[0]["AssetStatus"].ToString();
                    ComboBoxCondition.EditValue = DS.Tables[0].Rows[0]["AssetCondition"].ToString();
                    TextNotes.Text = DS.Tables[0].Rows[0]["AssetNotes"].ToString();
                    TextAcCode.Text = DS.Tables[0].Rows[0]["AssetAccCode"].ToString();
                    TextAcCodeDesc.Text = DS.Tables[0].Rows[0]["AccName"].ToString();

                    TextPONumber.Text = DS.Tables[0].Rows[0]["AssetPONo"].ToString();

                    if (DS.Tables[0].Rows[0]["AssetPODate"] != DBNull.Value)
                    {
                        DtPoDate.EditValue = Convert.ToDateTime(DS.Tables[0].Rows[0]["AssetPODate"].ToString());
                    }
                    TextBillNo.Text = DS.Tables[0].Rows[0]["AssetPurDocNo"].ToString();

                    TextSupplier.Text = DS.Tables[0].Rows[0]["AssetPurParyCode"].ToString();
                    TextSupplierDesc.Text = DS.Tables[0].Rows[0]["SupplierDesc"].ToString();

                    if (DS.Tables[0].Rows[0]["AssetFinPartyCode"] == null || DS.Tables[0].Rows[0]["AssetFinPartyCode"] == DBNull.Value)
                    {
                        TextFinanceBy.Enabled = false;
                    }
                    else
                    {
                        TextFinanceBy.Text = DS.Tables[0].Rows[0]["AssetFinPartyCode"].ToString();
                    }
                    TextFinByDesc.Text = DS.Tables[0].Rows[0]["FinByDesc"].ToString();

                    if (DS.Tables[0].Rows[0]["AssetLoanAmt"] == null || DS.Tables[0].Rows[0]["AssetLoanAmt"] == DBNull.Value)
                    {
                        TextLoanAmt.Enabled = false;
                    }
                    else
                    {
                        TextLoanAmt.EditValue = DS.Tables[0].Rows[0]["AssetLoanAmt"].ToString();
                    }
                    if (DS.Tables[0].Rows[0]["AssetLoanDownPymt"] == null || DS.Tables[0].Rows[0]["AssetLoanDownPymt"] == DBNull.Value)
                    {
                        TextDownPymt.Enabled = false;
                    }
                    else
                    {
                        TextDownPymt.EditValue = DS.Tables[0].Rows[0]["AssetLoanDownPymt"].ToString();
                    }
                    if (DS.Tables[0].Rows[0]["AssetLoanEMI"] == null || DS.Tables[0].Rows[0]["AssetLoanEMI"] == DBNull.Value)
                    {
                        TextEMI.Enabled = false;
                    }
                    else
                    {
                        TextEMI.EditValue = DS.Tables[0].Rows[0]["AssetLoanEMI"].ToString();
                    }
                    if (DS.Tables[0].Rows[0]["AssetEMIDate"] == null || DS.Tables[0].Rows[0]["AssetEMIDate"] == DBNull.Value)
                    {
                        DtEMI.Enabled = false;
                    }
                    else
                    {
                        DtEMI.EditValue = Convert.ToDateTime(DS.Tables[0].Rows[0]["AssetEMIDate"]);
                    }
                    if (DS.Tables[0].Rows[0]["AssetLoanNoOfEMI"] == null || DS.Tables[0].Rows[0]["AssetLoanNoOfEMI"] == DBNull.Value)
                    {
                        TextNoofEMI.Enabled = false;
                    }
                    else
                    {
                        TextNoofEMI.EditValue = DS.Tables[0].Rows[0]["AssetLoanNoOfEMI"].ToString();
                    }
                    if (DS.Tables[0].Rows[0]["AssetImageLoc"].ToString() != string.Empty)
                    {
                        try
                        {
                            var img = Image.FromFile(DS.Tables[0].Rows[0]["AssetImageLoc"].ToString());
                            AssetImage.Image = img;
                        }
                        catch (Exception ex)
                        {
                        }
                    }

                    if (DS.Tables[0].Rows[0]["AssetPurDocDate"] != DBNull.Value)
                    {
                        DtPurchased.EditValue = Convert.ToDateTime(DS.Tables[0].Rows[0]["AssetPurDocDate"].ToString());
                    }
                    if (DS.Tables[0].Rows[0]["AssetInServiceDate"] != DBNull.Value)
                    {
                        DtInService.EditValue = Convert.ToDateTime(DS.Tables[0].Rows[0]["AssetInServiceDate"].ToString());
                    }
                    TextPurchasePrice.EditValue = DS.Tables[0].Rows[0]["AssetPurDocAmt"].ToString();
                    TextCurrentValue.EditValue = DS.Tables[0].Rows[0]["AssetCurrentValue"].ToString();
                    TextScrapValue.EditValue = DS.Tables[0].Rows[0]["AssetScrapValue"].ToString();

                    if (DS.Tables[0].Rows[0]["AssetWarrantyExp"] != DBNull.Value)
                    {
                        DtWarrantyExpires.EditValue = Convert.ToDateTime(DS.Tables[0].Rows[0]["AssetWarrantyExp"].ToString());
                    }
                    TextAssPriIncAllTaxes.EditValue = DS.Tables[0].Rows[0]["AssetValue"].ToString();
                    TextAssetCode.Enabled = false;
                    var Dss = ProjectFunctions.GetDataSet("select * from dbo.AssetMovmentData Inner Join CityMSt On CityCode=AMMoved2Location WHERE AMAssetCode='" + TextAssetCode.Text + "'");
                    try
                    {
                        var sqlquery = "SELECT     DocID, DocFileName, DocDesc, DocLDate, DocLocation, DocCodeS FROM         DocData " +
                                        @"WHERE     (DocSource = 'AST') AND DocCodeP='" + TextAssetCode.Text + "' ";
                        Attachments_GridCtrl.DataSource = ProjectFunctions.GetDataSet(sqlquery).Tables[0];
                    }
                    catch (Exception ex)
                    {

                        XtraMessageBox.Show(ex.Message, "!Error");
                    }
                    HistoryGridControl.DataSource = Dss.Tables[0];
                    var Ds1s = "NA";
                    try
                    {
                        Ds1s = ProjectFunctions.GetDataSet(String.Format("select Top 1 CityName from dbo.AssetMovmentData Inner Join CityMSt On CityCode=AMMoved2Location WHERE AMAssetCode='{0}' Order By AmAid Desc", TextAssetCode.Text)).Tables[0].Rows[0][0].ToString();
                    }
                    catch (Exception ex)
                    {
                    }
                    barCodeControl1.Text = String.Format("ASSET CODE {0} NAME {1} REG. NO. {0}CURRENT LOCATION {2}", TextAssetNumber.Text.ToUpper(), TextDesc.Text.ToUpper(), Ds1s.ToUpper());
                    TextDesc.Focus();
                }
            }
            else
            {
                using (var Ds = ProjectFunctions.GetDataSet("select right('000000' +cast(isnull(max(assetCode),0)+1 as varchar(6)),6) from AssetMst;"))
                {
                    if (Ds.Tables[0].Rows.Count > 0)
                    {
                        TextAssetCode.Text = Ds.Tables[0].Rows[0][0].ToString();
                        TextDesc.Focus();
                    }
                }
            }
        }

        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(panelControl4);
            ProjectFunctions.TextBoxVisualize(panelControl5);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.DatePickerVisualize(this);
            ProjectFunctions.DatePickerVisualize(panelControl4);
            ProjectFunctions.DatePickerVisualize(panelControl5);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.ToolstripVisualize(AttachmentToolStrip);

            ProjectFunctions.TextBoxVisualize(xtraTabPage6);
            ProjectFunctions.DatePickerVisualize(xtraTabPage6);
            ProjectFunctions.ButtonVisualize(xtraTabPage6);

        }

        private void TextManufacturer_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, false, true, true, true);
            }
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            //using (var AD = new Forms_Transaction.AttachDoc() { DocNo = TextAssetCode.Text, Source = "AST", DocDate = DateTime.Now.Date })
            //{
            //    AD.ShowDialog();
            //}
            //try
            //{
            //    var sqlquery = "SELECT     DocID, DocFileName, DocDesc, DocLDate, DocLocation, DocCodeS FROM         DocData " +
            //                    @"WHERE     (DocSource = 'AST') AND DocCodeP='" + TextAssetCode.Text + "' ";
            //    Attachments_GridCtrl.DataSource = BaseFunctions.GetDataSet(sqlquery).Tables[0];
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, "!Error");
            //}
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            //using (var VD = new Forms_Transaction.AttachDoc() { IsView = true, Filelocation = DocLoc })
            //{
            //    VD.ShowDialog(this);
            //}
        }

        private void Attachments_GridCtrl_DoubleClick(object sender, EventArgs e)
        {
            btnOpen.PerformClick();
        }

        private void Attachments_Grid_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (Attachments_GridCtrl.DataSource != null)
                {
                    var selRows = Attachments_Grid.GetSelectedRows();
                    var selRow = (DataRowView)(Attachments_Grid.GetRow(selRows[0]));
                    ThisRecord = selRow.Row;
                    DocLoc = ThisRecord["DocLocation"].ToString();
                    DocID = ThisRecord["DocID"].ToString();
                    selected_Record = e.FocusedRowHandle;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnAttachDel_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.File.Delete(DocLoc);
                var query = String.Format("Delete from DocData where DocID='{0}';", DocID);
                using (var con = new SqlConnection(ProjectFunctions.ConnectionString))
                {
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    var sqlquery = "SELECT     DocID, DocFileName, DocDesc, DocLDate, DocLocation, DocCodeS FROM         DocData " +
                          @"WHERE     (DocSource = 'AST') AND DocCodeP='" + TextAssetCode.Text + "'";

                    Attachments_GridCtrl.DataSource = ProjectFunctions.GetDataSet(sqlquery).Tables[0];
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void TextAssetType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                CurrentControl = "TextAssetType";
                const string Query = "SELECT [ComplaintTypeCode] As 'Type',[ComplaintType] As 'Desc' FROM [dbo].[complaintmaster];";
                if (TextAssetType.Text.Trim().Length == 0)
                {
                    ShowHelpWindow(Query);
                }
                else
                {
                    var query = String.Format("SELECT [ComplaintTypeCode] As 'Type',[ComplaintType] As 'Desc' FROM [dbo].[complaintmaster]  where [ComplaintTypeCode]='{0}' ;", TextAssetType.Text.Trim());
                    var ds = ProjectFunctions.GetDataSet(query);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        TextAssetType.Text = ds.Tables[0].Rows[0]["Type"].ToString();
                        TextAssetTypeDesc.Text = ds.Tables[0].Rows[0]["Desc"].ToString();
                        TextAssetCategory.Focus();
                    }
                    else
                    {
                        ShowHelpWindow(Query);
                    }
                }

                e.Handled = true;
            }
            if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, false, true, true, true);
            }
        }


        private void TextAssetCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                CurrentControl = "TextAssetCategory";
                var Query = String.Format("Select Distinct CCDesc,CCCode From CommonCategoryMst Where CCType='{0}' and CCCode is not null ", TextAssetType.Text);

                if (TextAssetCategory.Text.Trim().Length == 0)
                {
                    ShowHelpWindow(Query);
                }
                else
                {
                    var query = String.Format("Select CCCode,CCDesc From CommonCategoryMst Where CCType='{0}' And CCCode='{1}'", TextAssetType.Text, TextAssetCategory.Text.Trim());
                    var ds = ProjectFunctions.GetDataSet(query);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        TextAssetCategory.Text = ds.Tables[0].Rows[0]["CCCode"].ToString();
                        TextAssetCategoryDesc.Text = ds.Tables[0].Rows[0]["CCDesc"].ToString();
                        TextAstSubCat.Focus();
                    }
                    else
                    {
                        ShowHelpWindow(Query);
                    }
                }

                e.Handled = true;
            }
            if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, false, true, true, true);
            }
        }

        private void TextAstSubCat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                CurrentControl = "TextAstSubCat";
                var Query = String.Format("Select CCSubDesc,CCSubCode From CommonCategoryMst Where CCCode='{0}' and CCSubCode is not null ;", TextAssetCategory.Text);
                if (TextAstSubCat.Text.Trim().Length == 0)
                {
                    ShowHelpWindow(Query);
                }
                else
                {
                    var query = String.Format("Select CCSubCode,CCSubDesc From CommonCategoryMst Where CCCode='{0}' And CCSubCode='{1}';", TextAssetCategory.Text, TextAstSubCat.Text.Trim());
                    var ds = ProjectFunctions.GetDataSet(query);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        TextAstSubCat.Text = ds.Tables[0].Rows[0]["CCSubCode"].ToString();
                        TextSubCatDesc.Text = ds.Tables[0].Rows[0]["CCSubDesc"].ToString();
                        TextAssetLocation.Focus();
                    }
                    else
                    {
                        ShowHelpWindow(Query);
                    }
                }

                e.Handled = true;
            }
            if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, false, true, true, true);
            }
        }

        private void TextAssetLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                CurrentControl = "TextAssetLocation";
                const string Query = "Select CityName,CityCode From CityMst;";
                if (TextAssetLocation.Text.Trim().Length == 0)
                {
                    ShowHelpWindow(Query);
                }
                else
                {
                    var query = String.Format("Select CityCode,CityName From CityMst  where [CityCode]='{0}' ;", TextAssetLocation.Text.Trim());
                    var ds = ProjectFunctions.GetDataSet(query);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        TextAssetLocation.Text = ds.Tables[0].Rows[0]["CityCode"].ToString();
                        AssetLocDesc.Text = ds.Tables[0].Rows[0]["CityName"].ToString();
                        TextManufacturer.Focus();
                    }
                    else
                    {
                        ShowHelpWindow(Query);
                    }
                }

                e.Handled = true;
            }
            if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, false, true, true, true);
            }
        }

        private void TextVehicleCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (TextAssetCode.Text != string.Empty && (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down))
            {
                CurrentControl = "VehicleCode";

                string Query = string.Format("Select VehicleCode,VehicleRegNo From vehicleMst WHere VehicleCode not in (Select IsNull(AssetRefCode,'XXXX') From AssetMst Where AssetCode <>'{0}') Order by 2;", TextAssetCode.Text);
                if (VehicleCode.Text.Trim().Length == 0)
                {
                    ShowHelpWindow(Query);
                }
                else
                {
                    var query = String.Format("Select VehicleCode,VehicleRegNo From vehicleMst WHere VehicleCode not in (Select IsNull(AssetRefCode,'XXXX') From AssetMst Where AssetCode <>'{1}') And VehicleCode='{0}' Order by 2;", VehicleCode.Text.Trim(), TextAssetCode.Text);
                    var ds = ProjectFunctions.GetDataSet(query);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        VehicleCode.Text = ds.Tables[0].Rows[0]["VehicleCode"].ToString();
                        VehicleDesc.Text = ds.Tables[0].Rows[0]["VehicleRegNo"].ToString();
                        TextModel.Focus();
                    }
                    else
                    {
                        ShowHelpWindow(Query);
                    }
                }

                e.Handled = true;
            }
            if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, false, true, true, true);
            }
        }

        private void ShowHelpWindow(string Query)
        {
            try
            {
                HelpGridCtrl.DataSource = null;
                HelpGrid.Columns.Clear();
                HelpGridCtrl.RefreshDataSource();
                HelpGridCtrl.Visible = true;
                HelpGridCtrl.Focus();
                HelpGridCtrl.DataSource = ProjectFunctions.GetDataSet(Query).Tables[0];




                HelpGrid.Columns[0].BestFit();
                HelpGrid.Columns[1].BestFit();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Unable to fetch Data please Contact IT Department.\n" + ex.Message, "!Error");
            }
        }

        private void HelpGridCtrl_DoubleClick(object sender, EventArgs e)




        {
            try
            {
                var row = HelpGrid.GetDataRow(HelpGrid.FocusedRowHandle);
                switch (CurrentControl)
                {
                    case "VehicleCode":
                        VehicleCode.Text = row["VehicleCode"].ToString();
                        VehicleDesc.Text = row["VehicleRegNo"].ToString();
                        TextModel.Focus();
                        break;
                    case "TextAssetType":
                        TextAssetType.Text = row["Type"].ToString();
                        TextAssetTypeDesc.Text = row["Desc"].ToString();
                        TextAssetCategory.Focus();
                        break;

                    case "TextAssetCategory":
                        TextAssetCategory.Text = row["CCCode"].ToString();
                        TextAssetCategoryDesc.Text = row["CCDesc"].ToString();
                        TextAstSubCat.Focus();
                        break;

                    case "TextAstSubCat":
                        TextAstSubCat.Text = row["CCSubCode"].ToString();
                        TextSubCatDesc.Text = row["CCSubDesc"].ToString();
                        TextAssetLocation.Focus();
                        break;

                    case "TextAssetLocation":
                        TextAssetLocation.Text = row["CityCode"].ToString();
                        AssetLocDesc.Text = row["CityName"].ToString();
                        TextManufacturer.Focus();
                        break;
                    case "TextCurrentLocation":
                        TextCurrentLocation.Text = row["CityCode"].ToString();
                        CLocDesc.Text = row["CityName"].ToString();
                        BtnHSave.Focus();
                        break;

                    case "TextAcCode":
                        TextAcCode.Text = row["AccCode"].ToString();
                        TextAcCodeDesc.Text = row["AccName"].ToString();
                        TextPONumber.Focus();
                        break;
                    case "TextSupplier":
                        TextSupplier.Text = row["AccCode"].ToString();
                        TextSupplierDesc.Text = row["AccName"].ToString();
                        TextFinanceBy.Focus();
                        rdbYes.Focus();
                        break;

                    case "TextFinanceBy":
                        TextFinanceBy.Text = row["AccCode"].ToString();
                        TextFinByDesc.Text = row["AccName"].ToString();
                        TextLoanAmt.Focus();
                        break;
                    default:
                        CurrentControl = " ";
                        break;
                }
                HelpGridCtrl.Visible = false;
                CurrentControl = string.Empty;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("!Error");
            }
        }

        private void RestoreFocus()
        {
            switch (CurrentControl)
            {
                case "TextAssetType":
                    TextAssetType.Focus();
                    break;
                case "TextAssetCategory":
                    TextAssetCategory.Focus();
                    break;
                case "TextAstSubCat":
                    TextAstSubCat.Focus();
                    break;
                case "TextAssetLocation":
                    TextAssetLocation.Focus();
                    break;

                default:
                    CurrentControl = string.Empty;
                    break;
            }
        }

        private void HelpGridCtrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                HelpGridCtrl_DoubleClick(sender, e);
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                HelpGridCtrl.Visible = false;
                RestoreFocus();
                e.Handled = true;
            }
        }

        private void TextAcCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                CurrentControl = "TextAcCode";
                const string Query = "Select AccName,AccCode From ActMst;";
                if (TextAcCode.Text.Trim().Length == 0)
                {
                    ShowHelpWindow(Query);
                }
                else
                {
                    var query = String.Format("Select AccCode,AccName From ActMst  where AccCode='{0}' ;", TextAcCode.Text.Trim());
                    var ds = ProjectFunctions.GetDataSet(query);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        TextAcCode.Text = ds.Tables[0].Rows[0]["AccCode"].ToString();
                        TextAcCodeDesc.Text = ds.Tables[0].Rows[0]["AccName"].ToString();
                        TextPONumber.Focus();
                    }
                    else
                    {
                        ShowHelpWindow(Query);
                    }
                }

                e.Handled = true;
            }
            if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, false, true, true, true);
            }
        }

        private void TextSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                CurrentControl = "TextSupplier";
                const string Query = "Select AccName,AccCode From ActMst;";
                if (TextSupplier.Text.Trim().Length == 0)
                {
                    ShowHelpWindow(Query);
                }
                else
                {
                    var query = String.Format("Select AccCode,AccName From ActMst  where AccCode='{0}' ;", TextSupplier.Text.Trim());
                    var ds = ProjectFunctions.GetDataSet(query);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        TextSupplier.Text = ds.Tables[0].Rows[0]["AccCode"].ToString();
                        TextSupplierDesc.Text = ds.Tables[0].Rows[0]["AccName"].ToString();
                        TextFinanceBy.Focus();
                    }
                    else
                    {
                        ShowHelpWindow(Query);
                    }
                }

                e.Handled = true;
            }
            if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, false, true, true, true);
            }
        }

        private void TextFinanceBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                CurrentControl = "TextFinanceBy";
                const string Query = "Select AccName,AccCode From ActMst;";
                if (TextFinanceBy.Text.Trim().Length == 0)
                {
                    ShowHelpWindow(Query);
                }
                else
                {
                    var query = String.Format("Select AccCode,AccName From ActMst  where AccCode='{0}' ;", TextFinanceBy.Text.Trim());
                    var ds = ProjectFunctions.GetDataSet(query);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        TextFinanceBy.Text = ds.Tables[0].Rows[0]["AccCode"].ToString();
                        TextFinByDesc.Text = ds.Tables[0].Rows[0]["AccName"].ToString();
                        TextLoanAmt.Focus();
                    }
                    else
                    {
                        ShowHelpWindow(Query);
                    }
                }

                e.Handled = true;
            }
            if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, false, true, true, true);
            }
        }






















































        private void rdbYes_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rdbYes.Checked == true)
            {
                TextFinanceBy.Enabled = true;
                TextLoanAmt.Enabled = true;
                TextDownPymt.Enabled = true;
                TextEMI.Enabled = true;
                DtEMI.Enabled = true;
                TextNoofEMI.Enabled = true;

                return;
            }
        }


        private void rdbNo_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rdbNo.Checked == true)
            {
                TextFinanceBy.Enabled = false;
                TextLoanAmt.Enabled = false;
                TextDownPymt.Enabled = false;
                TextEMI.Enabled = false;
                DtEMI.Enabled = false;
                TextNoofEMI.Enabled = false;
            }
        }


        private void HelpGridCtrl_Click(object sender, EventArgs e)
        {
        }

        private void rdbYes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextFinanceBy.Focus();
            }
        }

        private void rdbNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DtPurchased.Focus();
            }
        }

        private void BtnHSave_Click(object sender, EventArgs e)
        {
            if (TextAssetCode.Text.Length == 0)
            {
                XtraMessageBox.Show("Error! ");
                return;
            }
            if (TextCheckedOutTo.Text.Length == 0)
            {
                XtraMessageBox.Show("Error! ");
                return;
            }
            if (TextCurrentLocation.Text.Length == 0)
            {
                XtraMessageBox.Show("Error! ");
                return;
            }
            if (DtCheckedODate.Text.Length == 0)
            {
                XtraMessageBox.Show("Error! ");
                return;
            }


            using (var Connection = new SqlConnection(ProjectFunctions.ConnectionString))
            {
                var cmd = Connection.CreateCommand();
                cmd.Connection = Connection;
                var sql = string.Empty;
                if (IsUpdateLo)
                {
                    sql = "UPDATE [AssetMovmentData]" +
                           "SET [AMAssetCode] = @AMAssetCode,[AMMoved2Location] = @AMMoved2Location,[AMMovedonDate] = @AMMovedonDate,[AMMovedforPerson] = @AMMovedforPerson" +
                           ",[AMUpDtUser] = @AMUpDtUser,[AMUpDateDt] = @AMUpDateDt" +
                           " Where AMAssetCode=@AMAssetCode And AMAId=@AMAId";
                }
                else
                {
                    sql = "INSERT INTO [AssetMovmentData] ([AMAssetCode],[AMMoved2Location],[AMMovedonDate],[AMMovedforPerson],[AMUpDtUser],[AMFeedDt]) VALUES (@AMAssetCode,@AMMoved2Location,@AMMovedonDate,@AMMovedforPerson,@AMUpDtUser,@AMFeedDt)";
                }
                Connection.Open();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@AMAssetCode", TextAssetCode.Text);
                cmd.Parameters.AddWithValue("@AMMovedforPerson", TextCheckedOutTo.Text);
                cmd.Parameters.AddWithValue("@AMMoved2Location", TextCurrentLocation.Text);
                cmd.Parameters.Add("@AMMovedonDate", SqlDbType.SmallDateTime).Value = DtCheckedODate.DateTime.Date;
                cmd.Parameters.AddWithValue("@AMUpDtUser", GlobalVariables.CurrentUser);

                if (IsUpdateLo)
                {
                    cmd.Parameters.Add("@AMUpDateDt", SqlDbType.SmallDateTime).Value = DateTime.Now.Date;
                    cmd.Parameters.AddWithValue("@AMAId", id);
                }
                else
                {
                    cmd.Parameters.Add("@AMFeedDt", SqlDbType.SmallDateTime).Value = DateTime.Now.Date;
                }
                cmd.ExecuteNonQuery();
                IsUpdateLo = false;
                var Dss = ProjectFunctions.GetDataSet("select * from dbo.AssetMovmentData Inner Join CityMSt On CityCode=AMMoved2Location WHERE AMAssetCode='" + TextAssetCode.Text + "'");
                HistoryGridControl.DataSource = Dss.Tables[0];
                BtnHSave.Enabled = false;
            }
            var Ds1s = "NA";
            try
            {
                Ds1s = ProjectFunctions.GetDataSet(String.Format("select Top 1 CityName from dbo.AssetMovmentData Inner Join CityMSt On CityCode=AMMoved2Location WHERE AMAssetCode='{0}' Order By AmAid Desc", TextAssetCode.Text)).Tables[0].Rows[0][0].ToString();
                barCodeControl1.Text = String.Format("ASSET CODE {0} NAME {1} REG. NO. {0}CURRENT LOCATION {2}", TextAssetNumber.Text.ToUpper(), TextDesc.Text.ToUpper(), Ds1s.ToUpper());
            }
            catch (Exception ex)
            {
            }
        }

        private void HistoryGridControl_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var selRows = HistoryGridView.GetSelectedRows();
                var selRow = (DataRowView)(HistoryGridView.GetRow(selRows[0]));
                ThisRecord = selRow.Row;

                id = int.Parse(ThisRecord["AMAId"].ToString());
                TextCheckedOutTo.Text = ThisRecord["AMMovedforPerson"].ToString();
                TextCurrentLocation.Text = ThisRecord["AMMoved2Location"].ToString();

                DtCheckedODate.EditValue = Convert.ToDateTime(ThisRecord["AMMovedonDate"]).Date;
                var query = String.Format("Select CityCode,CityName From CityMst  where [CityCode]='{0}' ;", TextCurrentLocation.Text.Trim());
                var ds = ProjectFunctions.GetDataSet(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    TextCurrentLocation.Text = ds.Tables[0].Rows[0]["CityCode"].ToString();
                    CLocDesc.Text = ds.Tables[0].Rows[0]["CityName"].ToString();
                }
                IsUpdateLo = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "!Error");
            }
        }

        private void TextCurrentLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                CurrentControl = "TextCurrentLocation";
                const string Query = "Select CityName,CityCode From CityMst;";
                if (TextCurrentLocation.Text.Trim().Length == 0)
                {
                    ShowHelpWindow(Query);
                }
                else
                {
                    var query = String.Format("Select CityName,CityCode From CityMst  where [CityCode]='{0}' ;", TextAssetLocation.Text.Trim());
                    var ds = ProjectFunctions.GetDataSet(query);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        TextCurrentLocation.Text = ds.Tables[0].Rows[0]["CityCode"].ToString();
                        CLocDesc.Text = ds.Tables[0].Rows[0]["CityName"].ToString();
                        BtnHSave.Focus();
                    }
                    else
                    {
                        ShowHelpWindow(Query);
                    }
                }

                e.Handled = true;
            }
            if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, false, true, true, true);
            }
        }

        private void TextCheckedOutTo_Enter(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void AssetImage_ImageChanged(object sender, EventArgs e)
        {
            //AssetImage.Image.Save(ProjectFunctions.filelocation + @"\" + TextAssetCode.Text + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            //AssetLocation = ProjectFunctions.filelocation + @"\" + TextAssetCode.Text + ".jpg";
        }

        private void TextAssetNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var Ds1s = "NA";
            try
            {
                Ds1s = AssetLocDesc.Text;
                barCodeControl1.Text = String.Format("ASSET CODE {0} NAME {1} REG. NO. {0}CURRENT LOCATION {2}", TextAssetNumber.Text.ToUpper(), TextDesc.Text.ToUpper(), Ds1s.ToUpper());
            }
            catch (Exception ex)
            {
            }
        }

        private void TextAssetNumber_Enter(object sender, EventArgs e)
        {
            //TextAssetType.Focus();
        }

        private void TextModel_Enter(object sender, EventArgs e)
        {
            //TextAssetNumber.Focus();
        }

        private void TextAssetNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { TextAssetType.Focus(); e.Handled = true; }
        }
    }
}