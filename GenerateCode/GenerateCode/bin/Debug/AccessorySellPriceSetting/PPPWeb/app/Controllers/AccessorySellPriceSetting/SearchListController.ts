//#region Import																													
import { Component, AfterViewInit, ViewChild, ElementRef } from '@angular/core';												  
import { Router } from '@angular/router';																						  
import { SearchInfoInitViewModel, SearchInfoViewModel, SearchListViewModel, SearchItemViewModel } from '../../ViewModels/AccessorySellPriceSetting/SearchListViewModel';									  
import { AccessorySellPriceSettingService } from '../../Services/AccessorySellPriceSetting/AccessorySellPriceSettingService';						  
import { EnumActiveType, ResponseViewModel, GlobalVariableViewModel, QueryStringViewModel } from '../../ViewModels/BaseViewModel';
import { BaseUtinity } from '../../Utilities/BaseUtinity';																		  
//#endregin																														  
																																  
//#region Definition																											  
@Component({																													  
    selector: 'AccessorySellPriceSetting-SearchList',																					  
    templateUrl: '../../Views/AccessorySellPriceSetting/SearchList.html'																  
})																																  
//#endregin																														  
																																  
//#region Class																													  
export class SearchListController {																								  
																																  
    //#region Field																												  
    _pageName: string;																								  
    _search_info_init: SearchInfoInitViewModel;																		  
    _search_info: SearchInfoViewModel;																			  
    _search_list: SearchListViewModel;																		  
    private _response_object: ResponseViewModel = null;																			  
																																  
    //#endregion																												  
																																  
    //#region Initialized																										  
    constructor(private router: Router, private service: AccessorySellPriceSettingService) {											  
        this._pageName = GlobalVariableViewModel.pageName;																		  
        this._search_info = new SearchInfoInitViewModel();																		  
        this._search_condition = new SearchInfoViewModel();																		  
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
            this._search_info = (this._response_object.body.Data as SearchInfoInitViewModel);										  
																																  
            //console.log( this._search_info); ParameterLevel																	  
        });																														  
    }																															  
																																  
    private SearchList() {																										  
																																  
        if (null == this._search_list) {																							  
            this._search_list = new SearchListViewModel();																		  
        }																														  
																																  
        this._search_condition.Page.PageSize = 10;																				  
        this._search_condition.Page.PageIndex = 1;																				  
																																  
        this.service.Search(this._search_condition).subscribe(data => {															  
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
        var path = 'accessorysellpricesetting/editdetail';																				  
		//帶入轉址參數																														  
        var query_model:QueryStringViewModel[] = [];																			  
        //query_model.push(new QueryStringViewModel('Id', id));																	  
																																  
        var query_str = BaseUtinity.CombileQueryString(query_model);															  
        																														  
        //console.log(query_str);																								  
																																  
        this.router.navigate([path, query_str]);																				  
    }																															  
																																  
    private ViewDetail(model: SearchItemViewModel) {																					  
        var path = 'accessorysellpricesetting/viewdetail';																				  
		//帶入轉址參數																														  
        var query_model:QueryStringViewModel[] = [];																			  
        //query_model.push(new QueryStringViewModel('Id', id));																	  
																																  
        var query_str = BaseUtinity.CombileQueryString(query_model);															  
        																														  
        //console.log(query_str);																								  
																																  
        this.router.navigate([path, query_str]);																				  
    }																															  
																																  
    private DeleteDetail(model: SearchListItemViewModel) {			  
        model.ActiveType = EnumActiveType.DELETE;			  
																  
        this.service.deleteDetail(model).subscribe(data => {	  
            //set body										  
            this._response_object.body = JSON.parse(data._body);
																  
            if (null != this._response_object.body.Data &&	  
                (this._response_object.body.Data as boolean)) { 
																  
                this.Init();									  
                alert('刪除成功');							  
            }												  
            else { alert('刪除失敗'); }						  
        });													  
    }														  
    //#endregion																												  
}																																  
//#endregin																														  
