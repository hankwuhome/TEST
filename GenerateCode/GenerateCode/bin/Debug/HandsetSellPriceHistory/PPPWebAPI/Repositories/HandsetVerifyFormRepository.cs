using System;																												
using System.Collections.Generic;																						   
using Dapper;																											   
using System.Linq;																										   
using System.Web;																										   
using PPPWEBAPI.Models;																									   
using PPPWEBAPI.Models.ViewModels.HandsetSellPriceHistory;																					   
using PPPWEBAPI.Repositories.Interfaces;																				   
using System.Data.SqlClient;																							   
																														   
namespace PPPWEBAPI.Repositories																						   
{																														   
    public partial class HandsetVerifyFormRepository : _BaseRepository<HandsetVerifyFormModel>, IHandsetVerifyFormRepository										   
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
																														   
        public bool AddHandsetVerifyForm(HandsetVerifyFormModel model)																				   
        {																												   
            #region 參數宣告																							   
            var result = false;																							   
            #endregion																									   
																														   
            #region 流程																									 
            AddHandsetVerifyFormSql(model);																							   
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
																														   
        public bool UpdateHandsetVerifyForm(HandsetVerifyFormModel model)																			   
        {																												   
            #region 參數宣告																							   
            var result = false;																							   
            #endregion																									   
																														   
            #region 流程																									 
            UpdateHandsetVerifyFormSql(model);																						   
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
																														   
        public bool DeleteHandsetVerifyForm(HandsetVerifyFormModel model)																			   
        {																												   
            #region 參數宣告																							   
            var result = false;																							   
            #endregion																									   
																														   
            #region 流程																									 
            DeleteHandsetVerifyFormSql(model);																						   
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
