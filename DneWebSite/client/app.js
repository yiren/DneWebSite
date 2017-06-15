(function(){
    'use strict';
    
    //angular���ε{���J�f�A���J�����M��
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
        'ngDialog',
        'toaster'
    ])
    .value('duScrollDuration', 2000)
    .value('duScrollOffset',40);
        
})();