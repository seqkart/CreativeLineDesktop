using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmSaleReportF2 : DevExpress.XtraEditors.XtraForm
    {
        public String WorkingTag { get; set; }
        DataTable dt = new DataTable();
        String HOTAG = String.Empty;
        public frmSaleReportF2()
        {
            InitializeComponent();
            dt.Columns.Add("Name", typeof(String));
            dt.Columns.Add("Amount", typeof(Decimal));

        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSaleReportF2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }



        private void HOSale()
        {
#pragma warning disable CS0219 // The variable 'i' is assigned but its value is never used
            int i = 0;
#pragma warning restore CS0219 // The variable 'i' is assigned but its value is never used


            dt.Clear();


            DataRow row1 = dt.NewRow();
            row1["Name"] = "CashAmount";
            row1["Amount"] = 0.00;
            dt.Rows.Add(row1);

            DataRow row2 = dt.NewRow();
            row2["Name"] = "CardAmount";
            row2["Amount"] = 0.00;
            dt.Rows.Add(row2);

            DataRow row3 = dt.NewRow();
            row3["Name"] = "PaymentGateAmount";
            row3["Amount"] = 0.00;

            dt.Rows.Add(row3);


            DataSet dsSale = ProjectFunctions.GetDataSet("sp_ShowRoomDashBoard '" + WorkingTag + "','" + GlobalVariables.CUnitID + "'");
            if (dsSale.Tables[0].Rows.Count > 0)
            {
                lblTotalSale.Text = Convert.ToDecimal(dsSale.Tables[2].Rows[0][0]).ToString("0.00");
                lblTotalSaleQty.Text = Convert.ToDecimal(dsSale.Tables[0].Rows[0][0]).ToString("0.00");
                lblNoOfBills.Text = Convert.ToDecimal(dsSale.Tables[1].Rows[0][0]).ToString("0.00");
                if ((Convert.ToDecimal(lblTotalSale.Text) > 0) && (Convert.ToDecimal(lblTotalSaleQty.Text) > 0))
                {
                    lblAverageBillSale.Text = (Convert.ToDecimal(lblTotalSale.Text) / Convert.ToDecimal(lblTotalSaleQty.Text)).ToString("0.00");
                }
                else
                {
                    lblAverageBillSale.Text = "0.00";
                }
                int j = 0;
                if (dsSale.Tables[3].Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (j == 0)
                        {
                            if (dr["Name"].ToString() == "CashAmount")
                            {
                                dr["Amount"] = Convert.ToDecimal(dsSale.Tables[3].Rows[0][0]);
                                j++;
                            }
                        }
                        if (j == 1)
                        {
                            if (dr["Name"].ToString() == "CardAmount")
                            {
                                dr["Amount"] = Convert.ToDecimal(dsSale.Tables[3].Rows[0][1]);
                                j++;
                            }
                        }
                        if (j == 2)
                        {
                            if (dr["Name"].ToString() == "PaymentGateAmount")
                            {
                                dr["Amount"] = Convert.ToDecimal(dsSale.Tables[3].Rows[0][2]);
                                j++;
                            }
                        }

                    }

                    InfoGrid.DataSource = dt;
                    InfoGridView.BestFitColumns();
                }
                else
                {
                    InfoGrid.DataSource = dt;
                    InfoGridView.BestFitColumns();

                }
            }
        }


        private void FrmSaleReportF2_Load(object sender, EventArgs e)
        {
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);

            DataSet dsCmp = ProjectFunctions.GetDataSet("select COMNAME from COMCONF ");
            if (dsCmp.Tables[0].Rows.Count > 0)
            {
                CmpGrid.DataSource = dsCmp.Tables[0];
                CmpGridView.BestFitColumns();
            }
            else
            {
                CmpGrid.DataSource = null;
                CmpGridView.BestFitColumns();
            }



            DataSet dsHOTag = ProjectFunctions.GetDataSet("Select ISNULL(HOTag,'N') as HOTag  from UNITS");
            if (dsHOTag.Tables[0].Rows.Count > 0)
            {
                HOTAG = dsHOTag.Tables[0].Rows[0][0].ToString();
            }

            if (HOTAG == "Y")
            {
                DataSet dsUnits = ProjectFunctions.GetDataSet("select UNITNAME,UNITID from units");
                if (dsUnits.Tables[0].Rows.Count > 0)
                {
                    dsUnits.Tables[0].Columns.Add("Select", typeof(bool));
                    foreach (DataRow dr in dsUnits.Tables[0].Rows)
                    {
                        dr["Select"] = true;
                    }
                    CmpUnitGrid.DataSource = dsUnits.Tables[0];
                    CmpUnitGridView.BestFitColumns();
                }
                else
                {
                    CmpUnitGrid.DataSource = null;
                    CmpUnitGridView.BestFitColumns();
                }

            }
            else
            {
                DataSet dsUnits = ProjectFunctions.GetDataSet("select UNITNAME,UNITID from units where UnitCode='" + Convert.ToInt32(GlobalVariables.CUnitID) + "'");
                if (dsUnits.Tables[0].Rows.Count > 0)
                {
                    dsUnits.Tables[0].Columns.Add("Select", typeof(bool));
                    foreach (DataRow dr in dsUnits.Tables[0].Rows)
                    {
                        dr["Select"] = true;
                    }
                    CmpUnitGrid.DataSource = dsUnits.Tables[0];
                    CmpUnitGridView.BestFitColumns();
                }
                else
                {
                    CmpUnitGrid.DataSource = null;
                    CmpUnitGridView.BestFitColumns();
                }
            }

            HOSale();
        }

        private void CmpUnitGridView_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            CmpUnitGridView.CloseEditor();
            CmpUnitGridView.UpdateCurrentRow();
            HOSale();
        }

        private void InfoGrid_Click(object sender, EventArgs e)
        {

        }

        private void Menu_ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}