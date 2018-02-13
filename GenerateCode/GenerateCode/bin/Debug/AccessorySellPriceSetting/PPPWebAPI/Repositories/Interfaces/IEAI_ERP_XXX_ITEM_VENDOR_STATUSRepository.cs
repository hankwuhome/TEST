using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.AccessorySellPriceSetting;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IEAI_ERP_XXX_ITEM_VENDOR_STATUSRepository : _IBaseRepository<EAI_ERP_XXX_ITEM_VENDOR_STATUSModel>						
    {																								
        bool AddEAI_ERP_XXX_ITEM_VENDOR_STATUS(EAI_ERP_XXX_ITEM_VENDOR_STATUSModel model);							
        bool UpdateEAI_ERP_XXX_ITEM_VENDOR_STATUS(EAI_ERP_XXX_ITEM_VENDOR_STATUSModel model);							
        bool DeleteEAI_ERP_XXX_ITEM_VENDOR_STATUS(EAI_ERP_XXX_ITEM_VENDOR_STATUSModel model);							
    }																								
}																									
