using System;                                            
using System.Collections.Generic;						 
using System.Linq;										 
using System.Web;										 
														 
namespace PPPWEBAPI.Models								 
{														 
    /// <summary>										 
    /// 									   
    /// </summary>										 
    public class MaterialPriceVerifyFormModel : _BaseModel	 
    {													 
        #region Properties                                
        public GUID MaterialVerifyFormID { get; set;}  
        public GUID MaterialPriceVerifyFormID { get; set;}  
        public string MaterialCD { get; set;}  
        public DateTime PurchaseEffectiveDate { get; set;}  
        public DateTime PurchaseExprireDate { get; set;}  
        public Double PurchasePrice { get; set;}  
        public DateTime ShippingEffectiveDate { get; set;}  
        public DateTime ShippingExprireDate { get; set;}  
        public Double ShippingPrice { get; set;}  
        #endregion										  
    }													 
}														 
