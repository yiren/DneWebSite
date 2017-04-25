(function(){
    'use strict';
    
    //angular應用程式入口，載入相關套件
    angular.module("main", [
        'ui.router',
        'ngAnimate',
        'ui.calendar',
        'ui.bootstrap',
        'ui.grid',
        'ui.grid.resizeColumns',
        'ui.grid.selection',
        'ui.grid.pagination',
        'duScroll',
        'ngDialog'
    ])
    .value('duScrollDuration', 2000)
    .value('duScrollOffset',40);
        
})();