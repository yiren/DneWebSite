import angular from 'angular';
import duScroll from 'angular-scroll';
import ngAnimate from 'angular-animate';
import uiBootstrap from 'angular-bootstrap';
import uiGrid from 'angular-ui-grid';

angular.module("main", [
        // 'ui.router',
         ngAnimate,
        // 'ui.calendar',
        'ui-bootstrap',
        uiGrid,
        'ui.grid.resizeColumns',
        'ui.grid.selection',
        'ui.grid.pagination',
        duScroll,
        // 'ngDialog'
    ])
    .value('duScrollDuration', 2000)
    .value('duScrollOffset',40);