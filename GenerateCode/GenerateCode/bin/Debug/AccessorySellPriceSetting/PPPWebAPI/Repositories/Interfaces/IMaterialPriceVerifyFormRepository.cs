using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.AccessorySellPriceSetting;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IMaterialPriceVerifyFormRepository : _IBaseRepository<MaterialPriceVerifyFormModel>						
    {																								
        bool AddMaterialPriceVerifyForm(MaterialPriceVerifyFormModel model);							
        bool UpdateMaterialPriceVerifyForm(MaterialPriceVerifyFormModel model);							
        bool DeleteMaterialPriceVerifyForm(MaterialPriceVerifyFormModel model);							
    }																								
}																									
