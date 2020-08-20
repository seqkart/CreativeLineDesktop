using System;
using System.Data;

namespace WindowsFormsApplication1.FormReports
{
    public partial class frmPartyAccounts : DevExpress.XtraEditors.XtraForm
    {
        RangeSelectorLedger _SelectRange;
        public DataSet dsGetData { get; set; }
        public frmPartyAccounts()
        {
            InitializeComponent();
        }

        private void FrmPartyAccounts_Load(object sender, EventArgs e)
        {
            try
            {
                _SelectRange = new RangeSelectorLedger() { StartDate = GlobalVariables.FinYearStartDate, EndDate = GlobalVariables.FinYearEndDate };
                ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
                _SelectRange.BtnLoad.Click += BtnLoad_Click;
                this.Controls.Add(_SelectRange);
                _SelectRange.BringToFront();
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                if (_SelectRange.chParty.Checked)
                {
                    DataRow currentrow = _SelectRange.HelpGridView.GetDataRow(_SelectRange.HelpGridView.FocusedRowHandle);
                    ds = ProjectFunctions.GetDataSet("[sp_ZoomPartyActGrid] '" + Convert.ToDateTime(_SelectRange.DtFrom.EditValue).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(_SelectRange.DtEnd.EditValue).ToString("yyyy-MM-dd") + "','" + currentrow["AccCode"].ToString() + "'");
                }

                if (ds.Tables[0].Rows.Count > 0)
                {


                    dt = ds.Tables[0];

                    int Count = 0;
                    for (Count = 0; Count < dt.Rows.Count; Count++)
                    {
                        if (Count == 0)
                        {
                            dt.Rows[0]["Balance"] = Convert.ToDecimal(dt.Rows[0]["Debit"]) - Convert.ToDecimal(dt.Rows[0]["Credit"]);
                        }
                        else
                        {
                            dt.Rows[Count]["Balance"] = Convert.ToDecimal(dt.Rows[Count - 1]["Balance"]) + Convert.ToDecimal(dt.Rows[Count]["Debit"]) - Convert.ToDecimal(dt.Rows[Count]["Credit"]);
                        }
                    }


                    HelpGrid.DataSource = dt;
                    HelpGridView.BestFitColumns();
                }
                else
                {
                    HelpGrid.DataSource = null;
                }
                _SelectRange.Visible = false;
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            _SelectRange.Visible = true;
            _SelectRange.BringToFront();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}