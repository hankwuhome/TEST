using System;                                            
using System.Collections.Generic;						 
using System.Linq;										 
using System.Web;										 
														 
namespace PPPWEBAPI.Models								 
{														 
    /// <summary>										 
    /// 									   
    /// </summary>										 
    public class CategoryModel : _BaseModel	 
    {													 
        #region Properties                                
        public int CategoryID { get; set;}  
        public string CategoryName { get; set;}  
        public int ParentCategoryID { get; set;}  
        public int CategoryLevel { get; set;}  
        public int ErpCategpryID { get; set;}  
        #endregion										  
    }													 
}														 
