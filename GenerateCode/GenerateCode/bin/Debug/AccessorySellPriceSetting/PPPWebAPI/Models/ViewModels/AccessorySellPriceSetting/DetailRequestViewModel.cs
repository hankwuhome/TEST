using System;                                            
using System.Collections.Generic;						 
using System.ComponentModel;							 
using System.Linq;										 
using System.Web;										 
using PPPWEBAPI.Extensions;								 
														 
namespace PPPWEBAPI.Models.ViewModels.AccessorySellPriceSetting 
{														 
	/// <summary>                                                    
    /// 查詢結果													 
    /// </summary>													 
    public class DetailRequestViewModel : _BaseDetailRequestViewModel		 
    {																 
        #region Enums									 
        //要先定義SQL Sort排序欄位
        public enum EnumSort                                  
        {													  
            [Description("ORDER BY ")] 
            DEFAULT,										  
        }													  
        #endregion										 
																	 
        #region Properties											 
        #endregion													 
    }																 
}														 
