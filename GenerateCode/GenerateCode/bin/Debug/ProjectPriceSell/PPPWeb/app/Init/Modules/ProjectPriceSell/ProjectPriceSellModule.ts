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
import { ProjectPriceSellRouting } from '../../Routings/ProjectPriceSell/ProjectPriceSellRouting';   
import { BaseController } from '../../../Controllers/ProjectPriceSell/BaseController';				   
import { SearchListController } from '../../../Controllers/ProjectPriceSell/SearchListController';	   
import { DetailController } from '../../../Controllers/ProjectPriceSell/DetailController';			   
import { ProjectPriceSellService } from '../../../Services/ProjectPriceSell/ProjectPriceSellService';
//#endregion																							   
																										   
//#region Definition																					   
@NgModule({																								   
    imports: [																							   
        CommonModule,																					   
        FormsModule,																					   
        HttpModule,																						   
        ProjectPriceSellRouting,																		   
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
    providers: [ProjectPriceSellService],																   
    bootstrap: [BaseController]																			   
})																										   
//#endregion																							   
																										   
//#region Class																							   
export class ProjectPriceSellModule { }																   
//#endregion																							   
