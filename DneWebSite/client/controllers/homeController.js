(function(){
	'use strict';

	angular.module('main')
        .controller('homeCtrl', ['$scope','$log', '$state','ngDialog', function ($scope,$log, $state, ngDialog) {
            //�������J�u������
            //$scope.$on('$viewContentLoaded', function () {
            //    //call it here
            //    //console.log("preload");
            //    ngDialog.open({
            //        template: "client/templates/home/popup.html",
            //        width:600
            //    });
            //});
            var vm = this;
            //�º��D����}
            vm.host = '10.20.1.4';
            vm.host2 = '10.144.101.5';
            vm.goToHome = function () {
		   	    //ui-router $state.go�i�H����router.js�w�q��state���|�W��
		   	    $state.go('home');
		   	}
		   }])

})();