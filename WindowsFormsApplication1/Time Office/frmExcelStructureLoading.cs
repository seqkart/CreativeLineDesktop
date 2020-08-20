using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApplication1.Forms_Master
{
    public partial class frmExcelStructureLoading : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dt = new DataTable();
        public frmExcelStructureLoading()
        {
            InitializeComponent();
            dt.Columns.Add("EmpPartyCode", typeof(String));
            dt.Columns.Add("AccName", typeof(String));
            dt.Columns.Add("UnitCode", typeof(String));
            dt.Columns.Add("UnitName", typeof(String));
            dt.Columns.Add("EmpCode", typeof(String));
            dt.Columns.Add("EmpName", typeof(String));
            dt.Columns.Add("EmpFHRelationTag", typeof(String));
            dt.Columns.Add("EmpFHName", typeof(String));
            dt.Columns.Add("EmpDeptCode", typeof(String));
            dt.Columns.Add("DeptDesc", typeof(String));
            dt.Columns.Add("EmpDesgCode", typeof(String));
            dt.Columns.Add("DesgDesc", typeof(String));
            dt.Columns.Add("EmpDOJ", typeof(DateTime));
            dt.Columns.Add("EmpDOB", typeof(DateTime));
            dt.Columns.Add("EmpPFno", typeof(String));
            dt.Columns.Add("EmpUANNo", typeof(String));
            dt.Columns.Add("EmpBasic", typeof(decimal));
            dt.Columns.Add("EmpHRA", typeof(decimal));
            dt.Columns.Add("EmpConv", typeof(decimal));
            dt.Columns.Add("EmpPET", typeof(decimal));
            dt.Columns.Add("EmpSplAlw", typeof(decimal));
            dt.Columns.Add("EmpTDS", typeof(decimal));
            dt.Columns.Add("EmpMscD1", typeof(decimal));
            dt.Columns.Add("EmpPanNo", typeof(String));
            dt.Columns.Add("EmpAdharCardNo", typeof(String));
            dt.Columns.Add("EmpBankIFSCode", typeof(String));
            dt.Columns.Add("EmpBankAcNo", typeof(String));

            dt.Columns.Add("EmpPFDTag", typeof(String));
            dt.Columns.Add("EmpFpfDTag", typeof(String));
            dt.Columns.Add("EmpESIDTag", typeof(String));

        }
        private string getNewDocumentNo()
        {
            var s2 = string.Empty;
            try
            {
                var strsql = string.Empty;
                var ds = new DataSet();
                strsql = strsql + ("select isnull(max(Cast(EmpCode as int)),00000) from EmpMst");
                ds = ProjectFunctions.GetDataSet(strsql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s2 = ds.Tables[0].Rows[0][0].ToString().Trim();
                    s2 = (Convert.ToInt32(s2) + 1).ToString().Trim();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            return s2;
        }
        private void SetMyControls()
        {
            // panelControl1.Location = new Point(ClientSize.Width / 2 - panelControl1.Size.Width / 2, ClientSize.Height / 2 - panelControl1.Size.Height / 2);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.DatePickerVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
            //ProjectFunctions.GroupCtrlVisualize(panelControl1);
            ProjectFunctions.XtraFormVisualize(this);
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmExcelDataLoading_Load(object sender, EventArgs e)
        {
            SetMyControls();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SFeedingGrid.DataSource = null;
            dt.Clear();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " .xlsx files(*.xlsx)|*.xlsx";
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            SFeedingGrid.Refresh();
            var xlConn = string.Empty;
            xlConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + openFileDialog1.FileName + ";Extended Properties=\"Excel 12.0;\";";
            using (var myCommand = new OleDbDataAdapter("SELECT EmpPartyCode,AccName,UnitCode,UnitName, EmpCode,EmpName,EmpFHRelationTag,EmpFHName,EmpDeptCode,DeptDesc,EmpDesgCode,DesgDesc,EmpDOJ,EmpPFno,EmpUANNo,EmpBasic,EmpHRA,EmpConv,EmpPET,EmpSplAlw,EmpTDS,EmpMscD1,EmpPanNo,EmpAdharCardNo,EmpBankIFSCode,EmpBankAcNo,EmpDOB,PFTAG,FPFTAG,ESITAG FROM[Sheet1$]", xlConn))
            {
                myCommand.Fill(dt);
                SFeedingGrid.DataSource = dt;
                SFeedingGridView.BestFitColumns();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var ds1 = new DataSet();
            var ds2 = new DataSet();
            var ds3 = new DataSet();
            var ds4 = new DataSet();
#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            var MaxRow = ((SFeedingGrid.KeyboardFocusView as GridView).RowCount);
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            for (var i = 0; i < MaxRow; i++)
            {
                var currentrow = SFeedingGridView.GetDataRow(i);
                var str1 = "Select DeptCode,DeptDesc from DeptMst where   DeptCode='" + currentrow["EmpDeptCode"].ToString().PadLeft(4, '0') + "'";
                ds1 = ProjectFunctions.GetDataSet(str1);
                var str2 = "Select DesgCode,DesgDesc from DesgMst where  DesgCode='" + currentrow["EmpDesgCode"].ToString().PadLeft(4, '0') + "'";
                ds2 = ProjectFunctions.GetDataSet(str2);



                var str3 = "Select UnitCode,UnitName from UnitMst where  UnitCode='" + currentrow["UnitCode"].ToString().PadLeft(4, '0') + "'";
                ds3 = ProjectFunctions.GetDataSet(str3);

                var str4 = "Select AccCode,AccName from ActMst where  AccCode='" + currentrow["EmpPartyCode"].ToString().PadLeft(4, '0') + "'";
                ds4 = ProjectFunctions.GetDataSet(str4);


                if (ds1.Tables[0].Rows.Count > 0)
                {
                    SFeedingGridView.SetRowCellValue(i, SFeedingGridView.Columns["DeptDesc"], ds1.Tables[0].Rows[0]["DeptDesc"].ToString());

                }
                else
                {
                    SFeedingGridView.SetRowCellValue(i, SFeedingGridView.Columns["EmpDeptCode"], "XXXXXXXXXXXXXXXXXXX");
                    SFeedingGridView.SetRowCellValue(i, SFeedingGridView.Columns["DeptDesc"], "XXXXXXXXXXXXXXXXXXX");
                    XtraMessageBox.Show("Invalid Dept ");
                }
                if (ds2.Tables[0].Rows.Count > 0)
                {

                    SFeedingGridView.SetRowCellValue(i, SFeedingGridView.Columns["DesgDesc"], ds2.Tables[0].Rows[0]["DesgDesc"].ToString());
                }
                else
                {
                    SFeedingGridView.SetRowCellValue(i, SFeedingGridView.Columns["EmpDesgCode"], "XXXXXXXXXXXXXX");
                    SFeedingGridView.SetRowCellValue(i, SFeedingGridView.Columns["DesgDesc"], "XXXXXXXXXXXXXX");
                    XtraMessageBox.Show("Invalid Designation ");
                }

                if (ds3.Tables[0].Rows.Count > 0)
                {

                    SFeedingGridView.SetRowCellValue(i, SFeedingGridView.Columns["UnitName"], ds3.Tables[0].Rows[0]["UnitName"].ToString());
                }
                else
                {
                    SFeedingGridView.SetRowCellValue(i, SFeedingGridView.Columns["UnitCode"], "XXXXXXXXXXXXXX");
                    SFeedingGridView.SetRowCellValue(i, SFeedingGridView.Columns["UnitName"], "XXXXXXXXXXXXXX");
                    XtraMessageBox.Show("Invalid Unit ");
                }

                if (ds4.Tables[0].Rows.Count > 0)
                {

                    SFeedingGridView.SetRowCellValue(i, SFeedingGridView.Columns["AccName"], ds4.Tables[0].Rows[0]["AccName"].ToString());
                }
                else
                {
                    SFeedingGridView.SetRowCellValue(i, SFeedingGridView.Columns["EmpPartyCode"], "XXXXXXXXXXXXXX");
                    SFeedingGridView.SetRowCellValue(i, SFeedingGridView.Columns["AccName"], "XXXXXXXXXXXXXX");
                    XtraMessageBox.Show("Invalid Unit ");
                }
            }
            SFeedingGridView.BestFitColumns();
        }

        private bool ValidateData()
        {
#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            var MaxRow = ((SFeedingGrid.KeyboardFocusView as GridView).RowCount);
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'

            for (var i = 0; i < MaxRow; i++)
            {
                var currentrow = SFeedingGridView.GetDataRow(i);
                //if (currentrow["AccName"].ToString().Contains("x") || currentrow["AccName"].ToString() == string.Empty)
                //{
                //    XtraMessageBox.Show("Invalid Party Name");
                //    return false;
                //}
                //if (currentrow["UnitName"].ToString().Contains("x") || currentrow["UnitName"].ToString() == string.Empty)
                //{
                //    XtraMessageBox.Show("Invalid Unit");
                //    return false;
                //}
                //if (currentrow["DeptDesc"].ToString().Contains("x") || currentrow["DeptDesc"].ToString() == string.Empty)
                //{
                //    XtraMessageBox.Show("Invalid Department");
                //    return false;
                //}
                //if (currentrow["DesgDesc"].ToString().Contains("x") || currentrow["DesgDesc"].ToString() == string.Empty)
                //{
                //    XtraMessageBox.Show("Invalid Designation");
                //    return false;
                //}
                //if (currentrow["EmpDOJ"].ToString() == string.Empty)
                //{
                //    XtraMessageBox.Show("Invalid Date Of Joining");
                //    return false;
                //}
                //if (currentrow["EmpDOB"].ToString() == string.Empty)
                //{
                //    XtraMessageBox.Show("Invalid Date Of Birth");
                //    return false;
                //}
                if (currentrow["EmpBasic"].ToString() == string.Empty)
                {
                    SFeedingGridView.SetRowCellValue(i, SFeedingGridView.Columns["EmpBasic"], "0");
                }
                if (currentrow["EmpHRA"].ToString() == string.Empty)
                {
                    SFeedingGridView.SetRowCellValue(i, SFeedingGridView.Columns["EmpHRA"], "0");
                }
                if (currentrow["EmpConv"].ToString() == string.Empty)
                {
                    SFeedingGridView.SetRowCellValue(i, SFeedingGridView.Columns["EmpConv"], "0");
                }
                if (currentrow["EmpPET"].ToString() == string.Empty)
                {
                    SFeedingGridView.SetRowCellValue(i, SFeedingGridView.Columns["EmpPET"], "0");
                }
                if (currentrow["EmpSplAlw"].ToString() == string.Empty)
                {
                    SFeedingGridView.SetRowCellValue(i, SFeedingGridView.Columns["EmpSplAlw"], "0");
                }
                if (currentrow["EmpTDS"].ToString() == string.Empty)
                {
                    SFeedingGridView.SetRowCellValue(i, SFeedingGridView.Columns["EmpTDS"], "0");
                }
                if (currentrow["EmpMscD1"].ToString() == string.Empty)
                {
                    SFeedingGridView.SetRowCellValue(i, SFeedingGridView.Columns["EmpMscD1"], "0");
                }
                //if (currentrow["EmpAdharCardNo"].ToString() == string.Empty)
                //{
                //    XtraMessageBox.Show("Invalid Aadhar Card No");
                //    return false;
                //}
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
                var MaxRow = ((SFeedingGrid.KeyboardFocusView as GridView).RowCount);
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
                if (ValidateData())
                {
                    using (var con = new SqlConnection(ProjectFunctions.ConnectionString))
                    {
                        con.Open();
                        var cmd = new SqlCommand
                        {
                            Connection = con
                        };

                        for (var i = 0; i < MaxRow; i++)
                        {
                            var doc = getNewDocumentNo().PadLeft(5, '0');
                            var currentrow = SFeedingGridView.GetDataRow(i);
                            cmd.CommandType = CommandType.Text;
                            //cmd.CommandText = "Insert into EmpMst(EmpPartyCode, EmpDOB,EmpCode,EmpName,EmpFHRelationTag,EmpFHName,EmpDeptCode,EmpDesgCode,EmpDOJ,EmpPFno,EmpUANNo,EmpBasic,EmpHRA,EmpConv,EmpPET,EmpSplAlw,EmpTDS,EmpMscD1,EmpPanNo,EmpAdharCardNo,EmpBankIFSCode,EmpBankAcNo,UnitCode)values(@EmpPartyCode,@EmpDOB,@EmpCode,@EmpName,@EmpFHRelationTag,@EmpFHName,@EmpDeptCode,@EmpDesgCode,@EmpDOJ,@EmpPFno,@EmpUANNo,@EmpBasic,@EmpHRA,@EmpConv,@EmpPET,@EmpSplAlw,@EmpTDS,@EmpMscD1,@EmpPanNo,@EmpAdharCardNo,@EmpBankIFSCode,@EmpBankAcNo,@UnitCode)";
                            cmd.CommandText = "Insert into EmpMst( EmpDOB,EmpCode,EmpName,EmpFHRelationTag,EmpFHName,EmpDeptCode,EmpDesgCode,EmpDOJ,EmpPFno,EmpUANNo,EmpBasic,EmpHRA,EmpConv,EmpPET,EmpSplAlw,EmpTDS,EmpMscD1,EmpPanNo,EmpAdharCardNo,EmpBankIFSCode,EmpBankAcNo,UnitCode,EmpPFDTag,EmpFpfDTag,EmpESIDTag)values(@EmpDOB,@EmpCode,@EmpName,@EmpFHRelationTag,@EmpFHName,@EmpDeptCode,@EmpDesgCode,@EmpDOJ,@EmpPFno,@EmpUANNo,@EmpBasic,@EmpHRA,@EmpConv,@EmpPET,@EmpSplAlw,@EmpTDS,@EmpMscD1,@EmpPanNo,@EmpAdharCardNo,@EmpBankIFSCode,@EmpBankAcNo,@UnitCode,@EmpPFDTag,@EmpFpfDTag,@EmpESIDTag)";
                            //cmd.Parameters.Add("@EmpPartyCode", SqlDbType.NVarChar).Value = currentrow["EmpPartyCode"].ToString();
                            cmd.Parameters.Add("@EmpDOB", SqlDbType.DateTime).Value = Convert.ToDateTime(currentrow["EmpDOB"]).ToString("yyyy-MM-dd");
                            cmd.Parameters.Add("@EmpCode", SqlDbType.NVarChar).Value = currentrow["EmpCode"].ToString().PadLeft(5, '0');
                            cmd.Parameters.Add("@EmpName", SqlDbType.NVarChar).Value = currentrow["EmpName"].ToString();
                            cmd.Parameters.Add("@EmpFHRelationTag", SqlDbType.NVarChar).Value = currentrow["EmpFHRelationTag"].ToString();
                            cmd.Parameters.Add("@EmpFHName", SqlDbType.NVarChar).Value = currentrow["EmpFHName"].ToString();
                            cmd.Parameters.Add("@EmpDeptCode", SqlDbType.NVarChar).Value = currentrow["EmpDeptCode"].ToString().PadLeft(4, '0');

                            cmd.Parameters.Add("@EmpDesgCode", SqlDbType.NVarChar).Value = currentrow["EmpDesgCode"].ToString().PadLeft(4, '0');
                            cmd.Parameters.Add("@EmpDOJ", SqlDbType.DateTime).Value = Convert.ToDateTime(currentrow["EmpDOJ"]).ToString("yyyy-MM-dd");
                            cmd.Parameters.Add("@EmpPFno", SqlDbType.NVarChar).Value = currentrow["EmpPFno"].ToString();
                            cmd.Parameters.Add("@EmpUANNo", SqlDbType.NVarChar).Value = currentrow["EmpUANNo"].ToString();
                            cmd.Parameters.Add("@EmpBasic", SqlDbType.NVarChar).Value = currentrow["EmpBasic"].ToString();
                            cmd.Parameters.Add("@EmpHRA", SqlDbType.NVarChar).Value = currentrow["EmpHRA"].ToString();
                            cmd.Parameters.Add("@EmpConv", SqlDbType.NVarChar).Value = currentrow["EmpConv"].ToString();
                            cmd.Parameters.Add("@EmpPET", SqlDbType.NVarChar).Value = currentrow["EmpPET"].ToString();
                            cmd.Parameters.Add("@EmpSplAlw", SqlDbType.NVarChar).Value = currentrow["EmpSplAlw"].ToString();
                            cmd.Parameters.Add("@EmpTDS", SqlDbType.NVarChar).Value = currentrow["EmpTDS"].ToString();
                            cmd.Parameters.Add("@EmpMscD1", SqlDbType.NVarChar).Value = currentrow["EmpMscD1"].ToString();
                            cmd.Parameters.Add("@EmpPanNo", SqlDbType.NVarChar).Value = currentrow["EmpPanNo"].ToString();
                            cmd.Parameters.Add("@EmpAdharCardNo", SqlDbType.NVarChar).Value = currentrow["EmpAdharCardNo"].ToString();
                            cmd.Parameters.Add("@EmpBankIFSCode", SqlDbType.NVarChar).Value = currentrow["EmpBankIFSCode"].ToString();
                            cmd.Parameters.Add("@EmpBankAcNo", SqlDbType.NVarChar).Value = currentrow["EmpBankAcNo"].ToString();
                            cmd.Parameters.Add("@UnitCode", SqlDbType.NVarChar).Value = currentrow["UnitCode"].ToString().PadLeft(4, '0');

                            cmd.Parameters.Add("@EmpPFDTag", SqlDbType.NVarChar).Value = currentrow["PFTAG"].ToString();
                            cmd.Parameters.Add("@EmpFpfDTag", SqlDbType.NVarChar).Value = currentrow["FPFTAG"].ToString();
                            cmd.Parameters.Add("@EmpESIDTag", SqlDbType.NVarChar).Value = currentrow["ESITAG"].ToString();
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                    }
                }
                SFeedingGrid.DataSource = null;
            }
            catch (Exception ex)

            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}
