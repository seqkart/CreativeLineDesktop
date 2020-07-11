using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace SeqKartLibrary.Repository
{
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

        public string returnScalar(string query, DynamicParameters param)
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

