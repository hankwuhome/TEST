//#region Common Import																															
import { Component } from '@angular/core';																									   
import { Router, ActivatedRoute } from '@angular/router';																					   
import { List } from 'linqts';																												   
import { BaseUtinity } from '../../Utilities/BaseUtinity';																					   
//#endregion																																   
																																			   
//#region Custom Import																														   
import { EnumActiveType, ResponseViewModel, GlobalVariableViewModel, QueryStringViewModel } from '../../ViewModels/BaseViewModel';
import { ActorSettingService } from '../../Services/ActorSetting/ActorSettingService';																					   
import { DetailRequesViewModel, ViewDetailViewModel, DetailViewModel } from '../../ViewModels/ActorSetting/DetailViewModel';							   
//#endregion																																   
																																			   
//#region Definition																														   
@Component({																																   
    selector: 'ActorSetting-Detail',																													   
    templateUrl: '../../Views/ActorSetting/Detail.html'																								   
})																																			   
//#endregin																																	   
																																			   
//#region Class																																   
export class DetailController {																												   
																																			   
    //#region Properties																													   
    private _pageName: string;																												   
    private _activeType: string;																												   
    private _response_object: ResponseViewModel = null;																						   
    private _detail_model: ViewDetailViewModel = null;																						   
    private _show_detail_data: DetailViewModel[] = [];																						   
    private _detail_model_for_add: DetailViewModel = new DetailViewModel();																	   
    private _detail_model_for_check: DetailViewModel = new DetailViewModel();																   
    private _detail_seq_check: string = '';																									   
    //#endregion																															   
																																			   
    //#region Initialize																													   
    constructor(																															   
        private router: Router,																												   
        private service: ActorSettingService,																										   
        private _activatedRoute: ActivatedRoute) {																							   
																																			   
        this._response_object = new ResponseViewModel();																					   
        this._detail_model = new ViewDetailViewModel();																						   
																																			   
        this._pageName = GlobalVariableViewModel.pageName;																					   
																																			   
        this.Init();																														   
    }																																		   
    //#endregion																															   
																																			   
    //#region private method																												   
    private Init() {																														   
        this._activatedRoute.params.subscribe(data => {																						   
            var param = data['Param'];																										   
            var query_model:QueryStringViewModel[] = BaseUtinity.ParseQueryString(param);													   
            var req: DetailRequesViewModel = new DetailRequesViewModel();																	   
            this._activeType = query_model[1].value;																							   
            req.ActiveType = EnumActiveType[this._activeType.toUpperCase()];																							   
            //req.Sort = EnumSortActorSetting.DEFAULT;																									   
																																			   
            this.service.InitDetail(req)																									   
                .subscribe(data => {																										   
                    //set body																												   
                    this._response_object.body = JSON.parse(data._body);																	   
                    //transfor																												   
                    this._detail_model = (this._response_object.body.Data as ViewDetailViewModel);											   
																																			   
                    //set show list data																									   
                    																														   
																																			   
                    //set to add model																										   
                    																														   
                });																															   
        });																																	   
    }																																		   
																																			   
    private SaveDetail(_model: DetailViewModel) {																							   
																																			   
        _model.ActiveType = EnumActiveType[this._activeType.toUpperCase()];;																								   
																																			   
        var verifyParams = this.VerifyParams(_model);																						   
        if (!verifyParams) { return; }																										   
																																			   
        this.service.SaveDetail(_model).subscribe(data => {																					   
            //set body																														   
            this._response_object.body = JSON.parse(data._body);																			   
																																			   
            if (null != this._response_object.body.Data &&																					   
                (this._response_object.body.Data as boolean)) {																				   
																																			   
                this.Init();																												   
                alert('存檔成功');																											   
            }																																   
            else { alert('存檔失敗'); }																										   
        });																																	   
    }																																		   
																																			   
    private BackToSearchList() {																					  
        var path = 'actorsetting/searchlist';																				  
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
