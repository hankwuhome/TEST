//#region Common Import																
import { NgModule } from '@angular/core';											
import { RouterModule, Routes } from '@angular/router';								
//#endregion																			
																						
//#region Custom Import																
import { BaseController } from '../../../Controllers/DeviceSellPriceSetting/BaseController';			
import { SearchListController } from '../../../Controllers/DeviceSellPriceSetting/SearchListController';
import { DetailController } from '../../../Controllers/DeviceSellPriceSetting/DetailController';		
//#endregion																			
																						
//#region Definition																	
const setRoutes: Routes = [															
    {																				
        path: '',																	
        component: BaseController,													
        children: [																	
            { path: 'devicesellpricesetting/searchlist', component: SearchListController },				
            { path: 'devicesellpricesetting/editdetail/:Param', component: DetailController },			
            { path: 'devicesellpricesetting/viewdetail/:Param', component: DetailController },			
        ]																			
    }																				
];																					
@NgModule({																			
    imports: [RouterModule.forChild(setRoutes)],										
    exports: [RouterModule]															
})																					
//#endregion																			
																						
//#region Class																		
export class DeviceSellPriceSettingRouting { }															
//#endregion																			
