using System;                                            
using System.Collections.Generic;						 
using System.Linq;										 
using System.Web;										 
														 
namespace PPPWEBAPI.Models								 
{														 
    /// <summary>										 
    /// 									   
    /// </summary>										 
    public class BatchImportMaterialModel : _BaseModel	 
    {													 
        #region Properties                                
        public string BatchImportID { get; set;}  
        public string UploadUserID { get; set;}  
        public DateTime UploadDate { get; set;}  
        public DateTime FinishDate { get; set;}  
        public string FileName { get; set;}  
        public string FileSize { get; set;}  
        public string Status { get; set;}  
        public string TotalCount { get; set;}  
        public string WaitCount { get; set;}  
        public string SuccessCount { get; set;}  
        public string FailCount { get; set;}  
        public string UnmodifyCount { get; set;}  
        #endregion										  
    }													 
}														 
