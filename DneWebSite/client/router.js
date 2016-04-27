(function(){
    'use strict';
    
    angular
        .module("main")
        .config(
                function($stateProvider, $urlRouterProvider){
     			
     			// default route
        		$urlRouterProvider.otherwise('/');

        		$stateProvider
        			.state('home',{
        				url:'/',
        				templateUrl:'/../client/templates/home/body.html',
        				controller:'homeCtrl'
        			})

                    .state('v1',{
                        url:'/v1',
                        templateUrl:'/../client/templates/home/bodyv1.html',
                        controller:'homeCtrl'
                    })
                    .state('v2',{
                        url:'/v2',
                        templateUrl:'/../client/templates/home/bodyv2.html',
                        controller:'homeCtrl'
                    })
                    .state('sitemap',{
                        url:'/sitemap',
                        templateUrl:'/../client/templates/home/sitemap.html',
                        controller:'homeCtrl'
                    })
                    .state('downloads',{
                        url:'/downloads',
                        templateUrl:'/../client/templates/home/downloads.html',
                        controller:'homeCtrl'
                    })
                    .state('lungmenIntro',{
                        url:'/engineering/lungmen/intro',
                        templateUrl:'/../client/templates/engineering/lungmen/lungmen.html',
                        controller:'homeCtrl'
                    })
                ;
    })
    
})();