using System;                                            
using System.Collections.Generic;						 
using System.Linq;										 
using System.Web;										 
														 
namespace PPPWEBAPI.Models								 
{														 
    /// <summary>										 
    /// 									   
    /// </summary>										 
    public class MaterialCostSettingHistoryModel : _BaseModel	 
    {													 
        #region Properties                                
        public int LogNo { get; set;}  
        public string MaterialCD { get; set;}  
        public string CostType { get; set;}  
        public Double Cost { get; set;}  
        public string UpdateUserID { get; set;}  
        public DateTime UpdateDate { get; set;}  
        #endregion										  
    }													 
}														 
