//#region Common Import																
import { NgModule } from '@angular/core';											
import { RouterModule, Routes } from '@angular/router';								
//#endregion																			
																						
//#region Custom Import																
import { BaseController } from '../../../Controllers/aaa/BaseController';			
import { SearchListController } from '../../../Controllers/aaa/SearchListController';
import { DetailController } from '../../../Controllers/aaa/DetailController';		
//#endregion																			
																						
//#region Definition																	
const setRoutes: Routes = [															
    {																				
        path: '',																	
        component: BaseController,													
        children: [																	
            { path: 'aaa/searchlist', component: SearchListController },				
            { path: 'aaa/adddetail/:Param', component: DetailController },			
            { path: 'aaa/editdetail/:Param', component: DetailController },			
            { path: 'aaa/viewdetail/:Param', component: DetailController },			
        ]																			
    }																				
];																					
@NgModule({																			
    imports: [RouterModule.forChild(setRoutes)],										
    exports: [RouterModule]															
})																					
//#endregion																			
																						
//#region Class																		
export class aaaRouting { }															
//#endregion																			
