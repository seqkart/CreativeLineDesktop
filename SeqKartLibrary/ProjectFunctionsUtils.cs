using DevExpress.XtraEditors;
using SeqKartLibrary.Repository;
using SeqKartSecurity.Connections;
using System;
using System.Collections.Generic;
using System.Data;

using System.Data.SqlClient;
//using CrystalDecisions.;
using System.Linq;
//using CrystalDecisions.CrystalReports.Engine;
using System.Net;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeqKartLibrary
{
    public class ProjectFunctionsUtils
    {
        public static SpeechSynthesizer _synthesizer = new SpeechSynthesizer();
        public static String ConnectionString = ConnectionStringsDb.DefaultConnectionString;//@"Data Source=seqkart.ddns.net;Initial Catalog=SEQKARTNew;User ID=sa;pwd=Seq@2021";
        //public static String ConnectionString = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\server.txt");

        //public static void SendSMS(string uid, string password, string message, string no)
        //{
        //    HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("http://ubaid.tk/sms/sms.aspx?uid=" + uid + "&pwd=" + password + "&msg=" + message + "&phone=" + no + "&provider=way2sms");
        //    myReq.Credentials = CredentialCache.DefaultNetworkCredentials;
        //    HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
        //    System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
        //    string responseString = respStreamReader.ReadToEnd();
        //    respStreamReader.Close();
        //    myResp.Close();
        //}
        //public static GsmCommMain comm;
        //public static SmsServer;
        //public static void ConnectModem()
        //{
        //    comm = new GsmCommMain(GlobalVariables.PortNo, 9600, 150);
        //    Cursor.Current = Cursors.Default;
        //    bool retry;
        //    do
        //    {
        //        retry = false;
        //        try
        //        {
        //            Cursor.Current = Cursors.WaitCursor;
        //            comm.Open();
        //            Cursor.Current = Cursors.Default;

        //        }
        //        catch (Exception ex)
        //        {
        //            ProjectFunctionsUtils.SpeakError(ex.Message);
        //            comm.Close();
        //        }
        //    }
        //    while (retry);

        //}

        public static void SpeakError(String Error)
        {
            Task.Run(() => _synthesizer.Speak(Error));

            XtraMessageBox.Show(Error);

        }
        public static String CheckNull(String Value)
        {
            if (Value.Trim().Length == 0)
            {
                Value = "0";
            }
            return Value;
        }

        public DataTable ConvertToDataTable(IEnumerable<dynamic> items)
        {
            var t = new DataTable();
            var first = (IDictionary<string, object>)items.First();
            foreach (var k in first.Keys)
            {
                var c = t.Columns.Add(k);
                var val = first[k];
                if (val != null) c.DataType = val.GetType();
            }

            foreach (var item in items)
            {
                var r = t.NewRow();
                var i = (IDictionary<string, object>)item;
                foreach (var k in i.Keys)
                {
                    var val = i[k];
                    if (val == null) val = DBNull.Value;
                    r[k] = val;
                }
                t.Rows.Add(r);
            }
            return t;
        }

        public static DataTable GetDataTable(string Query, bool flag = true)
        {
            try
            {
                var dt = new DataTable();
                var _VarSqlConnection = new SqlConnection(ProjectFunctionsUtils.ConnectionString);
                try
                {
                    _VarSqlConnection.Open();
                    var cmd = new SqlCommand(Query, _VarSqlConnection) { CommandTimeout = 600 };
                    dt.Load(cmd.ExecuteReader());
                    return dt;
                }
                finally
                {
                    if (_VarSqlConnection != null)
                    {
                        _VarSqlConnection.Dispose();
                        dt.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                if (flag)
                {
                    MessageBox.Show("Unable To Fetch Data.\n" + ex.Message);
                }
                return null;
            }
        }
        public static bool CheckRange(DateTime dateToCheck, DateTime startDate, DateTime endDate)
        {
            return dateToCheck.Date >= startDate.Date && dateToCheck.Date <= endDate.Date;
        }
        //public static void SendSMS(String sms,String MobileNo)
        //{
        //    try
        //    {

        //        SmsSubmitPdu pdu;
        //        byte dcs = (byte)DataCodingScheme.GeneralCoding.Alpha7BitDefault;
        //        pdu = new SmsSubmitPdu(sms, MobileNo, "");

        //        comm.SendMessage(pdu);
        //        comm.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        ProjectFunctionsUtils.SpeakError(ex.Message);
        //        comm.Close();
        //    }
        //}

        public static String GetConnection()
        {
            // ; return ConnectionString;


            return ConnectionString;

        }
        public static void NumberOnly(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) != true && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        public static void NumericWithDecimal(KeyPressEventArgs e)
        {
            e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back);
        }
        public static decimal NetRateCalculation(decimal TAXRATE, decimal SURCHARGERATE, decimal RATE)
        {
            var netrate = Math.Round((Convert.ToDecimal(RATE) * 100) / (100 + Convert.ToDecimal(TAXRATE) + (Convert.ToDecimal(TAXRATE) * Convert.ToDecimal(SURCHARGERATE)) / 100), 2);
            return netrate;
        }
        public static string ClipFYearN(string finyear)
        {
            return (finyear.Substring(2, 2) + finyear.Substring(7, 2));
        }

        public static string ClipFYearBarCode(string finyear)
        {
            return (finyear.Substring(2, 2));
        }

        public static Tuple<Decimal, Decimal, Decimal, Decimal> TaxCalculatioData(Decimal CGSTRate, Decimal SGSTRate, Decimal IGSTRate, Decimal RATE, Decimal RDC, Decimal Quantity)
        {
            var disc = Convert.ToDecimal(RDC); ;
            var AmountATRDC = Math.Round((Quantity * RATE * disc) / 100, 2);
            AmountATRDC = (Quantity * RATE) - AmountATRDC;
            var taxableamount = AmountATRDC;
            var CGST = Math.Round((taxableamount * CGSTRate / 100), 2);
            var SGST = Math.Round((taxableamount * SGSTRate / 100), 2);
            var IGST = Math.Round((taxableamount * IGSTRate / 100), 2);
            var RESULT = Tuple.Create(taxableamount, CGST, SGST, IGST);
            return (RESULT);
        }

        public static Tuple<decimal, decimal, decimal, decimal> ReplacementTaxCalculatioData(decimal TAXRATE, decimal SURCHARGERATE, decimal QUANTITY, decimal RATE, decimal RDC, decimal REPL, decimal WSB, decimal ForQuantity, decimal freeQuantity, decimal free)
        {
            decimal s7, s2, s3, s4, s5, s6, s8, s9, s10, taxableamount, NetRateR;
            s7 = Convert.ToDecimal(RATE);
            s2 = Convert.ToDecimal(REPL);
            s3 = Convert.ToDecimal(RDC);
            s4 = Convert.ToDecimal(WSB);
            s5 = Convert.ToDecimal(ForQuantity) + Convert.ToDecimal(freeQuantity);
            s6 = Convert.ToDecimal(ForQuantity);
            s7 = (s7 - (s7 * s2 / 100));
            s8 = (s7 - (s7 * s3 / 100));
            s9 = (s8 - (s8 * s4 / 100));
            if (Convert.ToInt32(ForQuantity) == 0)
            {
                s10 = s9;
            }
            else
            {
                s10 = (s9 * (s6 / s5));
            }
            NetRateR = Math.Round(s10, 2);
            taxableamount = Math.Round(s10, 2) * Convert.ToDecimal(QUANTITY);
            var taxamount = Math.Round((taxableamount * TAXRATE / 100), 2);
            var surchargeamount = Math.Round((taxamount * SURCHARGERATE / 100), 2);
            var RESULT = Tuple.Create(taxableamount, taxamount, surchargeamount, NetRateR);
            return (RESULT);

        }
        public static void TextOnly(KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
        public static DataSet GetDataSet(string Query)
        {
            using (var _VarDataSet = new DataSet())
            {
                try
                {
                    using (var _VarSqlDataAdapter = new SqlDataAdapter(Query, new SqlConnection(GetConnection())))
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
                    System.Diagnostics.Debug.WriteLine("ProjectFunctionUtils => GetDataSet => " + Query);
                    System.Diagnostics.Debug.WriteLine("ProjectFunctionUtils => GetDataSet => " + ex);
                    return null;
                }
            }
        }

        public static DataSet GetDataSet_New(string sqlQuery)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection dbconn = new SqlConnection(GetConnection()))
                {
                    dbconn.Open();
                    bool openConn = (dbconn.State == ConnectionState.Open);
                    if (openConn)
                    {
                        SqlCommand cmd = new SqlCommand(sqlQuery, dbconn);
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds);
                        adp.Dispose();
                        dbconn.Dispose();
                    }
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("===========> " + ex);
            }
            return ds;
        }

        public static Tuple<bool, DataSet> GetDataSet_T(string sqlQuery)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection dbconn = new SqlConnection(GetConnection()))
                {
                    dbconn.Open();
                    bool openConn = (dbconn.State == ConnectionState.Open);
                    if (openConn)
                    {
                        SqlCommand cmd = new SqlCommand(sqlQuery, dbconn);
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds);
                        adp.Dispose();
                        dbconn.Dispose();
                    }
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("===========> " + ex);
            }

            bool hasData = false;
            try
            {
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        hasData = true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("===========> " + ex);
            }
            return new Tuple<bool, DataSet>(hasData, ds);
        }

        public static int InsertQuery(String sqlQuery)
        {
            int intResult = -1;
            try
            {
                using (SqlConnection dbconn = new SqlConnection(GetConnection()))
                {
                    dbconn.Open();
                    bool openConn = (dbconn.State == ConnectionState.Open);
                    if (openConn)
                    {
                        SqlCommand cmd = new SqlCommand(sqlQuery, dbconn);

                        intResult = cmd.ExecuteNonQuery();
                        cmd.Dispose();

                        dbconn.Dispose();
                    }
                }

                //SqlConnection sqlconn = new SqlConnection(GetConnection());
                //sqlconn.Open();
                //SqlCommand cmd = new SqlCommand(sqlQuery, sqlconn);
                //cmd.ExecuteNonQuery();
                //cmd.Dispose();
                //sqlconn.Close();
                //sqlconn.Dispose();
            }
            catch// (Exception ex)
            {

            }
            return intResult;
        }

        public static List<GridView_Style_Model> GridView_Style(string form_name, string gridview_name)
        {
            RepList<object> repList = new RepList<object>();
            List<GridView_Style_Model> gridView_Style_List = new List<GridView_Style_Model>();
            try
            {
                gridView_Style_List = repList.returnListClass_1<GridView_Style_Model>("SELECT * FROM GridViewStyle_Master WHERE form_name='" + form_name + "' AND gridview_name='" + gridview_name + "'", null);

                //ds = ProjectFunctionsUtils.GetDataSet("SELECT * FROM GridViewStyle_Master WHERE form_name='" + form_name + "' AND gridview_name='" + gridview_name + "'");
            }
            catch (Exception ex)
            {

            }
            return gridView_Style_List;
        }

        public static String SqlString(string Text)
        {
            return string.Concat(Text.Select(c => @"'()%#!<>{};:?/\-[]+@".IndexOf(c) >= 0 ? '_' : c));
        }


        public static void SendMessage(string smsMessage, string SenderId, string MobileNos)
        {
            smsMessage.Replace('#', '_');

            //////////////-----   //http://msg.smscluster.com/rest/services/sendSMS/sendGroupSms?AUTH_KEY=YourAuthKey&message=message&senderId=dddddd&routeId=1&mobileNos=9999999999&smsContentType=english


            var uri = @"http://msg.smscluster.com/rest/services/sendSMS/sendGroupSms?AUTH_KEY=8ef012ac2bbcaaf804bd6e9c7a5712b&message=" + smsMessage + "&senderId=" + SenderId + "&routeId=1&mobileNos=" + MobileNos + "&smsContentType=english";

            var request = HttpWebRequest.Create(uri) as HttpWebRequest;
            try
            {
                //request.Method = "GET";
                //if (request.Method == "GET")
                //{
                //    var response = (HttpWebResponse)request.GetResponse();
                //    var receiveStream = response.GetResponseStream();

                //    var readStream = new StreamReader(receiveStream, Encoding.UTF8);
                //    if (readStream.ReadToEnd().ToString().Contains("3001"))
                //    {
                //        ProjectFunctionsUtils.SpeakError(smsMessage + "/ Message Send Successfully");

                //    }
                //    else
                //    {
                //ProjectFunctionsUtils.SpeakError(smsMessage + "/ Unable To Send Message");

                //    }
                //    response.Close();
                //    readStream.Close();
                //}

                ProjectFunctionsUtils.SpeakError("Unable To Send Message");
            }
            catch (Exception ex)
            {
                ProjectFunctionsUtils.SpeakError(ex.Message);
            }
            finally
            {
                request = null;
                GC.Collect();
            }
        }


        //public static void sendsmsviagatepass(String Message)
        //{
        //    string serverURL1 = "167.114.117.218";//eg IP or Domain     
        //    string authkey1 = "d93f366bc185af6158755201ab143ab"; // "Sample Auth key" 'eg -- 16 digits alphanumeric;
        //    string message1 = "Sample message"; //eg "message hello ";
        //    string senderId1 = "testing";//eg -- TestinG 6 Alphabet'
        //    string routeId1 = "1";// eg 1;
        //    string mobileNos1 = "9855630394";//eg '99999999xx,99999998xx
        //    string smsContentType1 = "english";//or Unicode
        //    string groupId1 = "1";// eg 1

        //    string scheduledate1 = string.Empty; //optional if(scheduledate  eg “26/08/2015 17:00”);
        //    string signature1 = string.Empty; //optional if(signature available  eg “1”);
        //    string groupName = string.Empty;//optional if(groupName available eg “1”);

        //    Sendsms.HitApi hitAPI = new Sendsms.HitApi();
        //    hitAPI.hitGetApi(serverURL1, authkey1, Message, senderId1, routeId1, mobileNos1, smsContentType1, groupId1, null, signature1, groupName);

        //}
        public static DataSet GetMasterFormAdd(string ProgCode)
        {
            DataSet dsMaster = GetDataSet("Select ProgCode,Mode,Caption,FormName from MasterAddEdit Where ProgCode='" + ProgCode + "' And Mode='ADD'");
            if (dsMaster.Tables[0].Rows.Count > 0)
            { return dsMaster; }
            return null;
        }
        public static DataSet GetMasterFormEdit(string ProgCode)
        {
            DataSet dsMaster = GetDataSet("Select ProgCode,Mode,Caption,FormName from MasterAddEdit Where ProgCode='" + ProgCode + "' And Mode='EDIT'");
            if (dsMaster.Tables[0].Rows.Count > 0)
            { return dsMaster; }
            return null;
        }
        /*
        public static void SaveNewMasterRecord(String ProcedureName, XtraForm FormName)
        {
            DataSet dsMaster = GetDataSet("select PARAMETER_NAME from information_schema.parameters where specific_name='" + ProcedureName + "'");
            using (var sqlcon = new SqlConnection(GetConnection()))
            {
                sqlcon.Open();
                var sqlcom = new SqlCommand();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = ProcedureName;
                sqlcom.Connection = sqlcon;
                if (dsMaster.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsMaster.Tables[0].Rows)
                    {
                        foreach (Control C in FormName.Controls)
                        {
                            if (dr["PARAMETER_NAME"].ToString().Replace("@", string.Empty).ToUpper() == C.Name.Replace("TextEdit", string.Empty).Trim().ToUpper())
                            {
                                sqlcom.Parameters.AddWithValue(dr["PARAMETER_NAME"].ToString(), (C as TextEdit).EditValue);
                            }
                        }
                    }
                    sqlcom.ExecuteNonQuery();
                    sqlcon.Close();
                }
            }
        }
        */

        public static void SaveDataTable(String ProcedureName, DataTable dtFinal)
        {
            DataSet dsMaster = GetDataSet("select PARAMETER_NAME from information_schema.parameters where specific_name='" + ProcedureName + "'");
            using (var sqlcon = new SqlConnection(GetConnection()))
            {
                sqlcon.Open();
                var sqlcom = new SqlCommand
                {
                    Connection = sqlcon
                };
                if (dsMaster.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtOuter in dtFinal.Rows)
                    {
                        sqlcom.CommandType = CommandType.StoredProcedure;
                        sqlcom.CommandText = ProcedureName;
                        foreach (DataRow dr in dsMaster.Tables[0].Rows)
                        {
                            foreach (DataColumn C in dtFinal.Columns)
                            {
                                if (dr["PARAMETER_NAME"].ToString().Replace("@", string.Empty).ToUpper() == C.ColumnName.ToUpper())
                                {
                                    sqlcom.Parameters.AddWithValue(dr["PARAMETER_NAME"].ToString(), dr[C.ColumnName]);
                                }
                            }
                        }
                        sqlcom.ExecuteNonQuery();
                        sqlcom.Parameters.Clear();
                    }
                    sqlcon.Close();
                }
            }
        }


        public static String ValidateKeysForSearchBox(KeyEventArgs e)
        {
            String Value = String.Empty;
            switch (e.KeyCode)
            {
                case Keys.NumPad1:
                    Value = "1";
                    break;
                case Keys.NumPad2:
                    Value = "2";
                    break;
                case Keys.NumPad3:
                    Value = "3";
                    break;
                case Keys.NumPad4:
                    Value = "4";
                    break;
                case Keys.NumPad5:
                    Value = "5";
                    break;
                case Keys.NumPad6:
                    Value = "6";
                    break;
                case Keys.NumPad7:
                    Value = "7";
                    break;
                case Keys.NumPad8:
                    Value = "8";
                    break;
                case Keys.NumPad9:
                    Value = "9";
                    break;
                case Keys.NumPad0:
                    Value = "0";
                    break;

                default:
                    Value = ((char)e.KeyValue).ToString();
                    break;
            }
            return Value;
        }

        public static string GetNewTransactionCode(String Query)
        {
            String s2 = String.Empty;
            DataSet ds = ProjectFunctionsUtils.GetDataSet(Query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString();
                s2 = (Convert.ToInt32(s2) + 1).ToString();
            }
            return s2;
        }

        public static Decimal RoundFive(Decimal No)
        {
            No = ((int)(No / 5)) * 5;
            return No;
        }

        public static bool CheckAllPossible(String ArticleID, Decimal MRP, String ColorID, String SizeID)
        {
            DataSet dsCheckART = ProjectFunctionsUtils.GetDataSet("select ARTSYSID,ARTMRP from ARTICLE where ARTSYSID='" + ArticleID + "' ");
            if (dsCheckART.Tables[0].Rows.Count > 0)
            {
                if (MRP == Convert.ToDecimal(dsCheckART.Tables[0].Rows[0]["ARTMRP"]))
                {

                }
                else
                {
                    ProjectFunctionsUtils.SpeakError("Wrong MRP Found");
                    return false;
                }
            }
            else
            {
                ProjectFunctionsUtils.SpeakError("No Article Found");
                return false;
            }

            DataSet dsCheckColor = ProjectFunctionsUtils.GetDataSet("select COLSYSID from COLOURS where COLSYSID='" + ColorID + "' ");
            if (dsCheckColor.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                ProjectFunctionsUtils.SpeakError("No Color Found");
                return false;
            }
            DataSet dsCheckSize = ProjectFunctionsUtils.GetDataSet("select SZSYSID from SIZEMAST where SZSYSID='" + SizeID + "' ");
            if (dsCheckSize.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                ProjectFunctionsUtils.SpeakError("No Size Found");
                return false;
            }
            return true;

        }



        public static void EventTracker(String ProcessName, string ProgCode, string CurrentUser)
        {
            using (var sqlcon = new SqlConnection(GetConnection()))
            {
                sqlcon.Open();
                var sqlcom = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "sp_InsertEventData",
                    Connection = sqlcon
                };
                sqlcom.Parameters.AddWithValue("@ProgCode", ProgCode);
                sqlcom.Parameters.AddWithValue("@EventDesc", ProcessName);
                sqlcom.Parameters.AddWithValue("@UserName", CurrentUser);
                sqlcom.Parameters.AddWithValue("@EventDatetime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                sqlcom.ExecuteNonQuery();
                sqlcon.Close();
            }
        }

        public static string GetNewEmpCode()
        {
            string sql = SQL_QUERIES._frmEmployeeMstAddEdit._GetNewEmpCode();

            String s2 = String.Empty;
            DataSet ds = GetDataSet(sql);//"select isnull(max(Cast(EmpCode as int)),00000) from EmpMst"
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString();
                //s2 = (Convert.ToInt32(s2) + 1).ToString();
            }
            return s2;
        }

        public static string GetNewDeptCode()
        {
            string sql = SQL_QUERIES._frmDepartmentAddUpdate._GetNewDeptCode(); ;
            //"select isnull(max(Cast(DeptCode as int)),00000) from DeptMSt"
            String s2 = String.Empty;
            DataSet ds = GetDataSet(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString();
                //s2 = (Convert.ToInt32(s2) + 1).ToString();
            }
            return s2;
        }

        public static string GetNewDesgCode()
        {
            string sql = SQL_QUERIES._frmDesignationAddUpdate._GetNewDesgCode();
            String s2 = String.Empty;
            DataSet ds = GetDataSet(sql);//"select isnull(max(Cast(DesgCode as int)),00000) from DesgMst"
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString();
                //s2 = (Convert.ToInt32(s2) + 1).ToString();
            }
            return s2;
        }
        public static string GetDateChangePassword()
        {
            RepGen repGen = new RepGen();

            string pass = repGen.returnScalar("SELECT password FROM tbl_Passwords WHERE p_type='entry_date_edit'", new Dapper.DynamicParameters());

            return pass;

        }

    }
}
