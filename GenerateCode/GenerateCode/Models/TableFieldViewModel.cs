using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCode.Models
{
    class TableFieldViewModel
    {
        #region Properties
        public string FieldName { get; set; }
        public string DBType { get; set; }
        #endregion

        #region Public Methods
        public string GetPropertyStr() {
            return string.Concat("        public ", GetDataType(), " ", FieldName, " { get; set;}  ");
        }
        #endregion
        #region Private Methods
        private string GetDataType()
        {
            #region 參數宣告
            string dataType = "string";
            #endregion

            #region 流程
            switch (DBType)
            {
                case "int":
                    dataType = "int";
                    break;
                case "datetime":
                    dataType = "DateTime";
                    break;
                case "numeric":
                    dataType = "Double";
                    break;
                case "uniqueidentifier":
                    dataType = "GUID";
                    break;
            }

            return dataType;
            #endregion
        }

        #endregion
    }
}
