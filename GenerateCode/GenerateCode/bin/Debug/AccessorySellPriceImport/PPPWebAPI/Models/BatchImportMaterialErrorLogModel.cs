using System;                                            
using System.Collections.Generic;						 
using System.Linq;										 
using System.Web;										 
														 
namespace PPPWEBAPI.Models								 
{														 
    /// <summary>										 
    /// 									   
    /// </summary>										 
    public class BatchImportMaterialErrorLogModel : _BaseModel	 
    {													 
        #region Properties                                
        public string BatchImportID { get; set;}  
        public string MaterialCD { get; set;}  
        public string TransactionType { get; set;}  
        public string UploadAccount { get; set;}  
        public string ResponsibleAccount { get; set;}  
        public string PurchaseEffectiveDate { get; set;}  
        public string PurchaseExprireDate { get; set;}  
        public string PurchasePrice { get; set;}  
        public string ShippingEffectiveDate { get; set;}  
        public string ShippingExprireDate { get; set;}  
        public string ShippingPrice { get; set;}  
        public string Cost { get; set;}  
        public string ErrorMessage { get; set;}  
        #endregion										  
    }													 
}														 
