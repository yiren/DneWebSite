(function(){
    'use strict';
    
    angular
        .module("main")
        .config(
                function($stateProvider, $urlRouterProvider){
     			
     			// �w�]����
        		$urlRouterProvider.otherwise('/');
                //�s�W�����ι�����html
                $stateProvider
                    //�i�J��
        			//.state('cover',{
        			//	url:'/',
        			//	templateUrl:'/../client/templates/home/imageSilderFull.html',
        			//	controller:'homeCtrl'
        			//})
                    //����
                    .state('home',{
                        url:'/',
                        templateUrl:'/../client/templates/home/body.html',
                        controller:'homeCtrl'
                    })
                    //�����a��
                    .state('sitemap',{
                        url:'/sitemap',
                        templateUrl:'/../client/templates/home/sitemap.html',
                        controller:'homeCtrl'
                    })
                    //�`�Ϊ��/���
                    .state('downloads',{
                        url:'/downloads',
                        templateUrl:'/../client/templates/home/downloads.html',
                        controller:'homeCtrl'
                    })
                    //�s���p�e²��
                    .state('lungmenIntro',{
                        url:'/engineering/lungmen/intro',
                        templateUrl:'/../client/templates/engineering/lungmen/lungmen.html',
                        controller:'homeCtrl'
                    })
                    //�|ĳ����
                    .state('meeting', {
                        url: '/regular/meeting',
                        templateUrl: '/../client/templates/regular/meeting.html',
                        controller: 'homeCtrl'
                    })
                    //�s���ơB�֯�~����Z�\������
                    .state('books', {
                        url: '/regular/books',
                        templateUrl: '/../client/templates/regular/books.html',
                        controller: 'homeCtrl'
                    })
                    //�s�@������
                    .state('underConstruction', {
                        url: '/underConstruction',
                        templateUrl: '/../client/templates/error/underConstruction.html',
                        controller: 'homeCtrl'
                    })
                     //���q���h
                    .state('govReg', {
                        url: '/govReg',
                        templateUrl: '/../client/templates/regular/govReg.html',
                        controller: 'homeCtrl'
                    })
                    //���q���h
                    .state('companyReg', {
                        url: '/companyReg',
                        templateUrl: '/../client/templates/regular/companyReg.html',
                        controller: 'homeCtrl'
                    })
                    //�Ʒ~�����h
                    .state('departmentReg', {
                        url: '/departmentReg',
                        templateUrl: '/../client/templates/regular/departmentReg.html',
                        controller: 'homeCtrl'
                    })
                    //�Ʒ~�����h
                    .state('dcrList', {
                        url: '/dcrList',
                        templateUrl: '/../client/templates/engineering/dcrList.html',
                        controller: 'homeCtrl'
                    })
                ;
    })
    
})();