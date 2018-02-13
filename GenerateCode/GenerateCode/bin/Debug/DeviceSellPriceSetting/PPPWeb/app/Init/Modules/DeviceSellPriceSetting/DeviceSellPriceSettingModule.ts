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
import { DeviceSellPriceSettingRouting } from '../../Routings/DeviceSellPriceSetting/DeviceSellPriceSettingRouting';   
import { BaseController } from '../../../Controllers/DeviceSellPriceSetting/BaseController';				   
import { SearchListController } from '../../../Controllers/DeviceSellPriceSetting/SearchListController';	   
import { DetailController } from '../../../Controllers/DeviceSellPriceSetting/DetailController';			   
import { DeviceSellPriceSettingService } from '../../../Services/DeviceSellPriceSetting/DeviceSellPriceSettingService';
//#endregion																							   
																										   
//#region Definition																					   
@NgModule({																								   
    imports: [																							   
        CommonModule,																					   
        FormsModule,																					   
        HttpModule,																						   
        DeviceSellPriceSettingRouting,																		   
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
    providers: [DeviceSellPriceSettingService],																   
    bootstrap: [BaseController]																			   
})																										   
//#endregion																							   
																										   
//#region Class																							   
export class DeviceSellPriceSettingModule { }																   
//#endregion																							   
