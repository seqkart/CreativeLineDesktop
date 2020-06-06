using System;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApplication1.Transaction.Pos
{
    public partial class Schemesetup : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String SchemeID { get; set; }
        public Schemesetup()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.DatePickerVisualize(this);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
        }
        private void BtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool ValidateData()
        {
            if (txtSchemeName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Scheme Name");
                txtSchemeName.Focus();
                return false;
            }
            if (txtSchemeName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Scheme Name");
                txtSchemeName.Focus();
                return false;
            }

            return true;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                if (ValidateData())
                {
                    using (var sqlcon = new SqlConnection(ProjectFunctions.GetConnection()))
                    {
                        sqlcon.Open();
                        var sqlcom = sqlcon.CreateCommand();
                        sqlcom.Connection = sqlcon;
                        sqlcom.CommandType = CommandType.Text;
                        try
                        {
                            if (s1 == "&Add")
                            {

                                sqlcom.CommandText = " Insert into SchemeMst"
                                                        + " (SchmDate,SchmName,FromDate,EndDate)"
                                                        + " values(@SchmDate,@SchmName,@FromDate,@EndDate)";

                            }
                            if (s1 == "Edit")
                            {
                                sqlcom.CommandText = " UPDATE SchemeMst SET "
                                                    + " SchmDate=@SchmDate,SchmName=@SchmName,FromDate=@FromDate,EndDate=@EndDate"
                                                    + " Where SchmID=@SchmID";
                                sqlcom.Parameters.AddWithValue("@SchmID", txtSchmID.Text.Trim());

                                ProjectFunctions.GetDataSet("Delete from SchemeUnitMst Where SchmID ='" + txtSchmID.Text + "'");
                            }
                            sqlcom.Parameters.AddWithValue("@SchmDate", Convert.ToDateTime(txtSchmDate.Text).ToString("yyyy-MM-dd"));
                            sqlcom.Parameters.AddWithValue("@SchmName", txtSchemeName.Text.Trim());
                            sqlcom.Parameters.AddWithValue("@FromDate", Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd"));
                            sqlcom.Parameters.AddWithValue("@EndDate", Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd"));

                            sqlcom.ExecuteNonQuery();
                            sqlcon.Close();




                            foreach (DataRow dr in (LocGrid.DataSource as DataTable).Rows)
                            {
                                if (dr["Select"].ToString().ToUpper() == "TRUE")
                                {
                                    ProjectFunctions.GetDataSet("Insert into SchemeUnitMst(SchmID,LocID)values('" + txtSchmID.Text + "','" + dr["UNITID"].ToString() + "')");
                                }
                            }


                            ProjectFunctions.SpeakError("Data Saved Successfully");
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            ProjectFunctions.SpeakError("Something Wrong. \n I am going to Roll Back." + ex.Message);
                        }
                    }
                }
            }
        }

        private void Schemesetup_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtSchmDate.EditValue = DateTime.Now.ToString("dd-MM-yyyy");
                txtSchemeName.Focus();

                DataSet dsLoc = ProjectFunctions.GetDataSet("select UNITID,UNITNAME from UNITS ");
                if (dsLoc.Tables[0].Rows.Count > 0)
                {
                    dsLoc.Tables[0].Columns.Add("Select", typeof(bool));
                    foreach (DataRow dr in dsLoc.Tables[0].Rows)
                    {
                        dr["Select"] = false;
                    }
                    LocGrid.DataSource = dsLoc.Tables[0];
                    LocGridView.BestFitColumns();
                }

                DataSet dsSchemeNames = ProjectFunctions.GetDataSet("select distinct SchmName from SchemeMst");
                if (dsSchemeNames.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsSchemeNames.Tables[0].Rows)
                    {
                        cmbFlatSchemeName.Properties.Items.Add(dr["SchmName"].ToString());
                    }
                }
                if (dsSchemeNames.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsSchemeNames.Tables[0].Rows)
                    {
                        cmbPowerSchemeName.Properties.Items.Add(dr["SchmName"].ToString());
                    }
                }
            }
            if (s1 == "Edit")
            {

                DataSet ds = ProjectFunctions.GetDataSet("select * from SchemeMst where SchmID='" + SchemeID + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtSchmDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["SchmDate"]).ToString("dd-MM-yyyy");
                    txtSchemeName.Text = ds.Tables[0].Rows[0]["SchmName"].ToString();
                    txtSchmID.Text = ds.Tables[0].Rows[0]["SchmID"].ToString();
                    txtFromDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["FromDate"]).ToString("dd-MM-yyyy");
                    txtToDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["EndDate"]).ToString("dd-MM-yyyy");
                    txtSchemeName.Focus();


                    DataSet dsLoc = ProjectFunctions.GetDataSet("select UNITID,UNITNAME from UNITS ");
                    if (dsLoc.Tables[0].Rows.Count > 0)
                    {
                        dsLoc.Tables[0].Columns.Add("Select", typeof(bool));
                        foreach (DataRow dr in dsLoc.Tables[0].Rows)
                        {
                            DataSet dsInner = ProjectFunctions.GetDataSet("Select * from SchemeUnitMst where SchmID='" + SchemeID + "' And LocID='" + dr["UNITID"] + "'");
                            if (dsInner.Tables[0].Rows.Count > 0)
                            {
                                dr["Select"] = true;
                            }
                            else
                            {
                                dr["Select"] = false;

                            }

                        }
                        LocGrid.DataSource = dsLoc.Tables[0];
                        LocGridView.BestFitColumns();
                    }
                }
                txtSchemeName.Focus();
            }
        }

        private void LoadArticle()
        {
            gridView2.Columns.Clear();
            gridView3.Columns.Clear();
            gridView4.Columns.Clear();
            DataSet dsArticle = ProjectFunctions.GetDataSet("SELECT        ARTNO, ARTSYSID FROM   ARTICLE");
            if (dsArticle.Tables[0].Rows.Count > 0)
            {
                dsArticle.Tables[0].Columns.Add("Select", typeof(bool));
                foreach (DataRow dr in dsArticle.Tables[0].Rows)
                {
                    dr["Select"] = false;
                }
                FlatSchemeGrid.DataSource = dsArticle.Tables[0];
                PowerSchemeGrid.DataSource = dsArticle.Tables[0];
            }
        }
        private void LoadGroup()
        {
            gridView2.Columns.Clear();
            gridView3.Columns.Clear();
            gridView4.Columns.Clear();
            DataSet dsGroup = ProjectFunctions.GetDataSet("SELECT    Distinct GrpCode,GrpSubCode,GrpDesc,GrpSubDesc FROM   GrpMst where GrpSubCode is not null");
            if (dsGroup.Tables[0].Rows.Count > 0)
            {
                dsGroup.Tables[0].Columns.Add("Select", typeof(bool));
                foreach (DataRow dr in dsGroup.Tables[0].Rows)
                {
                    dr["Select"] = false;
                }
                FlatSchemeGrid.DataSource = dsGroup.Tables[0];
                PowerSchemeGrid.DataSource = dsGroup.Tables[0];
            }
        }
        private void LoadFilter()
        {
            gridView2.Columns.Clear();
            gridView3.Columns.Clear();
            gridView4.Columns.Clear();
            DataSet dsFilter = ProjectFunctions.GetDataSet("sp_LoadFilterData");
            if (dsFilter.Tables[0].Rows.Count > 0)
            {
                dsFilter.Tables[0].Columns.Add("Select", typeof(bool));
                foreach (DataRow dr in dsFilter.Tables[0].Rows)
                {
                    dr["Select"] = false;
                }
                FlatSchemeGrid.DataSource = dsFilter.Tables[0];
                PowerSchemeGrid.DataSource = dsFilter.Tables[0];
            }
        }

        private void LoadSKU()
        {
            gridView2.Columns.Clear();
            gridView3.Columns.Clear();
            gridView4.Columns.Clear();
            DataSet dsGroup = ProjectFunctions.GetDataSet("sp_LoadDataFromSFDet_F3");
            if (dsGroup.Tables[0].Rows.Count > 0)
            {
                dsGroup.Tables[0].Columns.Add("Select", typeof(bool));
                foreach (DataRow dr in dsGroup.Tables[0].Rows)
                {
                    dr["Select"] = false;
                }
                FlatSchemeGrid.DataSource = dsGroup.Tables[0];
                PowerSchemeGrid.DataSource = dsGroup.Tables[0];
            }
        }


        private void chFlatArticle_CheckedChanged(object sender, EventArgs e)
        {
            if (chFlatArticle.Checked)
            {
                chFlatGroup.Checked = false;
                chFlatSKU.Checked = false;
                chFlatFilter.Checked = false;
                LoadArticle();
            }
        }

        private void chFlatGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (chFlatGroup.Checked)
            {
                chFlatArticle.Checked = false;
                chFlatSKU.Checked = false;
                chFlatFilter.Checked = false;
                LoadGroup();
            }
        }

        private void chFlatSKU_CheckedChanged(object sender, EventArgs e)
        {
            if (chFlatSKU.Checked)
            {
                chFlatArticle.Checked = false;
                chFlatGroup.Checked = false;
                chFlatFilter.Checked = false;
                LoadSKU();
            }
        }

        private void chFlatFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (chFlatFilter.Checked)
            {
                chFlatArticle.Checked = false;
                chFlatGroup.Checked = false;
                chFlatSKU.Checked = false;
                LoadFilter();
            }
        }

        private void chPowerArticle_CheckedChanged(object sender, EventArgs e)
        {
            if (chPowerArticle.Checked)
            {
                chPowerFilter.Checked = false;
                chPowerGroup.Checked = false;
                chPowerSKU.Checked = false;
                LoadArticle();
            }
        }

        private void chPowerGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (chPowerGroup.Checked)
            {
                chPowerFilter.Checked = false;
                chPowerArticle.Checked = false;
                chPowerSKU.Checked = false;
                LoadGroup();
            }
        }

        private void chPowerSKU_CheckedChanged(object sender, EventArgs e)
        {
            if (chPowerSKU.Checked)
            {
                chPowerFilter.Checked = false;
                chPowerArticle.Checked = false;
                chPowerGroup.Checked = false;
                LoadSKU();
            }
        }

        private void chPowerFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (chPowerFilter.Checked)
            {
                chPowerSKU.Checked = false;
                chPowerArticle.Checked = false;
                chPowerGroup.Checked = false;
                LoadFilter();
            }
        }
    }
}