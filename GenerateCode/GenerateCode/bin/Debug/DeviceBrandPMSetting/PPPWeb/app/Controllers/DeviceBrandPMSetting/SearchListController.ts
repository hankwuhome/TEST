//#region Import																													
import { Component, AfterViewInit, ViewChild, ElementRef } from '@angular/core';												  
import { Router } from '@angular/router';																						  
import { SearchInfoInitViewModel, SearchInfoViewModel, SearchListViewModel, SearchItemViewModel } from '../../ViewModels/DeviceBrandPMSetting/SearchListViewModel';									  
import { DeviceBrandPMSettingService } from '../../Services/DeviceBrandPMSetting/DeviceBrandPMSettingService';						  
import { EnumActiveType, ResponseViewModel, GlobalVariableViewModel, QueryStringViewModel } from '../../ViewModels/BaseViewModel';
import { BaseUtility } from '../../Utilities/BaseUtility';																		  
import { NgbPaginationConfig } from '@ng-bootstrap/ng-bootstrap';                                                                 
//#endregin																														  
																																  
//#region Definition																											  
@Component({																													  
    selector: 'DeviceBrandPMSetting-SearchList',																					  
    templateUrl: '../../Views/DeviceBrandPMSetting/SearchList.html',																  
    providers: [NgbPaginationConfig]                                                                                              
})																																  
//#endregin																														  
																																  
//#region Class																													  
export class SearchListController {																								  
																																  
    //#region Field																												  
    _page_btn_maxSize: number = 5;                                                                                    
    _pageName: string;																								  
    _tmp_sort: string = ""; 																						  
    _search_info_init: SearchInfoInitViewModel;																		  
    _search_info: SearchInfoViewModel;																			  
    _search_info_condition: SearchInfoViewModel;                                                              
    _search_list: SearchListViewModel;																		  
    private _response_object: ResponseViewModel = null;																			  
																																  
    //#endregion																												  
																																  
    //#region Initialized																										  
    constructor(private router: Router,                                                               
        private service: DeviceBrandPMSettingService,                                               
        private config: NgbPaginationConfig) {											  
        this._pageName = GlobalVariableViewModel.pageName;																		  
        this._search_info_init = new SearchInfoInitViewModel();																		  
        this._search_info = new SearchInfoViewModel();                                                                            
        this._search_info_condition = new SearchInfoViewModel();																		  
        this._response_object = new ResponseViewModel();																			  
																																  
        this.Init();																									  
    }																															  
    //#endregion																												  
																																  
    //#region Private Method																									  
    /** init */					
    private Init(){				
        this.SearchInfoInit();	
        this.SearchList();		
    }							
																																  
    /** init search info data */																								  
    private SearchInfoInit() {																									  
        //init search info																										  
        this.service.InitSearchInfo().subscribe(data => {																		  
            //set auth																											  
            this._response_object.authorization = data.headers.get('Authorization');												  
            //set body																											  
            this._response_object.body = JSON.parse(data._body);																	  
            //transfor																											  
            //this._search_info = (this._response_object.body.Data as SearchInfoInitViewModel);										  
																																  
            //console.log( this._search_info); ParameterLevel																	  
        });																														  
    }																															  
																																  
    private SearchList() {																										  
																																  
        if (null == this._search_list) {																							  
            this._search_list = new SearchListViewModel();																		  
        }																														  
																																  
        //this._search_condition.Page.PageSize = 10;																				  
        //this._search_condition.Page.PageIndex = 1;																				  
																																  
        this.service.Search(this._search_info_condition).subscribe(data => {															  
            //set auth																											  
            this._response_object.authorization = data.headers.get('Authorization');												  
            //set body																											  
            this._response_object.body = JSON.parse(data._body);																	  
            //transfor																											  
            this._search_list = (this._response_object.body.Data as SearchListViewModel);											  
            //console.log( this._search_list);																					  
        });     																												  
    }																															  
																																  
	private Paging() { //重置搜尋條件 > 帶入Page資訊 > Call SearchList											 
	}																																  
	private Sort(sortField: string) { //重置搜尋條件 > 帶入Page資訊 > 變更排序條件 > Call SearchList												 
	}																															  
    private EditDetail(model: SearchItemViewModel) {																					  
        var path = 'devicebrandpmsetting/editdetail';																				  
		//帶入轉址參數																														  
        var query_model:QueryStringViewModel[] = [];																			  
        //query_model.push(new QueryStringViewModel('Id', id));																	  
																																  
        var query_str = BaseUtility.CombileQueryString(query_model);															  
        																														  
        //console.log(query_str);																								  
																																  
        this.router.navigate([path, query_str]);																				  
    }																															  
																																  
    private ViewDetail(model: SearchItemViewModel) {																					  
        var path = 'devicebrandpmsetting/viewdetail';																				  
		//帶入轉址參數																														  
        var query_model:QueryStringViewModel[] = [];																			  
        //query_model.push(new QueryStringViewModel('Id', id));																	  
																																  
        var query_str = BaseUtility.CombileQueryString(query_model);															  
        																														  
        //console.log(query_str);																								  
																																  
        this.router.navigate([path, query_str]);																				  
    }																															  
																																  
    //#endregion																												  
}																																  
//#endregin																														  
