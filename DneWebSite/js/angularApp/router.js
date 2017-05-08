
routing.$inject=['$stateProvider', '$urlRouterProvider'];

export default function routing
    ($stateProvider, $urlRouterProvider){    			

    $urlRouterProvider.otherwise('/');
    
    $stateProvider
        
        .state('home',{
            url:'/',
            template:require('./templates/home/body.html'),
            controller:'homeCtrl'
        })
        
        .state('sitemap',{
            url:'/sitemap',
            template:require('./templates/home/sitemap.html'),
            controller:'homeCtrl'
        })
        
        .state('downloads',{
            url:'/downloads',
            template:require('./templates/home/downloads.html'),
            controller:'homeCtrl'
        })
        
        .state('lungmenIntro',{
            url:'/engineering/lungmen/intro',
            template:require('./templates/engineering/lungmen/lungmen.html'),
            controller:'homeCtrl'
        })
        
        .state('meeting', {
            url: '/regular/meeting',
            template:require('./templates/regular/meeting.html'),
            controller: 'homeCtrl'
        })
        
        .state('books', {
            url: '/regular/books',
            template:require('./templates/regular/books.html'),
            controller: 'homeCtrl'
        })
        
        .state('underConstruction', {
            url: '/underConstruction',
            template:require('./templates/error/underConstruction.html'),
            controller: 'homeCtrl'
        })
        
        .state('govReg', {
            url: '/govReg',
            template:require('./templates/regular/govReg.html'),
            controller: 'homeCtrl'
        })
    
        .state('companyReg', {
            url: '/companyReg',
            template:require('./templates/regular/companyReg.html'),
            controller: 'homeCtrl'
        })
    
        .state('departmentReg', {
            url: '/departmentReg',
            template:require('./templates/regular/departmentReg.html'),
            controller: 'homeCtrl'
        })
    ;
};
    
