using System;																			
using System.Collections.Generic;													  
using System.Linq;																	  
using System.Web;																	  
using PPPWEBAPI.Extensions;															  
using PPPWEBAPI.Models;																  
using PPPWEBAPI.Models.ViewModels;													  
using PPPWEBAPI.Models.ViewModels.SystemParamSetting;												  
using PPPWEBAPI.Services.Interfaces;												  
using PPPWEBAPI.Repositories;														  
using PPPWEBAPI.Repositories.Interfaces;											  
using PPPWEBAPI.Utilities;															  
																					  
namespace PPPWEBAPI.Services														  
{																					  
    public class SystemParamSettingService : ISystemParamSettingService											  
    {																				  
        /// <summary>																  
        /// 初始化搜尋列表(下拉選單)												   
        /// </summary>																  
        /// <returns></returns>														  
        public SearchInfoInitViewModel QuerySearchInfoInit()						  
        {																			  
            #region 參數宣告														  
            SearchInfoInitViewModel searchInfoInit = new SearchInfoInitViewModel();	  
            #endregion																  
																					  
            #region 流程																
																					  
            return searchInfoInit;													  
            #endregion																  
        }																			  
																					  
        /// <summary>																  
        /// 查詢列表															  
        /// </summary>																  
        /// <param name="searchInfo"></param>										  
        /// <returns></returns>														  
        public SearchListViewModel QuerySearchList(SearchInfoViewModel searchInfo)	  
        {																			  
            #region 參數宣告														  
																					  
            SearchListViewModel searchList = new SearchListViewModel();				  
            IParameterCategoryRepository parameterCategoryRp = new ParameterCategoryRepository();								  
            #endregion																  
																					  
            #region 流程																
            searchList = parameterCategoryRp.QuerySearchList(searchInfo);							  
																					  
            return searchList;														  
            #endregion																  
        }																			  
																					  
        /// <summary>																  
        /// 查詢明細															  
        /// </summary>																  
        /// <param name="detailRequest"></param>									  
        /// <returns></returns>														  
        public DetailViewModel QueryDetail(DetailRequestViewModel detailRequest)	  
        {																			  
            #region 參數宣告														  
            DetailViewModel detail = new DetailViewModel();							  
            IParameterCategoryRepository parameterCategoryRp = new ParameterCategoryRepository();								  
            #endregion																  
																					  
            #region 流程																
            detail = parameterCategoryRp.QueryDetail(detailRequest);								  
            																		  
            return detail;															  
            #endregion																  
        }																			  
																					  
		/// <summary>																  
        /// 初始化明細(下拉選單)														 
        /// </summary>																  
        /// <returns></returns>														  
        public DetailOptionViewModel QueryDetailOption()							  
        {																			  
            #region 參數宣告														  
            DetailOptionViewModel detailOption = new DetailOptionViewModel();		  
            																		  
            #endregion																  
																					  
            #region 流程																
																					  
            return detailOption;													  
            #endregion																  
        }																			  
																					  
        /// <summary>																  
        /// 新增明細															  
        /// </summary>																  
        /// <param name="detail"></param>											  
        /// <returns></returns>														  
        public bool AddDetail(DetailViewModel detail)								  
        {																			  
            #region 參數宣告														  
            bool result = false;													  
			ParameterCategoryModel parameterCategory = new ParameterCategoryModel(); 											  
            IParameterCategoryRepository parameterCategoryRp = new ParameterCategoryRepository();								  
            #endregion																  
																					  
            #region 流程																
			parameterCategory =  PropertyCopy.Convert<DetailViewModel, ParameterCategoryModel>(detail);  
			result = parameterCategoryRp.AddParameterCategory(parameterCategory);												  
																					  
            return result;															  
            #endregion																  
        }																			  
																					  
        /// <summary>																  
        /// 修改明細															  
        /// </summary>																  
        /// <param name="detail"></param>											  
        /// <returns></returns>														  
        public bool EditDetail(DetailViewModel detail)								  
        {																			  
            #region 參數宣告														  
            bool result = false;													  
			ParameterCategoryModel parameterCategory = new ParameterCategoryModel(); 											  
            IParameterCategoryRepository parameterCategoryRp = new ParameterCategoryRepository();								  
            #endregion																  
																					  
            #region 流程																
			parameterCategory =  PropertyCopy.Convert<DetailViewModel, ParameterCategoryModel>(detail);  
			result = parameterCategoryRp.UpdateParameterCategory(parameterCategory);											  
																					  
            return result;															  
            #endregion																  
        }																			  
																					  
        /// <summary>																  
        ///刪除明細															  
        /// </summary>																  
        /// <param name="detail"></param>											  
        /// <returns></returns>														  
        public bool DeleteDetail(DetailViewModel detail)							  
        {																			  
            #region 參數宣告														  
            bool result = false;													  
			ParameterCategoryModel parameterCategory = new ParameterCategoryModel(); 											  
            IParameterCategoryRepository parameterCategoryRp = new ParameterCategoryRepository();								  
            #endregion																  
																					  
            #region 流程																
			parameterCategory =  PropertyCopy.Convert<DetailViewModel, ParameterCategoryModel>(detail);  
			result = parameterCategoryRp.DeleteParameterCategory(parameterCategory);											  
																					  
            return result;															  
            #endregion																  
        }																			  
    }																				  
}																					  
