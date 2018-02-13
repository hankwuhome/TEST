//#region Common Import																
import { NgModule } from '@angular/core';											
import { RouterModule, Routes } from '@angular/router';								
//#endregion																			
																						
//#region Custom Import																
import { BaseController } from '../../../Controllers/DeviceSellPriceHistory/BaseController';			
import { SearchListController } from '../../../Controllers/DeviceSellPriceHistory/SearchListController';
import { DetailController } from '../../../Controllers/DeviceSellPriceHistory/DetailController';		
//#endregion																			
																						
//#region Definition																	
const setRoutes: Routes = [															
    {																				
        path: '',																	
        component: BaseController,													
        children: [																	
            { path: 'devicesellpricehistory/searchlist', component: SearchListController },				
            { path: 'devicesellpricehistory/editdetail/:Param', component: DetailController },			
            { path: 'devicesellpricehistory/viewdetail/:Param', component: DetailController },			
        ]																			
    }																				
];																					
@NgModule({																			
    imports: [RouterModule.forChild(setRoutes)],										
    exports: [RouterModule]															
})																					
//#endregion																			
																						
//#region Class																		
export class DeviceSellPriceHistoryRouting { }															
//#endregion																			
