using System;                                            
using System.Collections.Generic;						 
using System.Linq;										 
using System.Web;										 
														 
namespace PPPWEBAPI.Models								 
{														 
    /// <summary>										 
    /// 									   
    /// </summary>										 
    public class MaterialVerifyFormModel : _BaseModel	 
    {													 
        #region Properties                                
        public GUID MaterialVerifyFormID { get; set;}  
        public string MaterialCD { get; set;}  
        public int VerifyStatus { get; set;}  
        public string IsUrgentCase { get; set;}  
        public string UpdateUserID { get; set;}  
        public DateTime UpdateUserDate { get; set;}  
        #endregion										  
    }													 
}														 
