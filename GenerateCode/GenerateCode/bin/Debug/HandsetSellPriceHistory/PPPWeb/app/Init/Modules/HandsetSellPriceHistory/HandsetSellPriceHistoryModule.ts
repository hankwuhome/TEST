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
import { HandsetSellPriceHistoryRouting } from '../../Routings/HandsetSellPriceHistory/HandsetSellPriceHistoryRouting';   
import { BaseController } from '../../../Controllers/HandsetSellPriceHistory/BaseController';				   
import { SearchListController } from '../../../Controllers/HandsetSellPriceHistory/SearchListController';	   
import { DetailController } from '../../../Controllers/HandsetSellPriceHistory/DetailController';			   
import { HandsetSellPriceHistoryService } from '../../../Services/HandsetSellPriceHistory/HandsetSellPriceHistoryService';
//#endregion																							   
																										   
//#region Definition																					   
@NgModule({																								   
    imports: [																							   
        CommonModule,																					   
        FormsModule,																					   
        HttpModule,																						   
        HandsetSellPriceHistoryRouting,																		   
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
    providers: [HandsetSellPriceHistoryService],																   
    bootstrap: [BaseController]																			   
})																										   
//#endregion																							   
																										   
//#region Class																							   
export class HandsetSellPriceHistoryModule { }																   
//#endregion																							   
