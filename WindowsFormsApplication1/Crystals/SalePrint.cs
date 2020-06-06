using System;
using System.Data;
namespace WindowsFormsApplication1.Crystals
{
    public partial class SalePrint : DevExpress.XtraReports.UI.XtraReport
    {
        public String InvType { get; set; }
        public DataSet ds { get; set; }

        public SalePrint()
        {
            InitializeComponent();
        }

        private void SalePrint_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (GlobalVariables.ProgCode == "PROG21")
            {
                lblDocType.Text = "RP Credit Note";
                lblDocNo.Text = "RP Doc No :-";
                lblDocDate.Text = "RP Doc Date :-";
                xrLabel9.Visible = false;
                xrLabel34.Visible = false;
                lblEWayBillDate.Visible = false;
                lblEWayBillNo.Visible = false;
                xrLabel11.Visible = false;
                lblTCSAmount.Visible = false;
            }
            if (GlobalVariables.ProgCode == "PROG22")
            {
                lblDocType.Text = "Sale Return";
                lblDocNo.Text = "Doc No :-";
                lblDocDate.Text = "Doc Date :-";
                xrLabel9.Visible = false;
                xrLabel34.Visible = false;
                lblEWayBillDate.Visible = false;
                lblEWayBillNo.Visible = false;
                xrLabel11.Visible = false;
                lblTCSAmount.Visible = false;
            }
            if (GlobalVariables.ProgCode == "PROG23")
            {
                lblDocType.Text = "Sale Invoice";
                lblDocNo.Text = "Bill No :-";
                lblDocDate.Text = "Bill Date :-";
            }

            lblAddress.Text = GlobalVariables.CAddress1;
            lblBillDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["IdDate"]).ToString("dd-MM-yyyy");
            lblBillNo.Text = ds.Tables[0].Rows[0]["IdNo"].ToString();
            lblBillToAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            lblBillToGSTNo.Text = ds.Tables[0].Rows[0]["AccGSTNo"].ToString();
            lblBillToName.Text = ds.Tables[0].Rows[0]["AccName"].ToString();
            lblBillToPlaceofSupply.Text = ds.Tables[0].Rows[0]["GSTStateDesc"].ToString();
            lblBillToState.Text = ds.Tables[0].Rows[0]["GSTStateDesc"].ToString();
            lblBillToStateCode.Text = ds.Tables[0].Rows[0]["AccGSTStateCode"].ToString();
            lblCompanyName.Text = GlobalVariables.CompanyName;

            lblDispatchToAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            lblDispatchToGSTNo.Text = ds.Tables[0].Rows[0]["AccGSTNo"].ToString();
            lblDispatchToName.Text = ds.Tables[0].Rows[0]["AccName"].ToString();
            lblDispatchToState.Text = ds.Tables[0].Rows[0]["GSTStateDesc"].ToString();
            lblDispatchToStateCode.Text = ds.Tables[0].Rows[0]["AccGSTStateCode"].ToString();
            lblGSTNo.Text = GlobalVariables.CmpGSTNo;
            lblInvoiceAmount.Text = ds.Tables[0].Rows[0]["ImNetAmt"].ToString();
            lblTotalInvoiceAmount.Text = ds.Tables[0].Rows[0]["ImNetAmtRO"].ToString();
            xrInvType.Text = InvType;

            if (GlobalVariables.ProgCode == "PROG23")
            {
                lblTCSAmount.Text = ds.Tables[0].Rows[0]["ImTCSAmount"].ToString();

                lblEWayBillNo.Text = ds.Tables[0].Rows[0]["ImEWayBillNo"].ToString();

                if (ds.Tables[0].Rows[0]["ImEWayBillDate"].ToString().Trim() == string.Empty)
                {
                }
                else
                {

                    lblEWayBillDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["ImEWayBillDate"]).ToString("dd-MM-yyyy");
                }
            }


        }
    }
}
