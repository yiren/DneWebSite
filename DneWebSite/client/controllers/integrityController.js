(function () {
    'use strict';

    angular
        .module('main')
        .controller('integrityCtrl', ['$scope', integrity]);


    function integrity($scope) {
        
        activate();

        function activate() {
            $scope.oneAtATime = true;

            $scope.groups = [
                {
                    title: '政風法令',
                    content: [
                        { linkText: '貪污治罪條例', link:'http://10.16.10.128/廉政宣導/貪污治罪條例.pdf'}
                    ],
                },
                {
                    title: '廉政會報',
                    content: '',
                }
            ];

            $scope.status = {
                isCustomHeaderOpen: false,
                isFirstOpen: true,
                isFirstDisabled: false,
                expandAll:false
            };
        }
    }
})();
