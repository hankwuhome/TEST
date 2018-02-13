using System;															
using System.Collections.Generic;										
using System.Linq;														
using System.Net;														
using System.Net.Http;													
using System.Web.Http;													
using PPPWEBAPI.Models.ViewModels.AccessorySellPriceImport;					
using PPPWEBAPI.Models;													
using PPPWEBAPI.Services;													
using PPPWEBAPI.Services.Interfaces;													
																		
namespace PPPWEBAPI.Controllers.AccessorySellPriceImport						
{																		
    public partial class AccessorySellPriceImportController : _BaseController	
    {																	
        #region Properties												
        #endregion														
        														
        #region Action												
        [ApiJwtAuthActionFilter]														
        [System.Web.Http.Route("Api/AccessorySellPriceImport/SearchInfoInit")]													  
        [System.Web.Http.HttpPost]													  
        public SearchInfoInitViewModel SearchInfoInit()								  
        {																			  
																					  
            #region 參數宣告														  
																					  
            SearchInfoInitViewModel searchInfoInit = new SearchInfoInitViewModel();	  
            IAccessorySellPriceImportService accessorySellPriceImportService = new AccessorySellPriceImportService();								  
            IAuthorityService authorityService = new AuthorityService();	  
																					  
            #endregion																  
																					  
            #region 流程																
																					  
			//檢查是否驗證通過														  
            if (!_authState.IsAuth) { throw new Exception(_authState.AuthDescription);} 
																					  
            try																		  
            {																		  
				//取得SearchInfoInit													
                searchInfoInit = accessorySellPriceImportService.QuerySearchInfoInit();					  
																					  
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
