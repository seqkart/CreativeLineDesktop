using System;
using System.Data;
using System.Linq;

namespace WindowsFormsApplication1
{
    public partial class frmShowRoomDashBoard : DevExpress.XtraEditors.XtraForm
    {
        public frmShowRoomDashBoard()
        {
            InitializeComponent();
        }

        private void FrmShowRoomDashBoard_Load(object sender, EventArgs e)
        {
            DataSet ds = ProjectFunctions.GetDataSet("sp_ShowRoomDashBoard");
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalQtyToday.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                lblTotalCashSaleToday.Text = ds.Tables[1].Rows[0][0].ToString();
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                lblTotalCardSaleToday.Text = ds.Tables[2].Rows[0][0].ToString();
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                lblTotalPGSaleToday.Text = ds.Tables[3].Rows[0][0].ToString();
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                lblTotalSaleToday.Text = ds.Tables[4].Rows[0][0].ToString();
            }


            //if (ds.Tables[5].Rows.Count > 0)
            //{
            //    lblTotalQtyToday.Text = ds.Tables[5].Rows[0][0].ToString();
            //}
            //if (ds.Tables[6].Rows.Count > 0)
            //{
            //    lblTotalCashSaleToday.Text = ds.Tables[6].Rows[0][0].ToString();
            //}
            //if (ds.Tables[7].Rows.Count > 0)
            //{
            //    lblTotalCardSaleToday.Text = ds.Tables[7].Rows[0][0].ToString();
            //}
            //if (ds.Tables[8].Rows.Count > 0)
            //{
            //    lblTotalPGSaleToday.Text = ds.Tables[8].Rows[0][0].ToString();
            //}
            //if (ds.Tables[9].Rows.Count > 0)
            //{
            //    lblTotalSaleToday.Text = ds.Tables[9].Rows[0][0].ToString();
            //}



            if (ds.Tables[5].Rows.Count > 0)
            {
                lblTotalQtyMonth.Text = ds.Tables[5].Rows[0][0].ToString();
            }
            if (ds.Tables[6].Rows.Count > 0)
            {
                lblTotalCashSaleMonth.Text = ds.Tables[6].Rows[0][0].ToString();
            }
            if (ds.Tables[7].Rows.Count > 0)
            {
                lblTotalCardSaleMonth.Text = ds.Tables[7].Rows[0][0].ToString();
            }
            if (ds.Tables[8].Rows.Count > 0)
            {
                lblTotalPGSaleMonth.Text = ds.Tables[8].Rows[0][0].ToString();
            }
            if (ds.Tables[9].Rows.Count > 0)
            {
                lblTotalSaleMonth.Text = ds.Tables[9].Rows[0][0].ToString();
            }


            if (ds.Tables[10].Rows.Count > 0)
            {
                lblTotalQtyYear.Text = ds.Tables[10].Rows[0][0].ToString();
            }
            if (ds.Tables[11].Rows.Count > 0)
            {
                lblTotalCashSaleYear.Text = ds.Tables[11].Rows[0][0].ToString();
            }
            if (ds.Tables[12].Rows.Count > 0)
            {
                lblTotalCardSaleYear.Text = ds.Tables[12].Rows[0][0].ToString();
            }
            if (ds.Tables[13].Rows.Count > 0)
            {
                lblTotalPGSaleYear.Text = ds.Tables[13].Rows[0][0].ToString();
            }
            if (ds.Tables[14].Rows.Count > 0)
            {
                lblTotalSaleYear.Text = ds.Tables[14].Rows[0][0].ToString();
            }

        }
    }
}