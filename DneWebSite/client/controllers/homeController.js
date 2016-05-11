(function(){
	'use strict';

	angular.module('main')
		   .controller('homeCtrl', ['$log', function ($log) {
		   		var vm = this;
		   		vm.host = '10.144.101.3';
		   		vm.host2 = '10.144.101.5';
		   }])

})();