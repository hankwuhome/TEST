//#region Import																							
import { NgModule } from '@angular/core';																   
import { FormsModule } from '@angular/forms';															   
import { CommonModule } from '@angular/common';															   
import { HttpModule } from '@angular/http';																   
//#endregion																							   
																										   
//#region Custom Import																					   
import { InputTrimModule } from 'ng2-trim-directive';													   
import { LayoutModule } from '../Layout/LayoutModule';													   
import { ActorSettingRouting } from '../../Routings/ActorSetting/ActorSettingRouting';   
import { BaseController } from '../../../Controllers/ActorSetting/BaseController';				   
import { SearchListController } from '../../../Controllers/ActorSetting/SearchListController';	   
import { DetailController } from '../../../Controllers/ActorSetting/DetailController';			   
import { ActorSettingService } from '../../../Services/ActorSetting/ActorSettingService';
//#endregion																							   
																										   
//#region Definition																					   
@NgModule({																								   
    imports: [																							   
        CommonModule,																					   
        FormsModule,																					   
        HttpModule,																						   
        ActorSettingRouting,																		   
        InputTrimModule,																				   
        LayoutModule.forRoot()																			   
    ],																									   
    declarations: [																						   
        BaseController,																					   
        SearchListController,																			   
        DetailController																				   
    ],																									   
    providers: [ActorSettingService],																   
    bootstrap: [BaseController]																			   
})																										   
//#endregion																							   
																										   
//#region Class																							   
export class ActorSettingModule { }																   
//#endregion																							   
