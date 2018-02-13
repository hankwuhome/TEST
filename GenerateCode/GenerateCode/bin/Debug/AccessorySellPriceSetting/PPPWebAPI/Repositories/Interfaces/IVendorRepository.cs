using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.AccessorySellPriceSetting;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IVendorRepository : _IBaseRepository<VendorModel>						
    {																								
        bool AddVendor(VendorModel model);							
        bool UpdateVendor(VendorModel model);							
        bool DeleteVendor(VendorModel model);							
    }																								
}																									
