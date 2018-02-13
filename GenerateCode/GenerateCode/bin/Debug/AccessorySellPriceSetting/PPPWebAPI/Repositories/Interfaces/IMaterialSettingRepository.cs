using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.AccessorySellPriceSetting;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IMaterialSettingRepository : _IBaseRepository<MaterialSettingModel>						
    {																								
        bool AddMaterialSetting(MaterialSettingModel model);							
        bool UpdateMaterialSetting(MaterialSettingModel model);							
        bool DeleteMaterialSetting(MaterialSettingModel model);							
    }																								
}																									
