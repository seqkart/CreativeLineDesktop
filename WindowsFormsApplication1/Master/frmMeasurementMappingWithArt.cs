using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

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
                    DevExpress.XtraEditors.Controls.CheckedListBoxItem item = new DevExpress.XtraEditors.Controls.CheckedListBoxItem();
                    item.Description = dr["MCode"].ToString();
                    item.Value = dr["MDesc"].ToString();
                    item.CheckState = CheckState.Unchecked;
                    txtMeasurement.Properties.Items.Add(item);
                }
                if(dsData.Tables[0].Rows.Count>0)
                {

                }
                

            }
            DataSet dsSize = ProjectFunctions.GetDataSet("select SZSYSID,SZNAME from SIZEMAST");
            if (dsSize.Tables[0].Rows.Count > 0)
            {
                txtSize.Properties.Items.Clear();
                InfoGridView.Columns.Clear();
              
                DevExpress.XtraGrid.Columns.GridColumn FieldA = new DevExpress.XtraGrid.Columns.GridColumn();
                FieldA.Caption = "MCode";
                FieldA.FieldName = "MCode";
                FieldA.Visible = true;
                InfoGridView.Columns.Add(FieldA);
                DevExpress.XtraGrid.Columns.GridColumn FieldB = new DevExpress.XtraGrid.Columns.GridColumn();
                FieldB.Caption = "MDesc";
                FieldB.FieldName = "MDesc";
                FieldB.Visible = true;
                InfoGridView.Columns.Add(FieldB);

                foreach (DataRow dr in dsSize.Tables[0].Rows)
                {
                    DevExpress.XtraEditors.Controls.CheckedListBoxItem item = new DevExpress.XtraEditors.Controls.CheckedListBoxItem();
                    item.Description = dr["SZNAME"].ToString();
                    item.Value = dr["SZSYSID"].ToString();
                    item.CheckState = CheckState.Unchecked;
                    txtSize.Properties.Items.Add(item);

                    DevExpress.XtraGrid.Columns.GridColumn Field = new DevExpress.XtraGrid.Columns.GridColumn();
                    Field.Caption = dr["SZNAME"].ToString();
                    Field.FieldName = dr["SZSYSID"].ToString();
                    Field.Visible = false;
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
                if(col.Visible)
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
            if(dt.Rows.Count>0)
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