using System;                                            
using System.Collections.Generic;						 
using System.Linq;										 
using System.Web;										 
														 
namespace PPPWEBAPI.Models								 
{														 
    /// <summary>										 
    /// 									   
    /// </summary>										 
    public class HandsetModel : _BaseModel	 
    {													 
        #region Properties                                
        public string Handset { get; set;}  
        public string IsDelete { get; set;}  
        public string BrandCD { get; set;}  
        public string ItemMode { get; set;}  
        public string DefaultMaterialCD { get; set;}  
        #endregion										  
    }													 
}														 
