(function(){
    'use strict';
    
    angular
        .module("main")
        .config(
                function($stateProvider, $urlRouterProvider){
     			
     			// default route
        		$urlRouterProvider.otherwise('/');

                $stateProvider
        			.state('cover',{
        				url:'/',
        				templateUrl:'/../client/templates/home/imageSilderFull.html',
        				controller:'homeCtrl'
        			})
                    .state('home',{
                        url:'/home',
                        templateUrl:'/../client/templates/home/body.html',
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
                    .state('meeting', {
                        url: '/regular/meeting',
                        templateUrl: '/../client/templates/regular/meeting.html',
                        controller: 'homeCtrl'
                    })
                ;
    })
    
})();