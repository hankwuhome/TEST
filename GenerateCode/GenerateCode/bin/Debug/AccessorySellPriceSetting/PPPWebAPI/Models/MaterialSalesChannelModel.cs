using System;                                            
using System.Collections.Generic;						 
using System.Linq;										 
using System.Web;										 
														 
namespace PPPWEBAPI.Models								 
{														 
    /// <summary>										 
    /// 									   
    /// </summary>										 
    public class MaterialSalesChannelModel : _BaseModel	 
    {													 
        #region Properties                                
        public string MaterialCD { get; set;}  
        public string ChannelType { get; set;}  
        public string ChannelID { get; set;}  
        public DateTime EffectiveDate { get; set;}  
        public DateTime ExprireDate { get; set;}  
        #endregion										  
    }													 
}														 
