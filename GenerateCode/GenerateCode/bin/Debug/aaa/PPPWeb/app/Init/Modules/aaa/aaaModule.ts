//#region Import																							
import { NgModule } from '@angular/core';																   
import { FormsModule } from '@angular/forms';															   
import { CommonModule } from '@angular/common';															   
import { HttpModule } from '@angular/http';																   
//#endregion																							   
																										   
//#region Custom Import																					   
import { InputTrimModule } from 'ng2-trim-directive';													   
import { LayoutModule } from '../Layout/LayoutModule';													   
import { aaaRouting } from '../../Routings/aaa/aaaRouting';   
import { BaseController } from '../../../Controllers/aaa/BaseController';				   
import { SearchListController } from '../../../Controllers/aaa/SearchListController';	   
import { DetailController } from '../../../Controllers/aaa/DetailController';			   
import { aaaService } from '../../../Services/aaa/aaaService';
//#endregion																							   
																										   
//#region Definition																					   
@NgModule({																								   
    imports: [																							   
        CommonModule,																					   
        FormsModule,																					   
        HttpModule,																						   
        aaaRouting,																		   
        InputTrimModule,																				   
        LayoutModule.forRoot()																			   
    ],																									   
    declarations: [																						   
        BaseController,																					   
        SearchListController,																			   
        DetailController																				   
    ],																									   
    providers: [aaaService],																   
    bootstrap: [BaseController]																			   
})																										   
//#endregion																							   
																										   
//#region Class																							   
export class aaaModule { }																   
//#endregion																							   
