using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.DeviceBrandPMSetting;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IBrandPMRepository : _IBaseRepository<BrandPMModel>						
    {																								
        SearchListViewModel QuerySearchList(SearchInfoViewModel searchInfo); 
        DetailViewModel QueryDetail(DetailRequestViewModel detailRequest);	
        bool AddBrandPM(BrandPMModel model);							
        bool UpdateBrandPM(BrandPMModel model);							
        bool DeleteBrandPM(BrandPMModel model);							
    }																								
}																									
