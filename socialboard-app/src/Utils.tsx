class Utils {	
	getDataIndex = (data:Array<any>, e:any) => {
		return data.findIndex((obj: any) => obj.id === e.id);
	}
}

export default Utils;