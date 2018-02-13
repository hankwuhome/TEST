using System;																												
using System.Collections.Generic;																						   
using Dapper;																											   
using System.Linq;																										   
using System.Web;																										   
using PPPWEBAPI.Models;																									   
using PPPWEBAPI.Models.ViewModels.AccessorySellPriceSetting;																					   
using PPPWEBAPI.Repositories.Interfaces;																				   
using System.Data.SqlClient;																							   
																														   
namespace PPPWEBAPI.Repositories																						   
{																														   
    public partial class CategoryGrossProfitSettingRepository : _BaseRepository<CategoryGrossProfitSettingModel>, ICategoryGrossProfitSettingRepository										   
    {																													   
        #region Public Methods																							   
        public bool AddCategoryGrossProfitSetting(CategoryGrossProfitSettingModel model)																				   
        {																												   
            #region 參數宣告																							   
            var result = false;																							   
            #endregion																									   
																														   
            #region 流程																									 
            AddCategoryGrossProfitSettingSql(model);																							   
            try																											   
            {																											   
                using (var cn = new SqlConnection(_dbConnPPP))															   
                {																										   
                    cn.Open();																							   
                    var ExecResult = cn.Execute(_sqlStr.ToString(), _sqlParams);										   
                }																										   
                result = true;																							   
            }																											   
            catch (Exception ex)																						   
            {																											   
                throw ex;																								   
            }																											   
																														   
            return result;																								   
            #endregion																									   
        }																												   
																														   
        public bool UpdateCategoryGrossProfitSetting(CategoryGrossProfitSettingModel model)																			   
        {																												   
            #region 參數宣告																							   
            var result = false;																							   
            #endregion																									   
																														   
            #region 流程																									 
            UpdateCategoryGrossProfitSettingSql(model);																						   
            try																											   
            {																											   
                using (var cn = new SqlConnection(_dbConnPPP))															   
                {																										   
                    cn.Open();																							   
                    var ExecResult = cn.Execute(_sqlStr.ToString(), _sqlParams);										   
                }																										   
                result = true;																							   
            }																											   
            catch (Exception ex)																						   
            {																											   
                throw ex;																								   
            }																											   
																														   
            return result;																								   
            #endregion																									   
        }																												   
																														   
        public bool DeleteCategoryGrossProfitSetting(CategoryGrossProfitSettingModel model)																			   
        {																												   
            #region 參數宣告																							   
            var result = false;																							   
            #endregion																									   
																														   
            #region 流程																									 
            DeleteCategoryGrossProfitSettingSql(model);																						   
            try																											   
            {																											   
                using (var cn = new SqlConnection(_dbConnPPP))															   
                {																										   
                    cn.Open();																							   
                    var ExecResult = cn.Execute(_sqlStr.ToString(), _sqlParams);										   
                }																										   
                result = true;																							   
            }																											   
            catch (Exception ex)																						   
            {																											   
                throw ex;																								   
            }																											   
																														   
            return result;																								   
            #endregion																									   
        }																												   
        #endregion																										   
																														   
    }																													   
}																														   
