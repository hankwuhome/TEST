using GenerateCode.Models;
using GenerateCode.Repositories;
using GenerateCode.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateCode.Services
{
    static class GenerateWebCodeService
    {
        #region Enums
        enum EnumFileType
        {
            SearchInfo,
            ViewDetail,
        }
        #endregion

        #region Properties
        private static string _appPath = Path.GetDirectoryName(Application.ExecutablePath);

        private static List<string> _pathes = new List<string>()
        {
            "{0}/PPPWeb/app/Controllers/{0}",
            "{0}/PPPWeb/app/Init/Modules/{0}",
            "{0}/PPPWeb/app/Init/Routings/{0}",
            "{0}/PPPWeb/app/Services/{0}",
            "{0}/PPPWeb/app/ViewModels/{0}",
            "{0}/PPPWeb/app/Views/{0}",
        };
        #endregion

        #region Public Methods
        public static void CreatePathes(string controllerName)
        {
            #region 參數宣告
            List<string> newpathes = new List<string>();

            #endregion

            #region 流程
            _pathes.ForEach(path => {
                string newpath = Path.Combine(_appPath, string.Format(path, controllerName));
                FileService.CreatePath(newpath);
            });
            #endregion
        }
        public static void GenerateCode(string controllerName, bool generateSearchList, bool generateDetail, List<string> searchListActionList)
        {
            #region 參數宣告
            #endregion

            #region 流程

            #region Generate Controllers
            GenerateBaseController(controllerName);
            if (generateSearchList)
            {
                GenerateSearchListController(controllerName, searchListActionList);
            }
            if (generateDetail)
            {
                GenerateDetailController(controllerName);
            }
            #endregion

            #region Generate Modules
            GenerateModule(controllerName);
            #endregion

            #region Generate Routings
            GenerateRouting(controllerName, searchListActionList);
            #endregion

            #region Generate Services
            GenerateService(controllerName);
            #endregion

            #region Generate ViewModels
            if (generateSearchList)
            {
                GenerateSearchListViewModel(controllerName);
            }
            if (generateDetail)
            {
                GenerateDetailViewModel(controllerName);
            }
            #endregion

            #region Views
            GenerateBaseHtml(controllerName);
            if (generateSearchList)
            {
                GenerateSearchListHtml(controllerName, searchListActionList);
            }
            if (generateDetail)
            {
                GenerateDetailHtml(controllerName);
            }
            #endregion

            #endregion

        }
        #endregion

        #region Private Methods

        #region GenerateControllers

        /// <summary>
        /// Generate BaseController
        /// </summary>
        /// <param name="controllerName"></param>
        private static void GenerateBaseController(string controllerName)
        {
            #region 參數宣告
            
            string path = string.Concat(_appPath, "/", string.Format(_pathes[0], controllerName), "/");
            string filename = string.Format("BaseController.ts", controllerName);
            StringBuilder content = new StringBuilder();
            #endregion

            #region 流程
            content.AppendLine("//#region Import											");
            content.AppendLine("import { Component } from '@angular/core';					");
            content.AppendLine("//#endregin													");
            content.AppendLine("															");
            content.AppendLine("//#region Definition										");
            content.AppendLine("@Component({												");
            content.AppendLine(string.Format("    selector: '{0}-Base',					", controllerName));
            content.AppendLine(string.Format("    templateUrl: '../../Views/{0}/Base.html'	", controllerName));
            content.AppendLine("})															");
            content.AppendLine("//#endregin													");
            content.AppendLine("															");
            content.AppendLine("//#region Class												");
            content.AppendLine("export class BaseController {}								");
            content.AppendLine("//#endregin													");
            FileService.CreateFile(path, filename, content.ToString());
            #endregion
        }

        /// <summary>
        /// Generate SearchListController
        /// </summary>
        /// <param name="controllerName"></param>
        /// <param name="searchListActionList"></param>
        private static void GenerateSearchListController(string controllerName, List<string> searchListActionList)
        {
            #region 參數宣告
            string paramAction = "";
            string path = string.Concat(_appPath, "/", string.Format(_pathes[0], controllerName), "/");
            string filename = string.Format("SearchListController.ts", controllerName);
            StringBuilder content = new StringBuilder();
            #endregion

            #region 流程

            content.AppendLine("//#region Import																													");
            content.AppendLine("import { Component, AfterViewInit, ViewChild, ElementRef } from '@angular/core';												  ");
            content.AppendLine("import { Router } from '@angular/router';																						  ");
            content.AppendLine("import { BaseUtility } from '../../Utilities/BaseUtility';																		  ");
            content.AppendLine("import { EnumActiveType, ResponseViewModel, GlobalVariableViewModel, QueryStringViewModel } from '../../ViewModels/BaseViewModel';");
            content.AppendLine("import { NgbPaginationConfig, NgbDatepicker, NgbInputDatepicker } from '@ng-bootstrap/ng-bootstrap';                                                                 ");
            content.AppendLine("//#endregin																														  ");
            content.AppendLine("																																  ");
            content.AppendLine("//#region Custom Import																														  ");
            content.AppendLine("import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';                                                                       ");
            content.AppendLine("import { SearchInfoInitViewModel, SearchInfoViewModel, SearchListViewModel, SearchItemViewModel, EnumSort  } from '../../ViewModels/" + controllerName + "/SearchListViewModel';									  ");
            content.AppendLine("import { " + controllerName + "Service }" + string.Format(" from '../../Services/{0}/{0}Service';						  ", controllerName));
            content.AppendLine("//#endregin																														  ");           
            content.AppendLine("																																  ");
            content.AppendLine("//#region Definition																											  ");
            content.AppendLine("@Component({																													  ");
            content.AppendLine(string.Format("    selector: '{0}-SearchList',																					  ", controllerName));
            content.AppendLine(string.Format("    templateUrl: '../../Views/{0}/SearchList.html',																  ", controllerName));
            content.AppendLine("    providers: [NgbPaginationConfig]                                                                                              ");
            content.AppendLine("})																																  ");
            content.AppendLine("//#endregin																														  ");
            content.AppendLine("																																  ");
            content.AppendLine("//#region Class																													  ");
            content.AppendLine("export class SearchListController {																								  ");
            content.AppendLine("																																  ");
            content.AppendLine("    //#region Field																												  ");
            content.AppendLine("    _page_btn_maxSize: number = 5;                                                                                    ");
            content.AppendLine("    _pageName: string;																								  ");
            content.AppendLine("    _tmp_sort: string = \"\"; 																						  ");
            content.AppendLine("    _search_info_init: SearchInfoInitViewModel;																		  ");
            content.AppendLine("    _search_info: SearchInfoViewModel;																			  ");
            content.AppendLine("    _search_info_condition: SearchInfoViewModel;                                                              ");
            content.AppendLine("    _search_list: SearchListViewModel;																		  ");
            content.AppendLine("    private _response_object: ResponseViewModel = null;																			  ");
            content.AppendLine("																																  ");
            //content.AppendLine("    @ViewChild('listTable') listTable: ElementRef;																				  ");
            content.AppendLine("    //#endregion																												  ");
            content.AppendLine("																																  ");
            content.AppendLine("    //#region Initialized																										  ");
            content.AppendLine("    constructor(private router: Router,                                                               ");
            content.AppendLine("        private service: " + controllerName + "Service,                                               ");
            content.AppendLine("        private config: NgbPaginationConfig) {											  ");
            content.AppendLine("        this._pageName = GlobalVariableViewModel.pageName;																		  ");
            content.AppendLine("        this._search_info_init = new SearchInfoInitViewModel();																		  ");
            content.AppendLine("        this._search_info = new SearchInfoViewModel();                                                                            ");
            content.AppendLine("        this._search_info_condition = new SearchInfoViewModel();																		  ");
            content.AppendLine("        this._response_object = new ResponseViewModel();																			  ");
            content.AppendLine("																																  ");
            content.AppendLine("        this.Init();																									  ");
            content.AppendLine("    }																															  ");
            content.AppendLine("    //#endregion																												  ");
            content.AppendLine("																																  ");
            content.AppendLine("    //#region Private Method																									  ");
            content.AppendLine("    /** init */					");
            content.AppendLine("    private Init(){				");
            content.AppendLine("        this.SearchInfoInit();	");
            content.AppendLine("        //this.SearchList();	");
            content.AppendLine("    }							");
            content.AppendLine("																																  ");
            content.AppendLine("    /** init search info data */																								  ");
            content.AppendLine("    private SearchInfoInit() {																									  ");
            content.AppendLine("        //init search info																										  ");
            content.AppendLine("        this.service.InitSearchInfo().subscribe(data => {																		  ");
            content.AppendLine("            //set auth																											  ");
            content.AppendLine("            this._response_object.authorization = data.headers.get('Authorization');												  ");
            content.AppendLine("            //set body																											  ");
            content.AppendLine("            this._response_object.body = JSON.parse(data._body);																	  ");
            content.AppendLine("            //transfor																											  ");
            content.AppendLine("            this._search_info = (this._response_object.body.Data as SearchInfoInitViewModel);										  ");
            content.AppendLine("																																  ");
            content.AppendLine("            //console.log( this._search_info); ParameterLevel																	  ");
            content.AppendLine("        });																														  ");
            content.AppendLine("    }																															  ");
            content.AppendLine("																																  ");
            content.AppendLine("    private SearchList() {																										  ");
            content.AppendLine("																																  ");
            content.AppendLine("        if (null == this._search_list) {																							  ");
            content.AppendLine("            this._search_list = new SearchListViewModel();																		  ");
            content.AppendLine("        }																														  ");
            content.AppendLine("																																  ");
            content.AppendLine("        //this._search_condition.Page.PageSize = 10;																				  ");
            content.AppendLine("        //this._search_condition.Page.PageIndex = 1;																				  ");
            content.AppendLine("																																  ");
            content.AppendLine("        this.service.Search(this._search_info_condition).subscribe(data => {															  ");
            content.AppendLine("            //set auth																											  ");
            content.AppendLine("            this._response_object.authorization = data.headers.get('Authorization');												  ");
            content.AppendLine("            //set body																											  ");
            content.AppendLine("            this._response_object.body = JSON.parse(data._body);																	  ");
            content.AppendLine("            //transfor																											  ");
            content.AppendLine("            this._search_list = (this._response_object.body.Data as SearchListViewModel);											  ");
            content.AppendLine("            //console.log( this._search_list);																					  ");
            content.AppendLine("        });     																												  ");
            content.AppendLine("        this.DoSearchList();                                                                                                      ");
            content.AppendLine("    }																															  ");
            content.AppendLine("																																  ");
            content.AppendLine("    private DoSearchList() {                                                                                                     ");
            content.AppendLine("																																 ");
            content.AppendLine("        if (null == this._search_list) {                                                                                         ");
            content.AppendLine("            this._search_list = new SearchListViewModel();                                                                       ");
            content.AppendLine("        }                                                                                                                        ");
            content.AppendLine("																																 ");
            content.AppendLine("		var compare = this.VarifyParams(this._search_info_condition);															 ");
            content.AppendLine("		if (!compare) { return; }                                    															 ");
            content.AppendLine("																																 ");
            content.AppendLine("		this.service.Search(this._search_info_condition).subscribe(data => {													 ");
            content.AppendLine("		    //set auth															                                                 ");
            content.AppendLine("		    this._response_object.authorization = data.headers.get('Authorization');											 ");
            content.AppendLine("		    //set body                                                                 											 ");
            content.AppendLine("		    this._response_object.body = JSON.parse(data._body);															     ");
            content.AppendLine("		    //transfor                                                                 											 ");
            content.AppendLine("		    this._search_list = (this._response_object.body.Data as SearchListViewModel);                                        ");
            content.AppendLine("																																 ");
            content.AppendLine("		});                                                                 											         ");
            content.AppendLine("	}                                                                                                                            ");
            content.AppendLine("	private VarifyParams(_model: SearchInfoViewModel): boolean {                                                                 ");
            content.AppendLine("	  var regex = /^.[A - Za - z0 - 9_] +$/g;                                                                                    ");
            content.AppendLine("	  var accept_save: boolean = true;                                                                                           ");
            content.AppendLine("																																 ");
            content.AppendLine("	  // if (_model.ParameterCategoryCD != undefined &&                                                                          ");
            content.AppendLine("	  //     _model.ParameterCategoryCD != '' &&                                                                                 ");
            content.AppendLine("	  //     !regex.test(_model.ParameterCategoryCD)) {                                                                          ");
            content.AppendLine("	  //     this._search_info_check.ParameterCategoryCD = \"限輸入英文或數字或“_”符號\";                                      ");
            content.AppendLine("	  //     accept_save = false;                                                                                                ");
            content.AppendLine("	  // }                                                                                                                       ");
            content.AppendLine("	  // else { this._search_info_check.ParameterCategoryCD = ''; }                                                              ");
            content.AppendLine("	            return accept_save;                                                               ");
            content.AppendLine("	}                                                              ");
            content.AppendLine("	private CleanSearchInfo()                                                              ");
            content.AppendLine("	{                                                              ");
            content.AppendLine("	    // this._search_info_condition.ParameterCategoryCD = this._search_info.ParameterCategoryCD = \"\";                         ");
            content.AppendLine("	}                                                              ");
            content.AppendLine("	//#region page select dalegate                                 ");
            content.AppendLine("	Paging(totalCount, pageIndex) { //重置搜尋條件 > 帶入Page資訊 > Call SearchList											 ");
            content.AppendLine("	    //reset page											 ");
            content.AppendLine("	    this._search_info.Page.PageSize = parseInt(totalCount);											 ");
            content.AppendLine("	    this._search_info.Page.PageIndex = parseInt(pageIndex);											 ");
            content.AppendLine("	    this._search_info_condition.Page = this._search_info.Page;											 ");
            content.AppendLine("                                                                                                                                 ");
            content.AppendLine("	    //reset search info											 ");
            content.AppendLine("	    this.CleanSearchInfo();											 ");
            content.AppendLine("                                                                                                                                 ");
            content.AppendLine("	    //do search info											 ");
            content.AppendLine("	    this.DoSearchList();											 ");
            content.AppendLine("	}																																  ");
            content.AppendLine("	//#region Sort delegate                                 ");
            content.AppendLine("	Sort(sortField: string) { //重置搜尋條件 > 帶入Page資訊 > 變更排序條件 > Call SearchList												 ");
            content.AppendLine("	    var tmp_symbol = \"\"; ");
            content.AppendLine("	    //check sort param     ");
            content.AppendLine("	    if (!BaseUtility.IsStringNonEmpty(this._tmp_sort)) {     ");
            content.AppendLine("	        //is empty                                           ");
            content.AppendLine("	        this._tmp_sort = `${sortField}_DESC`;                ");
            content.AppendLine("	        tmp_symbol = \"?\";                                  ");
            content.AppendLine("	    } else {                                                 ");
            content.AppendLine("	      //non empty                                            ");
            content.AppendLine("	     if (this._tmp_sort.startsWith(sortField)) {             ");
            content.AppendLine("	        //change to desc or asc with the sort                ");
            content.AppendLine("	        var after = this._tmp_sort.replace(`${sortField}_`, \"\"); ");
            content.AppendLine("	        switch (after)               ");
            content.AppendLine("	        {                            ");
            content.AppendLine("	            case \"ASC\":              ");
            content.AppendLine("	                after = \"DESC\";       ");
            content.AppendLine("	                tmp_symbol = \"?\";     ");
            content.AppendLine("	                break;                  ");
            content.AppendLine("	            case \"DESC\":              ");
            content.AppendLine("	                after = \"ASC\";        ");
            content.AppendLine("	                tmp_symbol = \"?\";     ");
            content.AppendLine("	                break;                  ");
            content.AppendLine("	        }                               ");
            content.AppendLine("	        this._tmp_sort = `${ sortField}_${ after}`; ");
            content.AppendLine("	      }  else { ");
            content.AppendLine("	            //reset to new sort default desc ");
            content.AppendLine("	            this._tmp_sort = `${sortField}_DESC`; ");
            content.AppendLine("                tmp_symbol = \"?\"; ");
            content.AppendLine("          } ");
            content.AppendLine("       } ");
            content.AppendLine("       this.CheckSortPosition(tmp_symbol, this._tmp_sort); ");
            content.AppendLine("                                                           ");
            content.AppendLine("       //set sort condition                                ");
            content.AppendLine("       this._search_info.Sort = EnumSort[this._tmp_sort];  ");
            content.AppendLine("                                                           ");
            content.AppendLine("       //clean search info                                 ");
            content.AppendLine("       this.CleanSearchInfo();                                 ");
            content.AppendLine("                                                           ");
            content.AppendLine("       //do search                                 ");
            content.AppendLine("       this.SearchList();                                ");
            content.AppendLine("	}																															  ");
            content.AppendLine("	private CheckSortPosition(symbol: string, tmp_sort: string) { ");
            content.AppendLine("	    this.CleanSymbols();                                ");
            content.AppendLine("	    // switch (tmp_sort) {                              ");
            content.AppendLine("	    //     case EnumSort.PARAMETER_LEVEL_ASC:    ");
            content.AppendLine("	    //         this._symbols.ParameterLevelName = \"?\";    ");
            content.AppendLine("	    //         break;                                    ");
            content.AppendLine("	    //     case EnumSort.PARAMETER_LEVEL_DESC:    ");
            content.AppendLine("	    //         this._symbols.ParameterLevelName = \"?\";    ");
            content.AppendLine("	    //         break;                                    ");
            content.AppendLine("	    //     default:    ");
            content.AppendLine("	    //         this.CleanSymbols();    ");
            content.AppendLine("	    //         break;   }                                 ");
            content.AppendLine("	 } ");
            content.AppendLine("	 private CleanSymbols() ");
            content.AppendLine("	 {                      ");
            content.AppendLine("	      // this._symbols.ParameterCategoryCD = \"\";             ");
            content.AppendLine("	 }                      ");
            content.AppendLine("	 //#endregion           ");
            if (searchListActionList != null)
            {
                searchListActionList.ForEach(action =>
                {
                    paramAction = string.Concat(action.Substring(0, 1).ToLower(), action.Substring(1, action.Length - 1));
                    if (action.Equals("Delete", StringComparison.OrdinalIgnoreCase))
                    {
                        content.AppendLine("    private DeleteDetail(model: SearchListItemViewModel) {			  ");
                        content.AppendLine("        model.ActiveType = EnumActiveType.DELETE;			  ");
                        content.AppendLine("																  ");
                        content.AppendLine("        this.service."+ paramAction + "Detail(model).subscribe(data => {	  ");
                        content.AppendLine("            //set body										  ");
                        content.AppendLine("            this._response_object.body = JSON.parse(data._body);");
                        content.AppendLine("																  ");
                        content.AppendLine("            if (null != this._response_object.body.Data &&	  ");
                        content.AppendLine("                (this._response_object.body.Data as boolean)) { ");
                        content.AppendLine("																  ");
                        content.AppendLine("                this.Init();									  ");
                        content.AppendLine("                alert('刪除成功');							  ");
                        content.AppendLine("            }												  ");
                        content.AppendLine("            else { alert('刪除失敗'); }						  ");
                        content.AppendLine("        });													  ");
                        content.AppendLine("    }														  ");
                    }
                    else
                    {
                        content.AppendLine("    private "+ action + "Detail(model: SearchItemViewModel) {																					  ");
                        content.AppendLine(string.Format("        var path = '{0}/{1}detail';																				  ", controllerName.ToLower(), action.ToLower()));
                        content.AppendLine("		//帶入轉址參數																														  ");
                        content.AppendLine("        var query_model:QueryStringViewModel[] = [];																			  ");
                        content.AppendLine("        //query_model.push(new QueryStringViewModel('Id', id));																	  ");
                        content.AppendLine("																																  ");
                        content.AppendLine("        var query_str = BaseUtility.CombileQueryString(query_model);															  ");
                        content.AppendLine("        																														  ");
                        content.AppendLine("        //console.log(query_str);																								  ");
                        content.AppendLine("																																  ");
                        content.AppendLine("        this.router.navigate([path, query_str]);																				  ");
                        content.AppendLine("    }																															  ");
                        content.AppendLine("																																  ");
                    }

                });
            }
            content.AppendLine("    //#endregion																												  ");
            content.AppendLine("}																																  ");
            content.AppendLine("//#endregin																														  ");
            FileService.CreateFile(path, filename, content.ToString());
            #endregion
        }

        /// <summary>
        /// Generate DetailController
        /// </summary>
        /// <param name="controllerName"></param>
        private static void GenerateDetailController(string controllerName)
        {
            #region 參數宣告
            string path = string.Concat(_appPath, "/", string.Format(_pathes[0], controllerName), "/");
            string filename = string.Format("DetailController.ts", controllerName);
            StringBuilder content = new StringBuilder();
            #endregion

            #region 流程
            content.AppendLine("//#region Common Import																															");
            content.AppendLine("import { Component, AfterViewInit, Directive } from '@angular/core';																									   ");
            content.AppendLine("import { Router, ActivatedRoute } from '@angular/router';																					   ");
            //content.AppendLine("import { List } from 'linqts';																												   ");
            content.AppendLine("import { BaseUtility } from '../../Utilities/BaseUtility';																					   ");
            content.AppendLine("import { EnumActiveType, ResponseViewModel, GlobalVariableViewModel, QueryStringViewModel } from '../../ViewModels/BaseViewModel';             ");
            content.AppendLine("import * as $ from 'jquery';                                                                                                                   ");
            content.AppendLine("//#endregion																																   ");
            content.AppendLine("																																			   ");
            content.AppendLine("//#region Custom Import																														   ");
            //content.AppendLine("import { EnumActiveType, ResponseViewModel, GlobalVariableViewModel, QueryStringViewModel } from '../../ViewModels/BaseViewModel';");
            content.AppendLine("import { " + controllerName + "Service } " +  string.Format("from '../../Services/{0}/{0}Service';																					   ", controllerName));
            content.AppendLine("import { DetailRequestViewModel, ViewDetailViewModel, DetailViewModel }"+ string.Format(" from '../../ViewModels/{0}/DetailViewModel';							   ", controllerName));
            content.AppendLine("//#endregion																																   ");
            content.AppendLine("																																			   ");
            content.AppendLine("//#region Definition																														   ");
            content.AppendLine("@Component({																																   ");
            content.AppendLine(string.Format("    selector: '{0}-Detail',																													   ", controllerName));
            content.AppendLine(string.Format("    templateUrl: '../../Views/{0}/Detail.html'																								   ", controllerName));
            content.AppendLine("})																																			   ");
            content.AppendLine("//#endregin																																	   ");
            content.AppendLine("																																			   ");
            content.AppendLine("//#region Class																																   ");
            content.AppendLine("export class DetailController {																												   ");
            content.AppendLine("																																			   ");
            content.AppendLine("    //#region Properties																													   ");
            content.AppendLine("    _pageName: string;																												   ");
            content.AppendLine("    _view_detail_viewmodel: ViewDetailViewModel;																												   ");
            content.AppendLine("    _detail_model_for_check: DetailViewModel;																						   ");
            content.AppendLine("    private _detailReques: DetailRequestViewModel;																						   ");
            content.AppendLine("    private _response_object: ResponseViewModel;																						   ");
            content.AppendLine("    private _editable: boolean;																	   ");
            content.AppendLine("    //#endregion																															   ");
            content.AppendLine("																																			   ");
            content.AppendLine("    //#region Initialize																													   ");
            content.AppendLine("    constructor(																															   ");
            content.AppendLine("        private router: Router,																												   ");
            content.AppendLine(string.Format("        private service: {0}Service,																										   ", controllerName));
            content.AppendLine("        private activatedRoute: ActivatedRoute) {																							   ");
            content.AppendLine("																																			   ");
            content.AppendLine("        this._pageName = GlobalVariableViewModel.pageName;																					   ");
            content.AppendLine("        this._response_object = new ResponseViewModel();																						   ");
            content.AppendLine("		this._view_detail_viewmodel = new ViewDetailViewModel();																																	   ");
            content.AppendLine("        this._detail_model_for_check = new DetailViewModel();																					   ");
            content.AppendLine("																																			   ");
            content.AppendLine("        this.Init();																														   ");
            content.AppendLine("    }																																		   ");
            content.AppendLine("    																																		   ");
            content.AppendLine("    ngAfterViewInit(){																																		   ");
            content.AppendLine("    																																		   ");
            content.AppendLine("    }																																		   ");
            content.AppendLine("    //#endregion																															   ");
            content.AppendLine("																																			   ");
            content.AppendLine("    //#region private method																												   ");
            content.AppendLine("    private Init() {																							");
            content.AppendLine("        this._activatedRoute.params.subscribe(data => {														");
            content.AppendLine("            var param = data['Param'];                                                                        ");
            content.AppendLine("            var query_model: Map<string, any> = BaseUtility.ParseQueryString(param);                          ");
            content.AppendLine("            this._detailReques = new DetailRequestViewModel();                                                 ");
            content.AppendLine("                                                                                                              ");
            content.AppendLine("            //#region 要手動 自行判斷要接什麼參數                                                             ");
            content.AppendLine("            //this._detailReques.ActiveType = query_model.get('Type');                                          ");
            content.AppendLine("            //this._detailReques.ActorID = query_model.get('ActorID');                                          ");
            content.AppendLine("            //this._detailReques.ActorName = query_model.get('ActorName');                                      ");
            content.AppendLine("            //if (this._detailReques.ActorID === undefined) {                                                   ");
            content.AppendLine("            //    this._detailReques.ActorID = '';                                                              ");
            content.AppendLine("            //}                                                                                                 ");
            content.AppendLine("            //if (this._detailReques.ActorName === undefined) {                                                 ");
            content.AppendLine("            //    this._detailReques.ActorName = '';                                                            ");
            content.AppendLine("            //}                                                                                                 ");
            content.AppendLine("            //#endregion                                                                                      ");
            content.AppendLine("																								                ");
            content.AppendLine("            this.service.InitDetail(this._detailReques)														");
            content.AppendLine("                .subscribe(data => {																			");
            content.AppendLine("                    //set body																				");
            content.AppendLine("                    this._response_object.body = JSON.parse(data._body);										");
            content.AppendLine("                    //transfor																				");
            content.AppendLine("                    this._view_detail_viewmodel = (this._response_object.body.Data as ViewDetailViewModel);	");
            content.AppendLine("																												");
            content.AppendLine("                    //continue..                                                                              ");
            content.AppendLine("                    																							");
            content.AppendLine("                });																							");
            content.AppendLine("        });																									");
            content.AppendLine("    }																											");
            content.AppendLine("																																			   ");
            content.AppendLine("    private SaveDetail(_model: DetailViewModel) {																							   ");
            content.AppendLine("																																			   ");
            content.AppendLine("        this._view_detail_viewmodel.Detail.ActiveType = this._detailReques.ActiveType;																								   ");
            content.AppendLine("																																			   ");
            content.AppendLine("        var verifyParams = this.VerifyParams(this._view_detail_viewmodel.Detail);																						   ");
            content.AppendLine("        if (!verifyParams) { return; }																										   ");
            content.AppendLine("																																			   ");
            content.AppendLine("        this.service.SaveDetail(this._view_detail_viewmodel.Detail).subscribe(res => {																					   ");
            content.AppendLine("            //set body																														   ");
            content.AppendLine("            this._response_object.body = JSON.parse(res._body);																			   ");
            content.AppendLine("																																			   ");
            content.AppendLine("            if (null != this._response_object.body.Data &&																					   ");
            content.AppendLine("                (this._response_object.body.Data as boolean)) {																				   ");
            content.AppendLine("																																			   ");
            content.AppendLine("                this.Init();																												   ");
            content.AppendLine("                alert('存檔成功');																											   ");
            content.AppendLine("            }																																   ");
            content.AppendLine("            else { alert('存檔失敗'); }																										   ");
            content.AppendLine("        });																																	   ");
            content.AppendLine("    }																																		   ");
            content.AppendLine("																																			   ");
            content.AppendLine("    private BackToSearchList() {																					  ");
            content.AppendLine(string.Format("        var path = '{0}/searchlist';																				  ", controllerName.ToLower()));
            content.AppendLine("		//帶入轉址參數																														  ");
            //content.AppendLine("        var query_model:QueryStringViewModel[] = [];																			  ");
            //content.AppendLine("        //query_model.push(new QueryStringViewModel('Id', id));																	  ");
            content.AppendLine("																																  ");
            //content.AppendLine("        var query_str = BaseUtinity.CombileQueryString(query_model);															  ");
            content.AppendLine("        																														  ");
            //content.AppendLine("        //console.log(query_str);																								  ");
            content.AppendLine("																																  ");
            content.AppendLine("        this.router.navigate([path]);																				  ");
            content.AppendLine("    }																															  ");
            content.AppendLine("																																  ");
            content.AppendLine("	//參數驗證																																   ");
            content.AppendLine("    private VerifyParams(_model: DetailViewModel): boolean {																				   ");
            content.AppendLine("        var regex = /^.[A-Za-z0-9_]+$/g;																									   ");
            content.AppendLine("        var accept_save: boolean = true;																									   ");
            content.AppendLine("																																			   ");
            content.AppendLine("		//																																	   ");
            content.AppendLine("        return accept_save;																													   ");
            content.AppendLine("    }																																		   "); 
            content.AppendLine("    //#endregion																															   ");
            content.AppendLine("}																																			   ");
            content.AppendLine("//#endregion																																   ");
            FileService.CreateFile(path, filename, content.ToString());
            #endregion
        }
        #endregion

        #region GenerateModules
        /// <summary>
        /// Generate Module
        /// </summary>
        /// <param name="controllerName"></param>
        private static void GenerateModule(string controllerName)
        {
            #region 參數宣告
            string path = string.Concat(_appPath, "/", string.Format(_pathes[1], controllerName), "/");
            string filename = string.Format("{0}Module.ts", controllerName);
            StringBuilder content = new StringBuilder();
            #endregion

            #region 流程
            content.AppendLine("//#region Import																							");
            content.AppendLine("import { NgModule } from '@angular/core';																   ");
            content.AppendLine("import { NgbModule } from '@ng-bootstrap/ng-bootstrap';                                                    ");
            content.AppendLine("import { FormsModule } from '@angular/forms';															   ");
            content.AppendLine("import { CommonModule } from '@angular/common';															   ");
            content.AppendLine("import { HttpModule } from '@angular/http';																   ");
            content.AppendLine("//#endregion																							   ");
            content.AppendLine("																										   ");
            content.AppendLine("//#region Custom Import																					   ");
            content.AppendLine("import { NgDatepickerModule } from 'ng2-datepicker';                                                       ");
            content.AppendLine("import { InputTrimModule } from 'ng2-trim-directive';													   ");
            content.AppendLine("import { LayoutModule } from '../Layout/LayoutModule';													   ");
            content.AppendLine("import { " + controllerName + "Routing }"+ string.Format(" from '../../Routings/{0}/{0}Routing';   ", controllerName));
            content.AppendLine("import { BaseController }"+ string.Format(" from '../../../Controllers/{0}/BaseController';				   ", controllerName));
            content.AppendLine("import { SearchListController }"+ string.Format(" from '../../../Controllers/{0}/SearchListController';	   ", controllerName));
            content.AppendLine("import { DetailController }"+ string.Format(" from '../../../Controllers/{0}/DetailController';			   ", controllerName));
            content.AppendLine("import { "+ controllerName + "Service }"+ string.Format(" from '../../../Services/{0}/{0}Service';", controllerName));
            content.AppendLine("//#endregion																							   ");
            content.AppendLine("																										   ");
            content.AppendLine("//#region Definition																					   ");
            content.AppendLine("@NgModule({																								   ");
            content.AppendLine("    imports: [																							   ");
            content.AppendLine("        CommonModule,																					   ");
            content.AppendLine("        FormsModule,																					   ");
            content.AppendLine("        HttpModule,																						   ");
            content.AppendLine(string.Format("        {0}Routing,																		   ", controllerName));
            content.AppendLine("        InputTrimModule,																				   ");
            content.AppendLine("        LayoutModule.forRoot(),																			   ");
            content.AppendLine("        NgbModule.forRoot(),                                                                               ");
            content.AppendLine("        NgDatepickerModule                                                                                 ");
            content.AppendLine("    ],																									   ");
            content.AppendLine("    declarations: [																						   ");
            content.AppendLine("        BaseController,																					   ");
            content.AppendLine("        SearchListController,																			   ");
            content.AppendLine("        DetailController																				   ");
            content.AppendLine("    ],																									   ");
            content.AppendLine(string.Format("    providers: [{0}Service],																   ", controllerName));
            content.AppendLine("    bootstrap: [BaseController]																			   ");
            content.AppendLine("})																										   ");
            content.AppendLine("//#endregion																							   ");
            content.AppendLine("																										   ");
            content.AppendLine("//#region Class																							   ");
            content.AppendLine("export class "+ controllerName + "Module { }																   ");
            content.AppendLine("//#endregion																							   ");
            FileService.CreateFile(path, filename, content.ToString());
            #endregion
        }
        #endregion

        #region GenerateRoutings
        /// <summary>
        /// Generate Routing
        /// </summary>
        /// <param name="controllerName"></param>
        private static void GenerateRouting(string controllerName, List<string> searchListActionList)
        {
            #region 參數宣告
            string path = string.Concat(_appPath, "/", string.Format(_pathes[2], controllerName), "/");
            string filename = string.Format("{0}Routing.ts", controllerName);
            StringBuilder content = new StringBuilder();
            #endregion

            #region 流程
            content.AppendLine("//#region Common Import																");
            content.AppendLine("import { NgModule } from '@angular/core';											");
            content.AppendLine("import { RouterModule, Routes } from '@angular/router';								");
            content.AppendLine("//#endregion																			");
            content.AppendLine("																						");
            content.AppendLine("//#region Custom Import																");
            content.AppendLine("import { BaseController }"+ string.Format(" from '../../../Controllers/{0}/BaseController';			", controllerName));
            content.AppendLine("import { SearchListController }" + string.Format(" from '../../../Controllers/{0}/SearchListController';", controllerName));
            content.AppendLine("import { DetailController }" + string.Format(" from '../../../Controllers/{0}/DetailController';		", controllerName));
            content.AppendLine("//#endregion																			");
            content.AppendLine("																						");
            content.AppendLine("//#region Definition																	");
            content.AppendLine("const setRoutes: Routes = [															");
            content.AppendLine("    {																				");
            content.AppendLine("        path: '',																	");
            content.AppendLine("        component: BaseController,													");
            content.AppendLine("        children: [																	");
            content.AppendLine("            { path: '"+ controllerName.ToLower() + "/searchlist', component: SearchListController },				");
            if (searchListActionList != null)
            {
                searchListActionList.ForEach(action =>
                {
                    if (! action.Equals("Delete", StringComparison.OrdinalIgnoreCase))
                    {
                        content.AppendLine("            { path: '"+ controllerName.ToLower() + "/"+ action.ToLower() + "detail/:Param', component: DetailController },			");
                    }
                });
            }
            content.AppendLine("        ]																			");
            content.AppendLine("    }																				");
            content.AppendLine("];																					");
            content.AppendLine("@NgModule({																			");
            content.AppendLine("    imports: [RouterModule.forChild(setRoutes)],										");
            content.AppendLine("    exports: [RouterModule]															");
            content.AppendLine("})																					");
            content.AppendLine("//#endregion																			");
            content.AppendLine("																						");
            content.AppendLine("//#region Class																		");
            content.AppendLine("export class "+ controllerName + "Routing { }															");
            content.AppendLine("//#endregion																			");
            FileService.CreateFile(path, filename, content.ToString());
            #endregion
        }
        #endregion

        #region GenerateServices
        private static void GenerateService(string controllerName)
        {
            #region 參數宣告
            string path = string.Concat(_appPath, "/", string.Format(_pathes[3], controllerName), "/");
            string filename = string.Format("{0}Service.ts", controllerName);
            StringBuilder content = new StringBuilder();
            #endregion

            #region 流程
            content.AppendLine("//#region Common Import																						");
            content.AppendLine("import { Injectable } from '@angular/core';																	");
            content.AppendLine("import { Observable } from 'rxjs/Rx';																		");
            content.AppendLine("import { BaseService } from '../BaseService';																");
            content.AppendLine("//#endregion																								");
            content.AppendLine("																											");
            content.AppendLine("//#region Custom Import																						");
            content.AppendLine("import { ResponseViewModel, GlobalVariableViewModel, EnumActiveType } from '../../ViewModels/BaseViewModel';");
            content.AppendLine("import { SearchInfoInitViewModel, SearchInfoViewModel ,SearchListViewModel, SearchItemViewModel }"+ string.Format(" from '../../ViewModels/{0}/SearchListViewModel';	", controllerName));
            content.AppendLine("import { DetailRequestViewModel, DetailViewModel }" + string.Format(" from '../../ViewModels/{0}/DetailViewModel';								", controllerName));
            content.AppendLine("//#endregion																								");
            content.AppendLine("																											");
            content.AppendLine("//#region Class																								");
            content.AppendLine("@Injectable()																								");
            content.AppendLine("export class "+ controllerName + "Service {																					");
            content.AppendLine("																											");
            content.AppendLine("    //#region Initialize																					");
            content.AppendLine("    constructor(private baseService: BaseService) { }														");
            content.AppendLine("    //#endregion																							");
            content.AppendLine("																											");
            content.AppendLine("    //#region Public Method																					");
            content.AppendLine("																											");
            content.AppendLine("    /** get search info init data */																		");
            content.AppendLine("    public InitSearchInfo(): Observable<any> 																");
            content.AppendLine("    {																										");
            content.AppendLine(string.Format("        return this.baseService.HttpPost(GlobalVariableViewModel.api_domain+'{0}/SearchInfoInit', null);	", controllerName.ToLower()));
            content.AppendLine("    }																										");
            content.AppendLine("																											");
            content.AppendLine("    /** get search data */																					");
            content.AppendLine("    public Search(model: SearchInfoViewModel): Observable<any> {											");
            content.AppendLine("																											");
            content.AppendLine(string.Format("        return this.baseService.HttpPost(GlobalVariableViewModel.api_domain+'{0}/SearchList', model);		", controllerName.ToLower()));
            content.AppendLine("    }																										");
            content.AppendLine("																											");
            content.AppendLine("    /** Sort */																								");
            content.AppendLine("    public Sort() {																							");
            content.AppendLine("																											");
            content.AppendLine("    }																										");
            content.AppendLine("																											");
            content.AppendLine("    /** Paginging */																						");
            content.AppendLine("    public Paging() {																						");
            content.AppendLine("																											");
            content.AppendLine("    }																										");
            content.AppendLine("																											");
            content.AppendLine("    /** Init Detail */																						");
            content.AppendLine("    public InitDetail(model:DetailRequestViewModel): Observable<any> {										");
            content.AppendLine(string.Format("        return this.baseService.HttpPost(GlobalVariableViewModel.api_domain+'{0}/ViewDetail', model);		", controllerName.ToLower()));
            content.AppendLine("    }																										");
            content.AppendLine("																											");
            content.AppendLine("    /** Save Detail */																						");
            content.AppendLine("    public SaveDetail(model: DetailViewModel): Observable<any> {												");
            content.AppendLine(string.Format("        return this.baseService.HttpPost(GlobalVariableViewModel.api_domain+'{0}/Detail', model);			", controllerName.ToLower()));
            content.AppendLine("    }																										");
            content.AppendLine("																											");
            content.AppendLine("    /** Delete Detail */																					");
            content.AppendLine("    public DeleteDetail(model: SearchItemViewModel): Observable<any> {									");
            content.AppendLine(string.Format("        return this.baseService.HttpPost(GlobalVariableViewModel.api_domain+'{0}/Detail', model);			", controllerName.ToLower()));
            content.AppendLine("    }																										");
            content.AppendLine("    //#endregion																							");
            content.AppendLine("}																											");
            content.AppendLine("//#endregion																								");
            FileService.CreateFile(path, filename, content.ToString());
            #endregion
        }
        #endregion

        #region GenerateViewModels

        /// <summary>
        /// Generate DetailViewModel
        /// </summary>
        /// <param name="controllerName"></param>
        private static void GenerateDetailViewModel(string controllerName)
        {
            #region 參數宣告
            string path = string.Concat(_appPath, "/", string.Format(_pathes[4], controllerName), "/");
            string filename = string.Format("DetailViewModel.ts", controllerName);
            StringBuilder content = new StringBuilder();
            #endregion

            #region 流程
            content.AppendLine("//#region Custom Import													");
            content.AppendLine("import { EnumActiveType } from '../BaseViewModel';					   ");
            content.AppendLine("//#endregion														   ");
            content.AppendLine("																	   ");
            content.AppendLine("//#region Enum														   ");
            content.AppendLine("//export enum EnumSort {											   ");
            content.AppendLine("//    DEFAULT,														   ");
            content.AppendLine("//}																   ");
            content.AppendLine("//#endregion														   ");
            content.AppendLine("																	   ");
            content.AppendLine("//#region Class														   ");
            content.AppendLine("export class BaseDetailRequestViewModel {							   ");
            content.AppendLine("    ActiveType: EnumActiveType;										   ");
            content.AppendLine("    //Sort: EnumSort;												   ");
            content.AppendLine("}																	   ");
            content.AppendLine("																	   ");
            content.AppendLine("export class DetailRequestViewModel extends BaseDetailRequestViewModel {");
            content.AppendLine("																	   ");
            content.AppendLine("}																	   ");
            content.AppendLine("																	   ");
            content.AppendLine("export class ViewDetailViewModel {									   ");
            content.AppendLine("    Detail: DetailViewModel = new DetailViewModel();				   ");
            content.AppendLine("	DetailOption : DetailOptionViewModel = new DetailOptionViewModel   ");
            content.AppendLine("}																	   ");
            content.AppendLine("																	   ");
            content.AppendLine("export class DetailViewModel {										   ");
            content.AppendLine("    ActiveType: EnumActiveType;																	   ");
            content.AppendLine("}																	   ");
            content.AppendLine("																	   ");
            content.AppendLine("export class DetailOptionViewModel {								   ");
            content.AppendLine("																	   ");
            content.AppendLine("}																	   ");
            content.AppendLine("//#endregion														   ");

            FileService.CreateFile(path, filename, content.ToString());
            #endregion
        }

        /// <summary>
        /// Generate DetailViewModel
        /// </summary>
        /// <param name="controllerName"></param>
        private static void GenerateSearchListViewModel(string controllerName)
        {
            #region 參數宣告
            string path = string.Concat(_appPath, "/", string.Format(_pathes[4], controllerName), "/");
            string filename = string.Format("SearchListViewModel.ts", controllerName);
            StringBuilder content = new StringBuilder();
            #endregion

            #region 流程
            content.AppendLine("//#region Common Import									");
            content.AppendLine("import { PageViewModel, ListBoxViewModel } from '../BaseViewModel';		 ");
            content.AppendLine("import * as dateFormatUtility from 'dateformat';         ");
            content.AppendLine("//#endregion											 ");
            content.AppendLine("export class SearchInfoInitViewModel {                   ");
            content.AppendLine("/** 負責PM LIST */                                       ");
            content.AppendLine("//ResponsibleUserList: ListBoxViewModel[] = [];          ");
            content.AppendLine("/** 類別 LIST */                                         ");
            content.AppendLine("CategorySearchListViewModel: SearchListViewModel = new SearchListViewModel();");
            content.AppendLine("}                                                        ");
            content.AppendLine("														 ");
            content.AppendLine("//#region Enum                                           ");
            content.AppendLine("export enum EnumSort {                                   ");
            content.AppendLine("    DEFAULT = \"\"                                       ");
            content.AppendLine("    // , PARAMETER_CATEGORY_CD_ASC = \"PARAMETER_CATEGORY_CD_ASC\" ");
            content.AppendLine("    // , PARAMETER_CATEGORY_CD_DESC = \"PARAMETER_CATEGORY_CD_DESC\" ");
            content.AppendLine("}                                                        ");
            content.AppendLine("//#endregion                                             ");
            content.AppendLine("														 ");
            content.AppendLine("//#region Class											 ");
            content.AppendLine("export class SearchInfoViewModel extends PageViewModel  {");
            content.AppendLine("	Sort: EnumSort = null;  							 ");
            content.AppendLine("														 ");
            content.AppendLine("}														 ");
            content.AppendLine("														 ");
            content.AppendLine("export class SearchListViewModel extends PageViewModel { ");
            content.AppendLine("    SearchItemList: SearchItemViewModel[]= [];			 ");
            content.AppendLine("}														 ");
            content.AppendLine("														 ");
            content.AppendLine("export class SearchItemViewModel extends PageViewModel { ");
            content.AppendLine("														 ");
            content.AppendLine("}														 ");
            content.AppendLine("//#endregion											 ");

            FileService.CreateFile(path, filename, content.ToString());
            #endregion
        }

        #endregion

        #region GenerateHtml
        /// <summary>
        /// Generate Base.html
        /// </summary>
        /// <param name="controllerName"></param>
        private static void GenerateBaseHtml(string controllerName)
        {
            #region 參數宣告
            string path = string.Concat(_appPath, "/", string.Format(_pathes[5], controllerName), "/");
            string filename = string.Format("Base.html", controllerName);
            StringBuilder content = new StringBuilder();
            #endregion

            #region 流程
            content.AppendLine("<Layout-Header></Layout-Header>			");
            content.AppendLine("<div id=\"home_container\" >              ");
            content.AppendLine("    <div id=\"left_content\">             ");
            content.AppendLine("        <Layout-Menu></Layout-Menu>     ");
            content.AppendLine("    </div>                              ");
            content.AppendLine("    <div id=\"right_content\">            ");
            content.AppendLine("        <router-outlet></router-outlet> ");
            content.AppendLine("    </div>                              ");
            content.AppendLine("</div>                                  ");
            content.AppendLine("<Layout-Footer></Layout-Footer>			");

            FileService.CreateFile(path, filename, content.ToString());
            #endregion
        }

        /// <summary>
        /// Generate SearchList.html
        /// </summary>
        /// <param name="controllerName"></param>
        private static void GenerateSearchListHtml(string controllerName, List<string> searchListActionList)
        {
            #region 參數宣告
            string path = string.Concat(_appPath, "/", string.Format(_pathes[5], controllerName), "/");
            string filename = string.Format("SearchList.html", controllerName);
            StringBuilder content = new StringBuilder();
            #endregion

            #region 流程
            content.AppendLine("<p class=\"R_title\">																						");
            content.AppendLine("    <img src=\"../../../assets/images/title.png\" /> 當前頁: {{_pageName}}                                   ");
            content.AppendLine("</p>                                                                                                        ");
            content.AppendLine("<table class=\"tablea\">                                                                                    ");
            content.AppendLine("    <tbody>                                                                                                 ");
            content.AppendLine("        <tr class=\"tra\">                                                                                  ");
            content.AppendLine("            <th colspan=\"4\">&nbsp;</th>                                                                   ");
            content.AppendLine("        </tr>                                                                                               ");
            content.AppendLine("        <tr class=\"trb\">                                                                                  ");
            content.AppendLine("            <th>Input 搜尋條件1</th>                                                                        ");
            content.AppendLine("            <td>                                                                                            ");
            content.AppendLine("                <input [(ngModel)]=\"\" />                                                                  ");
            content.AppendLine("            </td>                                                                                           ");
            content.AppendLine("            <th>Select 搜尋條件2</th>                                                                       ");
            content.AppendLine("            <td>                                                                                            ");
            content.AppendLine("                <select id=\"search_level\" [(ngModel)]=\"指定回填的ngModel Property\">                     ");
            content.AppendLine("                    <option *ngFor=\"let {object Name} of _search_info.{選單Property}\"                      ");
            content.AppendLine("                    value=\"{{值}}\">{{顯示名稱}}</option>                                                  ");
            content.AppendLine("                </select>                                                                                   ");
            content.AppendLine("            </td>                                                                                           ");
            content.AppendLine("        </tr>                                                                                               ");
            content.AppendLine("    </tbody>                                                                                                ");
            content.AppendLine("</table>                                                                                                    ");
            content.AppendLine("<span class=\"spabut\">                                                                                     ");
            content.AppendLine("    <!-- condition to for each para -->                                                                     ");
            content.AppendLine("    <button id=\"btnSearch\" class=\"butt_b\" (click)=\"SearchList()\">查詢</button>");
            content.AppendLine("    < button class=\"butt_b\" (click)=\"Reset()\">重置</button>");
            if (searchListActionList != null) {
                if (searchListActionList.Exists(action => action.Equals("Add", StringComparison.OrdinalIgnoreCase))) {
                    content.AppendLine("    <button id=\"btnAdd\" class=\"butt_b\" (click)=\"AddDetail()\">新增</button>");
                }
            }
            content.AppendLine("</span>                                                                                                     ");
            content.AppendLine("<br />                                                                                                      ");
            content.AppendLine("<div style=\"text-align: center;\" *ngIf =\"null != _search_list && _search_list.SearchItemList.length <= 0\">");
            content.AppendLine("    <span class=\"textcolor_red\">查無任何資料</span>                                                       ");
            content.AppendLine("</div>                                                                                                      ");
            content.AppendLine("<table class=\"tableb\" *ngIf=\"null != _search_list && _search_list.SearchItemList.length > 0\" #listTable>  ");
            content.AppendLine("    <tbody>                                                                                                 ");
            content.AppendLine("        <tr class=\"tra\">                                                                                  ");
            content.AppendLine("            <th>操作</th>                                                                                   ");
            content.AppendLine("            <th>顯示欄位1</th>                                                                              ");
            content.AppendLine("            <th>顯示欄位2</th>                                                                              ");
            content.AppendLine("            <th>最後編輯人員</th>                                                                           ");
            content.AppendLine("            <th>最後編輯日期/時間</th>                                                                      ");
            content.AppendLine("        </tr>                                                                                               ");
            content.AppendLine("        <tr *ngFor=\"let data of search_list.SearchItemList\">                                              ");
            content.AppendLine("            <td>");
            if (searchListActionList != null)
            {
                if (searchListActionList.Exists(action => action.Equals("Edit", StringComparison.OrdinalIgnoreCase)))
                {
                    content.AppendLine("                <button id=\"btnEdit\" (click)=\"EditDetail(data)\">編輯</button>");
                }
                if (searchListActionList.Exists(action => action.Equals("View", StringComparison.OrdinalIgnoreCase)))
                {
                    content.AppendLine("                <button id=\"btnView\" (click)=\"ViewDetail(data)\">檢視</button>");
                }
                if (searchListActionList.Exists(action => action.Equals("Edit", StringComparison.OrdinalIgnoreCase)))
                {
                    content.AppendLine("                <button id=\"btnDelete\" (click)=\"DeleteDetail(data)\">刪除</button>");
                }
            }
            
            content.AppendLine("            </td>");
            content.AppendLine("            <td>{{data.Property1}}</td>                                                                     ");
            content.AppendLine("            <td>{{data.Property2}}</td>                                                                     ");
            content.AppendLine("            <td>{{data.UpdateUserName}}</td>                                                                ");
            content.AppendLine("            <td>{{data.UpdateDate | date:'yyyy-MM-dd HH:mm:ss'}}</td>                                       ");
            content.AppendLine("        </tr>                                                                                               ");
            content.AppendLine("    </tbody>                                                                                                ");
            content.AppendLine("</table>                                                                                                    ");
            content.AppendLine("<div class=\"pagination_div\"> ");
            content.AppendLine("    <div class=\"pagination_left\"> ");
            content.AppendLine("      <span *ngIf=\"null != _search_list && _search_list.Page != undefined\" class=\"pagination\">");
            content.AppendLine("        第{{_search_list.Page.PageIndex}}/{{_search_list.Page.GetTotalPageCount}}頁 共{{_search_list.Page.TotalCount}}筆 到");
            content.AppendLine("        <input [(ngModel)]=\"_search_list.Page.PageIndex\" />頁");
            content.AppendLine("      </span>");
            content.AppendLine("    </div>");
            content.AppendLine("    <div class=\"pagination_center\">");
            content.AppendLine("      <ngb-pagination *ngIf=\"null != _search_list && _search_list.Page != undefined\" [maxSize]=\"_page_btn_maxSize\" [collectionSize]=\"_search_list.Page.TotalCount\" ");
            content.AppendLine("        [pageSize]=\"_search_list.Page.PageSize\" [(page)]=\"_search_list.Page.PageIndex\" (pageChange)=\"Paging(_search_list.Page.PageSize,_search_list.Page.PageIndex)\"> ");
            content.AppendLine("      </ngb-pagination> ");
            content.AppendLine("    </div> ");
            content.AppendLine("    <div class=\"pagination_right\"> ");
            content.AppendLine("      <span class=\"pagination\" *ngIf=\"null != _search_list && _search_list.Page != undefined\"> ");
            content.AppendLine("        每頁顯示 ");
            content.AppendLine("        <select [(ngModel)]=\"_search_info.Page.PageSize\" (change)=\"Paging($event.target.value, 1)\"> ");
            content.AppendLine("          <option value=\"3\">3</option> ");
            content.AppendLine("          <option value=\"5\">5</option> ");
            content.AppendLine("          <option value=\"10\">10</option> ");
            content.AppendLine("          <option value=\"15\">15</option> ");
            content.AppendLine("          <option value=\"20\">20</option> ");
            content.AppendLine("          <option value=\"30\">30</option> ");
            content.AppendLine("          <option value=\"40\">40</option> ");
            content.AppendLine("          <option value=\"50\">50</option> ");
            content.AppendLine("          <option value=\"60\">70</option> ");
            content.AppendLine("          <option value=\"80\">80</option> ");
            content.AppendLine("          <option value=\"90\">90</option> ");
            content.AppendLine("          <option value=\"100\">100</option> ");
            content.AppendLine("        </select> ");
            content.AppendLine("        筆 ");
            content.AppendLine("      </span> ");
            content.AppendLine("    </div> ");
            content.AppendLine("  </div> ");
            FileService.CreateFile(path, filename, content.ToString());
            #endregion
        }

        private static void GenerateDetailHtml(string controllerName)
        {
            #region 參數宣告
            string path = string.Concat(_appPath, "/", string.Format(_pathes[5], controllerName), "/");
            string filename = string.Format("Detail.html", controllerName);
            StringBuilder content = new StringBuilder();
            #endregion

            #region 流程
            content.AppendLine("<p class=\"R_title\">																					");
            content.AppendLine("    <img src=\"../../../assets/images/title.png\" /> 當前頁: {{_pageName}}                              ");
            content.AppendLine("</p>                                                                                                    ");
            content.AppendLine("<table class=\"tablea\" >                                                                               ");
            content.AppendLine("    <tbody>                                                                                             ");
            content.AppendLine("        <tr class=\"tra\">                                                                              ");
            content.AppendLine("            <th colspan=\"4\">&nbsp;</th>                                                               ");
            content.AppendLine("        </tr>                                                                                           ");
            content.AppendLine("        <tr class=\"trb\">                                                                              ");
            content.AppendLine("            <th><span class=\"textcolor_red\">*</span>input 明細欄位1</th>                              ");
            content.AppendLine("            <td>                                                                                        ");
            content.AppendLine("                <input [(ngModel)]=\"_detail_model_for_add.欄位1\"                                      ");
            content.AppendLine("                maxlength=\"60\" pattern=\"[0-9]+\" trim=\"blur\"  />                                   ");
            content.AppendLine("                <span class=\"textcolor_red\">{{_detail_model_for_check.欄位1}}</span>                  ");
            content.AppendLine("            </td>                                                                                       ");
            content.AppendLine("            <th><span class=\"textcolor_red\">*</span>input 明細欄位2</th>                              ");
            content.AppendLine("            <td>                                                                                        ");
            content.AppendLine("                <input [(ngModel)]=\"_detail_model_for_add.欄位2\" trim=\"blur\" />                     ");
            content.AppendLine("                <span class=\"textcolor_red\">{{_detail_model_for_check.欄位2}}</span>                  ");
            content.AppendLine("            </td>                                                                                       ");
            content.AppendLine("        </tr>                                                                                           ");
            content.AppendLine("    </tbody>                                                                                            ");
            content.AppendLine("</table>                                                                                                ");
            content.AppendLine("<span class=\"spabut\" >                                             ");
            content.AppendLine("    <!-- condition to for each para -->                                                                 ");
            content.AppendLine("    <button id=\"btnSave\" class=\"butt_b\" (click)=\"saveDetail(_detail_model_for_add)\">存檔</button> ");
            content.AppendLine("	<button id=\"btnBackToSearchList\" class=\"butt_b\" (click)=\"backToSearchList()\">回列表</button>  ");
            content.AppendLine("</span>                                                                                                 ");
            content.AppendLine("<br />                                                                                                  ");

            FileService.CreateFile(path, filename, content.ToString());
            #endregion
        }
        #endregion

        #endregion

    }
}
