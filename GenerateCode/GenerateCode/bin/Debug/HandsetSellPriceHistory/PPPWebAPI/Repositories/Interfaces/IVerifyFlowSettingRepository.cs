using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.HandsetSellPriceHistory;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IVerifyFlowSettingRepository : _IBaseRepository<VerifyFlowSettingModel>						
    {																								
        bool AddVerifyFlowSetting(VerifyFlowSettingModel model);							
        bool UpdateVerifyFlowSetting(VerifyFlowSettingModel model);							
        bool DeleteVerifyFlowSetting(VerifyFlowSettingModel model);							
    }																								
}																									
