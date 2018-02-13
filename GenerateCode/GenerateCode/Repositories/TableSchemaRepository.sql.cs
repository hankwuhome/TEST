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
        
        #endregion

        #region  Methods
        public void QueryTableFieldsSql(string tableName)
        {
            _sqlStr = new StringBuilder();
            _sqlStr.Append(" SELECT COLUMN_NAME AS FieldName ");
            _sqlStr.Append("      , DATA_TYPE AS DBType ");
            _sqlStr.Append(" FROM INFORMATION_SCHEMA.COLUMNS"); 
            _sqlStr.Append(string.Format(" WHERE TABLE_NAME = '{0}' ", tableName));
        }
        #endregion
    }
}
