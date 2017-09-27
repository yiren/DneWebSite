(function () {
    'use strict';

    angular
        .module('main')
        .controller('orgCtrl', ['$scope', orgControl]);


    function orgControl($scope) {
        
        activate();

        function activate() {
            $scope.oneAtATime = true;

            $scope.groups = [
                {
                    divId:'controlDoc',
                    title: '內控文件',
                    content: [
                        {
                            linkText: '年度自行評估報告',
                            link: 'http://10.20.1.4/資料/1關於本處/內控專區/內控文件/年度自行評估報告'
                        },
                        {
                            linkText: '各季內控成效檢討會議紀錄',
                            link: 'http://10.20.1.4/資料/1關於本處/內控專區/內控文件/各季內控成效檢討會議紀錄'
                        }
                    ]
                },
                {
                    divId:'levelControl',
                    title: '分級檢核',
                    content: [
                        {
                            linkText: '核能技術處分級檢核實施要點',
                            link: 'http://10.20.1.4/資料/1關於本處/內控專區/分級檢核/核能技術處分級檢核實施要點'
                        },
                        {
                            linkText: '核能技術處分級檢核實施要點附表',
                            link: 'http://10.20.1.4/資料/1關於本處/內控專區/分級檢核/核能技術處分級檢核實施要點附表',
                        },
                        {
                            linkText: '各組(課)別編碼表',
                            link: 'http://10.20.1.4/資料/1關於本處/內控專區/分級檢核/各組(課)別編碼表',
                        }
                    ],
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
