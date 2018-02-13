using Dapper;
using GenerateCode.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCode.Repositories
{
    partial class TableSchemaRepository
    {
        #region Properties
        private StringBuilder _sqlStr;
        private DynamicParameters _sqlParams;
        private string _dbConnPPP = ConfigurationManager.ConnectionStrings["PPPWEB"].ToString();
        #endregion

        #region  Methods
        public List<TableFieldViewModel> QueryTableFields(string tableName)
        {
            #region 參數宣告
            List<TableFieldViewModel> result = new List<TableFieldViewModel>();
            #endregion

            #region 流程
            QueryTableFieldsSql(tableName);

            using (var cn = new SqlConnection(_dbConnPPP))
            {
                result = cn.Query<TableFieldViewModel>(_sqlStr.ToString(), _sqlParams).ToList();
            }

            return result;
            #endregion
        }
        #endregion
    }
}
