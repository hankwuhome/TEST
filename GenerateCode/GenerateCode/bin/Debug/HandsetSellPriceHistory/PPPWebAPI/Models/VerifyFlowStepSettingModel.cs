using System;                                            
using System.Collections.Generic;						 
using System.Linq;										 
using System.Web;										 
														 
namespace PPPWEBAPI.Models								 
{														 
    /// <summary>										 
    /// 									   
    /// </summary>										 
    public class VerifyFlowStepSettingModel : _BaseModel	 
    {													 
        #region Properties                                
        public string FlowType { get; set;}  
        public int FlowStep { get; set;}  
        public string SignActorID { get; set;}  
        #endregion										  
    }													 
}														 
