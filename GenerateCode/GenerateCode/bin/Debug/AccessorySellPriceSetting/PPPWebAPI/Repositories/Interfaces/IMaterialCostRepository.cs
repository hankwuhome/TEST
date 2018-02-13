using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.AccessorySellPriceSetting;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IMaterialCostRepository : _IBaseRepository<MaterialCostModel>						
    {																								
        bool AddMaterialCost(MaterialCostModel model);							
        bool UpdateMaterialCost(MaterialCostModel model);							
        bool DeleteMaterialCost(MaterialCostModel model);							
    }																								
}																									
