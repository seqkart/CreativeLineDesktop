using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Master
{
    public partial class frmMeasurementMappingWithArt : DevExpress.XtraEditors.XtraForm
    {
        public string s1 { get; set; }
        public frmMeasurementMappingWithArt()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtARTID_EditValueChanged(object sender, EventArgs e)
        {
            txtArtNo.Text = String.Empty;
            txtArtDesc.Text = String.Empty;
        }

        private void txtARTID_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForThreeBoxes("SELECT        ARTICLE.ARTSYSID, ARTICLE.ARTNO, GrpMst.GrpSubDesc FROM  ARTICLE INNER JOIN GrpMst ON ARTICLE.ARTSECTIONID = GrpMst.GrpCode AND ARTICLE.ARTSBSECTIONID = GrpMst.GrpSubCode", " Where  ARTNO", txtARTID, txtArtNo, txtArtDesc, txtARTID, HelpGrid, HelpGridView, e);
        }

        private void LoadSizeAndMeasurements()
        {
            DataSet dsData = ProjectFunctions.GetDataSet("Select * from MeasurementsMapping");
            DataSet dsLoadMeasurement = ProjectFunctions.GetDataSet("select MCode,MDesc from measurements");
            if (dsLoadMeasurement.Tables[0].Rows.Count > 0)
            {
                txtMeasurement.Properties.Items.Clear();

                foreach (DataRow dr in dsLoadMeasurement.Tables[0].Rows)
                {
                    DevExpress.XtraEditors.Controls.CheckedListBoxItem item = new DevExpress.XtraEditors.Controls.CheckedListBoxItem
                    {
                        Description = dr["MCode"].ToString(),
                        Value = dr["MDesc"].ToString(),
                        CheckState = CheckState.Unchecked
                    };
                    txtMeasurement.Properties.Items.Add(item);
                }
                if (dsData.Tables[0].Rows.Count > 0)
                {

                }


            }
            DataSet dsSize = ProjectFunctions.GetDataSet("select SZSYSID,SZNAME from SIZEMAST");
            if (dsSize.Tables[0].Rows.Count > 0)
            {
                txtSize.Properties.Items.Clear();
                InfoGridView.Columns.Clear();

                DevExpress.XtraGrid.Columns.GridColumn FieldA = new DevExpress.XtraGrid.Columns.GridColumn
                {
                    Caption = "MCode",
                    FieldName = "MCode",
                    Visible = true
                };
                InfoGridView.Columns.Add(FieldA);
                DevExpress.XtraGrid.Columns.GridColumn FieldB = new DevExpress.XtraGrid.Columns.GridColumn
                {
                    Caption = "MDesc",
                    FieldName = "MDesc",
                    Visible = true
                };
                InfoGridView.Columns.Add(FieldB);

                foreach (DataRow dr in dsSize.Tables[0].Rows)
                {
                    DevExpress.XtraEditors.Controls.CheckedListBoxItem item = new DevExpress.XtraEditors.Controls.CheckedListBoxItem
                    {
                        Description = dr["SZNAME"].ToString(),
                        Value = dr["SZSYSID"].ToString(),
                        CheckState = CheckState.Unchecked
                    };
                    txtSize.Properties.Items.Add(item);

                    DevExpress.XtraGrid.Columns.GridColumn Field = new DevExpress.XtraGrid.Columns.GridColumn
                    {
                        Caption = dr["SZNAME"].ToString(),
                        FieldName = dr["SZSYSID"].ToString(),
                        Visible = false
                    };
                    InfoGridView.Columns.Add(Field);
                }




            }
        }
        private void frmMeasurementMappingWithArt_Load(object sender, EventArgs e)
        {
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(this);
            LoadSizeAndMeasurements();
        }

        private void HelpGrid_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);
            if (HelpGrid.Text == "txtARTID")
            {
                txtARTID.Text = row["ARTSYSID"].ToString();
                txtArtNo.Text = row["ARTNO"].ToString();
                txtArtDesc.Text = row["GrpSubDesc"].ToString();
                HelpGrid.Visible = false;
                txtARTID.Focus();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in txtSize.Properties.Items)
            {
                if (item.CheckState == CheckState.Checked)
                {
                    foreach (DevExpress.XtraGrid.Columns.GridColumn col in InfoGridView.Columns)
                    {
                        if (item.Value.ToString().ToUpper() == col.FieldName.ToString().ToUpper())
                        {
                            col.Visible = true;
                            col.OptionsColumn.AllowEdit = true;
                        }
                    }
                }
            }

            DataTable dt = new DataTable();
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in InfoGridView.Columns)
            {
                if (col.Visible)
                {
                    dt.Columns.Add(col.FieldName, typeof(String));
                }
            }
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in txtMeasurement.Properties.Items)
            {
                if (item.CheckState == CheckState.Checked)
                {
                    DataRow dr = dt.NewRow();
                    dr["MCode"] = item.Value;
                    dr["MDesc"] = item.Description;
                    dt.Rows.Add(dr);

                }
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

        }
    }
}