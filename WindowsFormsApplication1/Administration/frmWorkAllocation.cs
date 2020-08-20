using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class frmWorkAllocation : XtraForm
    {
        public frmWorkAllocation()
        {
            InitializeComponent();
        }
        private void fillUserComboBox()
        {
            try
            {
                cmbSelectUser.DataSource = ProjectFunctions.GetDataSet("Select Distinct username from userMaster").Tables[0];
                cmbSelectUser.DisplayMember = "username";
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void fillGrid()
        {
            try
            {
                UserGridView.OptionsBehavior.Editable = true;
                DataSet ds = ProjectFunctions.GetDataSet("sp_LoadUserAllocatedWork '" + ProjectFunctions.SqlString(cmbSelectUser.Text) + "'");
                ds.Tables[0].Merge(ds.Tables[1]);
                ds.Tables[0].Columns.Add("SPLRIGHTS", typeof(bool));
                ds.Tables[0].Columns.Add("&Add", typeof(bool));
                ds.Tables[0].Columns.Add("EDIT", typeof(bool));
                ds.Tables[0].Columns.Add("DELETE", typeof(bool));
                ds.Tables[0].Columns.Add("SELECTFIELD", typeof(bool));
                ds.Tables[0].Columns.Add("MASTER", typeof(bool));
                ds.Tables[0].Columns.Add("TRANSACTION", typeof(bool));
                ds.Tables[0].Columns.Add("REPORT", typeof(bool));
                ds.Tables[0].Columns.Add("ADMIN", typeof(bool));
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dr["SPLRIGHTS"] = false;
                    dr["&Add"] = false;
                    dr["EDIT"] = false;
                    dr["DELETE"] = false;
                    dr["SELECTFIELD"] = false;
                    dr["MASTER"] = false;
                    dr["TRANSACTION"] = false;
                    dr["REPORT"] = false;
                    dr["ADMIN"] = false;
                }
                for (var j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    if (ds.Tables[0].Rows[j]["ProgAdd_F"].ToString() == "-1")
                    {
                        ds.Tables[0].Rows[j]["&Add"] = true;
                    }
                    else
                    {
                        ds.Tables[0].Rows[j]["&Add"] = false;
                    }
                    if (ds.Tables[0].Rows[j]["ProgUpd_F"].ToString() == "-1")
                    {
                        ds.Tables[0].Rows[j]["EDIT"] = true;
                    }
                    else
                    {
                        ds.Tables[0].Rows[j]["EDIT"] = false;
                    }
                    if (ds.Tables[0].Rows[j]["ProgDel_F"].ToString() == "-1")
                    {
                        ds.Tables[0].Rows[j]["DELETE"] = true;
                    }
                    else
                    {
                        ds.Tables[0].Rows[j]["DELETE"] = false;
                    }

                    if (ds.Tables[0].Rows[j]["MasterMenu"].ToString() == "-1")
                    {
                        ds.Tables[0].Rows[j]["MASTER"] = true;
                    }
                    else
                    {
                        ds.Tables[0].Rows[j]["MASTER"] = false;
                    }
                    if (ds.Tables[0].Rows[j]["TransactionsMenu"].ToString() == "-1")
                    {
                        ds.Tables[0].Rows[j]["TRANSACTION"] = true;
                    }
                    else
                    {
                        ds.Tables[0].Rows[j]["TRANSACTION"] = false;
                    }
                    if (ds.Tables[0].Rows[j]["AdministratorMenu"].ToString() == "-1")
                    {
                        ds.Tables[0].Rows[j]["ADMIN"] = true;
                    }
                    else
                    {
                        ds.Tables[0].Rows[j]["ADMIN"] = false;
                    }
                    if (ds.Tables[0].Rows[j]["ReportMenu"].ToString() == "-1")
                    {
                        ds.Tables[0].Rows[j]["REPORT"] = true;
                    }
                    else
                    {
                        ds.Tables[0].Rows[j]["REPORT"] = false;
                    }
                    if (ds.Tables[0].Rows[j]["SelectField"].ToString() == "-1")
                    {
                        ds.Tables[0].Rows[j]["SELECTFIELD"] = true;
                    }
                    else
                    {
                        ds.Tables[0].Rows[j]["SELECTFIELD"] = false;
                    }

                    if (ds.Tables[0].Rows[j]["ProgSpl_U"].ToString() == "-1")
                    {
                        ds.Tables[0].Rows[j]["SPLRIGHTS"] = true;
                    }
                    else
                    {
                        ds.Tables[0].Rows[j]["SPLRIGHTS"] = false;
                    }
                }
                ds.AcceptChanges();
                WorkAllocationGrid.DataSource = ds.Tables[0];
                UserGridView.BestFitColumns();
                UserGridView.Columns[0].BestFit();
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }
        private void SetMyControls()
        {
            try
            {
                panelControl1.Location = new Point(ClientSize.Width / 2 - panelControl1.Size.Width / 2, ClientSize.Height / 2 - panelControl1.Size.Height / 2);
                ProjectFunctions.TextBoxVisualize(this);
                ProjectFunctions.GirdViewVisualize(UserGridView);
                ProjectFunctions.DatePickerVisualize(this);
                ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
                ProjectFunctions.TextBoxVisualize(this);
                ProjectFunctions.ButtonVisualize(panelControl1);
                ProjectFunctions.GroupCtrlVisualize(panelControl1);
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }
        private void frmWorkAllocation_Load(object sender, EventArgs e)
        {
            try
            {
                SetMyControls();
                fillUserComboBox();
                OptionsGrid.Visible = false;
                btnSaveOpts.Enabled = false;
                btnCancle.Enabled = false;
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }
        private void cmbSelectUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillGrid();
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void UserGridView_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            try
            {
                UserGridView.GetDataRow(UserGridView.FocusedRowHandle);
                if (UserGridView.FocusedColumn.FieldName == "MASTER")
                {
                    if (Convert.ToBoolean(e.Value) == true)
                    {
                        UserGridView.SetRowCellValue(UserGridView.FocusedRowHandle, UserGridView.Columns["ADMIN"], false);
                        UserGridView.SetRowCellValue(UserGridView.FocusedRowHandle, UserGridView.Columns["REPORT"], false);
                        UserGridView.SetRowCellValue(UserGridView.FocusedRowHandle, UserGridView.Columns["TRANSACTION"], false);
                    }
                }
                if (UserGridView.FocusedColumn.FieldName == "TRANSACTION")
                {
                    if (Convert.ToBoolean(e.Value) == true)
                    {
                        UserGridView.SetRowCellValue(UserGridView.FocusedRowHandle, UserGridView.Columns["ADMIN"], false);
                        UserGridView.SetRowCellValue(UserGridView.FocusedRowHandle, UserGridView.Columns["REPORT"], false);
                        UserGridView.SetRowCellValue(UserGridView.FocusedRowHandle, UserGridView.Columns["MASTER"], false);
                    }
                }
                if (UserGridView.FocusedColumn.FieldName == "ADMIN")
                {
                    if (Convert.ToBoolean(e.Value) == true)
                    {
                        UserGridView.SetRowCellValue(UserGridView.FocusedRowHandle, UserGridView.Columns["MASTER"], false);
                        UserGridView.SetRowCellValue(UserGridView.FocusedRowHandle, UserGridView.Columns["REPORT"], false);
                        UserGridView.SetRowCellValue(UserGridView.FocusedRowHandle, UserGridView.Columns["TRANSACTION"], false);
                    }
                }
                if (UserGridView.FocusedColumn.FieldName == "REPORT")
                {
                    if (Convert.ToBoolean(e.Value) == true)
                    {
                        UserGridView.SetRowCellValue(UserGridView.FocusedRowHandle, UserGridView.Columns["MASTER"], false);
                        UserGridView.SetRowCellValue(UserGridView.FocusedRowHandle, UserGridView.Columns["ADMIN"], false);
                        UserGridView.SetRowCellValue(UserGridView.FocusedRowHandle, UserGridView.Columns["TRANSACTION"], false);
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                UserGridView.UpdateCurrentRow();
                UserGridView.CloseEditor();
                using (var con = new SqlConnection(ProjectFunctions.GetConnection()))
                {
                    con.Open();
                    var cmd = new SqlCommand
                    {
                        Connection = con
                    };
                    var Dt = (WorkAllocationGrid.DataSource as DataTable).GetChanges();

                    var MaxRow = Dt.Rows.Count;

                    for (var i = 0; i < MaxRow; i++)
                    {
                        var currentrow = Dt.Rows[i];
                        DataSet ds = ProjectFunctions.GetDataSet(" Select ProgCode From UserProgAccess Where UserName='" + ProjectFunctions.SqlString(cmbSelectUser.Text) + "'And  ProgCode='" + currentrow["ProgCode"].ToString() + "'");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "sp_UpdateUserWorkAllocation";
                        }
                        else
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "sp_InsertUserWorkAllocation";
                        }
                        cmd.Parameters.Add("@dUserName", SqlDbType.VarChar).Value = cmbSelectUser.Text;
                        cmd.Parameters.Add("@dProgCode", SqlDbType.VarChar).Value = currentrow["ProgCode"];
                        if (currentrow["&Add"].ToString() == "True")
                        {
                            cmd.Parameters.Add("@dProgAdd_F", SqlDbType.SmallInt).Value = -1;
                        }
                        else
                        {
                            cmd.Parameters.Add("@dProgAdd_F", SqlDbType.SmallInt).Value = 0;
                        }
                        if (currentrow["SELECTFIELD"].ToString() == "True")
                        {
                            cmd.Parameters.Add("@dSelectField", SqlDbType.SmallInt).Value = -1;
                        }
                        else
                        {
                            cmd.Parameters.Add("@dSelectField", SqlDbType.SmallInt).Value = 0;
                        }
                        if (currentrow["EDIT"].ToString() == "True")
                        {
                            cmd.Parameters.Add("@dProgUpd_F", SqlDbType.SmallInt).Value = -1;
                        }
                        else
                        {
                            cmd.Parameters.Add("@dProgUpd_F", SqlDbType.SmallInt).Value = 0;
                        }
                        if (currentrow["DELETE"].ToString() == "True")
                        {
                            cmd.Parameters.Add("@dProgDel_F", SqlDbType.SmallInt).Value = -1;
                        }
                        else
                        {
                            cmd.Parameters.Add("@dProgDel_F", SqlDbType.SmallInt).Value = 0;
                        }

                        if (currentrow["TRANSACTION"].ToString() == "True")
                        {
                            cmd.Parameters.Add("@dTransactionsMenu", SqlDbType.SmallInt).Value = -1;
                        }
                        else
                        {
                            cmd.Parameters.Add("@dTransactionsMenu", SqlDbType.SmallInt).Value = 0;
                        }
                        if (currentrow["MASTER"].ToString() == "True")
                        {
                            cmd.Parameters.Add("@dMasterMenu", SqlDbType.SmallInt).Value = -1;
                        }
                        else
                        {
                            cmd.Parameters.Add("@dMasterMenu", SqlDbType.SmallInt).Value = 0;
                        }
                        if (currentrow["ADMIN"].ToString() == "True")
                        {
                            cmd.Parameters.Add("@dAdministratorMenu", SqlDbType.SmallInt).Value = -1;
                        }
                        else
                        {

                            cmd.Parameters.Add("@dAdministratorMenu", SqlDbType.SmallInt).Value = 0;
                        }
                        if (currentrow["REPORT"].ToString() == "True")
                        {
                            cmd.Parameters.Add("@dReportMenu", SqlDbType.SmallInt).Value = -1;
                        }
                        else
                        {
                            cmd.Parameters.Add("@dReportMenu", SqlDbType.SmallInt).Value = 0;
                        }
                        if (currentrow["SPLRIGHTS"].ToString() == "True")
                        {
                            cmd.Parameters.Add("@dProgSpl_U", SqlDbType.SmallInt).Value = -1;
                        }
                        else
                        {
                            cmd.Parameters.Add("@dProgSpl_U", SqlDbType.SmallInt).Value = 0;
                        }
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    WorkAllocationGrid.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void UserGridView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                UserGridView.PostEditor();
                UserGridView.UpdateCurrentRow();
            }));
        }


        private void OptionsGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                OptionsGrid.Visible = false;
                WorkAllocationGrid.Focus();
                btnSaveOpts.Enabled = false;
                btnCancle.Enabled = false;
            }
        }

        private void WorkAllocationGrid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                btnCancle.Enabled = true;
                btnSaveOpts.Enabled = true;
                if (UserGridView.FocusedColumn.FieldName == "ProgCode" || UserGridView.FocusedColumn.FieldName == "ProgDesc")
                {
                    var row = UserGridView.GetDataRow(UserGridView.FocusedRowHandle);
                    DataSet ds = ProjectFunctions.GetDataSet("  [sp_LoadUserAlloactedPerForm] @NProgCode='" + row["ProgCode"].ToString() + "'");
                    ds.Tables[0].Merge(ds.Tables[1]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Tables[0].Columns.Add("SPLRIGHTS", typeof(bool));
                        ds.Tables[0].Columns.Add("&Add", typeof(bool));
                        ds.Tables[0].Columns.Add("EDIT", typeof(bool));
                        ds.Tables[0].Columns.Add("DELETE", typeof(bool));
                        ds.Tables[0].Columns.Add("SELECTFIELD", typeof(bool));
                        ds.Tables[0].Columns.Add("MASTER", typeof(bool));
                        ds.Tables[0].Columns.Add("TRANSACTION", typeof(bool));
                        ds.Tables[0].Columns.Add("REPORT", typeof(bool));
                        ds.Tables[0].Columns.Add("ADMIN", typeof(bool));
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            dr["SPLRIGHTS"] = false;
                            dr["&Add"] = false;
                            dr["EDIT"] = false;
                            dr["DELETE"] = false;
                            dr["SELECTFIELD"] = false;
                            dr["MASTER"] = false;
                            dr["TRANSACTION"] = false;
                            dr["REPORT"] = false;
                            dr["ADMIN"] = false;

                        }
                        for (var j = 0; j < ds.Tables[0].Rows.Count; j++)
                        {
                            if (ds.Tables[0].Rows[j]["ProgAdd_F"].ToString() == "-1")
                            {
                                ds.Tables[0].Rows[j]["&Add"] = true;
                            }
                            else
                            {
                                ds.Tables[0].Rows[j]["&Add"] = false;
                            }
                            if (ds.Tables[0].Rows[j]["ProgUpd_F"].ToString() == "-1")
                            {
                                ds.Tables[0].Rows[j]["EDIT"] = true;
                            }
                            else
                            {
                                ds.Tables[0].Rows[j]["EDIT"] = false;
                            }
                            if (ds.Tables[0].Rows[j]["ProgDel_F"].ToString() == "-1")
                            {
                                ds.Tables[0].Rows[j]["DELETE"] = true;
                            }
                            else
                            {
                                ds.Tables[0].Rows[j]["DELETE"] = false;
                            }

                            if (ds.Tables[0].Rows[j]["MasterMenu"].ToString() == "-1")
                            {
                                ds.Tables[0].Rows[j]["MASTER"] = true;
                            }
                            else
                            {
                                ds.Tables[0].Rows[j]["MASTER"] = false;
                            }
                            if (ds.Tables[0].Rows[j]["TransactionsMenu"].ToString() == "-1")
                            {
                                ds.Tables[0].Rows[j]["TRANSACTION"] = true;
                            }
                            else
                            {
                                ds.Tables[0].Rows[j]["TRANSACTION"] = false;
                            }
                            if (ds.Tables[0].Rows[j]["AdministratorMenu"].ToString() == "-1")
                            {
                                ds.Tables[0].Rows[j]["ADMIN"] = true;
                            }
                            else
                            {
                                ds.Tables[0].Rows[j]["ADMIN"] = false;
                            }
                            if (ds.Tables[0].Rows[j]["ReportMenu"].ToString() == "-1")
                            {
                                ds.Tables[0].Rows[j]["REPORT"] = true;
                            }
                            else
                            {
                                ds.Tables[0].Rows[j]["REPORT"] = false;
                            }
                            if (ds.Tables[0].Rows[j]["SelectField"].ToString() == "-1")
                            {
                                ds.Tables[0].Rows[j]["SELECTFIELD"] = true;
                            }
                            else
                            {
                                ds.Tables[0].Rows[j]["SELECTFIELD"] = false;
                            }

                            if (ds.Tables[0].Rows[j]["ProgSpl_U"].ToString() == "-1")
                            {
                                ds.Tables[0].Rows[j]["SPLRIGHTS"] = true;
                            }
                            else
                            {
                                ds.Tables[0].Rows[j]["SPLRIGHTS"] = false;
                            }
                        }
                    }
                    OptionsGrid.DataSource = ds.Tables[0];
                    OptionsGrid.Visible = true;
                    OptionsGrid.Focus();
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            OptionsGrid.Visible = false;
            OptionsGrid.DataSource = null;
            btnSaveOpts.Enabled = false;
            btnCancle.Enabled = false;
        }

        private void btnSaveOpts_Click(object sender, EventArgs e)
        {
            try
            {
                using (var con = new SqlConnection(ProjectFunctions.GetConnection()))
                {
                    OptionsGridView.UpdateCurrentRow();
                    OptionsGridView.CloseEditor();

                    con.Open();
                    var cmd = new SqlCommand
                    {
                        Connection = con
                    };
                    var Dt = (OptionsGrid.DataSource as DataTable).GetChanges();

                    var MaxRow = Dt.Rows.Count;
                    for (var i = 0; i < MaxRow; i++)
                    {
                        var currentrow = Dt.Rows[i];
                        DataSet ds = ProjectFunctions.GetDataSet("Select ProgCode From UserProgAccess Where UserName='" + currentrow["Username"].ToString() + "' And  ProgCode='" + currentrow["ProgCode"].ToString() + "'");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "sp_UpdateUserWorkAllocation";
                        }
                        else
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "sp_InsertUserWorkAllocation";
                        }
                        cmd.Parameters.Add("@dUserName", SqlDbType.VarChar).Value = currentrow["Username"];
                        cmd.Parameters.Add("@dProgCode", SqlDbType.VarChar).Value = currentrow["ProgCode"];
                        if (currentrow["&Add"].ToString() == "True")
                        {
                            cmd.Parameters.Add("@dProgAdd_F", SqlDbType.SmallInt).Value = -1;
                        }
                        else
                        {
                            cmd.Parameters.Add("@dProgAdd_F", SqlDbType.SmallInt).Value = 0;
                        }
                        if (currentrow["SELECTFIELD"].ToString() == "True")
                        {
                            cmd.Parameters.Add("@dSelectField", SqlDbType.SmallInt).Value = -1;
                        }
                        else
                        {
                            cmd.Parameters.Add("@dSelectField", SqlDbType.SmallInt).Value = 0;
                        }
                        if (currentrow["EDIT"].ToString() == "True")
                        {
                            cmd.Parameters.Add("@dProgUpd_F", SqlDbType.SmallInt).Value = -1;
                        }
                        else
                        {
                            cmd.Parameters.Add("@dProgUpd_F", SqlDbType.SmallInt).Value = 0;
                        }
                        if (currentrow["DELETE"].ToString() == "True")
                        {
                            cmd.Parameters.Add("@dProgDel_F", SqlDbType.SmallInt).Value = -1;
                        }
                        else
                        {
                            cmd.Parameters.Add("@dProgDel_F", SqlDbType.SmallInt).Value = 0;
                        }

                        if (currentrow["TRANSACTION"].ToString() == "True")
                        {
                            cmd.Parameters.Add("@dTransactionsMenu", SqlDbType.SmallInt).Value = -1;
                        }
                        else
                        {
                            cmd.Parameters.Add("@dTransactionsMenu", SqlDbType.SmallInt).Value = 0;
                        }
                        if (currentrow["MASTER"].ToString() == "True")
                        {
                            cmd.Parameters.Add("@dMasterMenu", SqlDbType.SmallInt).Value = -1;
                        }
                        else
                        {
                            cmd.Parameters.Add("@dMasterMenu", SqlDbType.SmallInt).Value = 0;
                        }
                        if (currentrow["ADMIN"].ToString() == "True")
                        {
                            cmd.Parameters.Add("@dAdministratorMenu", SqlDbType.SmallInt).Value = -1;
                        }
                        else
                        {
                            cmd.Parameters.Add("@dAdministratorMenu", SqlDbType.SmallInt).Value = 0;
                        }
                        if (currentrow["REPORT"].ToString() == "True")
                        {
                            cmd.Parameters.Add("@dReportMenu", SqlDbType.SmallInt).Value = -1;
                        }
                        else
                        {
                            cmd.Parameters.Add("@dReportMenu", SqlDbType.SmallInt).Value = 0;
                        }
                        if (currentrow["SPLRIGHTS"].ToString() == "True")
                        {
                            cmd.Parameters.Add("@dProgSpl_U", SqlDbType.SmallInt).Value = -1;
                        }
                        else
                        {
                            cmd.Parameters.Add("@dProgSpl_U", SqlDbType.SmallInt).Value = 0;
                        }
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    btnCancle_Click(null, e);
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void OptionsGridView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                var view = (GridView)sender;
                var row = view.GetDataRow(e.RowHandle);
                if (row.RowState != DataRowState.Unchanged)
                {
                    if (e.Column.UnboundType == DevExpress.Data.UnboundColumnType.Bound && row.HasVersion(DataRowVersion.Original))
                    {
                        if (!Equals(row[e.Column.FieldName, DataRowVersion.Current], row[e.Column.FieldName, DataRowVersion.Original]))
                        {
                            e.Appearance.BackColor = Color.Blue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void UserGridView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                var view = (GridView)sender;
                var row = view.GetDataRow(e.RowHandle);
                if (row.RowState != DataRowState.Unchanged)
                {
                    if (e.Column.UnboundType == DevExpress.Data.UnboundColumnType.Bound && row.HasVersion(DataRowVersion.Original))
                    {
                        if (!Equals(row[e.Column.FieldName, DataRowVersion.Current], row[e.Column.FieldName, DataRowVersion.Original]))
                        {
                            e.Appearance.BackColor = Color.Blue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void OptionsGridView_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            try
            {
                OptionsGridView.GetDataRow(OptionsGridView.FocusedRowHandle);
                if (OptionsGridView.FocusedColumn.FieldName == "MASTER")
                {
                    if (Convert.ToBoolean(e.Value) == true)
                    {
                        OptionsGridView.SetRowCellValue(OptionsGridView.FocusedRowHandle, OptionsGridView.Columns["ADMIN"], false);
                        OptionsGridView.SetRowCellValue(OptionsGridView.FocusedRowHandle, OptionsGridView.Columns["REPORT"], false);
                        OptionsGridView.SetRowCellValue(OptionsGridView.FocusedRowHandle, OptionsGridView.Columns["TRANSACTION"], false);
                    }
                }
                if (OptionsGridView.FocusedColumn.FieldName == "TRANSACTION")
                {
                    if (Convert.ToBoolean(e.Value) == true)
                    {
                        OptionsGridView.SetRowCellValue(OptionsGridView.FocusedRowHandle, OptionsGridView.Columns["ADMIN"], false);
                        OptionsGridView.SetRowCellValue(OptionsGridView.FocusedRowHandle, OptionsGridView.Columns["REPORT"], false);
                        OptionsGridView.SetRowCellValue(OptionsGridView.FocusedRowHandle, OptionsGridView.Columns["MASTER"], false);
                    }
                }
                if (OptionsGridView.FocusedColumn.FieldName == "ADMIN")
                {
                    if (Convert.ToBoolean(e.Value) == true)
                    {
                        OptionsGridView.SetRowCellValue(OptionsGridView.FocusedRowHandle, OptionsGridView.Columns["MASTER"], false);
                        OptionsGridView.SetRowCellValue(OptionsGridView.FocusedRowHandle, OptionsGridView.Columns["REPORT"], false);
                        OptionsGridView.SetRowCellValue(OptionsGridView.FocusedRowHandle, OptionsGridView.Columns["TRANSACTION"], false);
                    }
                }
                if (OptionsGridView.FocusedColumn.FieldName == "REPORT")
                {
                    if (Convert.ToBoolean(e.Value) == true)
                    {
                        OptionsGridView.SetRowCellValue(OptionsGridView.FocusedRowHandle, OptionsGridView.Columns["MASTER"], false);
                        OptionsGridView.SetRowCellValue(OptionsGridView.FocusedRowHandle, OptionsGridView.Columns["ADMIN"], false);
                        OptionsGridView.SetRowCellValue(OptionsGridView.FocusedRowHandle, OptionsGridView.Columns["TRANSACTION"], false);
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void OptionsGrid_Click(object sender, EventArgs e)
        {


        }
    }
}