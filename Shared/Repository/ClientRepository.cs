using Shared.Data;
using Model.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Shared.Repository
{
    public class ClientRepository
    {
        public List<ClientModel> GetClients()
        {
            var list = new List<ClientModel>();

            string sql = "SELECT LOGICALREF, CODE, DEFINITION_ FROM LG_001_CLCARD";
            DataTable dt = SqlHelper.Select(sql);

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new ClientModel
                {
                    LOGICALREF = Convert.ToInt32(dr["LOGICALREF"]),
                    CODE = dr["CODE"]?.ToString() ?? "",
                    DEFINITION_ = dr["DEFINITION_"]?.ToString() ?? ""
                });
            }

            return list;
        }

        public List<ClientModel> Search(string code, string definition)
        {
            string sql = "SELECT LOGICALREF, CODE, DEFINITION_ FROM LG_001_CLCARD WHERE 1=1";
            List<SqlParameter> prms = new();

            if (!string.IsNullOrEmpty(code))
            {
                sql += " AND CODE LIKE @code";
                prms.Add(new SqlParameter("@code", "%" + code + "%"));
            }

            if (!string.IsNullOrEmpty(definition))
            {
                sql += " AND DEFINITION_ LIKE @def";
                prms.Add(new SqlParameter("@def", "%" + definition + "%"));
            }

            DataTable dt = SqlHelper.Select(sql, prms.ToArray());
            List<ClientModel> list = new();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new ClientModel
                {
                    LOGICALREF = Convert.ToInt32(dr["LOGICALREF"]),
                    CODE = dr["CODE"]?.ToString() ?? "",
                    DEFINITION_ = dr["DEFINITION_"]?.ToString() ?? ""
                });
            }

            return list;
        }

        public void Create(string code, string definition)
        {
            string sql = @"
                INSERT INTO LG_001_CLCARD (CODE, DEFINITION_, ACTIVE, CARDTYPE)
                VALUES (@c, @d, 0, 3)";

            SqlHelper.Execute(sql,
                new SqlParameter("@c", code),
                new SqlParameter("@d", definition));
        }

        public bool Update(int id, string code, string definition)
        {
            string sql = @"
                UPDATE LG_001_CLCARD
                SET CODE = @c, DEFINITION_ = @d
                WHERE LOGICALREF = @id";

            return SqlHelper.Execute(sql,
                new SqlParameter("@id", id),
                new SqlParameter("@c", code),
                new SqlParameter("@d", definition)) > 0;
        }

        public bool Delete(int id)
        {
            string sql = "DELETE FROM LG_001_CLCARD WHERE LOGICALREF = @id";
            return SqlHelper.Execute(sql, new SqlParameter("@id", id)) > 0;
        }
    }
}