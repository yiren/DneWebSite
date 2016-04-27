(function(){
	'use strict'

	angular.module('main')
		.controller('calAdminCtrl', ['$uibModal', '$log', calendar]);


	function calendar($modal, $log){

		//Edit Modal
		//修改現有event資料，以及刪除event
		var openEditModal=function(event){
			var modalInstance=$modal.open({
				animation:true,
				templateUrl:'client/templates/caladmin/eventEditModal.html',
				controller:'calModalCtrl as edit',
				resolve:{
					event:function(){
						return event;
					}
				}
				}
			);

			

			function error(){
				$log.info("Modal dismissed at "+ new Date());
			}

			//modalInstance結束後要更新資料庫，更新資料庫後首頁要更新
			//modalInstance.result.then(insertEvent(event));
		} 

		//Add Modal
		var openAddModal=function(date){
			var modalInstance=$modal.open({
				animation:true,
				templateUrl:'client/templates/caladmin/eventEditModal.html',
				controller:'calModalCtrl as add',
				resolve:{
					date:function(){
						return date;
					}
				}
				}
			);

			function error(){
				$log.info("Modal dismissed at "+ new Date());
			}

			//modalInstance結束後要更新資料庫，更新資料庫後首頁要更新
			//modalInstance.result.then(insertEvent(event));
		} 

		//Full Calendar
		//Day Click Event
		var addEvent=function(date, jsEvent, view){
			openAddModal(date);
			console.log(date);
			console.log(jsEvent);
			console.log(view);
		};


		//Event Click Event
		//event編輯更新以及刪除
		var eventEdit=function(event, jsEvent, view){
			openEditModal(event)
			console.log(event);
			console.log(jsEvent);
			console.log(view);
		}

		var uiConfig={
			calendar:{
				//General Config
				header: {
	            left: 'prev,next today',
	            center: 'title',
	            right: 'month,agendaWeek,agendaDay'
	            },
	            timezone:'Asia/Taipei',
	            lang:'zh-tw',
	            weekends:false,
	            defaultView:'agendaWeek',
	            minTime:'07:00:00',
	            maxTime:'19:00:00',
	            
	            nowIndicator:true,
	            allDaySlot:true,
	            theme:true,
	            
	            businessHours:{
	            	start:'08:00',
	            	end:'17:20',
	            	dow:[1,2,3,4,5]
	            },
	            //Event Handling
            	dayClick:openAddModal,
            	eventClick:openEditModal
            },
            

        }

        //資料應從資料庫來
        var events=[
        		{
                    title:'GEH履約協商會議',
                    start: '2016-02-17 09:45',
                    end: '2016-02-17 11:45'

                },
                {
                    title:'核發處聯合晨會',
                    start:'08:15',
                    
                    dow:[1,2,3,4,5]
                },
                {
                    title:'核心訓練',
                    start:'15:15',
                    end:'17:15',
                    dow:[1,3,5]
                }
        ]

        var addEvent=function(){
        	events.push({
                    title:'核發處聯合晨會',
                    start:'08:15',
                    
                    dow:[1,2,3,4,5]
                });
        }

        var eventSources=[events]

		angular.extend(this, {
			uiConfig:uiConfig,
			eventSources:eventSources,
			addEvent: addEvent
		});
	}

})();