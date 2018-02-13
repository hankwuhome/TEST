using System;                                            
using System.Collections.Generic;						 
using System.Linq;										 
using System.Web;										 
														 
namespace PPPWEBAPI.Models								 
{														 
    /// <summary>										 
    /// 									   
    /// </summary>										 
    public class VendorModel : _BaseModel	 
    {													 
        #region Properties                                
        public int VendorID { get; set;}  
        public string VendorName { get; set;}  
        public string IsDelete { get; set;}  
        #endregion										  
    }													 
}														 
