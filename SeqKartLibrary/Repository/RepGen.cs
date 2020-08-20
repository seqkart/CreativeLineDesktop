using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SeqKartLibrary.Repository
{
    public enum ExecuteStatus
    {
        OK,
        FAILED,
        PENDING
    }
    public class ExecuteResult
    {
        public int Result { get; set; }

        public string ExceptionMessage { get; set; }

        public ExecuteStatus Status { get; set; }
    }
    public class RepGen
    {

        public SqlConnection con;
        private void connection()
        {
            con = new SqlConnection(ProjectFunctionsUtils.ConnectionString);
        }

        public async Task<string> executeNonQuery_Async(string query, DynamicParameters param)
        {
            try
            {
                connection();
                con.Open();
                await con.ExecuteAsync(query, param, commandType: CommandType.Text);
                con.Close();
                return "0";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public async Task<string> executeNonQuery_SP_Async(string query, DynamicParameters param)
        {
            try
            {
                connection();
                con.Open();
                await con.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
                con.Close();
                return "0";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string executeNonQuery(string query, DynamicParameters param)
        {
            try
            {
                connection();
                con.Open();
                con.Execute(query, param, commandType: CommandType.StoredProcedure);
                con.Close();
                return "0";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public ExecuteResult executeNonQuery_Query(string query, DynamicParameters param)
        {
            ExecuteResult executeResult = new ExecuteResult();
            try
            {
                connection();
                con.Open();
                executeResult.Result = con.Execute(query, param, commandType: CommandType.Text);
                con.Close();

                executeResult.Status = ExecuteStatus.OK;


            }
            catch (Exception ex)
            {
                executeResult.ExceptionMessage = ex.Message;
                executeResult.Status = ExecuteStatus.FAILED;
            }
            return executeResult;
        }

        public string executeNonQuery_SP(string query, DynamicParameters param)
        {
            try
            {

                connection();
                con.Open();
                con.Execute(query, param, commandType: CommandType.StoredProcedure);
                con.Close();
                return "0";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public int executeNonQuery_SP(string query, DynamicParameters param, bool hasOutput, out int outputVal)
        {
            outputVal = 0;
            try
            {
                param.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                param.Add("@Returnvalue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                connection();
                con.Open();
                con.Execute(query, param, commandType: CommandType.StoredProcedure);
                con.Close();

                outputVal = param.Get<int>("@output");
                var returnVal = param.Get<int>("@Returnvalue");
                return returnVal;
            }
            catch (Exception ex)
            {
                //return ex.Message;
            }
            return -1;

        }

        public string returnScalar(string query, DynamicParameters param)
        {
            try
            {
                string valor = "";
                connection();
                con.Open();
                valor = con.ExecuteScalar<string>(query, param, commandType: CommandType.Text);
                con.Close();
                return valor;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string returnScalar_SP(string query, DynamicParameters param)
        {
            try
            {
                string valor = "";
                connection();
                con.Open();
                valor = con.ExecuteScalar<string>(query, param, commandType: CommandType.StoredProcedure);
                con.Close();
                return valor;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string returnNumericValue(string query, DynamicParameters param)
        {
            try
            {
                string valor = "";
                param.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                param.Add("@Returnvalue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                // Getting Return value   
                connection();
                con.Open();
                valor = con.ExecuteScalar<string>(query, param, commandType: CommandType.StoredProcedure);
                con.Close();
                return valor;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }



    }
}

