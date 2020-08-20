
using Dapper;
using SeqKartLibrary.Repository;

namespace SeqKartLibrary.CrudTask
{
    public class DesignationData
    {
        public string InsertUpdate(string DesgCode, string DesgDesc, string AddEditTag)
        {
            RepGen reposGen = new RepGen();
            DynamicParameters param = new DynamicParameters();
            param.Add("@DesgCode", DesgCode);
            param.Add("@DesgDesc", DesgDesc);
            param.Add("@AddEditTag", AddEditTag);

            return reposGen.executeNonQuery_SP("sp_DesignationAddUpdate", param);
        }
    }
}