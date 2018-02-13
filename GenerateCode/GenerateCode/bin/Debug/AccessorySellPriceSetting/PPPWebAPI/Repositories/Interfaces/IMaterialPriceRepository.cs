using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.AccessorySellPriceSetting;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IMaterialPriceRepository : _IBaseRepository<MaterialPriceModel>						
    {																								
        bool AddMaterialPrice(MaterialPriceModel model);							
        bool UpdateMaterialPrice(MaterialPriceModel model);							
        bool DeleteMaterialPrice(MaterialPriceModel model);							
    }																								
}																									
