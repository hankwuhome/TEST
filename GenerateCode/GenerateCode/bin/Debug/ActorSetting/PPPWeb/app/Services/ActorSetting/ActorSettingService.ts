//#region Common Import																						
import { Injectable } from '@angular/core';																	
import { Observable } from 'rxjs/Rx';																		
import { BaseService } from '../BaseService';																
//#endregion																								
																											
//#region Custom Import																						
import { ResponseViewModel, GlobalVariableViewModel, EnumActiveType } from '../../ViewModels/BaseViewModel';
import { SearchInfoInitViewModel, SearchInfoViewModel ,SearchListViewModel, SearchItemViewModel } from '../../ViewModels/ActorSetting/SearchListViewModel';	
import { DetailRequesViewModel, DetailViewModel } from '../../ViewModels/ActorSetting/DetailViewModel';								
//#endregion																								
																											
//#region Class																								
@Injectable()																								
export class ActorSettingService {																					
																											
    //#region Initialize																					
    constructor(private baseService: BaseService) { }														
    //#endregion																							
																											
    //#region Public Method																					
																											
    /** get search info init data */																		
    public InitSearchInfo(): Observable<any> 																
    {																										
        return this.baseService.HttpPost(GlobalVariableViewModel.api_domain+'ActorSetting/SearchInfoInit', null);	
    }																										
																											
    /** get search data */																					
    public Search(model: SearchInfoViewModel): Observable<any> {											
																											
        return this.baseService.HttpPost(GlobalVariableViewModel.api_domain+'ActorSetting/SearchList', model);		
    }																										
																											
    /** Sort */																								
    public Sort() {																							
																											
    }																										
																											
    /** Paginging */																						
    public Paging() {																						
																											
    }																										
																											
    /** Init Detail */																						
    public InitDetail(model:DetailRequesViewModel): Observable<any> {										
        return this.baseService.HttpPost(GlobalVariableViewModel.api_domain+'ActorSetting/ViewDetail', model);		
    }																										
																											
    /** Save Detail */																						
    public SaveDetail(model: DetailViewModel): Observable<any> {												
        return this.baseService.HttpPost(GlobalVariableViewModel.api_domain+'ActorSetting/Detail', model);			
    }																										
																											
    /** Delete Detail */																					
    public DeleteDetail(model: SearchListItemViewModel): Observable<any> {									
        return this.baseService.HttpPost(GlobalVariableViewModel.api_domain+'ActorSetting/Detail', model);			
    }																										
    //#endregion																							
}																											
//#endregion																								
