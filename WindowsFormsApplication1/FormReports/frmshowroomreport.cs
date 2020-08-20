using DevExpress.XtraSplashScreen;
using System;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApplication1.FormReports
{
    public partial class frmshowroomreport : DevExpress.XtraEditors.XtraForm

    {
        String ShowConnectionString = @"Data Source=CREATIVE-PC\MSSQLSERVER1;Initial Catalog=SEQKART;User ID=sa;pwd=123";
        String ShowConnectionStringHO = @"Data Source=seqkart.ddns.net;Initial Catalog=test;User ID=sa;pwd=Seq@2020";
        public frmshowroomreport()
        {
            InitializeComponent();
        }
        public static DataSet GetDataSet(string Query, string conn)
        {
            using (var _VarDataSet = new DataSet())
            {
                try
                {
                    using (var _VarSqlDataAdapter = new SqlDataAdapter(Query, new SqlConnection(conn)))
                    {
                        _VarSqlDataAdapter.SelectCommand.CommandTimeout = 1200;
                        _VarSqlDataAdapter.Fill(_VarDataSet);
                    }
                    return _VarDataSet;
                }

                catch //(Exception ex)
                {

                    return null;
                }
            }
        }
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                SplashScreenManager.Default.SetWaitFormDescription("Moving Masters");
                GetDataSet("sp_MoveMasters", ShowConnectionString);
                SplashScreenManager.Default.SetWaitFormDescription("Moving Transaction");
                using (var sqlcon = new SqlConnection(ShowConnectionStringHO))
                {
                    sqlcon.Open();
                    var sqlcom = sqlcon.CreateCommand();
                    sqlcom.Connection = sqlcon;

                    DataSet ds1 = GetDataSet("Select * from Article", ShowConnectionString);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        gridControl1.DataSource = ds1.Tables[0];
                        sqlcom.CommandType = CommandType.StoredProcedure;
                        sqlcom.CommandText = "sp_InsertArticleData";
                        SqlParameter param1 = new SqlParameter
                        {
                            ParameterName = "@ArticleTable",
                            Value = (gridControl1.DataSource as DataTable)
                        };
                        sqlcom.Parameters.Add(param1);
                        sqlcom.ExecuteNonQuery();
                        sqlcom.Parameters.Clear();
                    }
                    else
                    {
                        gridControl1.DataSource = null;
                    }






                    DataSet ds2 = GetDataSet("Select * from CASHTENDER", ShowConnectionString);
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        gridControl1.DataSource = ds2.Tables[0];
                        sqlcom.CommandType = CommandType.StoredProcedure;
                        sqlcom.CommandText = "sp_InsertCASHTENDERData";
                        SqlParameter param2 = new SqlParameter
                        {
                            ParameterName = "@CASHTENDERTable",
                            Value = (gridControl1.DataSource as DataTable)
                        };
                        sqlcom.Parameters.Add(param2);
                        sqlcom.ExecuteNonQuery();
                        sqlcom.Parameters.Clear();
                    }
                    else
                    {
                        gridControl1.DataSource = null;
                    }


                    DataSet ds3 = GetDataSet("Select * from COLOURS", ShowConnectionString);
                    if (ds3.Tables[0].Rows.Count > 0)
                    {
                        gridControl1.DataSource = ds3.Tables[0];
                        sqlcom.CommandType = CommandType.StoredProcedure;
                        sqlcom.CommandText = "sp_InsertCOLOURSData";
                        SqlParameter param3 = new SqlParameter
                        {
                            ParameterName = "@COLOURSTable",
                            Value = (gridControl1.DataSource as DataTable)
                        };
                        sqlcom.Parameters.Add(param3);
                        sqlcom.ExecuteNonQuery();
                        sqlcom.Parameters.Clear();
                    }
                    else
                    {
                        gridControl1.DataSource = null;
                    }

                    DataSet ds4 = GetDataSet("Select * from PSWSLDET", ShowConnectionString);
                    if (ds4.Tables[0].Rows.Count > 0)
                    {
                        gridControl1.DataSource = ds4.Tables[0];
                        sqlcom.CommandType = CommandType.StoredProcedure;
                        sqlcom.CommandText = "sp_InsertPSWSLDETData";
                        SqlParameter param4 = new SqlParameter
                        {
                            ParameterName = "@PSWSLDETTable",
                            Value = (gridControl1.DataSource as DataTable)
                        };
                        sqlcom.Parameters.Add(param4);
                        sqlcom.ExecuteNonQuery();
                        sqlcom.Parameters.Clear();
                    }
                    else
                    {
                        gridControl1.DataSource = null;
                    }


                    DataSet ds5 = GetDataSet("Select * from PSWSLMAIN", ShowConnectionString);
                    if (ds5.Tables[0].Rows.Count > 0)
                    {
                        gridControl1.DataSource = ds5.Tables[0];
                        sqlcom.CommandType = CommandType.StoredProcedure;
                        sqlcom.CommandText = "sp_InsertPSWSLMAINData";
                        SqlParameter param5 = new SqlParameter
                        {
                            ParameterName = "@PSWSLMAINTable",
                            Value = (gridControl1.DataSource as DataTable)
                        };
                        sqlcom.Parameters.Add(param5);
                        sqlcom.ExecuteNonQuery();
                        sqlcom.Parameters.Clear();
                    }
                    else
                    {
                        gridControl1.DataSource = null;
                    }


                    DataSet ds6 = GetDataSet("Select * from SaleInvDet", ShowConnectionString);
                    if (ds6.Tables[0].Rows.Count > 0)
                    {
                        gridControl1.DataSource = ds6.Tables[0];
                        sqlcom.CommandType = CommandType.StoredProcedure;
                        sqlcom.CommandText = "sp_InsertSaleInvDetData";
                        SqlParameter param6 = new SqlParameter
                        {
                            ParameterName = "@SaleInvDetTable",
                            Value = (gridControl1.DataSource as DataTable)
                        };
                        sqlcom.Parameters.Add(param6);
                        sqlcom.ExecuteNonQuery();
                        sqlcom.Parameters.Clear();
                    }
                    else
                    {
                        gridControl1.DataSource = null;
                    }

                    DataSet ds7 = GetDataSet("Select * from SALEINVMAIN", ShowConnectionString);
                    if (ds7.Tables[0].Rows.Count > 0)
                    {
                        gridControl1.DataSource = ds7.Tables[0];
                        sqlcom.CommandType = CommandType.StoredProcedure;
                        sqlcom.CommandText = "sp_InsertSALEINVMAINData";
                        SqlParameter param7 = new SqlParameter
                        {
                            ParameterName = "@SALEINVMAINTable",
                            Value = (gridControl1.DataSource as DataTable)
                        };
                        sqlcom.Parameters.Add(param7);
                        sqlcom.ExecuteNonQuery();
                        sqlcom.Parameters.Clear();
                    }
                    else
                    {
                        gridControl1.DataSource = null;
                    }

                    DataSet ds8 = GetDataSet("Select * from SFDET", ShowConnectionString);
                    if (ds8.Tables[0].Rows.Count > 0)
                    {
                        gridControl1.DataSource = ds8.Tables[0];
                        sqlcom.CommandType = CommandType.StoredProcedure;
                        sqlcom.CommandText = "sp_InsertSFDETSData";
                        SqlParameter param8 = new SqlParameter
                        {
                            ParameterName = "@SFDETTable",
                            Value = (gridControl1.DataSource as DataTable)
                        };
                        sqlcom.Parameters.Add(param8);
                        sqlcom.ExecuteNonQuery();
                        sqlcom.Parameters.Clear();
                    }
                    else
                    {
                        gridControl1.DataSource = null;
                    }

                    DataSet ds10 = GetDataSet("Select * from SFMAIN", ShowConnectionString);
                    if (ds10.Tables[0].Rows.Count > 0)
                    {
                        gridControl1.DataSource = ds10.Tables[0];
                        sqlcom.CommandType = CommandType.StoredProcedure;
                        sqlcom.CommandText = "sp_InsertSFMAINData";
                        SqlParameter param10 = new SqlParameter
                        {
                            ParameterName = "@SFMAINTable",
                            Value = (gridControl1.DataSource as DataTable)
                        };
                        sqlcom.Parameters.Add(param10);
                        sqlcom.ExecuteNonQuery();
                        sqlcom.Parameters.Clear();
                    }
                    else
                    {
                        gridControl1.DataSource = null;
                    }

                    DataSet ds11 = GetDataSet("Select * from SKU", ShowConnectionString);
                    if (ds11.Tables[0].Rows.Count > 0)
                    {
                        gridControl1.DataSource = ds11.Tables[0];
                        sqlcom.CommandType = CommandType.StoredProcedure;
                        sqlcom.CommandText = "sp_InsertSKUData";
                        SqlParameter param11 = new SqlParameter
                        {
                            ParameterName = "@SKUTable",
                            Value = (gridControl1.DataSource as DataTable)
                        };
                        sqlcom.Parameters.Add(param11);
                        sqlcom.ExecuteNonQuery();
                        sqlcom.Parameters.Clear();
                    }
                    else
                    {
                        gridControl1.DataSource = null;
                    }








                    SplashScreenManager.CloseForm(false);

                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }


        //public void SaveData(DataTable table)
        //{


        //    using (AdventureWorksDataContext ctx = new AdventureWorksDataContext())
        //    {
        //        foreach (DataRow row in table.Rows)
        //        {
        //            YourObjectType myData = ConvertDataRowToObject(row);
        //            ctx.YourObjectTypes.InsertOnSubmit(myData);
        //        }
        //        ctx.SubmitChanges();
        //    }
        //}

        private void chSale1_CheckedChanged(object sender, EventArgs e)
        {
            if (chSale1.Checked)
            {
                chSale2.Checked = false;
            }
        }

        private void chSale2_CheckedChanged(object sender, EventArgs e)
        {
            if (chSale2.Checked)
            {
                chSale1.Checked = false;
            }
        }

        private void frmshowroomreport_Load(object sender, EventArgs e)
        {
            //DataSet ds = GetDataSet("Select * from SKU", ShowConnectionString);
            //if(ds.Tables[0].Rows.Count>0)
            //{
            //    gridControl1.DataSource = ds.Tables[0];

            //}
            //else
            //{
            //    gridControl1.DataSource = null;
            //}
        }
    }
}