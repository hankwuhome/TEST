using System;                                            
using System.Collections.Generic;						 
using System.Linq;										 
using System.Web;										 
														 
namespace PPPWEBAPI.Models								 
{														 
    /// <summary>										 
    /// 									   
    /// </summary>										 
    public class BatchImportMaterialSettingModel : _BaseModel	 
    {													 
        #region Properties                                
        public string BatchImportID { get; set;}  
        public string MaterialCD { get; set;}  
        public string TransactionType { get; set;}  
        public string UploadUserID { get; set;}  
        public DateTime UploadDate { get; set;}  
        public string Status { get; set;}  
        public string ResponsibleAccount { get; set;}  
        public string UpdateUserID { get; set;}  
        public DateTime UpdateDate { get; set;}  
        #endregion										  
    }													 
}														 
