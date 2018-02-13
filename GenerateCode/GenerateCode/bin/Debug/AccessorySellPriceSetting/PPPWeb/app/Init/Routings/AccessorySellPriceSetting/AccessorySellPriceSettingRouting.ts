//#region Common Import																
import { NgModule } from '@angular/core';											
import { RouterModule, Routes } from '@angular/router';								
//#endregion																			
																						
//#region Custom Import																
import { BaseController } from '../../../Controllers/AccessorySellPriceSetting/BaseController';			
import { SearchListController } from '../../../Controllers/AccessorySellPriceSetting/SearchListController';
import { DetailController } from '../../../Controllers/AccessorySellPriceSetting/DetailController';		
//#endregion																			
																						
//#region Definition																	
const setRoutes: Routes = [															
    {																				
        path: '',																	
        component: BaseController,													
        children: [																	
            { path: 'AccessorySellPriceSetting/searchlist', component: SearchListController },				
            { path: 'accessorysellpricesetting/editdetail/:Param', component: DetailController },			
            { path: 'accessorysellpricesetting/viewdetail/:Param', component: DetailController },			
        ]																			
    }																				
];																					
@NgModule({																			
    imports: [RouterModule.forChild(setRoutes)],										
    exports: [RouterModule]															
})																					
//#endregion																			
																						
//#region Class																		
export class AccessorySellPriceSettingRouting { }															
//#endregion																			
