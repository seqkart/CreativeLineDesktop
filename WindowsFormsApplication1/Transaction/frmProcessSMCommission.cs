using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public partial class frmProcessSMCommission : DevExpress.XtraEditors.XtraForm
    {
        public frmProcessSMCommission()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fillGrid()
        {
            var ds = ProjectFunctions.GetDataSet("	SELECT DISTINCT ActMst.AccCode, ActMst.AccName FROM            InvoiceMst left outer join ActMst ON InvoiceMst.ImPartyCode = ActMst.AccCode WHERE        (InvoiceMst.ImType = 'S') and Imdate between '" + Convert.ToDateTime(DtStartDate.Text).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(DtEndDate.Text).ToString("yyyy-MM-dd") + "'");
            ds.Tables[0].Columns.Add("Select", typeof(bool));


            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dr["Select"] = false;
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                ReplGrid.DataSource = ds.Tables[0];
                ReplGridView.BestFitColumns();
            }
        }
        private void SetMyControls()
        {
            var Query4Controls = string.Empty;
            panelControl1.Location = new Point(ClientSize.Width / 2 - panelControl1.Size.Width / 2, ClientSize.Height / 2 - panelControl1.Size.Height / 2);
            ProjectFunctions.XtraFormVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);

            ProjectFunctions.GroupCtrlVisualize(panelControl1);
            ProjectFunctions.GirdViewVisualize(ReplGridView);
            ReplGridView.OptionsBehavior.Editable = true;
            ProjectFunctions.DatePickerVisualize(panelControl1);
            ProjectFunctions.TextBoxVisualize(panelControl1);
            ProjectFunctions.ButtonVisualize(panelControl1);
        }

        private void frmProcessSMCommission_Load(object sender, EventArgs e)
        {
            SetMyControls();
            DtStartDate.EditValue = DateTime.Now;
            DtEndDate.EditValue = DateTime.Now;

            fillGrid();
        }

        private void Btn_RefreshGridData_Click(object sender, EventArgs e)
        {
            fillGrid();
        }

        private bool ValidateData()
        {
            if (Convert.ToDateTime(DtStartDate.Text).Date.Day == 1 && Convert.ToDateTime(DtStartDate.Text).Month == Convert.ToDateTime(DtEndDate.Text).Month && Convert.ToDateTime(DtStartDate.Text).Year == Convert.ToDateTime(DtEndDate.Text).Year)
            {

            }
            else
            {
                ProjectFunctions.SpeakError("Wrong Dates Are Selected");
                return false;
            }

            if (Convert.ToDateTime(DtEndDate.Text).Date.Day == DateTime.DaysInMonth(Convert.ToDateTime(DtEndDate.Text).Date.Year, Convert.ToDateTime(DtEndDate.Text).Date.Month) && Convert.ToDateTime(DtEndDate.Text).Month == Convert.ToDateTime(DtStartDate.Text).Month && Convert.ToDateTime(DtEndDate.Text).Year == Convert.ToDateTime(DtStartDate.Text).Year)
            {

            }
            else
            {
                ProjectFunctions.SpeakError("Wrong Dates Are Selected");
                return false;
            }

            DataSet ds = ProjectFunctions.GetDataSet("Select top 1 * from IncData Where IncDate> ='" + Convert.ToDateTime(DtStartDate.Text).ToString("yyyy-MM-dd") + "' And IncDate<='" + Convert.ToDateTime(DtEndDate.Text).ToString("yyyy-MM-dd") + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {

                ProjectFunctions.SpeakError("Incentive Already Processed For This Month");
                if (txtPassword.Text == "INCENTIVE")
                {


                }
                else
                {
                    return false;
                }


            }
            return true;
        }


        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                ProjectFunctions.GetDataSet("Delete from IncData Where IncDate >='" + Convert.ToDateTime(DtStartDate.Text).ToString("yyyy-MM-dd") + "' And IncDate<='" + Convert.ToDateTime(DtEndDate.Text).ToString("yyyy-MM-dd") + "'");

                var str = string.Format("[sp_Rpt_SaleData] '{0}','{1}'", Convert.ToDateTime(DtStartDate.Text).ToString("yyyy-MM-dd"), Convert.ToDateTime(DtEndDate.Text).ToString("yyyy-MM-dd"));
                DataSet ds = ProjectFunctions.GetDataSet(str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (dr["CratesInctives"].ToString().Trim() == string.Empty)
                        {
                            dr["CratesInctives"] = "0";
                        }
                        if (Convert.ToDecimal(dr["CratesInctives"]) > 0)
                        {
                            String Query = "Insert into IncData(IncAccIncTag,IncDate,IncPartyCode,IncPrdCode,IncQty,IncRate,IncAmount,IncBillNo)values(";
                            Query = Query + " '" + dr["AccIncTag"].ToString() + "',";
                            Query = Query + " '" + Convert.ToDateTime(dr["BillDate"]).ToString("yyyy-MM-dd") + "',";
                            Query = Query + " '" + dr["PartyCode"].ToString() + "',";
                            Query = Query + " '" + Convert.ToInt64(dr["PrdCode"]) + "',";
                            Query = Query + " '" + Convert.ToDecimal(dr["Quantity"]) + "',";
                            Query = Query + " '" + Convert.ToDecimal(dr["Crates"]) + "',";
                            Query = Query + " '" + Convert.ToDecimal(dr["CratesInctives"]) + "',";
                            Query = Query + " '" + dr["BillNo"].ToString() + "')";

                            ProjectFunctions.GetDataSet(Query);
                        }
                    }

                }
                fillGrid();
            }
        }
        private void btnSelectALL_CheckedChanged(object sender, EventArgs e)
        {
#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            var MaxRow = ((ReplGrid.KeyboardFocusView as GridView).RowCount);
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            if (btnSelectALL.Checked == true)
            {
                for (var i = 0; i < MaxRow; i++)
                {
                    ReplGridView.SetRowCellValue(i, "Select", "True");
                }
            }
            if (btnSelectALL.Checked == false)
            {
                for (var i = 0; i < MaxRow; i++)
                {
                    ReplGridView.SetRowCellValue(i, "Select", "False");
                }
            }
        }
    }
}