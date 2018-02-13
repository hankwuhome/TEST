//#region Common Import									
import { PageViewModel, ListBoxViewModel } from '../BaseViewModel';		 
import * as dateFormatUtility from 'dateformat';         
//#endregion											 
export class SearchInfoInitViewModel {                   
/** 負責PM LIST */                                       
//ResponsibleUserList: ListBoxViewModel[] = [];          
/** 類別 LIST */                                         
CategorySearchListViewModel: SearchListViewModel = new SearchListViewModel();
}                                                        
														 
//#region Enum                                           
export enum EnumSort {                                   
    DEFAULT = ""                                       
    // , PARAMETER_CATEGORY_CD_ASC = "PARAMETER_CATEGORY_CD_ASC" 
    // , PARAMETER_CATEGORY_CD_DESC = "PARAMETER_CATEGORY_CD_DESC" 
}                                                        
//#endregion                                             
														 
//#region Class											 
export class SearchInfoViewModel extends PageViewModel  {
	Sort: EnumSort = null;  							 
														 
}														 
														 
export class SearchListViewModel extends PageViewModel { 
    SearchItemList: SearchItemViewModel[]= [];			 
}														 
														 
export class SearchItemViewModel extends PageViewModel { 
														 
}														 
//#endregion											 
