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
import { DeviceSellPriceHistoryRouting } from '../../Routings/DeviceSellPriceHistory/DeviceSellPriceHistoryRouting';   
import { BaseController } from '../../../Controllers/DeviceSellPriceHistory/BaseController';				   
import { SearchListController } from '../../../Controllers/DeviceSellPriceHistory/SearchListController';	   
import { DetailController } from '../../../Controllers/DeviceSellPriceHistory/DetailController';			   
import { DeviceSellPriceHistoryService } from '../../../Services/DeviceSellPriceHistory/DeviceSellPriceHistoryService';
//#endregion																							   
																										   
//#region Definition																					   
@NgModule({																								   
    imports: [																							   
        CommonModule,																					   
        FormsModule,																					   
        HttpModule,																						   
        DeviceSellPriceHistoryRouting,																		   
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
    providers: [DeviceSellPriceHistoryService],																   
    bootstrap: [BaseController]																			   
})																										   
//#endregion																							   
																										   
//#region Class																							   
export class DeviceSellPriceHistoryModule { }																   
//#endregion																							   
