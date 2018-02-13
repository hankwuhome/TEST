using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.AccessorySellPriceSetting;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface ICategoryGrossProfitSettingRepository : _IBaseRepository<CategoryGrossProfitSettingModel>						
    {																								
        bool AddCategoryGrossProfitSetting(CategoryGrossProfitSettingModel model);							
        bool UpdateCategoryGrossProfitSetting(CategoryGrossProfitSettingModel model);							
        bool DeleteCategoryGrossProfitSetting(CategoryGrossProfitSettingModel model);							
    }																								
}																									
