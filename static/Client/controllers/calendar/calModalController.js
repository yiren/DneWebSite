(function(){
	'use strict'

	angular.module('main')
		.controller('calModalCtrl', ['$uibModalInstance','$log','event',calModal]);

	function calModal($uibModalInstance, $log, event){

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
		});
	}

})();