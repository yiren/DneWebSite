(function(){
	'use strict'

	angular.module('main')
		.controller('calModalCtrl', ['$uibModalInstance','$log','event',calModal]);

	function calModal($uibModalInstance, $log, event){


		//var start=moment(event.start).toDate();

		
		//var datetimeConfig = {
		//	datepickerOptions:{
		//		showWeeks:false,
		//		startingDay:1
		//	},
		//	timepickerOptions:{
		//		minuteStep:15,
		//		showMeridian:false
		//	}
		//};

		//var isOpen = false;

		//var openCalendar=function(e){
		//	e.preventDefault();
		//	e.stopPropagation();
		//	this.isOpen=true;
		//}

		//var isOpen2 = false;

		//var openCalendar2=function(e){
		//	e.preventDefault();
		//	e.stopPropagation();
		//	this.isOpen2=true;
		//}

	    
		var save=function(){

			$uibModalInstance.close();
		};
		
		var cancel=function(){
			$uibModalInstance.dismiss('cancel');
		};


		angular.extend(this, {
			save:save,
			cancel:cancel,
			event:event
			//isOpen:isOpen,
			//isOpen2:isOpen2,
			//openCalendar:openCalendar,
			//openCalendar2:openCalendar2,
			//dateOptions:datetimeConfig.datepickerOptions,
			//timeOptions:datetimeConfig.timepickerOptions
		});
	}

})();