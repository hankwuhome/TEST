using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.HandsetSellPriceHistory;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IVerifyFlowStepSettingRepository : _IBaseRepository<VerifyFlowStepSettingModel>						
    {																								
        bool AddVerifyFlowStepSetting(VerifyFlowStepSettingModel model);							
        bool UpdateVerifyFlowStepSetting(VerifyFlowStepSettingModel model);							
        bool DeleteVerifyFlowStepSetting(VerifyFlowStepSettingModel model);							
    }																								
}																									
