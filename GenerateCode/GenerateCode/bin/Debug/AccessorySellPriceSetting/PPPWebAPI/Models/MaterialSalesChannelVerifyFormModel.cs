using System;                                            
using System.Collections.Generic;						 
using System.Linq;										 
using System.Web;										 
														 
namespace PPPWEBAPI.Models								 
{														 
    /// <summary>										 
    /// 									   
    /// </summary>										 
    public class MaterialSalesChannelVerifyFormModel : _BaseModel	 
    {													 
        #region Properties                                
        public GUID MaterialSalesChannelVerifyFormID { get; set;}  
        public GUID MaterialVerifyFormID { get; set;}  
        public string MaterialCD { get; set;}  
        public string ChannelType { get; set;}  
        public string ChannelID { get; set;}  
        #endregion										  
    }													 
}														 
