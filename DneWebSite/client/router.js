(function(){
    'use strict';
    
    angular
        .module("main")
        .config(
                function($stateProvider, $urlRouterProvider){
     			
     			// 預設頁面
        		$urlRouterProvider.otherwise('/');
                //新增頁面及對應的html
                $stateProvider
                    //進入頁
        			//.state('cover',{
        			//	url:'/',
        			//	templateUrl:'/../client/templates/home/imageSilderFull.html',
        			//	controller:'homeCtrl'
        			//})
                    //首頁
                    .state('home',{
                        url:'/',
                        templateUrl:'/../client/templates/home/body.html',
                        controller:'homeCtrl'
                    })
                    //網站地圖
                    .state('sitemap',{
                        url:'/sitemap',
                        templateUrl:'/../client/templates/home/sitemap.html',
                        controller:'homeCtrl'
                    })
                    //常用表單/資料
                    .state('downloads',{
                        url:'/downloads',
                        templateUrl:'/../client/templates/home/downloads.html',
                        controller:'homeCtrl'
                    })
                    //龍門計畫簡介
                    .state('lungmenIntro',{
                        url:'/engineering/lungmen/intro',
                        templateUrl:'/../client/templates/engineering/lungmen/lungmen.html',
                        controller:'homeCtrl'
                    })
                    //會議紀錄
                    .state('meeting', {
                        url: '/regular/meeting',
                        templateUrl: '/../client/templates/regular/meeting.html',
                        controller: 'homeCtrl'
                    })
                    //新到資料、核能外文期刊閱覽評註
                    .state('books', {
                        url: '/regular/books',
                        templateUrl: '/../client/templates/regular/books.html',
                        controller: 'homeCtrl'
                    })
                    //製作中頁面
                    .state('underConstruction', {
                        url: '/underConstruction',
                        templateUrl: '/../client/templates/error/underConstruction.html',
                        controller: 'homeCtrl'
                    })
                     //公司章則
                    .state('govReg', {
                        url: '/govReg',
                        templateUrl: '/../client/templates/regular/govReg.html',
                        controller: 'homeCtrl'
                    })
                    //公司章則
                    .state('companyReg', {
                        url: '/companyReg',
                        templateUrl: '/../client/templates/regular/companyReg.html',
                        controller: 'homeCtrl'
                    })
                    //事業部章則
                    .state('departmentReg', {
                        url: '/departmentReg',
                        templateUrl: '/../client/templates/regular/departmentReg.html',
                        controller: 'homeCtrl'
                    })
                    //事業部章則
                    .state('dcrList', {
                        url: '/dcrList',
                        templateUrl: '/../client/templates/engineering/dcrList.html',
                        controller: 'homeCtrl'
                    })
                ;
    })
    
})();