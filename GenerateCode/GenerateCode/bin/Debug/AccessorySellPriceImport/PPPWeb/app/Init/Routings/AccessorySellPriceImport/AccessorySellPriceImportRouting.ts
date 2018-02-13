//#region Common Import																
import { NgModule } from '@angular/core';											
import { RouterModule, Routes } from '@angular/router';								
//#endregion																			
																						
//#region Custom Import																
import { BaseController } from '../../../Controllers/AccessorySellPriceImport/BaseController';			
import { SearchListController } from '../../../Controllers/AccessorySellPriceImport/SearchListController';
import { DetailController } from '../../../Controllers/AccessorySellPriceImport/DetailController';		
//#endregion																			
																						
//#region Definition																	
const setRoutes: Routes = [															
    {																				
        path: '',																	
        component: BaseController,													
        children: [																	
            { path: 'accessorysellpriceimport/searchlist', component: SearchListController },				
            { path: 'accessorysellpriceimport/viewdetail/:Param', component: DetailController },			
        ]																			
    }																				
];																					
@NgModule({																			
    imports: [RouterModule.forChild(setRoutes)],										
    exports: [RouterModule]															
})																					
//#endregion																			
																						
//#region Class																		
export class AccessorySellPriceImportRouting { }															
//#endregion																			
