using Dapper;
using SeqKartLibrary.Models;
using SeqKartLibrary.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeqKartLibrary.CrudTask
{
    partial class users
    {

        public async Task<string> insertUpdate(user _user)
        {
            RepGen reposGen = new Repository.RepGen();
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", _user.id);
            param.Add("@name", _user.name);
            param.Add("@address", _user.address);
            param.Add("@status", _user.status);
            return await reposGen.executeNonQuery_Async("users_Insert_Update", param);
        }

        public async Task<string> delete(user _user)
        {
            RepGen reposGen = new Repository.RepGen();
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", _user.id);
            return await reposGen.executeNonQuery_Async("users_DeleteRow_By_id", param);
        }

        public List<user> allRecords(user _user)
        {
            RepList<user> lista = new RepList<user>();
            DynamicParameters param = new DynamicParameters();
            return lista.returnListClass("users_SelectAll", param);

        }

        public List<user> AllRecordsById(string id)
        {
            RepList<user> lista = new RepList<user>();
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", id);
            return lista.returnListClass("users_SelectRow_By_id", param);
        }

        public user findById(string id)
        {
            RepList<user> class_usu = new RepList<user>();
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", id);
            return class_usu.returnClass("users_SelectRow_By_id", param);
        }

        public List<dynamic> dynamicsList()
        {
            //Funciones FG = new Funciones();
            DynamicParameters param = new DynamicParameters();
            Repository.RepList<dynamic> repo = new Repository.RepList<dynamic>();
            var items = repo.returnListClass("users_SelectwithDate", param);
            return items;
        }

    }




}
