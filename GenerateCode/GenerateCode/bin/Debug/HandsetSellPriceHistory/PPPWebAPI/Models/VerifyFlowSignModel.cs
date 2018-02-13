using System;                                            
using System.Collections.Generic;						 
using System.Linq;										 
using System.Web;										 
														 
namespace PPPWEBAPI.Models								 
{														 
    /// <summary>										 
    /// 									   
    /// </summary>										 
    public class VerifyFlowSignModel : _BaseModel	 
    {													 
        #region Properties                                
        public GUID VerifyFormID { get; set;}  
        public int SignStep { get; set;}  
        public int FlowType { get; set;}  
        public int FlowTypeStep { get; set;}  
        public string SignUserID { get; set;}  
        public string SignStatus { get; set;}  
        public DateTime SignDate { get; set;}  
        public string SignMemo { get; set;}  
        public DateTime LastSignDate { get; set;}  
        #endregion										  
    }													 
}														 
