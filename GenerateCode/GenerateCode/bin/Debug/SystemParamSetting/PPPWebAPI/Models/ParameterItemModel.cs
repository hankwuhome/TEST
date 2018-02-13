using System;                                            
using System.Collections.Generic;						 
using System.Linq;										 
using System.Web;										 
														 
namespace PPPWEBAPI.Models								 
{														 
    /// <summary>										 
    /// 									   
    /// </summary>										 
    public class ParameterItemModel : _BaseModel	 
    {													 
        #region Properties                                
        public string ParameterCategoryID { get; set;}  
        public string ParameterItemID { get; set;}  
        public string ParameterItemName { get; set;}  
        public int SortSeq { get; set;}  
        public string ParameterItemValue1 { get; set;}  
        public string ParameterItemValue2 { get; set;}  
        public DateTime UpdateDate { get; set;}  
        public string UpdateUserID { get; set;}  
        #endregion										  
    }													 
}														 
