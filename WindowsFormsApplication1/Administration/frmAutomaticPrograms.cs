using System;
namespace WindowsFormsApplication1.Administration
{
    public partial class frmAutomaticPrograms : DevExpress.XtraEditors.XtraForm
    {
        public frmAutomaticPrograms()
        {
            InitializeComponent();
        }

        private void btnCreateAssemblies_Click(object sender, EventArgs e)
        {
            string[] lines = new string[25];
            lines[0] = "using System;";
            lines[1] = "using System.Collections.Generic;";
            lines[2] = "using System.ComponentModel;";
            lines[3] = "using System.Data;";
            lines[4] = "using System.Windows.Forms;";
            lines[5] = "using DevExpress.XtraEditors;";
            lines[6] = "using DevExpress.XtraGrid.Views.Grid;";
            lines[7] = "using System.Linq;";
            lines[8] = "using System.Data.OleDb;";
            lines[9] = "using System.Windows.Forms;";
            lines[10] = "using System.Drawing;";
            lines[11] = "using System.Text;";
            lines[12] = "using DevExpress.Data.PivotGrid;";

            lines[13] = "using DevExpress.Utils.Menu;";
            lines[14] = "using System.Threading.Tasks;";
            lines[15] = "using CrystalDecisions.Shared;";
            lines[16] = "using CrystalDecisions.CrystalReports.Engine;";
            lines[17] = "using System.Data.Sql;";
            lines[18] = "using System.Data.SqlClient;";
            lines[19] = "using System.Data.SqlTypes;";

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"c:\happy\happy.txt"))
            {
                foreach (string line in lines)
                {

                    file.WriteLine(line);
                }
            }
        }

        private void btnPrimaryKey_Click(object sender, EventArgs e)
        {
            string[] lines = new string[5];
            lines[0] = "public String s1 { get; set; }";
            lines[1] = "public String PrimaryKey { get; set; }";
            using (System.IO.StreamWriter file =
             System.IO.File.AppendText(@"c:\happy\happy.txt"))
            {
                foreach (string line in lines)
                {
                    file.WriteLine(line);
                }
            }
        }

        private void btnSetMyCotrolsFunction_Click(object sender, EventArgs e)
        {

            string[] lines = new string[20];
            lines[0] = "private void SetMyControls();";
            lines[1] = "{";
            lines[2] = "ProjectFunctions.TextBoxVisualize(this);";
            lines[3] = "ProjectFunctions.DatePickerVisualize(this);";
            lines[4] = "ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);";
            lines[5] = "ProjectFunctions.ButtonVisualize(this);";
            lines[6] = "ProjectFunctions.XtraFormVisualize(this);";
            lines[7] = "}";

            using (System.IO.StreamWriter file =
             System.IO.File.AppendText(@"c:\happy\happy.txt"))
            {
                foreach (string line in lines)
                {
                    file.WriteLine(line);
                }
            }
        }

        private void btnGetNewMasterDocNo_Click(object sender, EventArgs e)
        {

            string[] lines = new string[20];
            lines[0] = "private string GetNewDocNo()";
            lines[1] = "{";
            lines[2] = "String s2 = String.Empty;";


            lines[3] = "String s2 = String.Empty;";
            lines[4] = "if (ds.Tables[0].Rows.Count > 0)";
            lines[5] = "{";
            lines[6] = "s2 = ds.Tables[0].Rows[0][0].ToString();";
            lines[7] = "s2 = (Convert.ToInt32(s2) + 1).ToString();";
            lines[8] = "}";
            lines[9] = "return s2;";
            lines[10] = "}";

            using (System.IO.StreamWriter file =
             System.IO.File.AppendText(@"c:\happy\happy.txt"))
            {
                foreach (string line in lines)
                {
                    file.WriteLine(line);
                }
            }
        }
    }

}