
routing.$inject=[$stateProvider, $urlRouterProvider]

export default function routing
    ($stateProvider, $urlRouterProvider){    			

    $urlRouterProvider.otherwise('/');
    
    $stateProvider
        
        .state('home',{
            url:'/',
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
        
        .state('books', {
            url: '/regular/books',
            templateUrl: '/../client/templates/regular/books.html',
            controller: 'homeCtrl'
        })
        
        .state('underConstruction', {
            url: '/underConstruction',
            templateUrl: '/../client/templates/error/underConstruction.html',
            controller: 'homeCtrl'
        })
        
        .state('govReg', {
            url: '/govReg',
            templateUrl: '/../client/templates/regular/govReg.html',
            controller: 'homeCtrl'
        })
    
        .state('companyReg', {
            url: '/companyReg',
            templateUrl: '/../client/templates/regular/companyReg.html',
            controller: 'homeCtrl'
        })
    
        .state('departmentReg', {
            url: '/departmentReg',
            templateUrl: '/../client/templates/regular/departmentReg.html',
            controller: 'homeCtrl'
        })

        .state('dcrList', {
            url: '/dcrList',
            templateUrl: '/../client/templates/engineering/dcrList.html',
            controller: 'homeCtrl'
        })
    ;
};
    
