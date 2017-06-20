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
                type: 'success',
                title: '「台電綠網」宣導',
                body: 'di-html',
                bodyOutputType: 'directive',
                timeout:4000
            });
            toaster.pop({
                type: 'info',
                title: '權益小幫手',
                body: '員工團體保險權益已變更，請至公佈欄查閱相關訊息',
                timeout: 2000
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
             template: "請踴躍<a href='http://greennet.taipower.com.tw' target='_blank'><i class='fa fa-hand-pointer-o'>點我</>"
         }
     }])

})();