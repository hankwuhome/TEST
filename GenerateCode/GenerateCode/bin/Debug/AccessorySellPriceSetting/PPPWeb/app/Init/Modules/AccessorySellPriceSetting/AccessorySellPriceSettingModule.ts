//#region Import																							
import { NgModule } from '@angular/core';																   
import { FormsModule } from '@angular/forms';															   
import { CommonModule } from '@angular/common';															   
import { HttpModule } from '@angular/http';																   
//#endregion																							   
																										   
//#region Custom Import																					   
import { InputTrimModule } from 'ng2-trim-directive';													   
import { LayoutModule } from '../Layout/LayoutModule';													   
import { AccessorySellPriceSettingRouting } from '../../Routings/AccessorySellPriceSetting/AccessorySellPriceSettingRouting';   
import { BaseController } from '../../../Controllers/AccessorySellPriceSetting/BaseController';				   
import { SearchListController } from '../../../Controllers/AccessorySellPriceSetting/SearchListController';	   
import { DetailController } from '../../../Controllers/AccessorySellPriceSetting/DetailController';			   
import { AccessorySellPriceSettingService } from '../../../Services/AccessorySellPriceSetting/AccessorySellPriceSettingService';
//#endregion																							   
																										   
//#region Definition																					   
@NgModule({																								   
    imports: [																							   
        CommonModule,																					   
        FormsModule,																					   
        HttpModule,																						   
        AccessorySellPriceSettingRouting,																		   
        InputTrimModule,																				   
        LayoutModule.forRoot()																			   
    ],																									   
    declarations: [																						   
        BaseController,																					   
        SearchListController,																			   
        DetailController																				   
    ],																									   
    providers: [AccessorySellPriceSettingService],																   
    bootstrap: [BaseController]																			   
})																										   
//#endregion																							   
																										   
//#region Class																							   
export class AccessorySellPriceSettingModule { }																   
//#endregion																							   
