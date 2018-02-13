using System;																																						
using System.Collections.Generic;																																	 
using System.Linq;																																					 
using System.Net;																																					 
using System.Net.Http;																																				 
using System.Web.Http;																																				 
using PPPWEBAPI.Extensions;																																			 
using PPPWEBAPI.Models.ViewModels.DeviceSellPriceHistory;																																 
using PPPWEBAPI.Models.ViewModels;																																	 
using PPPWEBAPI.Services;																																			 
using PPPWEBAPI.Services.Interfaces;																																 
using PPPWEBAPI.Utilities.Exceptions;																																 
using PPPWEBAPI.Utilities;																																			 
																																									 
namespace PPPWEBAPI.Controllers.DeviceSellPriceHistory																																	 
{																																									 
    public partial class DeviceSellPriceHistoryController : _BaseController																											 
    {																																								 
        [ApiJwtAuthActionFilter]														
        [System.Web.Http.Route("Api/DeviceSellPriceHistory/ViewDetail")]													  
        [System.Web.Http.HttpPost]																																	 
        public ViewDetailViewModel ViewDetail(DetailRequestViewModel detailRequest)																					 
        {																																							 
            #region 參數宣告																																		 
            ViewDetailViewModel viewDetail = new ViewDetailViewModel();																								 
            IDeviceSellPriceHistoryService deviceSellPriceHistoryService = new DeviceSellPriceHistoryService();																												 
            _BaseDetailRequestViewModel.EnumActiveType enumActiveType;																								 
            #endregion																																				 
																																									 
            #region 流程																																			   
																																									 
            if (!_authState.IsAuth) { throw new Exception(_authState.AuthDescription);	}																			 
																																									 
            // 參數驗證																																				 
            VerifyParams(detailRequest);																															 
																																									 
            try																																						 
            {																																						 
                enumActiveType = detailRequest.ActiveType.ConvertToEnum<_BaseDetailRequestViewModel.EnumActiveType>();												 
																																									 
                //判斷為EDIT 或 VIEW時需抓資料並檢查編輯權限																										 
                if (enumActiveType.Equals(_BaseDetailRequestViewModel.EnumActiveType.VIEW) || enumActiveType.Equals(_BaseDetailRequestViewModel.EnumActiveType.EDIT))
                {																																					 
                    //取得明細資料																																   
                    viewDetail.Detail = deviceSellPriceHistoryService.QueryDetail(detailRequest);																		 
																																									 
                    //驗證編輯權限																																   
                    VerifyActiveType(enumActiveType, ref viewDetail);																								 
                }																																					 
																																									 
                //取得明細下拉選單項目																															   
                viewDetail.DetailOption = deviceSellPriceHistoryService.QueryDetailOption();																 
            }																																						 
            catch (Exception ex)																																	 
            {																																						 
                throw ex;																																			 
            }																																						 
																																									 
            #endregion																																				 
																																									 
            return viewDetail;																																		 
        }																																							 
																																									 
        private void VerifyParams(DetailRequestViewModel detailRequest)																								 
        {																																							 
            #region 參數宣告																																		 
																																									 
            #endregion																																				 
																																									 
            #region 流程																																			   
																																									 
            //處理欄位驗證																																		   
			//檢核沒傳主Key時, 直接throw new Exception("未傳入主要查詢條件")																						
																																									 
            #endregion																																				 
        }																																							 
																																									 
        private bool VerifyActiveType(_BaseDetailRequestViewModel.EnumActiveType enumActiveType, ref ViewDetailViewModel viewDetail)								 
        {																																							 
																																									 
            #region 參數宣告																																		 
            IAuthorityService authorityService = new AuthorityService();																							 
            #endregion																																				 
																																									 
            #region 流程處理																																		 
																																									 
            if (enumActiveType.Equals(_BaseDetailRequestViewModel.EnumActiveType.EDIT))																				 
            {																																						 
				//先檢查是否有資料編輯權限																															 
                if (!authorityService.HasDataPermission(_authState.UserID, viewDetail.Detail.DepartmentCD))															 
                {																																					 
                    throw new Exception("無資料編輯權限");																											  
                }																																					 
				//額外處理各功能有關初始化明細頁時, 與增改查有關的驗證																								
            }																																						 
																																									 
            return true;																																			 
            #endregion																																				 
        }																																							 
    }																																								 
}																																									 
																																									 
