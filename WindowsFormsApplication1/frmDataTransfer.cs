using System;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class frmDataTransfer : DevExpress.XtraEditors.XtraForm
    {
        String SourceConnectionString = String.Empty;
        String DestinationConnectionString = String.Empty;

        String SourceTable;
        String DestinationTable;
        public frmDataTransfer()
        {
            InitializeComponent();
        }
        public DataSet GetDataSet(string Query, String ConnectionString)
        {
            using (var _VarDataSet = new DataSet())
            {
                try
                {
                    using (var _VarSqlDataAdapter = new SqlDataAdapter(Query, new SqlConnection(ConnectionString)))
                    {
                        _VarSqlDataAdapter.SelectCommand.CommandTimeout = 1200;
                        _VarSqlDataAdapter.Fill(_VarDataSet);
                    }
                    return _VarDataSet;
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {

                    return null;
                }
            }
        }


        private void STableGrid_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = STableGridView.GetDataRow(STableGridView.FocusedRowHandle);

            SourceTable = row["TableName"].ToString();
            DataSet dsSource = GetDataSet("SELECT COLUMN_NAME as ColumnName FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'" + row["TableName"].ToString() + "'", SourceConnectionString);
            if (dsSource.Tables[0].Rows.Count > 0)
            {
                SColumnGrid.DataSource = dsSource.Tables[0];
            }
            else
            {
                SColumnGrid.DataSource = null;
            }
        }

        private void DTableGrid_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = DTableGridVIew.GetDataRow(DTableGridVIew.FocusedRowHandle);

            DestinationTable = row["TableName"].ToString();
            DataSet dsSource = GetDataSet("SELECT COLUMN_NAME as ColumnName,'' as Value,'' as Source FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'" + row["TableName"].ToString() + "'", DestinationConnectionString);
            if (dsSource.Tables[0].Rows.Count > 0)
            {
                repositoryItemComboBox1.Items.Clear();
                DColumnGrid.DataSource = dsSource.Tables[0];
                foreach (DataRow dr in (SColumnGrid.DataSource as DataTable).Rows)
                {
                    repositoryItemComboBox1.Items.Add(dr["ColumnName"].ToString());
                }
            }
            else
            {
                DColumnGrid.DataSource = null;
            }




        }

        private void FrmDataTransfer_Load(object sender, EventArgs e)
        {
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
        }



        private void MakeQuery()
        {
            int i = 0;
            String Query = String.Empty;

            foreach (DataRow dr in (DColumnGrid.DataSource as DataTable).Rows)
            {
                if (i == 0)
                {
                    Query = Query + "Insert into " + SourceTable + "(";
                    i++;
                }
                if (dr["Source"].ToString().Length > 0 || dr["Value"].ToString().Length > 0)
                {
                    Query = Query + "[" + dr["ColumnName"].ToString() + "]" + ",";
                    i++;
                }
            }
            if (Query.Length > 0)
            {
                Query = Query.Remove(Query.Length - 1, 1);
                richTextBox1.Text = Query + ")";
            }

            int j = 0;
            foreach (DataRow dr in (DColumnGrid.DataSource as DataTable).Rows)
            {
                if (j == 0)
                {
                    Query = Query + "  Select ";
                    j++;
                }
                if (dr["Source"].ToString().Length > 0 || dr["Value"].ToString().Length > 0)
                {
                    if (dr["Value"].ToString().Length > 0)
                    {
                        Query = Query + "'" + dr["Value"].ToString() + "'" + ",";
                    }
                    else
                    {
                        Query = Query + "[" + dr["Source"].ToString() + "]" + ",";
                    }

                    j++;
                }
            }
            if (Query.Length > 0)
            {
                Query = Query.Remove(Query.Length - 1, 1);
                richTextBox1.Text = Query + " from " + DestinationTable;
            }

            DataSet dsCount = GetDataSet("Select count(*) from " + SourceTable, SourceConnectionString);
            if (dsCount.Tables[0].Rows.Count > 0)
            {
                lblTotalRecordsToTransfer.Text = dsCount.Tables[0].Rows[0][0].ToString();
            }
        }



        private void RepositoryItemComboBox1_EditValueChanged(object sender, EventArgs e)
        {
            MakeQuery();
        }

        private void BtnSource_Click(object sender, EventArgs e)
        {
            DataSet dsSource = GetDataSet("Select name as TableName from Sys.tables", SourceConnectionString);
            if (dsSource.Tables[0].Rows.Count > 0)
            {
                STableGrid.DataSource = dsSource.Tables[0];
            }
            else
            {
                STableGrid.DataSource = null;
            }
        }


        private void MakeConnectionStrings()
        {
            SourceConnectionString = "Data Source = " + txtSourceServer.Text + "; Initial Catalog = " + txtSourceDataBase.Text + "; User ID = " + txtSourceUserName.Text + "; pwd = " + txtSourcePassword.Text;
            DestinationConnectionString = "Data Source = " + txtDestinationServer.Text + "; Initial Catalog = " + txtDestinationDataBase.Text + "; User ID = " + txtDestinationUserName.Text + "; pwd = " + txtDestinationPassword.Text;
            txtSourceConnection.Text = SourceConnectionString;
            txtDestinationConnection.Text = DestinationConnectionString;
        }
        private void BtnDestination_Click(object sender, EventArgs e)
        {
            DataSet dsDestination = GetDataSet("Select name as TableName from Sys.tables", DestinationConnectionString);
            if (dsDestination.Tables[0].Rows.Count > 0)
            {
                DTableGrid.DataSource = dsDestination.Tables[0];
            }
            else
            {
                DTableGrid.DataSource = null;
            }
        }

        private void TxtSourceServer_EditValueChanged(object sender, EventArgs e)
        {
            MakeConnectionStrings();
        }

        private void DColumnGridVIew_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            MakeQuery();
        }
    }
}