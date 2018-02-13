//#region Common Import																
import { NgModule } from '@angular/core';											
import { RouterModule, Routes } from '@angular/router';								
//#endregion																			
																						
//#region Custom Import																
import { BaseController } from '../../../Controllers/ProjectPriceSell/BaseController';			
import { SearchListController } from '../../../Controllers/ProjectPriceSell/SearchListController';
import { DetailController } from '../../../Controllers/ProjectPriceSell/DetailController';		
//#endregion																			
																						
//#region Definition																	
const setRoutes: Routes = [															
    {																				
        path: '',																	
        component: BaseController,													
        children: [																	
            { path: 'projectpricesell/searchlist', component: SearchListController },				
            { path: 'projectpricesell/adddetail/:Param', component: DetailController },			
            { path: 'projectpricesell/editdetail/:Param', component: DetailController },			
            { path: 'projectpricesell/viewdetail/:Param', component: DetailController },			
        ]																			
    }																				
];																					
@NgModule({																			
    imports: [RouterModule.forChild(setRoutes)],										
    exports: [RouterModule]															
})																					
//#endregion																			
																						
//#region Class																		
export class ProjectPriceSellRouting { }															
//#endregion																			
