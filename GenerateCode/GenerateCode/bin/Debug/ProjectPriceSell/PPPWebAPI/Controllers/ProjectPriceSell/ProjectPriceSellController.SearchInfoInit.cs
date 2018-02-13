using System;															
using System.Collections.Generic;										
using System.Linq;														
using System.Net;														
using System.Net.Http;													
using System.Web.Http;													
using PPPWEBAPI.Models.ViewModels.ProjectPriceSell;					
using PPPWEBAPI.Models;													
using PPPWEBAPI.Services;													
using PPPWEBAPI.Services.Interfaces;													
																		
namespace PPPWEBAPI.Controllers.ProjectPriceSell						
{																		
    public partial class ProjectPriceSellController : _BaseController	
    {																	
        #region Properties												
        #endregion														
        														
        #region Action												
        [ApiJwtAuthActionFilter]														
        [System.Web.Http.Route("Api/ProjectPriceSell/SearchInfoInit")]													  
        [System.Web.Http.HttpPost]													  
        public SearchInfoInitViewModel SearchInfoInit()								  
        {																			  
																					  
            #region 參數宣告														  
																					  
            SearchInfoInitViewModel searchInfoInit = new SearchInfoInitViewModel();	  
            IProjectPriceSellService projectPriceSellService = new ProjectPriceSellService();								  
            IAuthorityService authorityService = new AuthorityService();	  
																					  
            #endregion																  
																					  
            #region 流程																
																					  
			//檢查是否驗證通過														  
            if (!_authState.IsAuth) { throw new Exception(_authState.AuthDescription);} 
																					  
            try																		  
            {																		  
				//取得SearchInfoInit													
                searchInfoInit = projectPriceSellService.QuerySearchInfoInit();					  
																					  
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
