using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.aaa;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IccccRepository : _IBaseRepository<ccccModel>						
    {																								
        bool Addcccc(ccccModel model);							
        bool Updatecccc(ccccModel model);							
        bool Deletecccc(ccccModel model);							
    }																								
}																									
