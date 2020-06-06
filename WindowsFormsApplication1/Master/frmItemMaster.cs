using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmItemMaster : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String ITMSYSID { get; set; }
        public frmItemMaster()
        {
            InitializeComponent();
        }

        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.DatePickerVisualize(this);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            txtItemName.Properties.MaxLength = 150;
            txtItemSubGroup.Properties.MaxLength = 55;
            txtRackNo.Properties.MaxLength = 10;
            txtRackLocation.Properties.MaxLength = 55;
            txtSysID.Enabled = false;

        }
        private void BtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmItemMaster_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtItemCode.Focus();
            }
            if (s1 == "Edit")
            {
                txtItemCode.Enabled = false;
                DataSet ds = ProjectFunctions.GetDataSet("Select * from ITEMMAST Where  ITMSYSID='" + ITMSYSID + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtSysID.Text = ds.Tables[0].Rows[0]["ITMSYSID"].ToString();
                    txtItemCode.Text = ds.Tables[0].Rows[0]["ITMCODE"].ToString();
                    txtItemName.Text = ds.Tables[0].Rows[0]["ITMNAME"].ToString();
                    txtItemSubGroup.Text = ds.Tables[0].Rows[0]["ITMSUBGROUP"].ToString();
                    txtUOM.Text = ds.Tables[0].Rows[0]["ITMUOM"].ToString();
                    txtCurrentStock.Text = ds.Tables[0].Rows[0]["ITMCURSTK"].ToString();
                    txtItemWeight.Text = ds.Tables[0].Rows[0]["ITMWEIGHT"].ToString();
                    txtItemWeightPerQty.Text = ds.Tables[0].Rows[0]["ITMWEIGHTPERQTY"].ToString();
                    txtMaxLevel.Text = ds.Tables[0].Rows[0]["ITMMAXSTK"].ToString();
                    txtMinLevel.Text = ds.Tables[0].Rows[0]["ITMMINSTK"].ToString();
                    txtOpBal.Text = ds.Tables[0].Rows[0]["ITMOPBAL"].ToString();
                    txtOPBalDate.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["ITMOPBLDT"]);
                    txtPurchasePrice.Text = ds.Tables[0].Rows[0]["ITMPURPRICE"].ToString();
                    txtRackLocation.Text = ds.Tables[0].Rows[0]["ITMRACLOC"].ToString();
                    txtRackNo.Text = ds.Tables[0].Rows[0]["ITMRACNO"].ToString();
                    txtTotalIssued.Text = ds.Tables[0].Rows[0]["ITMTOTOUT"].ToString();
                    txtTotalReceived.Text = ds.Tables[0].Rows[0]["ITMTOTIN"].ToString();
                }
                txtItemName.Focus();
            }
        }
        private bool ValidateData()
        {
            if (txtItemCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Item Code");
                txtItemCode.Focus();
                return false;
            }
            if (txtItemName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Item Name");
                txtItemName.Focus();
                return false;
            }

            if (txtUOM.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Unit Of Measurement");
                txtUOM.Focus();
                return false;
            }
            if (txtOPBalDate.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Opening Balance Date");
                txtOPBalDate.Focus();
                return false;
            }
            if (txtCurrentStock.Text.Trim().Length == 0)
            {
                txtCurrentStock.Text = "0";
            }
            if (txtItemWeight.Text.Trim().Length == 0)
            {
                txtItemWeight.Text = "0";
            }
            if (txtMaxLevel.Text.Trim().Length == 0)
            {
                txtMaxLevel.Text = "0";
            }
            if (txtMinLevel.Text.Trim().Length == 0)
            {
                txtMinLevel.Text = "0";
            }
            if (txtOpBal.Text.Trim().Length == 0)
            {
                txtOpBal.Text = "0";
            }
            if (txtPurchasePrice.Text.Trim().Length == 0)
            {
                txtPurchasePrice.Text = "0";
            }
            if (txtTotalIssued.Text.Trim().Length == 0)
            {
                txtTotalIssued.Text = "0";
            }
            if (txtTotalReceived.Text.Trim().Length == 0)
            {
                txtTotalReceived.Text = "0";
            }
            if (txtItemWeightPerQty.Text.Trim().Length == 0)
            {
                txtItemWeightPerQty.Text = "0";
            }

            return true;
        }



        private void FrmItemMaster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                System.Windows.Forms.SendKeys.Send("+{TAB}");
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                using (var sqlcon = new SqlConnection(ProjectFunctions.GetConnection()))
                {
                    sqlcon.Open();
                    var sqlcom = sqlcon.CreateCommand();
                    var transaction = sqlcon.BeginTransaction("SaveTransaction");
                    sqlcom.Connection = sqlcon;
                    sqlcom.Transaction = transaction;
                    sqlcom.CommandType = CommandType.Text;
                    try
                    {
                        if (s1 == "&Add")
                        {
                            sqlcom.CommandText = " Insert into ITEMMAST"
                                                 + " (ITMCODE,ITMNAME,ITMSUBGROUP,ITMUOM,ITMPURPRICE,ITMRACNO,ITMRACLOC,"
                                                 + " ITMOPBAL,ITMOPBLDT,ITMTOTIN,ITMTOTOUT,"
                                                 + " ITMMINSTK,ITMMAXSTK,ITMCURSTK,ITMWEIGHT,ITMWEIGHTPERQTY)"
                                                 + " values(@ITMCODE,@ITMNAME,@ITMSUBGROUP,@ITMUOM,@ITMPURPRICE,@ITMRACNO,@ITMRACLOC,"
                                                 + " @ITMOPBAL,@ITMOPBLDT,@ITMTOTIN,@ITMTOTOUT,"
                                                 + " @ITMMINSTK,@ITMMAXSTK,@ITMCURSTK,@ITMWEIGHT,@ITMWEIGHTPERQTY)";


                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE ITEMMAST SET "
                                                + " ITMCODE=@ITMCODE,ITMNAME=@ITMNAME,ITMSUBGROUP=@ITMSUBGROUP,ITMUOM=@ITMUOM,ITMPURPRICE=@ITMPURPRICE, "
                                                + " ITMRACNO=@ITMRACNO,ITMRACLOC=@ITMRACLOC,ITMOPBAL=@ITMOPBAL,ITMOPBLDT=@ITMOPBLDT, "
                                                + " ITMTOTIN=@ITMTOTIN,ITMTOTOUT=@ITMTOTOUT,ITMMINSTK=@ITMMINSTK,ITMMAXSTK=@ITMMAXSTK,ITMCURSTK=@ITMCURSTK, "
                                                + " ITMWEIGHT=@ITMWEIGHT,ITMWEIGHTPERQTY=@ITMWEIGHTPERQTY "
                                                + " Where ITMSYSID=@ITMSYSID";
                            sqlcom.Parameters.AddWithValue("@ITMSYSID", txtSysID.Text.Trim());
                        }

                        sqlcom.Parameters.AddWithValue("@ITMCODE", txtItemCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@ITMNAME", txtItemName.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@ITMSUBGROUP", txtItemSubGroup.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@ITMUOM", txtUOM.SelectedItem);
                        sqlcom.Parameters.AddWithValue("@ITMPURPRICE", Convert.ToDecimal(txtPurchasePrice.Text));
                        sqlcom.Parameters.AddWithValue("@ITMRACNO", txtRackNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@ITMRACLOC", txtRackLocation.Text.Trim());

                        sqlcom.Parameters.AddWithValue("@ITMOPBAL", Convert.ToDecimal(txtOpBal.Text));
                        sqlcom.Parameters.AddWithValue("@ITMOPBLDT", Convert.ToDateTime(txtOPBalDate.Text).ToString("yyyy-MM-dd"));
                        sqlcom.Parameters.AddWithValue("@ITMTOTIN", Convert.ToDecimal(txtTotalReceived.Text));
                        sqlcom.Parameters.AddWithValue("@ITMTOTOUT", Convert.ToDecimal(txtTotalIssued.Text));
                        sqlcom.Parameters.AddWithValue("@ITMMINSTK", Convert.ToDecimal(txtMinLevel.Text));
                        sqlcom.Parameters.AddWithValue("@ITMMAXSTK", Convert.ToDecimal(txtMaxLevel.Text));
                        sqlcom.Parameters.AddWithValue("@ITMCURSTK", Convert.ToDecimal(txtCurrentStock.Text));
                        sqlcom.Parameters.AddWithValue("@ITMWEIGHT", Convert.ToDecimal(txtItemWeight.Text));
                        sqlcom.Parameters.AddWithValue("@ITMWEIGHTPERQTY", Convert.ToDecimal(txtItemWeightPerQty.Text));

                        sqlcom.ExecuteNonQuery();
                        transaction.Commit();
                        sqlcon.Close();

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        ProjectFunctions.SpeakError("Something Wrong. \n I am going to Roll Back." + ex.Message);
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception ex2)
                        {
                            ProjectFunctions.SpeakError("Something Wrong. \n Roll Back Failed." + ex2.Message);
                        }
                    }
                }
            }
        }

        private void TxtCurrentStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }
    }
}