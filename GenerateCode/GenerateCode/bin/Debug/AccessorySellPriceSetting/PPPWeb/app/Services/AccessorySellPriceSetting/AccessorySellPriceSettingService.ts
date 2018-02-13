//#region Common Import																						
import { Injectable } from '@angular/core';																	
import { Observable } from 'rxjs/Rx';																		
import { BaseService } from '../BaseService';																
//#endregion																								
																											
//#region Custom Import																						
import { ResponseViewModel, GlobalVariableViewModel, EnumActiveType } from '../../ViewModels/BaseViewModel';
import { SearchInfoInitViewModel, SearchInfoViewModel ,SearchListViewModel, SearchItemViewModel } from '../../ViewModels/AccessorySellPriceSetting/SearchListViewModel';	
import { DetailRequesViewModel, DetailViewModel } from '../../ViewModels/AccessorySellPriceSetting/DetailViewModel';								
//#endregion																								
																											
//#region Class																								
@Injectable()																								
export class AccessorySellPriceSettingService {																					
																											
    //#region Initialize																					
    constructor(private baseService: BaseService) { }														
    //#endregion																							
																											
    //#region Public Method																					
																											
    /** get search info init data */																		
    public InitSearchInfo(): Observable<any> 																
    {																										
        return this.baseService.HttpPost(GlobalVariableViewModel.api_domain+'AccessorySellPriceSetting/SearchInfoInit', null);	
    }																										
																											
    /** get search data */																					
    public Search(model: SearchInfoViewModel): Observable<any> {											
																											
        return this.baseService.HttpPost(GlobalVariableViewModel.api_domain+'AccessorySellPriceSetting/SearchList', model);		
    }																										
																											
    /** Sort */																								
    public Sort() {																							
																											
    }																										
																											
    /** Paginging */																						
    public Paging() {																						
																											
    }																										
																											
    /** Init Detail */																						
    public InitDetail(model:DetailRequesViewModel): Observable<any> {										
        return this.baseService.HttpPost(GlobalVariableViewModel.api_domain+'AccessorySellPriceSetting/ViewDetail', model);		
    }																										
																											
    /** Save Detail */																						
    public SaveDetail(model: DetailViewModel): Observable<any> {												
        return this.baseService.HttpPost(GlobalVariableViewModel.api_domain+'AccessorySellPriceSetting/Detail', model);			
    }																										
																											
    /** Delete Detail */																					
    public DeleteDetail(model: SearchItemViewModel): Observable<any> {									
        return this.baseService.HttpPost(GlobalVariableViewModel.api_domain+'AccessorySellPriceSetting/Detail', model);			
    }																										
    //#endregion																							
}																											
//#endregion																								
