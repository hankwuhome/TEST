using System;                                            
using System.Collections.Generic;						 
using System.Linq;										 
using System.Web;										 
														 
namespace PPPWEBAPI.Models								 
{														 
    /// <summary>										 
    /// 									   
    /// </summary>										 
    public class MaterialCostVerifyFormModel : _BaseModel	 
    {													 
        #region Properties                                
        public GUID MaterialCostVerifyFormID { get; set;}  
        public GUID MaterialVerifyFormID { get; set;}  
        public string MaterialCD { get; set;}  
        public DateTime PurchaseCostCreateDate { get; set;}  
        public Double PurchaseCost { get; set;}  
        public Double PurchaseCostTax { get; set;}  
        public DateTime AverageCostBaseDate { get; set;}  
        public DateTime AverageCostCreateDate { get; set;}  
        public Double AverageCost { get; set;}  
        public Double AverageCostTax { get; set;}  
        public Double SettlementCostTax { get; set;}  
        public DateTime SettlementCostCreateDate { get; set;}  
        public Double ActivityCostTax { get; set;}  
        #endregion										  
    }													 
}														 
