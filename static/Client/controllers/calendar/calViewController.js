(function(){
	'use strict'

	angular.module('main')
		.controller('calViewCtrl', ['$uibModal', 'calService',calendar]);


	function calendar($modal){

		//Modal
		var openDetailModal=function(event){
			var modalInstance=$modal.open({
				animation:true,
				templateUrl:'client/templates/home/eventDetailModal.html',
				controller:'calModalCtrl as m',
				resolve:{
					event:function(){
						return event;
					}
				}
			});
			//Debug
			//console.log(event);
			// function insertEvent(event){
			// 	console.log(event);
			// }

			function error(){
				$log.info("Modal dismissed at "+ new Date());
			}

			//modalInstance.result.then(insertEvent(event));
		} 

		//Event Click Event
		var eventDetail=function(event, jsEvent, view){
			openDetailModal(event);
		}

		var uiConfig={
			calendar:{
				height:700,
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
            	eventClick:eventDetail
            },
            

        }
        //資料庫應由資料庫來
        var events=[
        		{
                    title:'GEH履約協商會議',
                    start: '2016-02-17 09:45',
                    end: '2016-02-17 11:45'

                },
                {
                    title:'核心訓練',
                    start:'15:15',
                    end:'17:15',
                    dow:[1,3,5]
                },
                {
                    title:'核發處聯合晨會',
                    start:'08:15',
                    
                    dow:[1,2,3,4,5]
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