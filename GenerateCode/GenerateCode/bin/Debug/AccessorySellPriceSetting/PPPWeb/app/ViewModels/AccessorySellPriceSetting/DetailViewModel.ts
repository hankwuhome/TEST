//#region Custom Import													
import { EnumActiveType } from '../BaseViewModel';					   
//#endregion														   
																	   
//#region Enum														   
//export enum EnumSort {											   
//    DEFAULT,														   
//}																	   
//#endregion														   
																	   
//#region Class														   
export class BaseDetailRequestViewModel {							   
    ActiveType: EnumActiveType;										   
    //Sort: EnumSort;												   
}																	   
																	   
export class DetailRequesViewModel extends BaseDetailRequestViewModel {
																	   
}																	   
																	   
export class ViewDetailViewModel {									   
    Detail: DetailViewModel = new DetailViewModel();				   
	DetailOption : DetailOptionViewModel = new DetailOptionViewModel   
}																	   
																	   
export class DetailViewModel {										   
    ActiveType: EnumActiveType;																	   
}																	   
																	   
export class DetailOptionViewModel {								   
																	   
}																	   
//#endregion														   
