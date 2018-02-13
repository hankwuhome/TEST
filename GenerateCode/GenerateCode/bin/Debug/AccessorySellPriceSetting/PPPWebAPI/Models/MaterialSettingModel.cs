using System;                                            
using System.Collections.Generic;						 
using System.Linq;										 
using System.Web;										 
														 
namespace PPPWEBAPI.Models								 
{														 
    /// <summary>										 
    /// 									   
    /// </summary>										 
    public class MaterialSettingModel : _BaseModel	 
    {													 
        #region Properties                                
        public string MaterialCD { get; set;}  
        public string TransactionType { get; set;}  
        public string UpdateUserID { get; set;}  
        public DateTime UpdateDate { get; set;}  
        public string IsDefaultCost { get; set;}  
        public string ResponsibleUserID { get; set;}  
        public GUID CurrentVerifyFormID { get; set;}  
        #endregion										  
    }													 
}														 
