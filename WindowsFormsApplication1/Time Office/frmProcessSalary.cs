using Dapper;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using SeqKartLibrary;
using SeqKartLibrary.HelperClass;
using SeqKartLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using WindowsFormsApplication1;

namespace BNPL.Forms_Transaction
{
    public partial class frmProcessSalary : DevExpress.XtraEditors.XtraForm
    {
        private string _Mnthyr;
        private bool flagExceed;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<GridView_Style_Model> gridView_Style_List = new List<GridView_Style_Model>();
        public frmProcessSalary()
        {
            InitializeComponent();
        }

        private void frmProcessSalary_Load(object sender, EventArgs e)
        {
            DtStartDate.EditValue = StartDate.Date;

            //gridView_Style_List = ProjectFunctionsUtils.GridView_Style("frmProcessSalary", "gridControl_SalaryProcess");

            SetMyControls();
            fillGrid();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void SetMyControls()
        {
            gridView_SalaryProcess.CustomColumnDisplayText += gridView_SalaryProcess_CustomColumnDisplayText;

            //panelControl1.Location = new Point(ClientSize.Width / 2 - panelControl1.Size.Width / 2, ClientSize.Height / 2 - panelControl1.Size.Height / 2);
            //ProjectFunctions.TextBoxVisualize(panelControl1);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            // ProjectFunctions.ButtonVisualize(panelControl1);
            //ProjectFunctions.GroupCtrlVisualize(panelControl1);
            ProjectFunctions.XtraFormVisualize(this);


            DtStartDate.EditValue = DateTime.Now;

            MainFormButtons.Roles(GlobalVariables.ProgCode, GlobalVariables.CurrentUser, btnAdd);
            
        }

        private void fillGrid()
        {
            //DECLARE @Salary_Month DATETIME = '2020-06-01 00:00:00';
            var str = "sp_Salary_Process '','" + ConvertTo.DateTimeVal(DtStartDate.EditValue).ToString("yyyy-MM-dd") + "', 1, 1";

            PrintLogWin.PrintLog(str);

            DataSet ds = ProjectFunctionsUtils.GetDataSet(str);
            if (ComparisonUtils.IsNotNull_DataSet(ds))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridControl_SalaryProcess.DataSource = ds.Tables[0];
                    gridView_SalaryProcess.BestFitColumns();
                }
            }
            else
            {

            }
            
            gridView_SalaryProcess.OptionsBehavior.Editable = true;

            foreach (DevExpress.XtraGrid.Columns.GridColumn Col in gridView_SalaryProcess.Columns)
            {
                if (Col.FieldName != "SalaryPaid")
                {
                    Col.OptionsColumn.AllowEdit = false;
                }
            }

            SetGridViewStyle();
        }

        private void SetGridViewStyle()
        {
            gridView_Style_List = ProjectFunctionsUtils.GridView_Style("frmProcessSalary", "gridControl_SalaryProcess");

            if (gridView_Style_List != null)
            {
                foreach (DevExpress.XtraGrid.Columns.GridColumn Col in gridView_SalaryProcess.Columns)
                {
                    try
                    {
                        if (gridView_Style_List.Exists(x => x.column_name.Equals(Col.FieldName)))
                        {
                            GridView_Style_Model item = gridView_Style_List.Single<GridView_Style_Model>(x => x.column_name.Equals(Col.FieldName));

                            bool colShow = true;
                            try
                            {
                                if (ComparisonUtils.IsNotEmpty(item.column_show))
                                {
                                    if (item.column_show == 0)
                                    {
                                        colShow = false;
                                        Col.Visible = false;
                                        //gridView_SalaryProcess.Columns[Col.FieldName].Visible = false;
                                    }
                                    else
                                    {
                                        colShow = true;
                                        Col.Visible = true;
                                        //gridView_SalaryProcess.Columns[Col.FieldName].Visible = true;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                PrintLogWin.PrintLog("SetGridViewStyle => Color => Exception => " + ex);
                            }
                            if (colShow)
                            {
                                try
                                {
                                    if (ComparisonUtils.IsNotEmpty(item.color_code))
                                    {
                                        string hex = item.color_code;
                                        Color color = System.Drawing.ColorTranslator.FromHtml(hex);
                                        Col.AppearanceCell.BackColor = color;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    PrintLogWin.PrintLog("SetGridViewStyle => Color => Exception => " + ex);
                                }
                                try
                                {
                                    if (ComparisonUtils.IsNotEmpty(item.font_style))
                                    {
                                        if (item.font_style.ToLower().Equals("bold"))
                                        {
                                            Col.AppearanceCell.FontStyleDelta = FontStyle.Bold;
                                        }
                                        if (item.font_style.ToLower().Equals("Italic"))
                                        {
                                            Col.AppearanceCell.FontStyleDelta = FontStyle.Italic;
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    PrintLogWin.PrintLog("SetGridViewStyle => FontStyle => Exception => " + ex);
                                }
                            }
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        PrintLogWin.PrintLog("SetGridViewStyle => Exception => " + ex);
                    }

                    //if (Col.FieldName == "SalaryPaid")
                    //{
                    //    string hex = "#FF0000";
                    //    Color color = System.Drawing.ColorTranslator.FromHtml(hex);

                    //    Col.AppearanceCell.BackColor = color;
                    //    Col.AppearanceCell.FontStyleDelta = FontStyle.Bold;

                    //}
                }
            }
            
        }
        
        private void gridView_SalaryProcess_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "OT_Time")
            {
                if (e.Value != DBNull.Value)
                {
                    //e.DisplayText = ConvertTo.MinutesToHours(e.Value) + " | " + e.Value;
                    e.DisplayText = ConvertTo.MinutesToHours(e.Value, EmptyReturn.DbNull) + "";
                }
            }
        }


        void gridView_SalaryProcess_KeyDown(object sender, KeyEventArgs e)
        {
            //PrintLogWin.PrintLog("===============");
            GridView view = sender as GridView;

            ColumnView detailView = (ColumnView)gridControl_SalaryProcess.FocusedView;

            string cellValue_EmpCode = (string)detailView.GetFocusedRowCellValue("EmpCode");

            if (view.FocusedColumn.FieldName == "SalaryCalculated")
            {
                if (e.KeyData == Keys.Enter)
                {
                                        
                }
            }


            //canShowEditor = e.KeyData == Keys.Enter;
        }

        private void btnProcessSalary_Click(object sender, EventArgs e)
        {
            DateTime salaryMonth = ConvertTo.DateTimeVal(DtStartDate.EditValue);
            if (XtraMessageBox.Show("Do you want to process Salary for month [ " + salaryMonth.ToString("MMMM yyyy") + " ]", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("EmpCode", typeof(string));
                    dt.Columns.Add("SalaryMonth", typeof(DateTime));
                    dt.Columns.Add("SalaryPaid", typeof(decimal));


                    for (int rowIndex = 0; rowIndex != gridView_SalaryProcess.RowCount; rowIndex++)
                    {
                        int intRow = gridView_SalaryProcess.GetVisibleRowHandle(rowIndex);
                        string strSalaryMonth = gridView_SalaryProcess.GetRowCellValue(intRow, "SalaryMonth").ToString();
                        string strEmpCode = gridView_SalaryProcess.GetRowCellValue(intRow, "EmpCode").ToString();
                        string strSalaryPaid = gridView_SalaryProcess.GetRowCellValue(intRow, "SalaryPaid").ToString();

                        PrintLogWin.PrintLog("strSalaryMonth => " + strSalaryMonth);
                        PrintLogWin.PrintLog("strEmpCode => " + strEmpCode);
                        PrintLogWin.PrintLog("strSalaryPaid => " + strSalaryPaid);
                        PrintLogWin.PrintLog("------------------------------");

                        if (strSalaryPaid != null)
                        {
                            if (!strSalaryPaid.Equals(""))
                            {
                                dt.Rows.Add(strEmpCode, ConvertTo.DateTimeVal(strSalaryMonth), ConvertTo.DecimalVal(strSalaryPaid));
                            }
                        }


                        //cn.Execute(@"Insert INTO #routineUpdatedRecords VALUES('" + strEmpCode + "', '" + strSalaryMonth + "', " + strSalaryPaid + ")");
                    }

                    PrintLogWin.PrintLog("*******************************" + "");

                    using (SqlConnection con = new SqlConnection(ProjectFunctionsUtils.ConnectionString))
                    {
                        con.Open();
                        using (SqlCommand com = new SqlCommand("sp_UpdateSalaryPaid", con))
                        {
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.AddWithValue("@TableParam", dt);
                            com.ExecuteNonQuery();

                            ProjectFunctions.SpeakError("Salary Has Been Processed");
                            fillGrid();
                        }

                    }
                }
                catch (Exception ex)
                {
                    PrintLogWin.PrintLog(ex);
                }
            }
            /*
            
            */
            
        }
        /*
        private void gridControl_SalaryProcess_ProcessGridKey(object sender, KeyEventArgs e)
        {

        }

        // Fires when no in-place editor is active
        private void gridView_SalaryProcess_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        // Fires when an in-place editor is active
        private void gridControl_SalaryProcess_EditorKeyPress(object sender, KeyPressEventArgs e)
        {

        }
        */
        private void fillGrid_OLD()
        {
            _Mnthyr = String.Format("{0}{1}", DtStartDate.Text.Substring(0, 2), DtStartDate.Text.Substring(DtStartDate.Text.Length - 2, 2));

            var ds = new DataSet();
            //var str = "SELECT DeptMst.DeptDesc,payFinal.EmpCode,EmpName,RTrim(EmpFHRelationTag) As 'F/H',empFHname As 'F/H Name', payFinal.EmpNetPaid,B.EmpPymtMode,payFinal.EmpLockTag As IsLock, Cast(0 As Bit) As Sel,payFinal.EmpSalLocTag as Locked from PayFinal INNER JOIN  DeptMst ON payFinal.EmpDeptCode = DeptMst.DeptCode inner join AtnData B on payfinal.EmpCode=B.EmpCode and B.MonthYear= '" + _Mnthyr + "'";
            //str = str + " where PayFinal.monthyear= '" + _Mnthyr + "'  Union select DeptMst.DeptDesc,EmpMst.EmpCode,EmpMst.EmpName,EmpFHRelationTag,EmpMst.empFHname, '' as EmpNetPaid,C.EmpPymtMode,";
            //str = str + "  '' as EmpLockTag, Cast(0 As Bit) As Sel,'' as Locked from empmst INNER JOIN  DeptMst ON EmpMst.EmpDeptCode = DeptMst.DeptCode  inner join AtnData C on EmpMst.EmpCode=C.EmpCode and C.MonthYear= '" + _Mnthyr + "' WHERE EmpMst.empcode NOT IN (SELECT empcode from PayFinal    where monthyear= '" + _Mnthyr + "' )  ";
            //str = str + " And EmpMst.empcode IN (SELECT empcode from AtnData    where monthyear='" + _Mnthyr + "' )  ";
            //str = str + "   and (empleft<>'Y' or empleft is null or EmpDOL>'" + Convert.ToDateTime(DtStartDate.EditValue).ToString("yyyy-MM-dd") + "')  ";
            //str = str + " order by PayFinal.EmpLockTag DESC ,PayFinal.empcode ";
            var str = "sp_LoadSalaryMstFProcess '" + _Mnthyr + "','" + Convert.ToDateTime(DtStartDate.EditValue).ToString("yyyy-MM-dd") + "'";

            PrintLogWin.PrintLog(str);


            ds = ProjectFunctions.GetDataSet(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                SalaryGrid.DataSource = ds.Tables[0];
                SalaryGridView.BestFitColumns();
            }
            SalaryGridView.OptionsBehavior.Editable = true;

            foreach (DevExpress.XtraGrid.Columns.GridColumn Col in SalaryGridView.Columns)
            {
                if (Col.FieldName != "Sel")
                {
                    Col.OptionsColumn.AllowEdit = false;
                }
            }
        }
               

        private void ChoiceSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (ChoiceSelect.Checked)
            {
                for (var i = 0; i < SalaryGridView.RowCount; i++)
                {
                    var rowHandle = SalaryGridView.GetVisibleRowHandle(i);
                    if (SalaryGridView.IsDataRow(rowHandle))
                    {
                        SalaryGridView.SetRowCellValue(rowHandle, SalaryGridView.Columns["Sel"], true);
                    }
                }
            }
            else
            {
                for (var i = 0; i < SalaryGridView.RowCount; i++)
                {
                    var rowHandle = SalaryGridView.GetVisibleRowHandle(i);
                    if (SalaryGridView.IsDataRow(rowHandle))
                    {
                        SalaryGridView.SetRowCellValue(rowHandle, SalaryGridView.Columns["Sel"], false);
                    }
                }
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            SplashScreenManager.Default.SetWaitFormDescription("Processing Salary");
            var tt = new DateTime(Convert.ToInt32(DtStartDate.Text.Substring(DtStartDate.Text.Length - 4, 4)), Convert.ToInt32(DtStartDate.Text.Substring(0, 2)), 20);
            var Dt = new DateTime((tt.Month + 1) > 12 ? tt.Year + 1 : tt.Year, (tt.Month + 1) > 12 ? 1 : tt.Month + 1, 20);
            if (DateTime.Now.Date > Dt.Date)
            {
                flagExceed = true;
            }
            SalaryGridView.CloseEditor();
            SalaryGridView.UpdateCurrentRow();
            try
            {
                if (btnAdd.Enabled)
                {
                    if (SalaryGrid.DataSource != null)
                    {
                        if (SalaryGridView.RowCount > 0)
                        {
                            if (!flagExceed)
                            {
                                Cursor saveCursor = Cursor.Current;
                                try
                                {
                                    int i = 0;
                                    Cursor.Current = Cursors.WaitCursor;
                                    DataRow[] Rows = (SalaryGrid.DataSource as DataTable).Select("Sel <> False");
                                    foreach (DataRow Dr in Rows)
                                    {
                                        i++;
                                        SplashScreenManager.Default.SetWaitFormDescription("Processing Salary " + i.ToString() + "/" + Rows.Count().ToString());
                                        if (Dr["Locked"].ToString().Trim() == "Y")
                                        {
                                        }
                                        else
                                        {
                                            DataSet dsCheckdays = ProjectFunctions.GetDataSet("Select EmpDW from atnData Where EmpCode='" + Dr["EmpCode"] + "' And MonthYear='" + _Mnthyr + "'");
                                            if (Convert.ToDecimal(dsCheckdays.Tables[0].Rows[0]["EmpDW"]) > 0)
                                            {
                                                int Year = Convert.ToInt32(Convert.ToDateTime(DtStartDate.Text).ToString("yyyy"));
                                                int Month = Convert.ToInt32(Convert.ToDateTime(DtStartDate.Text).ToString("MM"));
                                                int numberOfSundays = NumberOfParticularDaysInMonth(Year, Month, DayOfWeek.Sunday);

                                                ProjectFunctions.GetDataSet(String.Format("Sp_PayCalc '{0}','{1}','{2}'", Dr["EmpCode"], _Mnthyr, numberOfSundays));
                                            }
                                        }
                                    }
                                    SplashScreenManager.CloseForm();
                                }
                                finally
                                {
                                    Cursor.Current = saveCursor;
                                }
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("No Records to Process", "!Error");
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("No Datasource, Or Unable to fetch Data.", "!Error");
                    }
                }
                else
                {
                    XtraMessageBox.Show("You have No permission .", "!Error");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Unable to Process Data.\n" + ex.Message, "!Error");
            }
            fillGrid();
        }
        static int NumberOfParticularDaysInMonth(int year, int month, DayOfWeek dayOfWeek)
        {
            DateTime startDate = new DateTime(year, month, 1);
            int totalDays = startDate.AddMonths(1).Subtract(startDate).Days;

            int answer = Enumerable.Range(1, totalDays)
                .Select(item => new DateTime(year, month, item))
                .Where(date => date.DayOfWeek == dayOfWeek)
                .Count();

            return answer;
        }
        private void btnLock_Click(object sender, EventArgs e)
        {
            _Mnthyr = String.Format("{0}{1}", DtStartDate.Text.Substring(0, 2), DtStartDate.Text.Substring(DtStartDate.Text.Length - 2, 2));
#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            int MaxRow = ((SalaryGrid.KeyboardFocusView as GridView).RowCount);
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            for (int i = 0; i < MaxRow; i++)
            {
                DataRow currentrow = SalaryGridView.GetDataRow(i);
                if (currentrow["Sel"].ToString().ToUpper() == "TRUE")
                {
                    DataSet ds = ProjectFunctions.GetDataSet("Select * from PayFinal Where MonthYear='" + _Mnthyr + "' And EmpCode='" + currentrow["EmpCode"].ToString() + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["EmpSalLocTag"].ToString().Trim() == "Y")
                        {

                        }

                        else
                        {
                            ProjectFunctions.GetDataSet("update payfinal set  EmpSalLocTag = 'Y' , EmpSalLocDt='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "',EmpSalLocUser='" + GlobalVariables.CurrentUser + "' where empcode='" + currentrow["EmpCode"].ToString() + "' And monthyear='" + _Mnthyr + "' And EmpSalLocTag is null ");
                        }
                    }
                }
            }
            fillGrid();
        }

        
    }

}