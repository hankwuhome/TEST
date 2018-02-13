using System;                                            
using System.Collections.Generic;						 
using System.Linq;										 
using System.Web;										 
														 
namespace PPPWEBAPI.Models								 
{														 
    /// <summary>										 
    /// 									   
    /// </summary>										 
    public class EAI_ERP_XXX_ITEM_PRICEModel : _BaseModel	 
    {													 
        #region Properties                                
        public string ITEM_NUMBER { get; set;}  
        public DateTime CREATION_DATE { get; set;}  
        public Double PRICE { get; set;}  
        public Double PRICE_TAX { get; set;}  
        public Double AVG_PRICE { get; set;}  
        public Double AG_PRICE_TAX { get; set;}  
        public DateTime AVG_DATE { get; set;}  
        public DateTime AVG_CREATION_DATE { get; set;}  
        #endregion										  
    }													 
}														 
