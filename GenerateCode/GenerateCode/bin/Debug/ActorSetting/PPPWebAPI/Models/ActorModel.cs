using System;                                            
using System.Collections.Generic;						 
using System.Linq;										 
using System.Web;										 
														 
namespace PPPWEBAPI.Models								 
{														 
    /// <summary>										 
    /// 									   
    /// </summary>										 
    public class ActorModel : _BaseModel	 
    {													 
        #region Properties                                
        public string ActorID { get; set;}  
        public string ActorName { get; set;}  
        public string ActorDescription { get; set;}  
        public string ActorStatus { get; set;}  
        public string CreateUserID { get; set;}  
        public DateTime CreateDate { get; set;}  
        public string UpdateUserID { get; set;}  
        public DateTime UpdateDate { get; set;}  
        #endregion										  
    }													 
}														 
