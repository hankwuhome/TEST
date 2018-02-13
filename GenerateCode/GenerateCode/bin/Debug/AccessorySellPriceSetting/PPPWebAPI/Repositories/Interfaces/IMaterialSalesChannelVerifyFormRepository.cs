using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.AccessorySellPriceSetting;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IMaterialSalesChannelVerifyFormRepository : _IBaseRepository<MaterialSalesChannelVerifyFormModel>						
    {																								
        bool AddMaterialSalesChannelVerifyForm(MaterialSalesChannelVerifyFormModel model);							
        bool UpdateMaterialSalesChannelVerifyForm(MaterialSalesChannelVerifyFormModel model);							
        bool DeleteMaterialSalesChannelVerifyForm(MaterialSalesChannelVerifyFormModel model);							
    }																								
}																									
