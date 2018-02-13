using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.HandsetSellPriceHistory;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IVerifyFlowSignRepository : _IBaseRepository<VerifyFlowSignModel>						
    {																								
        bool AddVerifyFlowSign(VerifyFlowSignModel model);							
        bool UpdateVerifyFlowSign(VerifyFlowSignModel model);							
        bool DeleteVerifyFlowSign(VerifyFlowSignModel model);							
    }																								
}																									
