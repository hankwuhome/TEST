//#region Common Import																
import { NgModule } from '@angular/core';											
import { RouterModule, Routes } from '@angular/router';								
//#endregion																			
																						
//#region Custom Import																
import { BaseController } from '../../../Controllers/DeviceBrandPMSetting/BaseController';			
import { SearchListController } from '../../../Controllers/DeviceBrandPMSetting/SearchListController';
import { DetailController } from '../../../Controllers/DeviceBrandPMSetting/DetailController';		
//#endregion																			
																						
//#region Definition																	
const setRoutes: Routes = [															
    {																				
        path: '',																	
        component: BaseController,													
        children: [																	
            { path: 'devicebrandpmsetting/searchlist', component: SearchListController },				
            { path: 'devicebrandpmsetting/editdetail/:Param', component: DetailController },			
            { path: 'devicebrandpmsetting/viewdetail/:Param', component: DetailController },			
        ]																			
    }																				
];																					
@NgModule({																			
    imports: [RouterModule.forChild(setRoutes)],										
    exports: [RouterModule]															
})																					
//#endregion																			
																						
//#region Class																		
export class DeviceBrandPMSettingRouting { }															
//#endregion																			
