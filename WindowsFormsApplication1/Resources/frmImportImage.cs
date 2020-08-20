using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace WindowsFormsApplication1.Resources
{
    public partial class frmImportImage : DevExpress.XtraEditors.XtraForm
    {
        public frmImportImage()
        {
            InitializeComponent();
        }
        private void CaptureScreen()
        {
            try
            {

                System.IO.MemoryStream ms = new MemoryStream();

                byte[] photo = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(photo, 0, photo.Length);

                using (var sqlcon = new SqlConnection(ProjectFunctions.ConnectionString))
                {
                    sqlcon.Open();
                    String str = string.Empty;
                    DataSet ds = ProjectFunctions.GetDataSet("Select * from CRImages where TransId='1'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        str = "update CRImages Set Image= @photo Where TransId=@TransId";

                        var sqlcom = new SqlCommand(str, sqlcon);
                        sqlcom.Parameters.AddWithValue("@photo", photo);
                        sqlcom.Parameters.AddWithValue("@TransId", "1");
                        sqlcom.CommandType = CommandType.Text;
                        sqlcom.ExecuteNonQuery();
                        sqlcon.Close();
                        ProjectFunctions.SpeakError("Picture Saved Successfully");
                    }


                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }

        }
        private void BtnSaveImage_Click(object sender, EventArgs e)
        {
            CaptureScreen();
        }
    }
}