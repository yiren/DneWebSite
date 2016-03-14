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
        				templateUrl:'client/templates/home/body.html',
        				controller:'homeCtrl'
        			})
                    .state('sitemap',{
                        url:'/sitemap',
                        templateUrl:'client/templates/sitemap.html',
                        controller:'homeCtrl'
                    })
                    .state('caladmin',{
                        url:'/caladmin',
                        templateUrl:'client/templates/caladmin/caladmin.html',
                        controller:'calAdminCtrl as admin'

                    })
                    .state('downloads',{
                        url:'/downloads',
                        templateUrl:'client/templates/downloads/downloads.html',
                        controller:'homeCtrl'
                    })
                    .state('lungmenHome',{
                        url:'/engineering/lungmen/home',
                        templateUrl:'client/templates/engineering/lungmen/home.html',
                        controller:'homeCtrl'
                    })
                ;
    })
    
})();