using System;																																				  
using System.Collections.Generic;																															   
using System.Linq;																																			   
using System.Net;																																			   
using System.Net.Http;																																		   
using System.Web.Http;																																		   
using PPPWEBAPI.Models.ViewModels.ActorSetting;																														   
using PPPWEBAPI.Models.ViewModel;																															   
using PPPWEBAPI.Services;																																	   
using PPPWEBAPI.Services.Interfaces;																														   
using PPPWEBAPI.Utilities.Exceptions;																														   
																																							   
namespace PPPWEBAPI.Controllers.ActorSetting																															   
{																																							   
    public partial class ActorSettingController : _BaseController																									   
    {																																						   
        [ApiJwtAuthActionFilter]														
        [System.Web.Http.Route("Api/ActorSetting/SearchList")]													  
        [System.Web.Http.HttpPost]																															   
        public SearchListViewModel SearchList(SearchInfoViewModel searchInfo)																				   
        {																																					   
            #region 參數宣告																																   
            SearchListViewModel searchList = new SearchListViewModel();																						   
            IActorSettingService actorSettingService = new ActorSettingService();																										   
            #endregion																																		   
																																							   
            #region 流程																																	     
																																							   
			//檢查是否驗證通過														  
            if (!_authState.IsAuth) { throw new Exception(_authState.AuthDescription); }																		   
																																							   
            // 參數驗證																																		   
            VerifyParams(searchInfo);																														   
																																							   
            try																																				   
            {																																				   
				//取得查詢結果																															     
                searchList = actorSettingService.QuerySearchList(searchInfo);																						   
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
