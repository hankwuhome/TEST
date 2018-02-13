using System;                                            
using System.Collections.Generic;						 
using System.Linq;										 
using System.Web;										 
														 
namespace PPPWEBAPI.Models								 
{														 
    /// <summary>										 
    /// 									   
    /// </summary>										 
    public class MaterialModel : _BaseModel	 
    {													 
        #region Properties                                
        public string MaterialCD { get; set;}  
        public string MaterialName { get; set;}  
        public string ColorName { get; set;}  
        public string BrandCD { get; set;}  
        public string ItemMode { get; set;}  
        public string Handset { get; set;}  
        public int MainCategoryID { get; set;}  
        public int SubCategoryID { get; set;}  
        public int VendorID { get; set;}  
        public string IsDelete { get; set;}  
        public DateTime CreateDate { get; set;}  
        public DateTime UpdateDate { get; set;}  
        #endregion										  
    }													 
}														 
