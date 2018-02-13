using System;                                            
using System.Collections.Generic;						 
using System.Linq;										 
using System.Web;										 
														 
namespace PPPWEBAPI.Models								 
{														 
    /// <summary>										 
    /// 									   
    /// </summary>										 
    public class EAI_ERP_XXX_ITEM_CATEGORYModel : _BaseModel	 
    {													 
        #region Properties                                
        public int ITEM_ID { get; set;}  
        public string ITEM_NUMBER { get; set;}  
        public string DESCRIPTION { get; set;}  
        public string COLOR_NAME { get; set;}  
        public int BRAND_ID { get; set;}  
        public string BRAND_TYPE { get; set;}  
        public string BRAND_NAME { get; set;}  
        public string ITEM_MODEL { get; set;}  
        public int CATEGORY_ID { get; set;}  
        public string CATEGORY1_NAME { get; set;}  
        public string CATEGORY2_NAME { get; set;}  
        public string CATEGORY3_NAME { get; set;}  
        public string CATEGORY4_NAME { get; set;}  
        public string Function_CLASS1 { get; set;}  
        public string Function_CLASS2 { get; set;}  
        public DateTime CREATION_DATE { get; set;}  
        public DateTime LAST_UPDATE_DATE { get; set;}  
        public string REAL_ITEM_NUMBER { get; set;}  
        #endregion										  
    }													 
}														 
