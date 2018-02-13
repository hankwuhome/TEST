using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.HandsetSellPriceHistory;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IVerifyGroupItemRepository : _IBaseRepository<VerifyGroupItemModel>						
    {																								
        bool AddVerifyGroupItem(VerifyGroupItemModel model);							
        bool UpdateVerifyGroupItem(VerifyGroupItemModel model);							
        bool DeleteVerifyGroupItem(VerifyGroupItemModel model);							
    }																								
}																									
