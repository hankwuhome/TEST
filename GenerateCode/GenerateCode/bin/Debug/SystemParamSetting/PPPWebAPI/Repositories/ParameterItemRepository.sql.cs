using System;																								
using System.Collections.Generic;																		  
using System.Linq;																						  
using System.Text;																						  
using System.Web;																						  
using Dapper;																							  
using PPPWEBAPI.Extensions;																				  
using PPPWEBAPI.Models;																					  
using PPPWEBAPI.Models.ViewModels.SystemParamSetting;																	  
using PPPWEBAPI.Repositories.Interfaces;																  
																										  
namespace PPPWEBAPI.Repositories																		  
{																										  
    public partial class ParameterItemRepository : _BaseRepository<ParameterItemModel>, IParameterItemRepository						  
    {																									  
        #region Private Methods																			  
        private bool AddParameterItemSql(ParameterItemModel model)															  
        {																								  
            // 設定主SQL, _sqlStr 中不可以包含 ORDER BY													 
            _sqlStr = new StringBuilder();																  
            //_sqlStr.Append("主要SQL語法 ");															  
																										  
            //設定參數 																					  
            _sqlParams = new Dapper.DynamicParameters();												  
            //_sqlParams.Add("參數", model.參數);														  
            return true;																				  
        }																								  
																										  
        private bool UpdateParameterItemSql(ParameterItemModel model)														  
        {																								  
            // 設定主SQL												 
            _sqlStr = new StringBuilder();																  
            //_sqlStr.Append("主要SQL語法 ");															  
																										  
            //設定參數 																					  
            _sqlParams = new Dapper.DynamicParameters();												  
            //_sqlParams.Add("參數", model.參數);														  
            return true;																				  
        }																								  
																										  
        private bool DeleteParameterItemSql(ParameterItemModel model)														  
        {																								  
            // 設定主SQL												 
            _sqlStr = new StringBuilder();																  
            //_sqlStr.Append("主要SQL語法 ");															  
																										  
            //設定參數 																					  
            _sqlParams = new Dapper.DynamicParameters();												  
            //_sqlParams.Add("參數", model.參數);														  
            return true;																				  
        }																								  
																										  
        #endregion																						  
																										  
    }																									  
}																										  
