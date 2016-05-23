(function(){
	'use strict';

	angular.module('main')
        .controller('homeCtrl', ['$log', '$state', function ($log, $state) {
            var vm = this;
            //舊網主機位址
            vm.host = '10.20.1.4';
            vm.host2 = '10.144.101.5';
            vm.goToHome = function () {
		   	    //ui-router $state.go可以跳到router.js定義的state路徑名稱
		   	    $state.go('home');
		   	}
		   }])

})();