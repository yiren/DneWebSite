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
                    title:'核心訓練',
                    start:'15:15',
                    end:'17:15',
                    dow:[1,3,5]
                },
                {
                    title:'核技處、核發處聯合晨會',
                    start:'08:15',
                    location: '總處2008會議室',
                    attendee: '處長、吳副處長、賴副處長、王經理(視情況參加)、范組長陽錦、簡組長致煥、鄭組長素琴、郭組長東裕',
                    dow:[1,2,3,4,5]
                },
                {
                    title: '支援核一廠一號機EOC-27 partⅡ大修3/14~5/31',
                    
                    
                    location: '核一廠',
                    attendee: '鄭宏淵、李文翔、黃文靖、林宏璋',
                    allDay:true,
                    dow: [1, 2, 3, 4, 5]
                },
                 {
                     title: '支援核一廠一號機大修(A-46專案)3/3~5/31',
                     
                     
                     location: '核一廠',
                     attendee: '吳朝旺 、黃彥欽、李亮瑩、陳宥辰、黃茂豪、張正平',
                     allDay: true,
                     dow: [1, 2, 3, 4, 5]
                 },

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