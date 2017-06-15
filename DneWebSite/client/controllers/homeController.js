(function(){
	'use strict';

	angular.module('main')
        .controller('homeCtrl', ['$scope','$log', '$state','ngDialog','toaster', function ($scope,$log, $state, ngDialog, toaster) {
            //首頁popup視窗
            //$scope.$on('$viewContentLoaded', function () {
            //    //call it here
            //    //console.log("preload");
            //    ngDialog.open({
            //        template: "client/templates/home/popup.html",
            //        width:700
            //    });
            //});
            var vm = this;
            //舊網主機位址
            toaster.pop({
                type: 'info',
                title: '即時公告測試',
                body: 'di-html',
                bodyOutputType: 'directive'
            });
            //alert("會亂碼嗎?")
            vm.host = '10.20.1.4';
            vm.host2 = '10.144.101.5';
            vm.goToHome = function () {
		   	    //ui-router $state.go可以跳到router.js定義的state路徑名稱
		   	    $state.go('home');
		   	}
        }])
     .directive('diHtml', [function () {
         return {
             template:"<span>我會自己消失</span>"
         }
     }])

})();