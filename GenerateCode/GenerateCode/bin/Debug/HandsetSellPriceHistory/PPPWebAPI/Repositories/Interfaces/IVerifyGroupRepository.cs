using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.HandsetSellPriceHistory;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IVerifyGroupRepository : _IBaseRepository<VerifyGroupModel>						
    {																								
        bool AddVerifyGroup(VerifyGroupModel model);							
        bool UpdateVerifyGroup(VerifyGroupModel model);							
        bool DeleteVerifyGroup(VerifyGroupModel model);							
    }																								
}																									
