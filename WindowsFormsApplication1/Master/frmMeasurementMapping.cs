using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace WindowsFormsApplication1.Master
{

    public partial class frmMeasurementMapping : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String MCode { get; set; }
        public frmMeasurementMapping()
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
            txtMCode.Properties.MaxLength = 4;
            txtMDesc.Properties.MaxLength = 50;

            txtMCode.Enabled = false;

        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool ValidateData()
        {
            if (txtMDesc.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Measurement Desc");
                txtMDesc.Focus();
                return false;
            }


            return true;
        }

        //private void LoadMeasurementData()
        //{
        //    DataSet ds = ProjectFunctions.GetDataSet("sp_LoadMeasurementSizeMap");
        //    if(ds.Tables[0].Rows.Count>0)
        //    {
        //        HelpGrid.DataSource = ds.Tables[0];
        //        HelpGridView.BestFitColumns();
        //    }
        //    else
        //    {
        //        HelpGrid.DataSource = null;
        //    }
        //}
        private void frmMeasurementMapping_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtMDesc.Focus();

            }
            if (s1 == "Edit")
            {
                txtMCode.Enabled = false;
                DataSet ds = ProjectFunctions.GetDataSet("sp_LoadMeasurementsEdit '" + MCode + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtMCode.Text = ds.Tables[0].Rows[0]["MCode"].ToString();
                    txtMDesc.Text = ds.Tables[0].Rows[0]["MDesc"].ToString();
                }
            }
        }
        private string getNewNo()
        {
            var s2 = string.Empty;
            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(MCode as int)),0000) from Measurements");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString().Trim();
                s2 = (Convert.ToInt32(s2) + 1).ToString().Trim();
            }
            return s2;
        }
        private void btnSave_Click(object sender, EventArgs e)
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
                            sqlcom.CommandText = " Insert into Measurements"
                                                 + " (MCode, MDesc)"
                                                 + " values(@MCode, @MDesc)";
                            txtMCode.Text = getNewNo().PadLeft(4, '0');
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE Measurements SET "
                                                + " MCode=@MCode,MDesc=@MDesc "
                                                + " Where MCode=@MCode";
                        }
                        sqlcom.Parameters.AddWithValue("@MCode", txtMCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@MDesc", txtMDesc.Text.Trim());
                        sqlcom.ExecuteNonQuery();
                        //ProjectFunctions.GetDataSet("Delete from Measurements Where MCode='" + txtMCode.Text + "'");
                        //foreach (DataRow dr in (HelpGrid.DataSource as DataTable).Rows)
                        //{
                        //    ProjectFunctions.GetDataSet("Insert into Measurements(MCode,SZSYSID,Measurement)values('" + txtMCode.Text + "','" + dr["SZSYSID"].ToString() + "','" + dr["Measurement"].ToString() + "')");
                        //}
                        sqlcon.Close();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        ProjectFunctions.SpeakError(ex.Message);
                    }
                }
            }
        }

        private void frmMeasurementMapping_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                System.Windows.Forms.SendKeys.Send("+{TAB}");
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}