using Dapper;
using DevExpress.Export.Xl;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using SeqKartLibrary;
using SeqKartLibrary.CrudTask;
using SeqKartLibrary.HelperClass;
using SeqKartLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApplication1.Prints;

namespace WindowsFormsApplication1.Forms_Transaction
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

        private void gridView_SalaryProcess_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.IsTotalSummary && (e.Item as GridSummaryItem).FieldName == "EmpSalary")
            {
                GridSummaryItem item = e.Item as GridSummaryItem;
                if (item.FieldName == "EmpSalary")
                {
                    //e.TotalValue = ConvertTo.MinutesToHours(view.Columns["EmpSalary"].SummaryText);
                }
            }


        }
        bool IsInvalidValue(object value)
        {
            return true;
        }
        private void gridView_SalaryProcess_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            if (IsInvalidValue(e.Info.Value))
            {
                int dx = e.Bounds.Height;
                Brush brush = e.Cache.GetGradientBrush(e.Bounds, Color.Wheat, Color.FloralWhite, LinearGradientMode.Vertical);
                Rectangle r = e.Bounds;
                //Draw a 3D border
                BorderPainter painter = BorderHelper.GetPainter(DevExpress.XtraEditors.Controls.BorderStyles.Style3D);
                AppearanceObject borderAppearance = new AppearanceObject(e.Appearance)
                {
                    BorderColor = Color.DarkGray
                };
                painter.DrawObject(new BorderObjectInfoArgs(e.Cache, borderAppearance, r));
                //Fill the inner region of the cell
                r.Inflate(-1, -1);
                e.Cache.FillRectangle(brush, r);
                //Draw a summary value
                r.Inflate(-2, 0);
                e.Appearance.DrawString(e.Cache, e.Info.DisplayText, r);
                //Prevent default drawing of the cell
                e.Handled = true;

                /*
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Near;
                Rectangle r = e.Bounds;
                r.Inflate(-2, 0);
                Font f = new System.Drawing.Font("Tahoma", 8.25f, FontStyle.Bold);

                e.Appearance.BackColor = Color.FromArgb(50, 255, 0, 0);
                e.Appearance.DrawString(e.Cache, e.Info.DisplayText, r, f, format);
                */
                /*
                e.Appearance.BackColor = Color.FromArgb(50, 255, 0, 0);
                e.Appearance.FillRectangle(e.Cache, e.Bounds);
                e.Info.AllowDrawBackground = false;
                */
            }
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
            /*
            EmpSalary

            Salary Earned
            OT Salar
            Deduction Salary
            Salary Generated
            Adance

            Loan
            Salary Calculated
            Salary Paid
            Balance
            Arrears
            */
        }

        private void gridControl_SalaryProcess_DoubleClick(object sender, EventArgs e)
        {
            /*
            //Sender is actually of type GridControl  
            GridControl gridControl = (GridControl)sender;

            //Get a reference to the GridView from the GridControl  
            GridView view = (gridControl.FocusedView) as GridView;

            var dr = view.GetFocusedDataRow();
            if (dr["EmpCode"] != null && dr["SalaryMonth"] != null)
            {
                EmployeeSalaryDetails report_employeeSalaryDetails = new EmployeeSalaryDetails();

                DynamicParameters param = new DynamicParameters();
                param.Add("@Emp_Code_Processing", dr["EmpCode"].ToString());
                param.Add("@Salary_Month", dr["SalaryMonth"].ToString());
                param.Add("@Deduct_Advance", 1);
                param.Add("@Deduct_Loan", 1);

                salaryBindingSource.DataSource = EmployeeData.GetEmployeeSalary("sp_Salary_Process", param);
                report_employeeSalaryDetails.DataSource = salaryBindingSource;

                ReportPrintTool tool = new ReportPrintTool(report_employeeSalaryDetails);
                tool.ShowPreview();
            }
            */
        }

        private void clearGrid()
        {
            gridControl_SalaryProcess.DataSource = null;
            gridView_SalaryProcess.Columns.Clear();
        }

        private void fillGrid()
        {
            clearGrid();

            //DECLARE @Salary_Month DATETIME = '2020-06-01 00:00:00';
            var str = "sp_Salary_Process '','" + ConvertTo.DateFormatDb(ConvertTo.DateTimeVal(DtStartDate.EditValue)) + "', 1, 1";

            PrintLogWin.PrintLog(str);

            DataSet ds = ProjectFunctionsUtils.GetDataSet(str);
            ds.Tables[0].Columns.Add(new DataColumn("Balance_1", typeof(Double)));
            ds.Tables[0].Columns.Add(new DataColumn("Arrears_1", typeof(Double)));
            ds.Tables[0].Columns.Add(new DataColumn("Loan_1", typeof(Double)));
            ds.Tables[0].Columns.Add(new DataColumn("SalaryCalculated_1", typeof(Double)));

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                ds.Tables[0].Rows[i]["Balance_1"] = ConvertTo.DoubleVal(ds.Tables[0].Rows[i]["Balance"]);
                ds.Tables[0].Rows[i]["Arrears_1"] = ds.Tables[0].Rows[i]["Arrears"];
                ds.Tables[0].Rows[i]["Loan_1"] = ds.Tables[0].Rows[i]["Loan"];
                ds.Tables[0].Rows[i]["SalaryCalculated_1"] = ds.Tables[0].Rows[i]["SalaryCalculated"];
            }

            if (ComparisonUtils.IsNotNull_DataSet(ds))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridControl_SalaryProcess.DataSource = ds.Tables[0];
                    gridView_SalaryProcess.BestFitColumns();

                    gridView_SalaryProcess.Columns["EmpSalary"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "EmpSalary", string.Empty);
                    gridView_SalaryProcess.Columns["SalaryEarned"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "SalaryEarned", string.Empty);
                    gridView_SalaryProcess.Columns["OT_Salary"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "OT_Salary", string.Empty);
                    gridView_SalaryProcess.Columns["DeductionSalary"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "DeductionSalary", string.Empty);
                    gridView_SalaryProcess.Columns["SalaryGenerateBasic"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "SalaryGenerateBasic", string.Empty);
                    gridView_SalaryProcess.Columns["AdvanceSalary"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "AdvanceSalary", string.Empty);
                    gridView_SalaryProcess.Columns["Loan"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Loan", string.Empty);
                    gridView_SalaryProcess.Columns["SalaryCalculated"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "SalaryCalculated", string.Empty);
                    gridView_SalaryProcess.Columns["SalaryPaid"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "SalaryPaid", string.Empty);
                    gridView_SalaryProcess.Columns["Balance"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Balance", string.Empty);
                    gridView_SalaryProcess.Columns["Arrears"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Arrears", string.Empty);
                    //gridView_SalaryProcess.Columns["EmpSalary"].Summary.Add(DevExpress.Data.SummaryItemType.Custom);

                    gridView_SalaryProcess.UpdateTotalSummary();
                }
            }
            else
            {

            }

            /////////////////////////////////////



            //////////////////////////////////////////////
            // Create an unbound column.
            /*
            GridColumn unbColumn = gridView_SalaryProcess.Columns.AddField("Arrears_1");
            unbColumn.VisibleIndex = gridView_SalaryProcess.Columns.Count;
            unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            // Disable editing.
            unbColumn.OptionsColumn.AllowEdit = false;
            // Specify format settings.
            unbColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            
            //Rupees Currency Sign

            //unbColumn.DisplayFormat.FormatString = "c";
            // Customize the appearance settings.
            unbColumn.AppearanceCell.BackColor = Color.LemonChiffon;
            */

            /*
            GridColumn unboundColumn = gridView_SalaryProcess.Columns.Add();
            unboundColumn.ShowUnboundExpressionMenu = true;
            unboundColumn.FieldName = "Arrears_1";
            unboundColumn.Name = "Arrears_1";
            unboundColumn.Caption = "Arrears_1";
            unboundColumn.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            unboundColumn.Visible = true;
            unboundColumn.VisibleIndex = gridView_SalaryProcess.VisibleColumns.Count;
            unboundColumn.AppearanceCell.BackColor = Color.LemonChiffon;
            */
            //////////////////////////////////////////////
            ///
            gridView_SalaryProcess.OptionsBehavior.Editable = true;

            foreach (DevExpress.XtraGrid.Columns.GridColumn Col in gridView_SalaryProcess.Columns)
            {
                if (Col.FieldName == "LoanIntsallment" || Col.FieldName == "SalaryPaid" || Col.FieldName == "Loan")
                {

                }
                else
                {
                    Col.OptionsColumn.AllowEdit = false;

                }
            }

            SetGridViewStyle();

            /*
            for (int rowHandle = 0; rowHandle < gridView_SalaryProcess.RowCount; rowHandle++)
            {
                //DevExpress.XtraGrid.Columns.GridColumn col = View.Columns.ColumnByFieldName("Price");
                foreach (GridColumn gc in gridView_SalaryProcess.Columns)
                {

                    //int _SalaryLocked = 0;
                    if (gc.FieldName == "SalaryLocked")
                    {
                        int _SalaryLocked = ConvertTo.IntVal(gridView_SalaryProcess.GetRowCellDisplayText(rowHandle, gc));

                        PrintLogWin.PrintLog("%%%%%%%%> SalaryLocked : " + _SalaryLocked);
                        //gridView_SalaryProcess.Columns["Arrears"].OptionsColumn
                        PrintLogWin.PrintLog("========> Loan : " + gridView_SalaryProcess.GetRowCellDisplayText(rowHandle, gridView_SalaryProcess.Columns["Loan"]));
                        PrintLogWin.PrintLog("========> SalaryPaid : " + gridView_SalaryProcess.GetRowCellDisplayText(rowHandle, gridView_SalaryProcess.Columns["SalaryPaid"]));

                        if(_SalaryLocked == 1)
                        {
                            string hex = "#ff0000";
                            Color color = System.Drawing.ColorTranslator.FromHtml(hex);
                            gc.AppearanceCell.BackColor = color;
                        }
                        else
                        {
                            //gc.AppearanceCell.BackColor = Color.Transparent;
                        }
                    }
                    

                }
                    
            }
            */

        }

        public static void CustomDrawCell(GridControl gridControl, GridView gridView)
        {
            // Handle this event to paint cells manually
            gridView.CustomDrawCell += (s, e) =>
            {
                if (e.Column.VisibleIndex != 2)
                {
                    return;
                }
                e.Cache.FillRectangle(Color.Salmon, e.Bounds);
                e.Appearance.DrawString(e.Cache, e.DisplayText, e.Bounds);
                e.Handled = true;
            };
        }

        private void gridView_SalaryProcess_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            bool _mark = ConvertTo.IntVal(view.GetRowCellValue(e.RowHandle, "SalaryLocked")) == 1 ? true : false; ;
            if (e.Column.FieldName == "SalaryLocked")
            {
                string hexBackColor = "#eb4d46";
                Color colorLoked_BackColor = System.Drawing.ColorTranslator.FromHtml(hexBackColor);

                string hexForeColor = "#ffffff";
                Color colorLoked_ForeColor = System.Drawing.ColorTranslator.FromHtml(hexForeColor);

                e.Appearance.BackColor = _mark ? colorLoked_BackColor : Color.Transparent;
                e.Appearance.ForeColor = _mark ? colorLoked_ForeColor : Color.Black;
                //e.Appearance.TextOptions.HAlignment = _mark ? HorzAlignment.Far : HorzAlignment.Near;
            }
            if (e.Column.FieldName == "OT_Time")
            {
                e.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            }
            if (e.Column.FieldName == "DeductionTime")
            {
                e.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            }
        }

        private void gridView_SalaryProcess_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            /*
            GridView View = sender as GridView;

            //string cellValue = View.GetRowCellValue(View.FocusedRowHandle, gridView_SalaryProcess.Columns["SalaryLocked"]).ToString();

            if (e.Column.FieldName == "SalaryLocked")
            {
                Color currentColor = View.Columns["SalaryPaid"].AppearanceCell.BackColor;
                //e.DefaultDraw();
                if (Convert.ToInt32(e.CellValue) == 1)
                {
                    string hex = "#eeeeee";
                    Color color = System.Drawing.ColorTranslator.FromHtml(hex);
                    View.Columns["SalaryPaid"].AppearanceCell.BackColor = color;
                    View.Columns["Loan"].AppearanceCell.BackColor = color;

                    //DataRow dr = View.GetDataRow(e.RowHandle);
                    //View.GetDataRow(e.RowHandle).Field("Loan",)
                    //dr["SalaryPaid"].
                    //string cellValue = View.GetRowCellValue(e.RowHandle, View.Columns["SalaryLocked"]).ToString();
                    
                    //e.Cache.DrawImage(warningImage, e.Bounds.Location);
                }
                else
                {
                    View.Columns["SalaryPaid"].AppearanceCell.BackColor = currentColor;
                }
            }
            */
        }

        private void gridView_SalaryProcess_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GridView View = sender as GridView;

            var focusRowView = (DataRowView)View.GetFocusedRow();

            string cellValue = View.GetRowCellValue(View.FocusedRowHandle, gridView_SalaryProcess.Columns["SalaryLocked"]).ToString();
            if (cellValue == "1")
            {

                //string hex = "#eeeeee";
                //Color color = System.Drawing.ColorTranslator.FromHtml(hex);
                //View.Columns["SalaryPaid"].AppearanceCell.BackColor = color;
                //View.Columns["Loan"].AppearanceCell.BackColor = color;

                e.Cancel = true;
            }
        }

        /*
        // Returns the total amount for a specific row.
        private object getTotalValue(int listSourceRowIndex)
        {
            DataRow row = gridView_SalaryProcess.GetDataRow(listSourceRowIndex);// nwindDataSet.Tables["Order Details"].Rows[listSourceRowIndex];
            //decimal unitPrice = ConvertTo.DecimalVal(row["UnitPrice"]);
            //decimal quantity = ConvertTo.DecimalVal(row["Quantity"]);
            //decimal arrears = ConvertTo.DecimalVal(row["Arrears"]);
            return row["Arrears"];
        }
        private void gridView_SalaryProcess_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "Arrears_1" && e.IsGetData)
            {
                e.Value = ConvertTo.DecimalVal(getTotalValue(e.ListSourceRowIndex));
            }
        }
        */
        private void gridView_SalaryProcess_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {

        }

        private void SetGridViewStyle()
        {
            gridView_Style_List = ProjectFunctionsUtils.GridView_Style("frmProcessSalary", "gridControl_SalaryProcess");

            if (gridView_Style_List != null)
            {
                int rowIndex = 0;
                foreach (GridColumn Col in gridView_SalaryProcess.Columns)
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
                    if (Col.FieldName == "SalaryLocked")
                    {
                        //e.DefaultDraw();

                    }
                    rowIndex++;
                }
            }

        }
        private void gridView_SalaryProcess_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;

            var focusRowView = (DataRowView)view.GetFocusedRow();

            if (view.FocusedColumn.FieldName == "SalaryPaid")
            {
                int salary_locked = ConvertTo.IntVal(focusRowView["SalaryLocked"]);

                if (salary_locked == 0)
                {
                    //decimal balance_old = ConvertTo.DecimalVal(focusRowView["Balance_1"]);
                    //decimal arrears_old = ConvertTo.DecimalVal(focusRowView["Arrears_1"]);
                    decimal salary_paying = ConvertTo.DecimalVal(e.Value);

                    decimal salary_calculated = ConvertTo.DecimalVal(focusRowView["SalaryCalculated"]);

                    decimal salary_calculated_and_paying_difference = salary_calculated - salary_paying;
                    decimal balance_new = salary_calculated_and_paying_difference;

                    //PrintLogWin.PrintLog("******* balance_old A " + balance_old);
                    PrintLogWin.PrintLog("******* balance_old B " + focusRowView["Balance"]);

                    PrintLogWin.PrintLog("******* salary_paying " + salary_paying);

                    PrintLogWin.PrintLog("******* salary_calculated " + salary_calculated);
                    PrintLogWin.PrintLog("******* salary_calculated_and_paying_difference " + salary_calculated_and_paying_difference);
                    PrintLogWin.PrintLog("******* balance_new " + balance_new);

                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Balance"], balance_new);
                }
                else
                {
                    //view.SetRowCellValue(view.FocusedRowHandle, view.Columns["SalaryPaid"], balance_new);
                }
            }

            if (view.FocusedColumn.FieldName == "Loan")
            {
                decimal salary_paid = ConvertTo.DecimalVal(focusRowView["SalaryPaid"]);

                decimal loan_old = ConvertTo.DecimalVal(focusRowView["Loan_1"]);
                decimal loan_paying = ConvertTo.DecimalVal(e.Value);

                decimal salary_calculated_1 = ConvertTo.DecimalVal(focusRowView["SalaryCalculated_1"]);

                decimal new_salary_calculated = (salary_calculated_1 + loan_old) - loan_paying;

                PrintLogWin.PrintLog("******* loan_old " + loan_old);
                PrintLogWin.PrintLog("******* loan_paying " + loan_paying);

                PrintLogWin.PrintLog("******* salary_calculated_1 " + salary_calculated_1);
                PrintLogWin.PrintLog("******* new_salary_calculated " + new_salary_calculated);

                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["SalaryCalculated"], new_salary_calculated);

                /////////////////////////////////////////////////////////////
                if (salary_paid > 0)
                {
                    //decimal balance_old = ConvertTo.DecimalVal(focusRowView["Balance_1"]);
                    //decimal arrears_old = ConvertTo.DecimalVal(focusRowView["Arrears_1"]);
                    decimal salary_paying = ConvertTo.DecimalVal(focusRowView["SalaryPaid"]);

                    decimal salary_calculated = ConvertTo.DecimalVal(focusRowView["SalaryCalculated"]);

                    decimal salary_calculated_and_paying_difference = salary_calculated - salary_paying;
                    decimal balance_new = salary_calculated_and_paying_difference;

                    //PrintLogWin.PrintLog("******* balance_old A " + balance_old);
                    PrintLogWin.PrintLog("******* balance_old B " + focusRowView["Balance"]);

                    PrintLogWin.PrintLog("******* salary_paying " + salary_paying);

                    PrintLogWin.PrintLog("******* salary_calculated " + salary_calculated);
                    PrintLogWin.PrintLog("******* salary_calculated_and_paying_difference " + salary_calculated_and_paying_difference);
                    PrintLogWin.PrintLog("******* balance_new " + balance_new);

                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Balance"], balance_new);
                }
                //if (view.FocusedColumn.FieldName == "SalaryLocked")
                //{
                //    int salary_locked = ConvertTo.IntVal(e.Value);
                //    if (salary_locked == 1)
                //    {
                //        //view.Columns["SalaryPaid"].ColumnEdit = false;
                //        view.Columns["SalaryPaid"].OptionsColumn.AllowEdit = false;
                //        view.Columns["Loan"].OptionsColumn.AllowEdit = false;


                //        bool valid = false;
                //        view.SetRowCellValue(view.FocusedRowHandle, view.Columns["SalaryPaid"], valid);
                //        e.Valid = valid;
                //    }
                //}


            }

        }

        private void gridView_SalaryProcess_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            /*
            var view = sender as GridView;
            var focusRowView = (DataRowView)gridView_SalaryProcess.GetFocusedRow();
            if (view == null)
            {
                return;
            }

            if (view.FocusedColumn.FieldName == "Loan")
            {

                decimal oldValue = ConvertTo.DecimalVal(focusRowView["Loan"]);
                decimal newValue = ConvertTo.DecimalVal(e.Value);

                decimal salary_calculated = ConvertTo.DecimalVal(gridView_SalaryProcess.GetRowCellValue(e.RowHandle, gridView_SalaryProcess.Columns["SalaryCalculated"]).ToString());

                decimal new_salary_calculated = (salary_calculated + oldValue) - newValue;

                PrintLogWin.PrintLog("******* oldValue " + oldValue);
                PrintLogWin.PrintLog("******* newValue " + newValue);

                PrintLogWin.PrintLog("******* salary_calculated " + salary_calculated);
                PrintLogWin.PrintLog("******* new_salary_calculated " + new_salary_calculated);

                gridView_SalaryProcess.SetRowCellValue(e.RowHandle, gridView_SalaryProcess.Columns["SalaryCalculated"], new_salary_calculated);
            }
            */
            /*
             * 
            if (view.FocusedColumn.FieldName == "SalaryPaid")
            {
                //gridView_SalaryProcess.CellValueChanging -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gridView_SalaryProcess_CellValueChanging);

                decimal arrears_old = ConvertTo.DecimalVal(focusRowView["Arrears"]);
                decimal salary_paying = ConvertTo.DecimalVal(e.Value);

                decimal salary_calculated = ConvertTo.DecimalVal(gridView_SalaryProcess.GetRowCellValue(e.RowHandle, gridView_SalaryProcess.Columns["SalaryCalculated"]).ToString());
                //decimal arrears_old = ConvertTo.DecimalVal(gridView_SalaryProcess.GetRowCellValue(e.RowHandle, gridView_SalaryProcess.Columns["Arrears"]).ToString());

                decimal salary_calculated_and_paying_difference = salary_calculated - salary_paying;

                decimal arrears_new = arrears_old + salary_calculated_and_paying_difference;
                //

                //PrintLogWin.PrintLog("******* oldValue " + oldValue);
                PrintLogWin.PrintLog("******* salary_paying " + salary_paying);

                PrintLogWin.PrintLog("******* salary_calculated " + salary_calculated);
                PrintLogWin.PrintLog("******* salary_calculated_and_paying_difference " + salary_calculated_and_paying_difference);
                PrintLogWin.PrintLog("******* arrears_new " + arrears_new);

                gridView_SalaryProcess.SetRowCellValue(e.RowHandle, gridView_SalaryProcess.Columns["Arrears"], arrears_new);

                //gridView_SalaryProcess.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gridView_SalaryProcess_CellValueChanging);
            }
            */
            //PrintLogWin.PrintLog("******* A1");
            //if (e.Column.FieldName == "Loan")
            //{
            //    gridView_SalaryProcess.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gridView_SalaryProcess_CellValueChanged);



            //    decimal salary_calculated = ConvertTo.DecimalVal(gridView_SalaryProcess.GetRowCellValue(e.RowHandle, gridView_SalaryProcess.Columns["SalaryCalculated"]).ToString());

            //    //gridView_SalaryProcess.SetRowCellValue(e.RowHandle, e.Column, salary_calculated - (decimal)(e.Value));
            //    gridView_SalaryProcess.SetRowCellValue(e.RowHandle, gridView_SalaryProcess.Columns["SalaryCalculated"], salary_calculated - (decimal)(e.Value));

            //    gridView_SalaryProcess.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gridView_SalaryProcess_CellValueChanged);
            //}
        }

        private void gridView_SalaryProcess_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {


            /*BandedGridView view = sender as BandedGridView;
            if (view == null)
            {
                return;
            }
            PrintLogWin.PrintLog("******* B1");

            if (e.Column.Caption != "Loan")
            {
                return;
            }
            PrintLogWin.PrintLog("******* C1");
            decimal cellValue = ConvertTo.DecimalVal(view.GetRowCellValue(e.RowHandle, view.Columns["SalaryPaid"])) - ConvertTo.DecimalVal(e.Value);// e.Value.ToString() + " " + ConvertTo.DecimalVal(view.GetRowCellValue(e.RowHandle, view.Columns["SalaryPaid"]));
            view.SetRowCellValue(e.RowHandle, view.Columns["SalaryPaid"], cellValue);

            PrintLogWin.PrintLog("******* D1");
            */
        }

        private void gridView_SalaryProcess_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "OT_Time")
            {
                if (e.Value != DBNull.Value)
                {
                    //e.DisplayText = ConvertTo.MinutesToHours(e.Value) + " | " + e.Value;
                    //e.DisplayText = ConvertTo.MinutesToHours(e.Value, EmptyReturn.DbNull) + "";
                    //e.Value = ConvertTo.MinutesToHours(e.Value, EmptyReturn.DbNull) + "";
                }
            }
            if (e.Column.FieldName == "DeductionTime")
            {
                if (e.Value != DBNull.Value)
                {
                    //e.DisplayText = ConvertTo.MinutesToHours(e.Value, EmptyReturn.DbNull) + "";
                }
            }
            if (e.Column.FieldName == "EmpSalary")
            {
                if (e.Value != DBNull.Value)
                {
                    if (ConvertTo.DecimalVal(e.Value) == 0)
                    {
                        e.DisplayText = "";
                    }
                    //e.DisplayText = ConvertTo.MinutesToHours(e.Value, EmptyReturn.DbNull) + "";
                }
            }
        }

        private void gridView_SalaryProcess_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                //string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Category"]);
                //if (category == "Beverages")
                //{
                //    e.Appearance.BackColor = Color.Salmon;
                //    e.Appearance.BackColor2 = Color.SeaShell;
                //    e.HighPriority = true;
                //}
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
        private void btnLock_Click(object sender, EventArgs e)
        {
            DateTime salaryMonth = ConvertTo.DateTimeVal(DtStartDate.EditValue);
            if (ProjectFunctions.SpeakConfirmation("Do you want to lock Salary for month [ " + salaryMonth.ToString("MMMM yyyy") + " ]", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                try
                {
                    DataTable dtProcessSalary = new DataTable();
                    dtProcessSalary.Columns.Add("EmpCode", typeof(string));
                    dtProcessSalary.Columns.Add("SalaryMonth", typeof(DateTime));
                    dtProcessSalary.Columns.Add("SalaryPaid", typeof(decimal));
                    dtProcessSalary.Columns.Add("LoanInstallment", typeof(decimal));
                    dtProcessSalary.Columns.Add("SalaryCalculated", typeof(decimal));


                    for (int rowIndex = 0; rowIndex != gridView_SalaryProcess.RowCount; rowIndex++)
                    {
                        int intRow = gridView_SalaryProcess.GetVisibleRowHandle(rowIndex);
                        string strSalaryMonth = gridView_SalaryProcess.GetRowCellValue(intRow, "SalaryMonth").ToString();
                        string strEmpCode = gridView_SalaryProcess.GetRowCellValue(intRow, "EmpCode").ToString();
                        string strSalaryPaid = gridView_SalaryProcess.GetRowCellValue(intRow, "SalaryPaid").ToString();
                        string strLoanInstallment = gridView_SalaryProcess.GetRowCellValue(intRow, "Loan").ToString();
                        string strSalaryCalculated = gridView_SalaryProcess.GetRowCellValue(intRow, "SalaryCalculated").ToString();


                        PrintLogWin.PrintLog("----- btnProcessSalary_Click => strSalaryMonth: " + strSalaryMonth);
                        PrintLogWin.PrintLog("----- btnProcessSalary_Click => strEmpCode: " + strEmpCode);

                        if (strSalaryPaid != null && strEmpCode.Equals("0030") && ConvertTo.DateTimeVal(strSalaryMonth).Month == 6)
                        //if (strSalaryPaid != null)
                        {
                            if (ConvertTo.DecimalVal(strSalaryPaid) > 0)
                            {
                                PrintLogWin.PrintLog("strSalaryMonth => " + strSalaryMonth);
                                PrintLogWin.PrintLog("strEmpCode => " + strEmpCode);
                                PrintLogWin.PrintLog("strSalaryPaid => " + strSalaryPaid);
                                PrintLogWin.PrintLog("strLoanInstallment => " + strLoanInstallment);
                                PrintLogWin.PrintLog("strSalaryCalculated => " + strSalaryCalculated);
                                PrintLogWin.PrintLog("------------------------------");

                                //dt.Rows.Add(strEmpCode, ConvertTo.DateTimeVal(strSalaryMonth), ConvertTo.DecimalVal(strSalaryPaid));
                                dtProcessSalary.Rows.Add(
                                strEmpCode,
                                ConvertTo.DateFormatDb(strSalaryMonth),
                                ConvertTo.DecimalVal(strSalaryPaid),
                                ConvertTo.DecimalVal(strLoanInstallment),
                                ConvertTo.DecimalVal(strSalaryCalculated)
                                );

                                PrintLogWin.PrintLog("***** btnProcessSalary_Click => strSalaryMonth: " + strSalaryMonth);
                                PrintLogWin.PrintLog("***** btnProcessSalary_Click => strEmpCode: " + strEmpCode);
                            }

                        }


                        //cn.Execute(@"Insert INTO #routineUpdatedRecords VALUES('" + strEmpCode + "', '" + strSalaryMonth + "', " + strSalaryPaid + ")");
                    }

                    PrintLogWin.PrintLog("*******************************" + "");

                    using (SqlConnection con = new SqlConnection(ProjectFunctionsUtils.ConnectionString))
                    {
                        con.Open();
                        using (SqlCommand com = new SqlCommand("sp_LockSalaryPaid", con))
                        {
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.AddWithValue("@TableParam", dtProcessSalary);
                            com.ExecuteNonQuery();

                            ProjectFunctions.SpeakError("Salary Has Been Locked");
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

        private void btnProcessSalary_Click(object sender, EventArgs e)
        {
            DateTime salaryMonth = ConvertTo.DateTimeVal(DtStartDate.EditValue);
            if (ProjectFunctions.SpeakConfirmation("Do you want to process Salary for month [ " + salaryMonth.ToString("MMMM yyyy") + " ]", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                try
                {
                    DataTable dtProcessSalary = new DataTable();
                    dtProcessSalary.Columns.Add("EmpCode", typeof(string));
                    dtProcessSalary.Columns.Add("SalaryMonth", typeof(DateTime));
                    dtProcessSalary.Columns.Add("SalaryPaid", typeof(decimal));
                    dtProcessSalary.Columns.Add("LoanInstallment", typeof(decimal));
                    dtProcessSalary.Columns.Add("SalaryCalculated", typeof(decimal));


                    for (int rowIndex = 0; rowIndex != gridView_SalaryProcess.RowCount; rowIndex++)
                    {
                        int intRow = gridView_SalaryProcess.GetVisibleRowHandle(rowIndex);
                        string strSalaryMonth = gridView_SalaryProcess.GetRowCellValue(intRow, "SalaryMonth").ToString();
                        string strEmpCode = gridView_SalaryProcess.GetRowCellValue(intRow, "EmpCode").ToString();
                        string strSalaryPaid = gridView_SalaryProcess.GetRowCellValue(intRow, "SalaryPaid").ToString();
                        string strLoanInstallment = gridView_SalaryProcess.GetRowCellValue(intRow, "Loan").ToString();
                        string strSalaryCalculated = gridView_SalaryProcess.GetRowCellValue(intRow, "SalaryCalculated").ToString();

                        //PrintLogWin.PrintLog("strSalaryMonth => " + strSalaryMonth);
                        //PrintLogWin.PrintLog("strEmpCode => " + strEmpCode);
                        //PrintLogWin.PrintLog("strSalaryPaid => " + strSalaryPaid);
                        //PrintLogWin.PrintLog("strLoanInstallment => " + strLoanInstallment);
                        //PrintLogWin.PrintLog("strSalaryCalculated => " + strSalaryCalculated);
                        //PrintLogWin.PrintLog("------------------------------");

                        PrintLogWin.PrintLog("----- btnProcessSalary_Click => strSalaryMonth: " + strSalaryMonth);
                        PrintLogWin.PrintLog("----- btnProcessSalary_Click => strEmpCode: " + strEmpCode);

                        //if (strSalaryPaid != null && strEmpCode.Equals("0030") && ConvertTo.DateTimeVal(strSalaryMonth).Month == 6)
                        if (strSalaryPaid != null)
                        {
                            if (ConvertTo.DecimalVal(strSalaryPaid) > 0)
                            {
                                PrintLogWin.PrintLog("strSalaryMonth => " + strSalaryMonth);
                                PrintLogWin.PrintLog("strEmpCode => " + strEmpCode);
                                PrintLogWin.PrintLog("strSalaryPaid => " + strSalaryPaid);
                                PrintLogWin.PrintLog("strLoanInstallment => " + strLoanInstallment);
                                PrintLogWin.PrintLog("strSalaryCalculated => " + strSalaryCalculated);
                                PrintLogWin.PrintLog("------------------------------");

                                //dt.Rows.Add(strEmpCode, ConvertTo.DateTimeVal(strSalaryMonth), ConvertTo.DecimalVal(strSalaryPaid));
                                dtProcessSalary.Rows.Add(
                                strEmpCode,
                                ConvertTo.DateFormatDb(strSalaryMonth),
                                ConvertTo.DecimalVal(strSalaryPaid),
                                ConvertTo.DecimalVal(strLoanInstallment),
                                ConvertTo.DecimalVal(strSalaryCalculated)
                                );

                                PrintLogWin.PrintLog("***** btnProcessSalary_Click => strSalaryMonth: " + strSalaryMonth);
                                PrintLogWin.PrintLog("***** btnProcessSalary_Click => strEmpCode: " + strEmpCode);
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
                            com.Parameters.AddWithValue("@TableParam", dtProcessSalary);
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

                                                //ProjectFunctions.GetDataSet(String.Format("Sp_PayCalc '{0}','{1}','{2}'", Dr["EmpCode"], _Mnthyr, numberOfSundays));
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

        private void btnLock_Click_OLD(object sender, EventArgs e)
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

        private void Report_Print_Preview(string action)
        {
            //XtraReport_EmployeesSalaryList Xtra_report_employeesSalaryList = new XtraReport_EmployeesSalaryList();
            XtraReport_Salary Xtra_report_employeesSalaryList = new XtraReport_Salary();

            DynamicParameters param = new DynamicParameters();
            param.Add("@Emp_Code_Processing", "");
            param.Add("@Salary_Month", DtStartDate.EditValue);
            param.Add("@Deduct_Advance", 1);
            param.Add("@Deduct_Loan", 1);

            //List<EmployeeSalary> EmployeesSalaryList = EmployeeData.GetEmployeesSalaryList("sp_Salary_Process", param);

            MonthlySalaryDetails_Model monthlySalaryDetails_Model = new MonthlySalaryDetails_Model
            {
                SalaryMonth = ConvertTo.DateTimeVal(DtStartDate.EditValue),
                EmployeesSalaryList = EmployeeData.GetEmployeesSalaryList("sp_Salary_Process", param)
            };


            //MessageBox.Show(EmployeesSalaryList.Count + "");

            //salaryBindingSource.DataSource = EmployeesSalaryList;
            salaryBindingSource.DataSource = monthlySalaryDetails_Model;

            Xtra_report_employeesSalaryList.DataSource = salaryBindingSource;


            ReportPrintTool tool = new ReportPrintTool(Xtra_report_employeesSalaryList);

            if (action.Equals("preview"))
            {
                tool.ShowRibbonPreviewDialog();
            }
            if (action.Equals("print"))
            {
                tool.PrintDialog();
            }

        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (ComparisonUtils.IsEmpty(DtStartDate.EditValue))
            {
                ProjectFunctions.SpeakError("Enter Salary Month");
                DtStartDate.Focus();
            }
            else
            {
                Report_Print_Preview("preview");
            }

        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            if (ComparisonUtils.IsEmpty(DtStartDate.EditValue))
            {
                ProjectFunctions.SpeakError("Enter Salary Month");
                DtStartDate.Focus();
            }
            else
            {
                Report_Print_Preview("print");
            }

        }

        private void btnExportXsls_Click(object sender, EventArgs e)
        {
            if (ComparisonUtils.IsEmpty(DtStartDate.EditValue))
            {
                ProjectFunctions.SpeakError("Enter Salary Month");
                DtStartDate.Focus();
            }
            else
            {
                string path = "Salary_For_Month_" + ConvertTo.DateFormatDb(DtStartDate.EditValue) + ".xlsx";
                //gridControl_SalaryProcess.ExportToXlsx(path);
                // Open the created XLSX file with the default application.
                //Process.Start(path);


                XlsxExportOptionsEx options = new XlsxExportOptionsEx();
                options.CustomizeCell += Options_CustomizeCell;
                gridControl_SalaryProcess.ExportToXlsx(path, options);
                Process.Start(path);
            }

        }

        private void Options_CustomizeCell(DevExpress.Export.CustomizeCellEventArgs e)
        {
            if (e.ColumnFieldName == "OT_Time")
            {
                //return;
                e.Formatting.NumberFormat = XlNumberFormat.General;
                e.Handled = true;

            }

            //or  
            //e.Formatting.NumberFormat = XlNumberFormat.Text;  

        }


    }

}