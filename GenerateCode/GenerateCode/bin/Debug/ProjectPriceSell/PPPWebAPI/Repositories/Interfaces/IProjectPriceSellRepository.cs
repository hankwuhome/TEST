using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.ProjectPriceSell;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IProjectPriceSellRepository : _IBaseRepository<ProjectPriceSellModel>						
    {																								
        SearchListViewModel QuerySearchList(SearchInfoViewModel searchInfo); 
        DetailViewModel QueryDetail(DetailRequestViewModel detailRequest);	
        bool AddProjectPriceSell(ProjectPriceSellModel model);							
        bool UpdateProjectPriceSell(ProjectPriceSellModel model);							
        bool DeleteProjectPriceSell(ProjectPriceSellModel model);							
    }																								
}																									
