import 'angular-ui-grid';

import angular from 'angular';
import duScroll from 'angular-scroll';
import ngAnimate from 'angular-animate';
import postGridCtrl from '../angularApp/controllers/postGridController.js';
import uiBootstrap from 'angular-bootstrap';

angular.module("main", [
        // 'ui.router',
         ngAnimate,
        // 'ui.calendar',
        'ui-bootstrap',
        'ui-grid',
        'ui.grid.resizeColumns',
        'ui.grid.selection',
        'ui.grid.pagination',
        duScroll,
        // 'ngDialog'
    ])
    .controller('postGridCtrl', postGridCtrl)
    .value('duScrollDuration', 2000)
    .value('duScrollOffset',40);