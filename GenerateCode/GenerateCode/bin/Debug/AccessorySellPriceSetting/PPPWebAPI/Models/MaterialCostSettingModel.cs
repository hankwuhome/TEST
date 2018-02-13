using System;                                            
using System.Collections.Generic;						 
using System.Linq;										 
using System.Web;										 
														 
namespace PPPWEBAPI.Models								 
{														 
    /// <summary>										 
    /// 									   
    /// </summary>										 
    public class MaterialCostSettingModel : _BaseModel	 
    {													 
        #region Properties                                
        public string MaterialCD { get; set;}  
        public string CostType { get; set;}  
        public Double Cost { get; set;}  
        public string UpdateUserID { get; set;}  
        public DateTime UpdateDate { get; set;}  
        #endregion										  
    }													 
}														 
