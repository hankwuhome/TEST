using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.DeviceSellPriceSetting;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface ICategoryRepository : _IBaseRepository<CategoryModel>						
    {																								
        bool AddCategory(CategoryModel model);							
        bool UpdateCategory(CategoryModel model);							
        bool DeleteCategory(CategoryModel model);							
    }																								
}																									
