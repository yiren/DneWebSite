(function() {
        'use strict';

        angular.module('main')
            .controller('gridCtrl', ['i18nService', '$uibModal', '$scope', '$http', '$log', 'uiGridConstants', uiGrid]);


        function uiGrid(i18nService, $modal, $scope, $http, $log, uiGridConstants) {
            var vm = this;

            //彈跳視窗
            var openDetailModal = function (post) {
                var modalInstance = $modal.open({
                    animation: true,
                    templateUrl: 'client/templates/home/postDetailModal.html',
                    controller: 'modalCtrl as m',
                    resolve: {
                        data: function () {
                            return post;
                        }
                    }
                });
                //Debug
                //console.log(event);
                // function insertEvent(event){
                // 	console.log(event);
                // }
                
                function error() {
                    $log.info("Modal dismissed at " + new Date());
                }

                //modalInstance.result.then(insertEvent(event));
            }

          


            //ui-grid欄位設定
            var colDef=[
                    { name: "日期", field: "PostDate", width: 120, enableColumnMenu: false },
                    {
                        name: "類別", field: "Category", width: 150, enableColumnMenu: false
                        
                    },
                    { name: "標題", field: "Title", enableColumnMenu: false, enableSorting: false },
                    { name: "張貼部門", field: "Section", width: 140, enableColumnMenu: false }
            ];


            //ui-grid的相關設定
            vm.gridOptions = {
                enableFiltering:false,
                enableColumnResizing:true,
                enableSorting: true,
                paginationPageSize: 25,
                paginationPageSizes: [25, 50, 75],
                enableRowSelection: true,
                enableRowHeaderSelection: false,
                multiSelect:false,
                onRegisterApi: function (gridApi) {
                    //console.log(gridApi);
                    vm.gridApi = gridApi;
                    gridApi.selection.on.rowSelectionChanged($scope, function (row) {
                        openDetailModal(row);
                        //console.log(row);
                    });
                },
                columnDefs: colDef
                    

               
            }


            //取得Database中佈告資料
            $http.get('/api/postsdata/').then(suc, err);
            function suc(res) {
                vm.gridOptions.data = res.data;
                
            }
            function err(err) {
                
            }


            vm.toggleFiltering = function () {
                vm.gridOptions.enableFiltering = !vm.gridOptions.enableFiltering;
                vm.gridApi.core.notifyDataChange(uiGridConstants.dataChange.COLUMN);
            };


            
        }
    }
)();