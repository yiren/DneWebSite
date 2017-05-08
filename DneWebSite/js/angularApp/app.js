//@require "../**/*.html"

import 'angular-ui-grid';
import 'ng-dialog';
import 'angular-ui-calendar';

import angular from 'angular';
import duScroll from 'angular-scroll';
import ngAnimate from 'angular-animate';
import routing from './router.js';
import uiModal from 'angular-ui-bootstrap/src/modal';
import uiRouter from 'angular-ui-router';

angular.module("main", [
         uiRouter,
         ngAnimate,
         'ui.calendar',
        uiModal,
        'ui.grid',
        'ui.grid.resizeColumns',
        'ui.grid.selection',
        'ui.grid.pagination',
        duScroll,
        'ngDialog'
    ])
    .value('duScrollDuration', 2000)
    .value('duScrollOffset',40)
    .config(routing);

require('./controllers/homeController.js');
require('./controllers/postGridController.js');
require('./controllers/common/modalController.js');
require('./controllers/meetingGridController.js');
require('./controllers/calendar/calViewController.js')