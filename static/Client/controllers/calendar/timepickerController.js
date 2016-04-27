(function(){
	'use strict'

	angular.module('main')
		.controller('timepickerCtrl', ['calService', timepick]);

	function timepick(calService){
		


		angular.extend(this,{
			mStep:15,
			readonly:true,
			isMeridian:false
		});
	}

})();
