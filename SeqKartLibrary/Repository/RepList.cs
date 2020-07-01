using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace SeqKartLibrary.Repository
{
    public class RepList<T> where T : class
    {
        
        public SqlConnection con;
        private void connection()
        {
            con = new SqlConnection(ProjectFunctionsUtils.ConnectionString);
        }
        public List<T> returnListClass(string query, DynamicParameters param)
        {
            try
            {
                connection();
                con.Open();
                IList<T> Tlista = SqlMapper.Query<T>(con, query, param, null, true, null, commandType: CommandType.Text).ToList();
                con.Close();
                return Tlista.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<T> returnListClass_SP(string query, DynamicParameters param)
        {
            try
            {
                connection();
                con.Open();
                IList<T> Tlista = SqlMapper.Query<T>(con, query, param, null, true, null, commandType: CommandType.StoredProcedure).ToList();
                con.Close();
                return Tlista.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T returnClass_SP(string query, DynamicParameters param)
        {
            try
            {
                connection();
                con.Open();
                //     return this.con.Query( query, param, null, true, null, commandType: CommandType.StoredProcedure).FirstOrDefault();
                T Tlista = SqlMapper.Query<T>(con, query, param, null, true, null, commandType: CommandType.StoredProcedure).FirstOrDefault();
                con.Close();
                return Tlista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T returnClass(string query, DynamicParameters param)
        {
            try
            {
                connection();
                con.Open();
                //     return this.con.Query( query, param, null, true, null, commandType: CommandType.StoredProcedure).FirstOrDefault();
                T Tlista = SqlMapper.Query<T>(con, query, param, null, true, null, commandType: CommandType.Text).FirstOrDefault();
                con.Close();
                return Tlista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<T1> returnListClass_1<T1>(string query, DynamicParameters param)
        {
            try
            {
                connection();
                con.Open();
                IList<T1> Tlista = SqlMapper.Query<T1>(con, query, param, null, true, null, commandType: CommandType.Text).ToList();
                con.Close();
                return Tlista.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<T1> returnListClass_SP_1<T1>(string query, DynamicParameters param)
        {
            try
            {
                connection();
                con.Open();
                IList<T1> Tlista = SqlMapper.Query<T1>(con, query, param, null, true, null, commandType: CommandType.StoredProcedure).ToList();
                con.Close();
                return Tlista.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
