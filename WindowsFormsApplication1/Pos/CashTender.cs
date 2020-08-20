using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Transaction
{
    public partial class CashTender : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String MemoNo { get; set; }
        public DateTime MemoDate { get; set; }
        public Decimal CardPayment { get; set; }
        public Decimal PGPayment { get; set; }
        public Decimal TotalMemoAmount { get; set; }
        public CashTender()
        {
            InitializeComponent();
        }

        private void CashTender_Load(object sender, EventArgs e)
        {
            try

            {
                //ProjectFunctions.TextBoxVisualize(groupControl2);
                //ProjectFunctions.TextBoxVisualize(groupControl3);
                //ProjectFunctions.TextBoxVisualize(groupControl4);
                DataSet dsTotalGallaAmount = ProjectFunctions.GetDataSet("sp_LoadGallaBal '" + GlobalVariables.CUnitID + "'");
                if (dsTotalGallaAmount.Tables[0].Rows.Count > 0)
                {
                    txtTot2000.Text = (Convert.ToDecimal(dsTotalGallaAmount.Tables[0].Rows[0]["CURIN2000"]) / 2000).ToString();
                    txtTot1000.Text = (Convert.ToDecimal(dsTotalGallaAmount.Tables[0].Rows[0]["CURIN1000"]) / 1000).ToString();
                    txtTot500.Text = (Convert.ToDecimal(dsTotalGallaAmount.Tables[0].Rows[0]["CURIN500"]) / 500).ToString();
                    txtTot200.Text = (Convert.ToDecimal(dsTotalGallaAmount.Tables[0].Rows[0]["CURIN200"]) / 200).ToString();
                    txtTot100.Text = (Convert.ToDecimal(dsTotalGallaAmount.Tables[0].Rows[0]["CURIN100"]) / 100).ToString();
                    txtTot50.Text = (Convert.ToDecimal(dsTotalGallaAmount.Tables[0].Rows[0]["CURIN50"]) / 50).ToString();
                    txtTot20.Text = (Convert.ToDecimal(dsTotalGallaAmount.Tables[0].Rows[0]["CURIN20"]) / 20).ToString();
                    txtTot10.Text = (Convert.ToDecimal(dsTotalGallaAmount.Tables[0].Rows[0]["CURIN10"]) / 10).ToString();
                    txtTot5.Text = (Convert.ToDecimal(dsTotalGallaAmount.Tables[0].Rows[0]["CURIN5"]) / 5).ToString();
                    txtTot2.Text = (Convert.ToDecimal(dsTotalGallaAmount.Tables[0].Rows[0]["CURIN2"]) / 2).ToString();
                    txtTot1.Text = (Convert.ToDecimal(dsTotalGallaAmount.Tables[0].Rows[0]["CURIN1"]) / 1).ToString();
                    txtTotTotal.Text = dsTotalGallaAmount.Tables[0].Rows[0]["TotalAmount"].ToString();

                    txtCashOutCount2000.Text = (Convert.ToDecimal(txtCashOutAmount2000.Text) / 2000).ToString();
                    txtCashOutCount1000.Text = (Convert.ToDecimal(txtCashOutAmount1000.Text) / 1000).ToString();
                    txtCashOutCount500.Text = (Convert.ToDecimal(txtCashOutAmount500.Text) / 500).ToString();
                    txtCashOutCount200.Text = (Convert.ToDecimal(txtCashOutAmount200.Text) / 200).ToString();
                    txtCashOutCount100.Text = (Convert.ToDecimal(txtCashOutAmount100.Text) / 100).ToString();
                    txtCashOutCount50.Text = (Convert.ToDecimal(txtCashOutAmount50.Text) / 500).ToString();
                    txtCashOutCount20.Text = (Convert.ToDecimal(txtCashOutAmount20.Text) / 20).ToString();
                    txtCashOutCount10.Text = (Convert.ToDecimal(txtCashOutAmount10.Text) / 10).ToString();
                    txtCashOutCount5.Text = (Convert.ToDecimal(txtCashOutAmount5.Text) / 5).ToString();
                    txtCashOutCount2.Text = (Convert.ToDecimal(txtCashOutAmount2.Text) / 2).ToString();
                    txtCashOutCount1.Text = (Convert.ToDecimal(txtCashOutAmount1.Text) / 1).ToString();

                }


                txtCashMemoNo.Text = MemoNo;
                txtCashMemoDate.Text = MemoDate.ToString("dd-MM-yyyy");
                txtCardPayment.Text = CardPayment.ToString("0.00");
                txtPGPayment.Text = PGPayment.ToString("0.00");
                txtCashMemoAmount.Text = TotalMemoAmount.ToString("0.00");




                DataSet ds = ProjectFunctions.GetDataSet("Select * from CASHTENDER Where CATMEMONO='" + MemoNo + "' And CATMEMODATE='" + MemoDate.Date.ToString("yyyy-MM-dd") + "' And UnitCode='" + GlobalVariables.CUnitID + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtCashMemoNo.Text = ds.Tables[0].Rows[0]["CATMEMONO"].ToString();
                    txtCashMemoDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["CATMEMODATE"]).ToString("yyyy-MM-dd");
                    txtCashMemoAmount.Text = ds.Tables[0].Rows[0]["CATMEMOAMT"].ToString();
                    txtCardPayment.Text = ds.Tables[0].Rows[0]["CATCARDAMT"].ToString();
                    txtPGPayment.Text = ds.Tables[0].Rows[0]["CATPGAMT"].ToString();
                    txtCashInAmount2000.Text = ds.Tables[0].Rows[0]["CURIN2000"].ToString();
                    txtCashInAmount1000.Text = ds.Tables[0].Rows[0]["CURIN1000"].ToString();
                    txtCashInAmount200.Text = ds.Tables[0].Rows[0]["CURIN200"].ToString();
                    txtCashInAmount500.Text = ds.Tables[0].Rows[0]["CURIN500"].ToString();
                    txtCashInAmount100.Text = ds.Tables[0].Rows[0]["CURIN100"].ToString();
                    txtCashInAmount50.Text = ds.Tables[0].Rows[0]["CURIN50"].ToString();
                    txtCashInAmount20.Text = ds.Tables[0].Rows[0]["CURIN20"].ToString();
                    txtCashInAmount10.Text = ds.Tables[0].Rows[0]["CURIN10"].ToString();
                    txtCashInAmount5.Text = ds.Tables[0].Rows[0]["CURIN5"].ToString();
                    txtCashInAmount2.Text = ds.Tables[0].Rows[0]["CURIN2"].ToString();
                    txtCashInAmount1.Text = ds.Tables[0].Rows[0]["CURIN1"].ToString();


                    txtCashInCount2000.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0]["CURIN2000"]) / 2000).ToString();
                    txtCashInCount1000.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0]["CURIN1000"]) / 1000).ToString();
                    txtCashInCount500.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0]["CURIN500"]) / 500).ToString();
                    txtCashInCount200.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0]["CURIN200"]) / 200).ToString();
                    txtCashInCount100.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0]["CURIN100"]) / 100).ToString();
                    txtCashInCount50.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0]["CURIN50"]) / 500).ToString();
                    txtCashInCount20.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0]["CURIN20"]) / 20).ToString();
                    txtCashInCount10.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0]["CURIN10"]) / 10).ToString();
                    txtCashInCount5.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0]["CURIN5"]) / 5).ToString();
                    txtCashInCount2.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0]["CURIN2"]) / 2).ToString();
                    txtCashInCount1.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0]["CURIN1"]) / 1).ToString();



                    txtCashInTotal.Text = ds.Tables[0].Rows[0]["CURINTOT"].ToString();
                    txtCashOutAmount2000.Text = ds.Tables[0].Rows[0]["CUROUT2000"].ToString();
                    txtCashOutAmount1000.Text = ds.Tables[0].Rows[0]["CUROUT1000"].ToString();
                    txtCashOutAmount200.Text = ds.Tables[0].Rows[0]["CUROUT200"].ToString();
                    txtCashOutAmount500.Text = ds.Tables[0].Rows[0]["CUROUT500"].ToString();
                    txtCashOutAmount100.Text = ds.Tables[0].Rows[0]["CUROUT100"].ToString();
                    txtCashOutAmount50.Text = ds.Tables[0].Rows[0]["CUROUT50"].ToString();
                    txtCashOutAmount20.Text = ds.Tables[0].Rows[0]["CUROUT20"].ToString();
                    txtCashOutAmount10.Text = ds.Tables[0].Rows[0]["CUROUT10"].ToString();
                    txtCashOutAmount5.Text = ds.Tables[0].Rows[0]["CUROUT5"].ToString();
                    txtCashOutAmount2.Text = ds.Tables[0].Rows[0]["CUROUT2"].ToString();
                    txtCashOutAmount1.Text = ds.Tables[0].Rows[0]["CUROUT1"].ToString();
                    txtCashOutTotal.Text = ds.Tables[0].Rows[0]["CUROUTTOT"].ToString();

                    txtCashOutCount2000.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0]["CUROUT2000"]) / 2000).ToString();
                    txtCashOutCount1000.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0]["CUROUT1000"]) / 1000).ToString();
                    txtCashOutCount500.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0]["CUROUT500"]) / 500).ToString();
                    txtCashOutCount200.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0]["CUROUT200"]) / 200).ToString();
                    txtCashOutCount100.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0]["CUROUT100"]) / 100).ToString();
                    txtCashOutCount50.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0]["CUROUT50"]) / 500).ToString();
                    txtCashOutCount20.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0]["CUROUT20"]) / 20).ToString();
                    txtCashOutCount10.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0]["CUROUT10"]) / 10).ToString();
                    txtCashOutCount5.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0]["CUROUT5"]) / 5).ToString();
                    txtCashOutCount2.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0]["CUROUT2"]) / 2).ToString();
                    txtCashOutCount1.Text = (Convert.ToDecimal(ds.Tables[0].Rows[0]["CUROUT1"]) / 1).ToString();


                }

                txtBillBalanceAmount.Text = (TotalMemoAmount - Convert.ToDecimal(txtCardPayment.Text) - Convert.ToDecimal(txtPGPayment.Text)).ToString("0.00");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void Calculate()
        {
            try
            {
                txtCashInAmount2000.Text = (Convert.ToDecimal(txtCashInCount2000.Text) * 2000).ToString("0.00");
                txtCashInAmount1000.Text = (Convert.ToDecimal(txtCashInCount1000.Text) * 1000).ToString("0.00");
                txtCashInAmount500.Text = (Convert.ToDecimal(txtCashInCount500.Text) * 500).ToString("0.00");
                txtCashInAmount200.Text = (Convert.ToDecimal(txtCashInCount200.Text) * 200).ToString("0.00");
                txtCashInAmount100.Text = (Convert.ToDecimal(txtCashInCount100.Text) * 100).ToString("0.00");
                txtCashInAmount50.Text = (Convert.ToDecimal(txtCashInCount50.Text) * 50).ToString("0.00");
                txtCashInAmount20.Text = (Convert.ToDecimal(txtCashInCount20.Text) * 20).ToString("0.00");
                txtCashInAmount10.Text = (Convert.ToDecimal(txtCashInCount10.Text) * 10).ToString("0.00");
                txtCashInAmount5.Text = (Convert.ToDecimal(txtCashInCount5.Text) * 5).ToString("0.00");
                txtCashInAmount2.Text = (Convert.ToDecimal(txtCashInCount2.Text) * 2).ToString("0.00");
                txtCashInAmount1.Text = (Convert.ToDecimal(txtCashInCount1.Text) * 1).ToString("0.00");


                txtCashInTotal.Text = (Convert.ToDecimal(txtCashInAmount2000.Text) + Convert.ToDecimal(txtCashInAmount1000.Text) + Convert.ToDecimal(txtCashInAmount500.Text) + Convert.ToDecimal(txtCashInAmount200.Text) + Convert.ToDecimal(txtCashInAmount100.Text) + Convert.ToDecimal(txtCashInAmount50.Text) + Convert.ToDecimal(txtCashInAmount20.Text) + Convert.ToDecimal(txtCashInAmount10.Text) + Convert.ToDecimal(txtCashInAmount5.Text) + Convert.ToDecimal(txtCashInAmount2.Text) + Convert.ToDecimal(txtCashInAmount1.Text)).ToString("0.00");

                txtCashOutAmount2000.Text = (Convert.ToDecimal(txtCashOutCount2000.Text) * 2000).ToString("0.00");
                txtCashOutAmount1000.Text = (Convert.ToDecimal(txtCashOutCount1000.Text) * 1000).ToString("0.00");
                txtCashOutAmount500.Text = (Convert.ToDecimal(txtCashOutCount500.Text) * 500).ToString("0.00");
                txtCashOutAmount200.Text = (Convert.ToDecimal(txtCashOutCount200.Text) * 200).ToString("0.00");
                txtCashOutAmount100.Text = (Convert.ToDecimal(txtCashOutCount100.Text) * 100).ToString("0.00");
                txtCashOutAmount50.Text = (Convert.ToDecimal(txtCashOutCount50.Text) * 50).ToString("0.00");
                txtCashOutAmount20.Text = (Convert.ToDecimal(txtCashOutCount20.Text) * 20).ToString("0.00");
                txtCashOutAmount10.Text = (Convert.ToDecimal(txtCashOutCount10.Text) * 10).ToString("0.00");
                txtCashOutAmount5.Text = (Convert.ToDecimal(txtCashOutCount5.Text) * 5).ToString("0.00");
                txtCashOutAmount2.Text = (Convert.ToDecimal(txtCashOutCount2.Text) * 2).ToString("0.00");
                txtCashOutAmount1.Text = (Convert.ToDecimal(txtCashOutCount1.Text) * 1).ToString("0.00");
                txtCashOutTotal.Text = (Convert.ToDecimal(txtCashOutAmount2000.Text) + Convert.ToDecimal(txtCashOutAmount1000.Text) + Convert.ToDecimal(txtCashOutAmount500.Text) + Convert.ToDecimal(txtCashOutAmount200.Text) + Convert.ToDecimal(txtCashOutAmount100.Text) + Convert.ToDecimal(txtCashOutAmount50.Text) + Convert.ToDecimal(txtCashOutAmount20.Text) + Convert.ToDecimal(txtCashOutAmount10.Text) + Convert.ToDecimal(txtCashOutAmount5.Text) + Convert.ToDecimal(txtCashOutAmount2.Text) + Convert.ToDecimal(txtCashOutAmount1.Text)).ToString("0.00");


                txtCashOutCount2000.Text = (Convert.ToDecimal(txtCashOutAmount2000.Text) / 2000).ToString();
                txtCashOutCount1000.Text = (Convert.ToDecimal(txtCashOutAmount1000.Text) / 1000).ToString();
                txtCashOutCount500.Text = (Convert.ToDecimal(txtCashOutAmount500.Text) / 500).ToString();
                txtCashOutCount200.Text = (Convert.ToDecimal(txtCashOutAmount200.Text) / 200).ToString();
                txtCashOutCount100.Text = (Convert.ToDecimal(txtCashOutAmount100.Text) / 100).ToString();
                txtCashOutCount50.Text = (Convert.ToDecimal(txtCashOutAmount50.Text) / 50).ToString();
                txtCashOutCount20.Text = (Convert.ToDecimal(txtCashOutAmount20.Text) / 20).ToString();
                txtCashOutCount10.Text = (Convert.ToDecimal(txtCashOutAmount10.Text) / 10).ToString();
                txtCashOutCount5.Text = (Convert.ToDecimal(txtCashOutAmount5.Text) / 5).ToString();
                txtCashOutCount2.Text = (Convert.ToDecimal(txtCashOutAmount2.Text) / 2).ToString();
                txtCashOutCount1.Text = (Convert.ToDecimal(txtCashOutAmount1.Text) / 1).ToString();

                txtTotalReceived.Text = txtCashInTotal.Text;
                txtTotalPayBack.Text = (Convert.ToDecimal(txtCashMemoAmount.Text) - Convert.ToDecimal(txtTotalReceived.Text) + Convert.ToDecimal(txtCashOutTotal.Text)).ToString("0.00");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

        }
        private void GroupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TxtCashInCount1_EditValueChanged(object sender, EventArgs e)
        {
            Calculate();
        }
        private bool ValidateDataForSaving()
        {
            if (Convert.ToDecimal(txtCashInTotal.Text) > 0 || Convert.ToDecimal(txtCashOutTotal.Text) > 0)
            {

            }
            else
            {
                ProjectFunctions.SpeakError("Either Total Cash Or Total Cash Out Is Wrong");
                return false;
            }
            return true;
        }
        private void Save()
        {
            if (ValidateDataForSaving())
            {
                using (var sqlcon = new SqlConnection(ProjectFunctions.GetConnection()))
                {
                    sqlcon.Open();
                    var sqlcom = sqlcon.CreateCommand();
                    sqlcom.Connection = sqlcon;
                    sqlcom.CommandType = CommandType.Text;
                    try
                    {
                        DataSet dsCheck = ProjectFunctions.GetDataSet("Select * from CASHTENDER where CATMEMONO='" + txtCashMemoNo.Text + "' And CATMEMODATE='" + Convert.ToDateTime(txtCashMemoDate.Text).ToString("yyyy-MM-dd") + "' And UnitCode='" + GlobalVariables.CUnitID + "'");
                        if (dsCheck.Tables[0].Rows.Count == 0)
                        {

                            sqlcom.CommandText = "Insert into CASHTENDER(CATMEMONO,CATMEMODATE,CATMEMOAMT,CATCARDAMT,CATPGAMT,CURIN2000,CURIN1000,CURIN200,CURIN500,CURIN100,CURIN50,CURIN20,CURIN10,CURIN5," +
                                "  CURIN2,CURIN1,CURINTOT,CUROUT2000,CUROUT1000,CUROUT200,CUROUT500,CUROUT100,CUROUT50,CUROUT20,CUROUT10,CUROUT5,CUROUT2,CUROUT1,CUROUTTOT,CASHAmount,UnitCode)values(" +
                                "@CATMEMONO,@CATMEMODATE,@CATMEMOAMT,@CATCARDAMT,@CATPGAMT,@CURIN2000,@CURIN1000,@CURIN200,@CURIN500,@CURIN100,@CURIN50,@CURIN20,@CURIN10,@CURIN5," +
                                "  @CURIN2,@CURIN1,@CURINTOT,@CUROUT2000,@CUROUT1000,@CUROUT200,@CUROUT500,@CUROUT100,@CUROUT50,@CUROUT20,@CUROUT10,@CUROUT5,@CUROUT2,@CUROUT1,@CUROUTTOT,@CASHAmount,@UnitCode)";
                            sqlcom.Parameters.Add("@CATMEMONO", SqlDbType.NVarChar).Value = txtCashMemoNo.Text;
                            sqlcom.Parameters.Add("@CATMEMODATE", SqlDbType.NVarChar).Value = Convert.ToDateTime(txtCashMemoDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@CATMEMOAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashMemoAmount.Text);
                            sqlcom.Parameters.Add("@CATCARDAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCardPayment.Text);
                            sqlcom.Parameters.Add("@CATPGAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtPGPayment.Text);
                            sqlcom.Parameters.Add("@CURIN2000", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashInAmount2000.Text);
                            sqlcom.Parameters.Add("@CURIN1000", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashInAmount1000.Text);
                            sqlcom.Parameters.Add("@CURIN200", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashInAmount200.Text);
                            sqlcom.Parameters.Add("@CURIN500", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashInAmount500.Text);
                            sqlcom.Parameters.Add("@CURIN100", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashInAmount100.Text);
                            sqlcom.Parameters.Add("@CURIN50", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashInAmount50.Text);
                            sqlcom.Parameters.Add("@CURIN20", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashInAmount20.Text); ;
                            sqlcom.Parameters.Add("@CURIN10", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashInAmount10.Text);
                            sqlcom.Parameters.Add("@CURIN5", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashInAmount5.Text);
                            sqlcom.Parameters.Add("@CURIN2", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashInAmount2.Text);
                            sqlcom.Parameters.Add("@CURIN1", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashInAmount1.Text);
                            sqlcom.Parameters.Add("@CURINTOT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashInTotal.Text);
                            sqlcom.Parameters.Add("@CUROUT2000", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashOutAmount2000.Text);
                            sqlcom.Parameters.Add("@CUROUT1000", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashOutAmount1000.Text);
                            sqlcom.Parameters.Add("@CUROUT200", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashOutAmount200.Text);
                            sqlcom.Parameters.Add("@CUROUT500", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashOutAmount500.Text);
                            sqlcom.Parameters.Add("@CUROUT100", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashOutAmount100.Text);
                            sqlcom.Parameters.Add("@CUROUT50", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashOutAmount50.Text);
                            sqlcom.Parameters.Add("@CUROUT20", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashOutAmount20.Text);
                            sqlcom.Parameters.Add("@CUROUT10", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashOutAmount10.Text);
                            sqlcom.Parameters.Add("@CUROUT5", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashOutAmount5.Text);
                            sqlcom.Parameters.Add("@CUROUT2", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashOutAmount2.Text);
                            sqlcom.Parameters.Add("@CUROUT1", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashOutAmount1.Text);
                            sqlcom.Parameters.Add("@CUROUTTOT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashOutTotal.Text);
                            sqlcom.Parameters.Add("@CASHAmount", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashMemoAmount.Text);
                            sqlcom.Parameters.Add("@UnitCode", SqlDbType.NVarChar).Value = GlobalVariables.CUnitID;
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();
                        }
                        else
                        {
                            sqlcom.CommandText = "Update CASHTENDER Set CATMEMOAMT=@CATMEMOAMT,CATCARDAMT=@CATCARDAMT,CATPGAMT=@CATPGAMT,CURIN2000=@CURIN2000," +
                                " CURIN1000=@CURIN1000,CURIN200=@CURIN200,CURIN500=@CURIN500,CURIN100=@CURIN100," +
                                " CURIN50=@CURIN50,CURIN20=@CURIN20,CURIN10=@CURIN10,CURIN5=@CURIN5,CURIN2=@CURIN2,CURIN1=@CURIN1," +
                                 " CURINTOT=@CURINTOT,CUROUT2000=@CUROUT2000,CUROUT1000=@CUROUT1000,CUROUT200=@CUROUT200,CUROUT500=@CUROUT500,CUROUT100=@CUROUT100," +
                                  " CUROUT50=@CUROUT50,CUROUT20=@CUROUT20,CUROUT10=@CUROUT10,CUROUT5=@CUROUT5,CUROUT2=@CUROUT2,CUROUT1=@CUROUT1,CUROUTTOT=@CUROUTTOT,CASHAmount=@CASHAmount" +
                                " Where CATMEMODATE='" + Convert.ToDateTime(txtCashMemoDate.Text).ToString("yyyy-MM-dd") + "' And CATMEMONO='" + txtCashMemoNo.Text + "' And UnitCode='" + GlobalVariables.CUnitID + "'";


                            sqlcom.Parameters.Add("@CATMEMONO", SqlDbType.NVarChar).Value = txtCashMemoNo.Text;
                            sqlcom.Parameters.Add("@CATMEMODATE", SqlDbType.NVarChar).Value = Convert.ToDateTime(txtCashMemoDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@CATMEMOAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashMemoAmount.Text);
                            sqlcom.Parameters.Add("@CATCARDAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCardPayment.Text);
                            sqlcom.Parameters.Add("@CATPGAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtPGPayment.Text);
                            sqlcom.Parameters.Add("@CURIN2000", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashInAmount2000.Text);
                            sqlcom.Parameters.Add("@CURIN1000", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashInAmount1000.Text);
                            sqlcom.Parameters.Add("@CURIN200", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashInAmount200.Text);
                            sqlcom.Parameters.Add("@CURIN500", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashInAmount500.Text);
                            sqlcom.Parameters.Add("@CURIN100", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashInAmount100.Text);
                            sqlcom.Parameters.Add("@CURIN50", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashInAmount50.Text);
                            sqlcom.Parameters.Add("@CURIN20", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashInAmount20.Text); ;
                            sqlcom.Parameters.Add("@CURIN10", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashInAmount10.Text);
                            sqlcom.Parameters.Add("@CURIN5", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashInAmount5.Text);
                            sqlcom.Parameters.Add("@CURIN2", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashInAmount2.Text);
                            sqlcom.Parameters.Add("@CURIN1", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashInAmount1.Text);
                            sqlcom.Parameters.Add("@CURINTOT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashInTotal.Text);
                            sqlcom.Parameters.Add("@CUROUT2000", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashOutAmount2000.Text);
                            sqlcom.Parameters.Add("@CUROUT1000", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashOutAmount1000.Text);
                            sqlcom.Parameters.Add("@CUROUT200", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashOutAmount200.Text);
                            sqlcom.Parameters.Add("@CUROUT500", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashOutAmount500.Text);
                            sqlcom.Parameters.Add("@CUROUT100", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashOutAmount100.Text);
                            sqlcom.Parameters.Add("@CUROUT50", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashOutAmount50.Text);
                            sqlcom.Parameters.Add("@CUROUT20", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashOutAmount20.Text);
                            sqlcom.Parameters.Add("@CUROUT10", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashOutAmount10.Text);
                            sqlcom.Parameters.Add("@CUROUT5", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashOutAmount5.Text);
                            sqlcom.Parameters.Add("@CUROUT2", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashOutAmount2.Text);
                            sqlcom.Parameters.Add("@CUROUT1", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashOutAmount1.Text);
                            sqlcom.Parameters.Add("@CUROUTTOT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashOutTotal.Text);
                            sqlcom.Parameters.Add("@CASHAmount", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCashMemoAmount.Text);

                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();
                        }
                        sqlcon.Close();

                        this.Close();



                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }
                }
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
            Prints.CASHMEMO rpt = new Prints.CASHMEMO();
            ProjectFunctions.PrintDocument(txtCashMemoNo.Text, Convert.ToDateTime(txtCashMemoDate.Text), "S", rpt);
            this.Close();
        }

        private void SimpleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnSaveOnly_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
            //Transaction.Cashmemo frm = new Transaction.Cashmemo() { s1 = "&Add", Text = "Cash Memo Addition" };
            //var P = ProjectFunctions.GetPositionInForm(this);
            //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
            //frm.ShowDialog(Parent);

        }

        private void CashTender_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.SalePopUPForAllWindows(this, e);
        }
    }
}