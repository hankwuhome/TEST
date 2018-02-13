//#region Import																							
import { NgModule } from '@angular/core';																   
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';                                                    
import { FormsModule } from '@angular/forms';															   
import { CommonModule } from '@angular/common';															   
import { HttpModule } from '@angular/http';																   
//#endregion																							   
																										   
//#region Custom Import																					   
import { NgDatepickerModule } from 'ng2-datepicker';                                                       
import { InputTrimModule } from 'ng2-trim-directive';													   
import { LayoutModule } from '../Layout/LayoutModule';													   
import { DeviceBrandPMSettingRouting } from '../../Routings/DeviceBrandPMSetting/DeviceBrandPMSettingRouting';   
import { BaseController } from '../../../Controllers/DeviceBrandPMSetting/BaseController';				   
import { SearchListController } from '../../../Controllers/DeviceBrandPMSetting/SearchListController';	   
import { DetailController } from '../../../Controllers/DeviceBrandPMSetting/DetailController';			   
import { DeviceBrandPMSettingService } from '../../../Services/DeviceBrandPMSetting/DeviceBrandPMSettingService';
//#endregion																							   
																										   
//#region Definition																					   
@NgModule({																								   
    imports: [																							   
        CommonModule,																					   
        FormsModule,																					   
        HttpModule,																						   
        DeviceBrandPMSettingRouting,																		   
        InputTrimModule,																				   
        LayoutModule.forRoot(),																			   
        NgbModule.forRoot(),                                                                               
        NgDatepickerModule                                                                                 
    ],																									   
    declarations: [																						   
        BaseController,																					   
        SearchListController,																			   
        DetailController																				   
    ],																									   
    providers: [DeviceBrandPMSettingService],																   
    bootstrap: [BaseController]																			   
})																										   
//#endregion																							   
																										   
//#region Class																							   
export class DeviceBrandPMSettingModule { }																   
//#endregion																							   
