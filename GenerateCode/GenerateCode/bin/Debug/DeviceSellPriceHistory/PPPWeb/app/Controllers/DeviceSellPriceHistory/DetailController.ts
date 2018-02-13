//#region Common Import																															
import { Component, AfterViewInit, Directive } from '@angular/core';																									   
import { Router, ActivatedRoute } from '@angular/router';																					   
import { BaseUtility } from '../../Utilities/BaseUtility';																					   
import { EnumActiveType, ResponseViewModel, GlobalVariableViewModel, QueryStringViewModel } from '../../ViewModels/BaseViewModel';             
import * as $ from 'jquery';                                                                                                                   
//#endregion																																   
																																			   
//#region Custom Import																														   
import { DeviceSellPriceHistoryService } from '../../Services/DeviceSellPriceHistory/DeviceSellPriceHistoryService';																					   
import { DetailRequesViewModel, ViewDetailViewModel, DetailViewModel } from '../../ViewModels/DeviceSellPriceHistory/DetailViewModel';							   
//#endregion																																   
																																			   
//#region Definition																														   
@Component({																																   
    selector: 'DeviceSellPriceHistory-Detail',																													   
    templateUrl: '../../Views/DeviceSellPriceHistory/Detail.html'																								   
})																																			   
//#endregin																																	   
																																			   
//#region Class																																   
export class DetailController {																												   
																																			   
    //#region Properties																													   
    _pageName: string;																												   
    _view_detail_viewmodel: ViewDetailViewModel;																												   
    _detail_model_for_check: DetailViewModel;																						   
    private _detailReques: DetailRequesViewModel;																						   
    private _response_object: ResponseViewModel;																						   
    private _editable: boolean;																	   
    //#endregion																															   
																																			   
    //#region Initialize																													   
    constructor(																															   
        private router: Router,																												   
        private service: DeviceSellPriceHistoryService,																										   
        private activatedRoute: ActivatedRoute) {																							   
																																			   
        this._pageName = GlobalVariableViewModel.pageName;																					   
        this._response_object = new ResponseViewModel();																						   
		this._view_detail_viewmodel = new ViewDetailViewModel();																																	   
        this._detail_model_for_check = new DetailViewModel();																					   
																																			   
        this.Init();																														   
    }																																		   
    																																		   
    ngAfterViewInit(){																																		   
    																																		   
    }																																		   
    //#endregion																															   
																																			   
    //#region private method																												   
    private Init() {																							
        this._activatedRoute.params.subscribe(data => {														
            var param = data['Param'];                                                                        
            var query_model: Map<string, any> = BaseUtility.ParseQueryString(param);                          
            this._detailReques = new DetailRequesViewModel();                                                 
                                                                                                              
            //#region 要手動 自行判斷要接什麼參數                                                             
            //this._detailReques.ActiveType = query_model.get('Type');                                          
            //this._detailReques.ActorID = query_model.get('ActorID');                                          
            //this._detailReques.ActorName = query_model.get('ActorName');                                      
            //if (this._detailReques.ActorID === undefined) {                                                   
            //    this._detailReques.ActorID = '';                                                              
            //}                                                                                                 
            //if (this._detailReques.ActorName === undefined) {                                                 
            //    this._detailReques.ActorName = '';                                                            
            //}                                                                                                 
            //#endregion                                                                                      
																								                
            this.service.InitDetail(this._detailReques)														
                .subscribe(data => {																			
                    //set body																				
                    this._response_object.body = JSON.parse(data._body);										
                    //transfor																				
                    this._view_detail_viewmodel = (this._response_object.body.Data as ViewDetailViewModel);	
																												
                    //continue..                                                                              
                    																							
                });																							
        });																									
    }																											
																																			   
    private SaveDetail(_model: DetailViewModel) {																							   
																																			   
        this._view_detail_viewmodel.Detail.ActiveType = this._detailReques.ActiveType;																								   
																																			   
        var verifyParams = this.VerifyParams(this._view_detail_viewmodel.Detail);																						   
        if (!verifyParams) { return; }																										   
																																			   
        this.service.SaveDetail(this._view_detail_viewmodel.Detail).subscribe(res => {																					   
            //set body																														   
            this._response_object.body = JSON.parse(res._body);																			   
																																			   
            if (null != this._response_object.body.Data &&																					   
                (this._response_object.body.Data as boolean)) {																				   
																																			   
                this.Init();																												   
                alert('存檔成功');																											   
            }																																   
            else { alert('存檔失敗'); }																										   
        });																																	   
    }																																		   
																																			   
    private BackToSearchList() {																					  
        var path = 'devicesellpricehistory/searchlist';																				  
		//帶入轉址參數																														  
																																  
        																														  
																																  
        this.router.navigate([path]);																				  
    }																															  
																																  
	//參數驗證																																   
    private VerifyParams(_model: DetailViewModel): boolean {																				   
        var regex = /^.[A-Za-z0-9_]+$/g;																									   
        var accept_save: boolean = true;																									   
																																			   
		//																																	   
        return accept_save;																													   
    }																																		   
    //#endregion																															   
}																																			   
//#endregion																																   
