//#region Import																													
import { Component, AfterViewInit, ViewChild, ElementRef } from '@angular/core';												  
import { Router } from '@angular/router';																						  
import { BaseUtility } from '../../Utilities/BaseUtility';																		  
import { EnumActiveType, ResponseViewModel, GlobalVariableViewModel, QueryStringViewModel } from '../../ViewModels/BaseViewModel';
import { NgbPaginationConfig, NgbDatepicker, NgbInputDatepicker } from '@ng-bootstrap/ng-bootstrap';                                                                 
//#endregin																														  
																																  
//#region Custom Import																														  
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';                                                                       
import { SearchInfoInitViewModel, SearchInfoViewModel, SearchListViewModel, SearchItemViewModel, EnumSort  } from '../../ViewModels/ProjectPriceSell/SearchListViewModel';									  
import { ProjectPriceSellService } from '../../Services/ProjectPriceSell/ProjectPriceSellService';						  
//#endregin																														  
																																  
//#region Definition																											  
@Component({																													  
    selector: 'ProjectPriceSell-SearchList',																					  
    templateUrl: '../../Views/ProjectPriceSell/SearchList.html',																  
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
        private service: ProjectPriceSellService,                                               
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
        //this.SearchList();	
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
        this.DoSearchList();                                                                                                      
    }																															  
																																  
    private DoSearchList() {                                                                                                     
																																 
        if (null == this._search_list) {                                                                                         
            this._search_list = new SearchListViewModel();                                                                       
        }                                                                                                                        
																																 
		var compare = this.VarifyParams(this._search_info_condition);															 
		if (!compare) { return; }                                    															 
																																 
		this.service.Search(this._search_info_condition).subscribe(data => {													 
		    //set auth															                                                 
		    this._response_object.authorization = data.headers.get('Authorization');											 
		    //set body                                                                 											 
		    this._response_object.body = JSON.parse(data._body);															     
		    //transfor                                                                 											 
		    this._search_list = (this._response_object.body.Data as SearchListViewModel);                                        
																																 
		});                                                                 											         
	}                                                                                                                            
	private VarifyParams(_model: SearchInfoViewModel): boolean {                                                                 
	  var regex = /^.[A - Za - z0 - 9_] +$/g;                                                                                    
	  var accept_save: boolean = true;                                                                                           
																																 
	  // if (_model.ParameterCategoryCD != undefined &&                                                                          
	  //     _model.ParameterCategoryCD != '' &&                                                                                 
	  //     !regex.test(_model.ParameterCategoryCD)) {                                                                          
	  //     this._search_info_check.ParameterCategoryCD = "限輸入英文或數字或“_”符號";                                      
	  //     accept_save = false;                                                                                                
	  // }                                                                                                                       
	  // else { this._search_info_check.ParameterCategoryCD = ''; }                                                              
	            return accept_save;                                                               
	}                                                              
	private CleanSearchInfo()                                                              
	{                                                              
	    // this._search_info_condition.ParameterCategoryCD = this._search_info.ParameterCategoryCD = "";                         
	}                                                              
	//#region page select dalegate                                 
	Paging(totalCount, pageIndex) { //重置搜尋條件 > 帶入Page資訊 > Call SearchList											 
	    //reset page											 
	    this._search_info.Page.PageSize = parseInt(totalCount);											 
	    this._search_info.Page.PageIndex = parseInt(pageIndex);											 
	    this._search_info_condition.Page = this._search_info.Page;											 
                                                                                                                                 
	    //reset search info											 
	    this.CleanSearchInfo();											 
                                                                                                                                 
	    //do search info											 
	    this.DoSearchList();											 
	}																																  
	//#region Sort delegate                                 
	Sort(sortField: string) { //重置搜尋條件 > 帶入Page資訊 > 變更排序條件 > Call SearchList												 
	    var tmp_symbol = ""; 
	    //check sort param     
	    if (!BaseUtility.IsStringNonEmpty(this._tmp_sort)) {     
	        //is empty                                           
	        this._tmp_sort = `${sortField}_DESC`;                
	        tmp_symbol = "?";                                  
	    } else {                                                 
	      //non empty                                            
	     if (this._tmp_sort.startsWith(sortField)) {             
	        //change to desc or asc with the sort                
	        var after = this._tmp_sort.replace(`${sortField}_`, ""); 
	        switch (after)               
	        {                            
	            case "ASC":              
	                after = "DESC";       
	                tmp_symbol = "?";     
	                break;                  
	            case "DESC":              
	                after = "ASC";        
	                tmp_symbol = "?";     
	                break;                  
	        }                               
	        this._tmp_sort = `${ sortField}_${ after}`; 
	      }  else { 
	            //reset to new sort default desc 
	            this._tmp_sort = `${sortField}_DESC`; 
                tmp_symbol = "?"; 
          } 
       } 
       this.CheckSortPosition(tmp_symbol, this._tmp_sort); 
                                                           
       //set sort condition                                
       this._search_info.Sort = EnumSort[this._tmp_sort];  
                                                           
       //clean search info                                 
       this.CleanSearchInfo();                                 
                                                           
       //do search                                 
       this.SearchList();                                
	}																															  
	private CheckSortPosition(symbol: string, tmp_sort: string) { 
	    this.CleanSymbols();                                
	    // switch (tmp_sort) {                              
	    //     case EnumSort.PARAMETER_LEVEL_ASC:    
	    //         this._symbols.ParameterLevelName = "?";    
	    //         break;                                    
	    //     case EnumSort.PARAMETER_LEVEL_DESC:    
	    //         this._symbols.ParameterLevelName = "?";    
	    //         break;                                    
	    //     default:    
	    //         this.CleanSymbols();    
	    //         break;   }                                 
	 } 
	 private CleanSymbols() 
	 {                      
	      // this._symbols.ParameterCategoryCD = "";             
	 }                      
	 //#endregion           
    private AddDetail(model: SearchItemViewModel) {																					  
        var path = 'projectpricesell/adddetail';																				  
		//帶入轉址參數																														  
        var query_model:QueryStringViewModel[] = [];																			  
        //query_model.push(new QueryStringViewModel('Id', id));																	  
																																  
        var query_str = BaseUtility.CombileQueryString(query_model);															  
        																														  
        //console.log(query_str);																								  
																																  
        this.router.navigate([path, query_str]);																				  
    }																															  
																																  
    private EditDetail(model: SearchItemViewModel) {																					  
        var path = 'projectpricesell/editdetail';																				  
		//帶入轉址參數																														  
        var query_model:QueryStringViewModel[] = [];																			  
        //query_model.push(new QueryStringViewModel('Id', id));																	  
																																  
        var query_str = BaseUtility.CombileQueryString(query_model);															  
        																														  
        //console.log(query_str);																								  
																																  
        this.router.navigate([path, query_str]);																				  
    }																															  
																																  
    private ViewDetail(model: SearchItemViewModel) {																					  
        var path = 'projectpricesell/viewdetail';																				  
		//帶入轉址參數																														  
        var query_model:QueryStringViewModel[] = [];																			  
        //query_model.push(new QueryStringViewModel('Id', id));																	  
																																  
        var query_str = BaseUtility.CombileQueryString(query_model);															  
        																														  
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
