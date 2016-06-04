(function() {
        'use strict';
        //會議紀錄
        angular.module('main')
            .controller('meetingGridCtrl', ['i18nService', '$uibModal', '$scope', '$http', '$log', 'uiGridConstants', uiGrid]);


        function uiGrid(i18nService, $modal, $scope, $http, $log, uiGridConstants) {
            var vm = this;

           

            //ui-grid欄位設定
            var colDef=[
                    { name: "日期", field: "PostDate", width: 120, enableColumnMenu: false },
                   
                    { name: "標題", field: "MeetingTitle", enableColumnMenu: false, enableSorting: false },
                    { name: "張貼人員", field: "PostedBy", width: 140, enableColumnMenu: false },
                    { name:"檔案下載", enableColumnMenu: false, cellTemplate:'<div>' +
                    '<p class="center"><a href="/meetings/download/?p={{row.entity.MeetingFiles[0].FileId}}{{row.entity.MeetingFiles[0].Extension}}&d={{row.entity.MeetingFiles[0].FileName}}"> <span class="fa fa-download"></span></a></p>' +
                    '</div>'}
            ];

            //多個檔案
            function attachmentFileLoop(row) {
                var cellTemplate = '';
                for (var i = 0; i < row.entity.MeetingFiles.length; i++) {

                    cellTemplate.concat('<div>' +
                    '<p class="center"><a href="/meetings/download/?p={{row.entity.MeetingFiles[i].FileId}}{{row.entity.MeetingFiles[i].Extension}}&d={{row.entity.MeetingFiles[i].FileName}}"> <span class="fa fa-download"></span></a></p>' +
                    '</div>');
                }
                return cellTemplate;
            }

            vm.searchTextToggle = "啟用";

            //ui-grid的相關設定
            vm.gridOptions = {
                enableFiltering:false,
                enableColumnResizing:true,
                enableSorting: true,
                paginationPageSize: 10,
                paginationPageSizes: [10, 25, 50, 75],
                enableRowSelection: true,
                enableRowHeaderSelection: false,
                multiSelect:false,
                onRegisterApi: function (gridApi) {
                    //console.log(gridApi);
                    vm.gridApi = gridApi;
                    
                },
                columnDefs: colDef
                    

               
            }


            //取得Database中佈告資料
            $http.get('/api/meetingsdata/').then(suc, err);
            function suc(res) {
                vm.gridOptions.data = res.data;
                
            }
            function err(err) {
                
            }


            vm.toggleFiltering = function () {
                //過濾狀態判斷
                vm.gridOptions.enableFiltering = !vm.gridOptions.enableFiltering;
                if (vm.gridOptions.enableFiltering==true) {
                    vm.searchTextToggle = "關閉";
                } else {
                    vm.searchTextToggle = "啟用";
                }
                //當輸入過濾條件後，自動render新資料
                vm.gridApi.core.notifyDataChange(uiGridConstants.dataChange.COLUMN);
            };


            
        }
    }
)();