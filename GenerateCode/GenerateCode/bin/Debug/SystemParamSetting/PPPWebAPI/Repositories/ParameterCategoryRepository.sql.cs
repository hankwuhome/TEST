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
    public partial class ParameterCategoryRepository : _BaseRepository<ParameterCategoryModel>, IParameterCategoryRepository						  
    {																									  
        #region Private Methods																			  
        private bool QuerySearchListSql(SearchInfoViewModel searchInfo)									  
        {																								  
            // 設定主SQL, _sqlStr 中不可以包含 ORDER BY													 
            _sqlStr = new StringBuilder();																  
            //_sqlStr.Append(" 主要SQL語法 ");															  
																										  
            //設定排序SQL																				  
            _sqlOrderByStr = searchInfo.GetOrderByFromSort(SearchInfoViewModel.EnumSort.DEFAULT);		  
																										  
            //設定參數 																					  
            _sqlParams = new Dapper.DynamicParameters();												  
            //_sqlParams.Add("參數", searchInfo.參數);													  
																										  
            return true;																				  
        }																								  
																										  
        private bool QueryDetailSql(DetailRequestViewModel detailRequest)								  
        {																								  
            // 設定主SQL, _sqlStr 中不可以包含 ORDER BY													 
            _sqlStr = new StringBuilder();																  
            //_sqlStr.Append("主要SQL語法 ");															  
																										  
            //設定排序SQL																				  
            //_sqlOrderByStr = detailRequest.GetOrderByFromSort(DetailRequestViewModel.EnumSort.DEFAULT); 
																										  
            //設定參數 																					  
            _sqlParams = new Dapper.DynamicParameters();												  
            //_sqlParams.Add("參數", detailRequest.參數);												  
            return true;																				  
        }																								  
																										  
        private bool AddParameterCategorySql(ParameterCategoryModel model)															  
        {																								  
            // 設定主SQL, _sqlStr 中不可以包含 ORDER BY													 
            _sqlStr = new StringBuilder();																  
            //_sqlStr.Append("主要SQL語法 ");															  
																										  
            //設定參數 																					  
            _sqlParams = new Dapper.DynamicParameters();												  
            //_sqlParams.Add("參數", model.參數);														  
            return true;																				  
        }																								  
																										  
        private bool UpdateParameterCategorySql(ParameterCategoryModel model)														  
        {																								  
            // 設定主SQL												 
            _sqlStr = new StringBuilder();																  
            //_sqlStr.Append("主要SQL語法 ");															  
																										  
            //設定參數 																					  
            _sqlParams = new Dapper.DynamicParameters();												  
            //_sqlParams.Add("參數", model.參數);														  
            return true;																				  
        }																								  
																										  
        private bool DeleteParameterCategorySql(ParameterCategoryModel model)														  
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
