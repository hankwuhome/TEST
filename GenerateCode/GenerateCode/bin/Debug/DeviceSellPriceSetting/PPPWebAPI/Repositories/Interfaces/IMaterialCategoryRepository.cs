using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.DeviceSellPriceSetting;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IMaterialCategoryRepository : _IBaseRepository<MaterialCategoryModel>						
    {																								
        bool AddMaterialCategory(MaterialCategoryModel model);							
        bool UpdateMaterialCategory(MaterialCategoryModel model);							
        bool DeleteMaterialCategory(MaterialCategoryModel model);							
    }																								
}																									
