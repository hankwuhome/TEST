using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.AccessorySellPriceSetting;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IMaterialSalesChannelRepository : _IBaseRepository<MaterialSalesChannelModel>						
    {																								
        bool AddMaterialSalesChannel(MaterialSalesChannelModel model);							
        bool UpdateMaterialSalesChannel(MaterialSalesChannelModel model);							
        bool DeleteMaterialSalesChannel(MaterialSalesChannelModel model);							
    }																								
}																									
