using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.DeviceSellPriceHistory;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IBrandRepository : _IBaseRepository<BrandModel>						
    {																								
        bool AddBrand(BrandModel model);							
        bool UpdateBrand(BrandModel model);							
        bool DeleteBrand(BrandModel model);							
    }																								
}																									
