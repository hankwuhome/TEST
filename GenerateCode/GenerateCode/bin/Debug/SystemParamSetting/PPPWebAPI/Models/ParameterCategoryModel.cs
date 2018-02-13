using System;                                            
using System.Collections.Generic;						 
using System.Linq;										 
using System.Web;										 
														 
namespace PPPWEBAPI.Models								 
{														 
    /// <summary>										 
    /// 									   
    /// </summary>										 
    public class ParameterCategoryModel : _BaseModel	 
    {													 
        #region Properties                                
        public string ParameterCategoryID { get; set;}  
        public string ParameterCategoryName { get; set;}  
        public string ParameterLevel { get; set;}  
        public DateTime UpdateDate { get; set;}  
        public string UpdateUserID { get; set;}  
        #endregion										  
    }													 
}														 
