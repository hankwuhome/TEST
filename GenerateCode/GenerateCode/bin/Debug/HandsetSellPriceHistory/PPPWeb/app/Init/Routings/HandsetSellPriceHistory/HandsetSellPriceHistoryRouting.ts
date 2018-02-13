//#region Common Import																
import { NgModule } from '@angular/core';											
import { RouterModule, Routes } from '@angular/router';								
//#endregion																			
																						
//#region Custom Import																
import { BaseController } from '../../../Controllers/HandsetSellPriceHistory/BaseController';			
import { SearchListController } from '../../../Controllers/HandsetSellPriceHistory/SearchListController';
import { DetailController } from '../../../Controllers/HandsetSellPriceHistory/DetailController';		
//#endregion																			
																						
//#region Definition																	
const setRoutes: Routes = [															
    {																				
        path: '',																	
        component: BaseController,													
        children: [																	
            { path: 'handsetsellpricehistory/searchlist', component: SearchListController },				
            { path: 'handsetsellpricehistory/editdetail/:Param', component: DetailController },			
            { path: 'handsetsellpricehistory/viewdetail/:Param', component: DetailController },			
        ]																			
    }																				
];																					
@NgModule({																			
    imports: [RouterModule.forChild(setRoutes)],										
    exports: [RouterModule]															
})																					
//#endregion																			
																						
//#region Class																		
export class HandsetSellPriceHistoryRouting { }															
//#endregion																			
