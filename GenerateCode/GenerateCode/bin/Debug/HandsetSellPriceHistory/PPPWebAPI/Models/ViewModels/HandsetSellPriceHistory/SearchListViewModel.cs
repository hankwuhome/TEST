using System;                                            
using System.Collections.Generic;						 
using System.ComponentModel;							 
using System.Linq;										 
using System.Web;										 
using PPPWEBAPI.Extensions;								 
														 
namespace PPPWEBAPI.Models.ViewModels.HandsetSellPriceHistory 
{														 
	/// <summary>                                                    
    /// 查詢結果													 
    /// </summary>													 
    public class SearchListViewModel : _BaseSearchListViewModel		 
    {																 
        #region Properties											 
        /// <summary>												 
        /// 查詢結果清單											   
        /// </summary>												 
        public List<SearchItemViewModel> SearchItemList { get; set; }
																	 
        #endregion													 
    }																 
																	 
    /// <summary>													 
    /// 查詢結果細項												   
    /// </summary>													 
    public class SearchItemViewModel : _BaseViewModel				 
    {																 
        #region Properties											 
																	 
        #endregion													 
    }																 
}														 
