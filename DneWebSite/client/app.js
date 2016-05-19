(function(){
    'use strict';
    
    //angular應用程式入口，載入相關套件
    angular.module("main", [
        'ui.router',
        'ui.calendar',
        'ui.bootstrap',
        'ngAnimate',
        'ui.grid',
        'ui.grid.resizeColumns',
        'ui.grid.selection',
        'duScroll',
        'feeds',
        'anim-in-out'
    ])
    .value('duScrollDuration', 2000)
    .value('duScrollOffset',40);
        
})();