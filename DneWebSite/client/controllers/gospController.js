(function () {
    'use strict';

    angular
        .module('main')
        .controller('gospCtrl', gospController);

    gospController.$inject = ['$http']; 

    function gospController($http) {
        /* jshint validthis:true */
        var vm = this;
        
        
        init();

        function init() {
            $http.get('/api/gosp').then(suc);
            function suc(res) {
                
                vm.gosps = res.data;
                console.log("data", vm.gosps);
            };

        vm.getPicFileName=function(_score){
            var score = parseFloat(_score);
            console.log(score);
                if(score<=60){
                    return 'red';
                }else if(score<=70){
                    return 'yellow';
                }else if(score<80){
                    return 'white';
                }else if(score >=80){
                    return 'green';
                }else{
                    return 'na';
                }
            };
        }
    }
})();
