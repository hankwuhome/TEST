//#region Common Import									
import { PageViewModel } from '../BaseViewModel';		 
//#endregion											 
														 
//#region Enum                                           
export enum EnumSort                                     
{                                                        
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
