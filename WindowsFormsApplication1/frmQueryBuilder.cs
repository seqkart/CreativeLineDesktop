using System;
using System.Data;
using System.IO;
using System.Linq;

namespace WindowsFormsApplication1
{
    public partial class frmQueryBuilder : DevExpress.XtraEditors.XtraForm
    {
        public frmQueryBuilder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();


            using (System.IO.StreamReader sr = new StreamReader("C:\\Temp\\ABC.csv"))
            {
                dt = new DataTable();
                string[] headers = sr.ReadLine().Split(',');


                DataSet ds = ProjectFunctions.GetDataSet("Select * from [Book2]");
                dt = ds.Tables[0].Clone();



                //for (int ii= 0; ii < headers.Count(); ii++)
                //{
                //    dt.Columns.Add();
                //}
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');



                    DataRow dr = dt.NewRow();
                    for (int ii = 0; ii < rows.Count(); ii++)
                    {
                        if (ii >= dt.Columns.Count)
                        {

                        }
                        else
                        {
                            dr[ii] = rows[ii];
                        }

                    }
                    dt.Rows.Add(dr);
                }
            }






            String str = "Insert into [Book2](";
            int i = 0;
            int MaxCOunt = dt.Columns.Count;
            foreach (DataColumn drCol in dt.Columns)
            {

                if (i == 0)
                {
                    str = str + "[" + drCol.ColumnName.ToString() + "],";
                    i++;
                }
                else
                {
                    if (i == MaxCOunt - 1)
                    {
                        str = str + "[" + drCol.ColumnName.ToString() + "])Values(";
                        i++;
                    }
                    else
                    {
                        str = str + "[" + drCol.ColumnName.ToString() + "],";
                        i++;
                    }
                }

            }

            foreach (DataRow dataRow in dt.Rows)
            {
                i = 0;
                String Str1 = str;
                foreach (DataColumn drCol in dt.Columns)
                {

                    if (i == 0)
                    {
                        Str1 = Str1 + "'" + dataRow[i].ToString() + "',";
                        i++;
                    }
                    else
                    {
                        if (i == MaxCOunt - 1)
                        {
                            Str1 = Str1 + "'" + dataRow[i].ToString() + "')";
                            i++;
                        }
                        else
                        {
                            Str1 = Str1 + "'" + dataRow[i].ToString() + "',";
                            i++;
                        }
                    }

                }
                ProjectFunctions.GetDataSet(Str1);
                Str1 = str;

            }



        }
    }
}