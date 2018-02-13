using System;                                            
using System.Collections.Generic;						 
using System.Linq;										 
using System.Web;										 
														 
namespace PPPWEBAPI.Models								 
{														 
    /// <summary>										 
    /// 									   
    /// </summary>										 
    public class BatchImportMaterialCostSettingModel : _BaseModel	 
    {													 
        #region Properties                                
        public string BatchImportID { get; set;}  
        public string MaterialCD { get; set;}  
        public string CostType { get; set;}  
        public Double Cost { get; set;}  
        #endregion										  
    }													 
}														 
