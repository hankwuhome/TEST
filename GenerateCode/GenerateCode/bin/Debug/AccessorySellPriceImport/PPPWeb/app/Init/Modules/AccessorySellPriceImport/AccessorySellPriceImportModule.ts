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
import { AccessorySellPriceImportRouting } from '../../Routings/AccessorySellPriceImport/AccessorySellPriceImportRouting';   
import { BaseController } from '../../../Controllers/AccessorySellPriceImport/BaseController';				   
import { SearchListController } from '../../../Controllers/AccessorySellPriceImport/SearchListController';	   
import { DetailController } from '../../../Controllers/AccessorySellPriceImport/DetailController';			   
import { AccessorySellPriceImportService } from '../../../Services/AccessorySellPriceImport/AccessorySellPriceImportService';
//#endregion																							   
																										   
//#region Definition																					   
@NgModule({																								   
    imports: [																							   
        CommonModule,																					   
        FormsModule,																					   
        HttpModule,																						   
        AccessorySellPriceImportRouting,																		   
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
    providers: [AccessorySellPriceImportService],																   
    bootstrap: [BaseController]																			   
})																										   
//#endregion																							   
																										   
//#region Class																							   
export class AccessorySellPriceImportModule { }																   
//#endregion																							   
