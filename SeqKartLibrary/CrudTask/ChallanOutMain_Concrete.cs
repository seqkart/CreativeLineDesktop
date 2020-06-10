//ChallanOutMain_Concrete
using Dapper;
using SeqKartLibrary;
using SeqKartLibrary.Interfaces;
using SeqKartLibrary.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
//using static DevExpress.DataAccess.Native.DataFederation.QueryBuilder.AvailableItemData;

public class ChallanOutMain_Concrete : IFrmTransaction
{
    string _ConnectionString = "";
    public ChallanOutMain_Concrete()
    {
        _ConnectionString = ProjectFunctionsUtils.ConnectionString;
    }

    public int DeleteChallanOut(int ProductID)
    {
        using (SqlConnection con = new SqlConnection(_ConnectionString))
        {
            con.Open();
            SqlTransaction sqltrans = con.BeginTransaction();
            var param = new DynamicParameters();
            param.Add("@ProductID", ProductID);
            var result = con.Execute("sprocProductTBDeleteSingleItem", param, sqltrans, 0, System.Data.CommandType.StoredProcedure);

            if (result > 0)
            {
                sqltrans.Commit();
            }
            else
            {
                sqltrans.Rollback();
            }
            return result;
        }
    }

    //public List<ChallanOutMain_Model> GetChallanOutMain_List()
    //{
    //    throw new System.NotImplementedException();
    //}

    public List<ChallanOutMain_Model> GetChallanOutMain_List()
    {
        using (SqlConnection con = new SqlConnection(_ConnectionString))
        {
            return con.Query<ChallanOutMain_Model>("sprocProductTBSelectList", null, null, true, 0, System.Data.CommandType.StoredProcedure).ToList();
        }
    }

    public ChallanOutMain_Model GetChallanOut(int ProductID)
    {
        using (SqlConnection con = new SqlConnection(_ConnectionString))
        {
            var param = new DynamicParameters();
            param.Add("@ProductID", ProductID);
            return con.Query("sprocProductTBSelectSingleItem", param, null, true, 0, System.Data.CommandType.StoredProcedure).SingleOrDefault();
        }
    }

    public int InsertChallanOut(ChallanOutMain_Model productmodel)
    {
        using (SqlConnection con = new SqlConnection(_ConnectionString))
        {
            con.Open();
            SqlTransaction sqltrans = con.BeginTransaction();
            var param = new DynamicParameters();
            //param.Add("@ProductID", productmodel.ProductID);
            //param.Add("@ProductName", productmodel.ProductName);
            //param.Add("@Price", productmodel.Price);
            //param.Add("@QuantityperUnit", productmodel.QuantityperUnit);
            //param.Add("@ProductDesc", productmodel.ProductDesc);
            param.Add("@Status", "A");
            var result = con.Execute("sprocProductTBInsertUpdateSingleItem", param, sqltrans, 0, System.Data.CommandType.StoredProcedure);

            if (result > 0)
            {
                sqltrans.Commit();
            }
            else
            {
                sqltrans.Rollback();
            }
            return result;
        }
    }

    public int UpdateChallanOut(ChallanOutMain_Model productmodel)
    {
        using (SqlConnection con = new SqlConnection(_ConnectionString))
        {
            con.Open();
            SqlTransaction sqltrans = con.BeginTransaction();
            var param = new DynamicParameters();
            //param.Add("@ProductID", productmodel.ProductID);
            //param.Add("@ProductName", productmodel.ProductName);
            //param.Add("@Price", productmodel.Price);
            //param.Add("@QuantityperUnit", productmodel.QuantityperUnit);
            //param.Add("@ProductDesc", productmodel.ProductDesc);
            //param.Add("@Status", productmodel.Status);
            var result = con.Execute("sprocProductTBInsertUpdateSingleItem", param, sqltrans, 0, System.Data.CommandType.StoredProcedure);

            if (result > 0)
            {
                sqltrans.Commit();
            }
            else
            {
                sqltrans.Rollback();
            }
            return result;
        }
    }
}