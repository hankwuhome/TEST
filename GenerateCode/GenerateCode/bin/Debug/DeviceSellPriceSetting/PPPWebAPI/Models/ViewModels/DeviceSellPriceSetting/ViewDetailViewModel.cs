using System;                                            
using System.Collections.Generic;						 
using System.ComponentModel;							 
using System.Linq;										 
using System.Web;										 
using PPPWEBAPI.Extensions;								 
														 
namespace PPPWEBAPI.Models.ViewModels.DeviceSellPriceSetting 
{														 
	/// <summary>                                                    
    /// 檢視明細資料													 
    /// </summary>													 
    public class ViewDetailViewModel		 
    {																 
        #region Properties											 
        /// <summary>												 
        /// 明細資料											   
        /// </summary>												 
        public DetailViewModel Detail { get; set; }
        /// <summary>												 
        /// 明細下拉選單											   
        /// </summary>												 
        public DetailOptionViewModel DetailOption { get; set; }
        #endregion													 
    }																 
														 
	/// <summary>                                                    
    /// 明細資料													 
    /// </summary>													 
    public class DetailViewModel : _BaseViewModel		 
    {																 
        #region Properties											 
        public string ActiveType { get; set; }													 
        #endregion													 
    }																 
														 
	/// <summary>                                                    
    /// 明細下拉選單													 
    /// </summary>													 
    public class DetailOptionViewModel		 
    {																 
        #region Properties											 
        #endregion													 
    }																 
}														 
