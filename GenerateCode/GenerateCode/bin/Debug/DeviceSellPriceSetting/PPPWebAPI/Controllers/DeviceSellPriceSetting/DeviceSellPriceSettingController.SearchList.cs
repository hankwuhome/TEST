using System;																																				  
using System.Collections.Generic;																															   
using System.Linq;																																			   
using System.Net;																																			   
using System.Net.Http;																																		   
using System.Web.Http;																																		   
using PPPWEBAPI.Models.ViewModels.DeviceSellPriceSetting;																														   
using PPPWEBAPI.Models.ViewModel;																															   
using PPPWEBAPI.Services;																																	   
using PPPWEBAPI.Services.Interfaces;																														   
using PPPWEBAPI.Utilities.Exceptions;																														   
																																							   
namespace PPPWEBAPI.Controllers.DeviceSellPriceSetting																															   
{																																							   
    public partial class DeviceSellPriceSettingController : _BaseController																									   
    {																																						   
        [ApiJwtAuthActionFilter]														
        [System.Web.Http.Route("Api/DeviceSellPriceSetting/SearchList")]													  
        [System.Web.Http.HttpPost]																															   
        public SearchListViewModel SearchList(SearchInfoViewModel searchInfo)																				   
        {																																					   
            #region 參數宣告																																   
            SearchListViewModel searchList = new SearchListViewModel();																						   
            IDeviceSellPriceSettingService deviceSellPriceSettingService = new DeviceSellPriceSettingService();																										   
            IAuthorityService authorityService = new AuthorityService();																			   
            #endregion																																		   
																																							   
            #region 流程																																	     
																																							   
			//檢查是否驗證通過														  
            if (!_authState.IsAuth) { throw new Exception(_authState.AuthDescription); }																		   
																																							   
            // 參數驗證																																		   
            VerifyParams(searchInfo);																														   
																																							   
            try																																				   
            {																																				   
				//取得查詢結果																															     
                searchList = deviceSellPriceSettingService.QuerySearchList(searchInfo);																						   
																																							   
				//檢查資料編輯權限																															   
                searchList.SearchItemList.ForEach(item => item.HasEditPermission = authorityService.HasDataPermission(_authState.UserID, item.DepartmentCD));  
            }																																				   
            catch (Exception ex)																															   
            {																																				   
                throw ex;																																	   
            }																																				   
																																							   
            #endregion																																		   
																																							   
            return searchList;																																   
        }																																					   
																																							   
        private void VerifyParams(SearchInfoViewModel searchInfo)																							   
        {																																					   
            #region 參數宣告																																   
            List<RequestValidateErrorViewModel> requestValidateErrorList = new List<RequestValidateErrorViewModel>();										   
            #endregion																																		   
																																							   
            #region 流程																																	     
            //處理欄位驗證																																     
            if (requestValidateErrorList.Count > 0)																											   
            {																																				   
                throw new RequestValidateException(requestValidateErrorList);																				   
            }																																				   
																																							   
            #endregion																																		   
        }																																					   
    }																																						   
}																																							   
