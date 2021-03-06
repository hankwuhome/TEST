using System;																																						
using System.Collections.Generic;																																	 
using System.Linq;																																					 
using System.Net;																																					 
using System.Net.Http;																																				 
using System.Web.Http;																																				 
using PPPWEBAPI.Extensions;																																			 
using PPPWEBAPI.Models.ViewModels.ProjectPriceSell;																																 
using PPPWEBAPI.Models.ViewModels;																																	 
using PPPWEBAPI.Services;																																			 
using PPPWEBAPI.Services.Interfaces;																																 
using PPPWEBAPI.Utilities.Exceptions;																																 
using PPPWEBAPI.Utilities;																																			 
																																									 
namespace PPPWEBAPI.Controllers.ProjectPriceSell																																	 
{																																									 
    public partial class ProjectPriceSellController : _BaseController																											 
    {																																								 
        [ApiJwtAuthActionFilter]														
        [System.Web.Http.Route("Api/ProjectPriceSell/Detail")]													  
        [System.Web.Http.HttpPost]																																	 
        public bool Detail(DetailViewModel detail)																					 
        {																																							 
            #region 參數宣告																																		 
            bool result = false;																								 
            IProjectPriceSellService projectPriceSellService = new ProjectPriceSellService();																												 
            _BaseDetailRequestViewModel.EnumActiveType enumActiveType;																								 
            #endregion																																				 
																																									 
            #region 流程																																			   
																																									 
            if (!_authState.IsAuth) { throw new Exception(_authState.AuthDescription);}																				 
																																									 
            // 參數驗證																																				 
            VerifyParams(detail);																															 
																																									 
            try																																						 
            {																																						 
                enumActiveType = detail.ActiveType.ConvertToEnum<_BaseDetailRequestViewModel.EnumActiveType>();												 
                VerifyActiveType(enumActiveType, detail);																								 
																																									 
                //處理新增/編輯/刪除資料																										 
                switch (enumActiveType)										
                {															
                    case _BaseDetailRequestViewModel.EnumActiveType.ADD:	
                        projectPriceSellService.AddDetail(detail);		
                        result = true;												
                        break;												
                    case _BaseDetailRequestViewModel.EnumActiveType.EDIT:	
                        projectPriceSellService.EditDetail(detail);		
                        result = true;												
                        break;												
                    case _BaseDetailRequestViewModel.EnumActiveType.DELETE:	
                        projectPriceSellService.DeleteDetail(detail);		
                        result = true;												
                        break;												
                }															
            }																																						 
            catch (Exception ex)																																	 
            {																																						 
                throw ex;																																			 
            }																																						 
																																									 
            #endregion																																				 
																																									 
            return result;																																		 
        }																																							 
																																									 
        private void VerifyParams(DetailViewModel detail)																								 
        {																																							 
            #region 參數宣告																																		 
																																									 
            #endregion																																				 
																																									 
            #region 流程																																			   
																																									 
            //處理欄位驗證																																		   
			//檢核沒傳主Key時, 直接throw new Exception("未傳入主要查詢條件")																						
																																									 
            #endregion																																				 
        }																																							 
																																									 
        private bool VerifyActiveType(_BaseDetailRequestViewModel.EnumActiveType enumActiveType, DetailViewModel Detail)								 
        {																																							 
																																									 
            #region 參數宣告																																		 
            IAuthorityService authorityService = new AuthorityService();																							 
            #endregion																																				 
																																									 
            #region 流程處理																																		 
																																									 
            if (enumActiveType.Equals(_BaseDetailRequestViewModel.EnumActiveType.EDIT) || enumActiveType.Equals(_BaseDetailRequestViewModel.EnumActiveType.DELETE))																				 
            {																																						 
				//先檢查是否有資料編輯權限																															 
                if (!authorityService.HasDataPermission(_authState.UserID, detail.DepartmentCD))															 
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
																																									 
