using System;                                            
using System.Collections.Generic;						 
using System.Linq;										 
using System.Web;										 
														 
namespace PPPWEBAPI.Models								 
{														 
    /// <summary>										 
    /// 									   
    /// </summary>										 
    public class MaterialPriceModel : _BaseModel	 
    {													 
        #region Properties                                
        public string MaterialCD { get; set;}  
        public string PriceType { get; set;}  
        public DateTime EffectiveDate { get; set;}  
        public DateTime ExprireDate { get; set;}  
        public Double Price { get; set;}  
        public GUID SourceVerifyFormID { get; set;}  
        public DateTime LastExportDate { get; set;}  
        public string IsNew { get; set;}  
        public string IsStopSelling { get; set;}  
        public string IsIncrease { get; set;}  
        public string IsReduction { get; set;}  
        #endregion										  
    }													 
}														 
