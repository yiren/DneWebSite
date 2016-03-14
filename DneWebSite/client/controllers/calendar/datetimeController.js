(function(){
	'use strict'



	angular.module('main')
		
		.controller('datetimeCtrl', ['calService', timepick]);

	function timepick(calService){
		
		


		var isOpen=false;

		var datetimeConfig={
			
			dateDisabled:true,
			datepickerOptions:{
				showWeeks:false,
				startingDay:1
			},
			timepickerOptions:{
				minuteStep:15,
				showMeridian:false
			}
		};
		var openCalendar=function(e){
			e.preventDefault();
			e.stopPropagation();
			this.isOpen=true;
		}

		angular.extend(this,{
			isOpen:isOpen,
			openCalendar:openCalendar,
			dateOptions:datetimeConfig.datepickerOptions,
			timeOptions:datetimeConfig.timepickerOptions,
			now:'17:12:00'
		});
	}

})();
