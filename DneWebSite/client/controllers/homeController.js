(function(){
	'use strict';

	angular.module('main')
        .controller('homeCtrl', ['$scope','$log', '$state','ngDialog','toaster', function ($scope,$log, $state, ngDialog, toaster) {
            //首頁popup視窗
            //$scope.$on('$viewContentLoaded', function () {
            //    //call it here
            //    console.log("preload");
            //    ngDialog.open({
            //        template: "client/templates/home/popup.html",
            //        width:700
            //    });
            //});
            var vm = this;
            //舊網主機位址
            //toaster.pop({
            //    type: 'success',
            //    title: '「台電綠網」宣導',
            //    body: 'di-html',
            //    bodyOutputType: 'directive',
            //    timeout:4000
            //});
            //toaster.pop({
            //    type: 'info',
            //    title: '安裝Adobe Flash更新程式注意事項',
            //    body: '建議取消勾選「將Google Chrome設為預設瀏覽器」，Google Chrome與本公司公文系統不相容。',
            //    timeout: 6000
            //});

            //alert("會亂碼嗎?")
            vm.host = '10.20.1.4';
            //vm.host = '10.20.1.3';
            //vm.host2 = '10.20.1.7';
            vm.host2 = '10.144.101.5';

            //vm.host ='\\10.20.1.30\backup\10.20.1.4\資料'
      //      vm.goToHome = function () {
		   	//    //ui-router $state.go可以跳到router.js定義的state路徑名稱
		   	//    $state.go('home');
		   	//}
        }])
     .directive('diHtml', [function () {
         return {
             template: "請踴躍<a href='http://greennet.taipower.com.tw' target='_blank'><i class='fa fa-hand-pointer-o'>點我</>"
         }
     }])

})();