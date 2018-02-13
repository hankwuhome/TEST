using System;															
using System.Collections.Generic;										
using System.Linq;														
using System.Net;														
using System.Net.Http;													
using System.Web.Http;													
using PPPWEBAPI.Models.ViewModels.DeviceSellPriceHistory;					
using PPPWEBAPI.Models;													
using PPPWEBAPI.Services;													
using PPPWEBAPI.Services.Interfaces;													
																		
namespace PPPWEBAPI.Controllers.DeviceSellPriceHistory						
{																		
    public partial class DeviceSellPriceHistoryController : _BaseController	
    {																	
        #region Properties												
        #endregion														
        														
        #region Action												
        [ApiJwtAuthActionFilter]														
        [System.Web.Http.Route("Api/DeviceSellPriceHistory/SearchInfoInit")]													  
        [System.Web.Http.HttpPost]													  
        public SearchInfoInitViewModel SearchInfoInit()								  
        {																			  
																					  
            #region 參數宣告														  
																					  
            SearchInfoInitViewModel searchInfoInit = new SearchInfoInitViewModel();	  
            IDeviceSellPriceHistoryService deviceSellPriceHistoryService = new DeviceSellPriceHistoryService();								  
            IAuthorityService authorityService = new AuthorityService();	  
																					  
            #endregion																  
																					  
            #region 流程																
																					  
			//檢查是否驗證通過														  
            if (!_authState.IsAuth) { throw new Exception(_authState.AuthDescription);} 
																					  
            try																		  
            {																		  
				//取得SearchInfoInit													
                searchInfoInit = deviceSellPriceHistoryService.QuerySearchInfoInit();					  
																					  
            }																		  
            catch (Exception ex)													  
            {																		  
                throw ex;															  
            }																		  
            return searchInfoInit;													  
            #endregion																  
																					  
        }																			  
        #endregion														
    }																	
}																		
