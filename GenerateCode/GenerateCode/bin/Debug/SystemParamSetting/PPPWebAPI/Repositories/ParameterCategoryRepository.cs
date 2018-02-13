using System;																												
using System.Collections.Generic;																						   
using Dapper;																											   
using System.Linq;																										   
using System.Web;																										   
using PPPWEBAPI.Models;																									   
using PPPWEBAPI.Models.ViewModels.SystemParamSetting;																					   
using PPPWEBAPI.Repositories.Interfaces;																				   
using System.Data.SqlClient;																							   
																														   
namespace PPPWEBAPI.Repositories																						   
{																														   
    public partial class ParameterCategoryRepository : _BaseRepository<ParameterCategoryModel>, IParameterCategoryRepository										   
    {																													   
        #region Public Methods																							   
        public SearchListViewModel QuerySearchList(SearchInfoViewModel searchInfo)										   
        {																												   
            #region 參數宣告																							   
            SearchListViewModel result = new SearchListViewModel();														   
            #endregion																									   
																														   
            #region 流程																									 
            var sql = QuerySearchListSql(searchInfo);																	   
            result.Page = searchInfo.Page;																				   
            result.SearchItemList = new List<SearchItemViewModel>();													   
            using (var cn = new SqlConnection(_dbConnPPP))																   
            {																											   
                result.SearchItemList = cn.Query<SearchItemViewModel>(GetPagingSql(searchInfo.Page), _sqlParams).ToList(); 
                result.Page.TotalCount = cn.Query<int>(GetTotalCountSql(), _sqlParams).ToList().FirstOrDefault();		   
            }																											   
																														   
            return result;																								   
            #endregion																									   
        }																												   
																														   
        public DetailViewModel QueryDetail(DetailRequestViewModel detailRequest)										   
        {																												   
            #region 參數宣告																							   
            DetailViewModel result = new DetailViewModel();																   
            #endregion																									   
																														   
            #region 流程																									 
            QueryDetailSql(detailRequest);																				   
																														   
            using (var cn = new SqlConnection(_dbConnPPP))																   
            {																											   
                result= cn.Query<DetailViewModel>(_sqlStr.ToString(), _sqlParams).ToList().FirstOrDefault();			   
            }																											   
																														   
            return result;																								   
            #endregion																									   
        }																												   
																														   
        public bool AddParameterCategory(ParameterCategoryModel model)																				   
        {																												   
            #region 參數宣告																							   
            var result = false;																							   
            #endregion																									   
																														   
            #region 流程																									 
            AddParameterCategorySql(model);																							   
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
																														   
        public bool UpdateParameterCategory(ParameterCategoryModel model)																			   
        {																												   
            #region 參數宣告																							   
            var result = false;																							   
            #endregion																									   
																														   
            #region 流程																									 
            UpdateParameterCategorySql(model);																						   
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
																														   
        public bool DeleteParameterCategory(ParameterCategoryModel model)																			   
        {																												   
            #region 參數宣告																							   
            var result = false;																							   
            #endregion																									   
																														   
            #region 流程																									 
            DeleteParameterCategorySql(model);																						   
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
