using System;                                            
using System.Collections.Generic;						 
using System.Linq;										 
using System.Web;										 
														 
namespace PPPWEBAPI.Models								 
{														 
    /// <summary>										 
    /// 									   
    /// </summary>										 
    public class VerifyFlowSettingModel : _BaseModel	 
    {													 
        #region Properties                                
        public string FlowType { get; set;}  
        public string FlowTypeName { get; set;}  
        public string FlowTypeDescription { get; set;}  
        #endregion										  
    }													 
}														 
