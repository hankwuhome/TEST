using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.DeviceSellPriceSetting;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IMaterialRepository : _IBaseRepository<MaterialModel>						
    {																								
        bool AddMaterial(MaterialModel model);							
        bool UpdateMaterial(MaterialModel model);							
        bool DeleteMaterial(MaterialModel model);							
    }																								
}																									
