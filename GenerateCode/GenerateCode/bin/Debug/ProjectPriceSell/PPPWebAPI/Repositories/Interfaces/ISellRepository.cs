using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.ProjectPriceSell;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface ISellRepository : _IBaseRepository<SellModel>						
    {																								
        bool AddSell(SellModel model);							
        bool UpdateSell(SellModel model);							
        bool DeleteSell(SellModel model);							
    }																								
}																									
