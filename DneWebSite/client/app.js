(function(){
    'use strict';
    
    angular.module("main", [
        'ui.router',
        'ui.calendar',
        'ui.bootstrap',
        'ui.bootstrap.datetimepicker',
        'ngAnimate',
        'ui.grid',
        'ui.grid.resizeColumns',
        'ui.grid.selection',
        'duScroll',
        'feeds'

    ])
    .value('duScrollDuration', 2000)
    .value('duScrollOffset',40);
        
})();