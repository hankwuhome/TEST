using System;                                            
using System.Collections.Generic;						 
using System.Linq;										 
using System.Web;										 
														 
namespace PPPWEBAPI.Models								 
{														 
    /// <summary>										 
    /// 									   
    /// </summary>										 
    public class HandsetVerifyFormModel : _BaseModel	 
    {													 
        #region Properties                                
        public GUID HandserVerifyFormID { get; set;}  
        public string Handset { get; set;}  
        public DateTime SuggestProjectPriceEffectiveDate { get; set;}  
        public int VerifyStatus { get; set;}  
        public string IsUrgentCase { get; set;}  
        public string CreateUserID { get; set;}  
        public DateTime CreateDate { get; set;}  
        public string UpdateUserID { get; set;}  
        public DateTime UpdateDate { get; set;}  
        #endregion										  
    }													 
}														 
