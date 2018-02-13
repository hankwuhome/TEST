using System;                                            
using System.Collections.Generic;						 
using System.Linq;										 
using System.Web;										 
														 
namespace PPPWEBAPI.Models								 
{														 
    /// <summary>										 
    /// 									   
    /// </summary>										 
    public class CategoryGrossProfitSettingModel : _BaseModel	 
    {													 
        #region Properties                                
        public int CategoryID { get; set;}  
        public Double PurchaseCheckRate { get; set;}  
        public Double ShippingCheckRate { get; set;}  
        #endregion										  
    }													 
}														 
