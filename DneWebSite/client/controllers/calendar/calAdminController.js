(function(){
	'use strict'

	angular.module('main')
		.controller('calAdminCtrl', ['uiCalendarConfig','$uibModal', '$log', calendar]);


	function calendar(uiCalendarConfig,$modal, $log){
		var vm=this;
		
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
			modalInstance.result.then(insertEvent(event));
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

		

		var oldEvent;

		//Full Calendar
		//Day Click Event
		var dayEvent=function(date, jsEvent, view){
			openAddModal(date);
			console.log(date);
			console.log(jsEvent);
			console.log(view);
		};


		//Event Click Event
		//event編輯更新以及刪除
		var eventEdit=function(event, jsEvent, view){
			//openEditModal(event)
			vm.event=event;
			oldEvent=event;
			
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
            	dayClick:dayEvent,
            	eventClick:eventEdit
            },
            

        }

        
        //資料應從資料庫來
        var events=[
        		{
        			id:1,
                    title:'GEH履約協商會議',
                    start: '2016-02-17 09:45',
                    end: '2016-02-17 11:45'

                },
                {
                	id:2,
                    title:'核發處聯合晨會',
                    start:'08:15',
                    location:'總處2008會議室',
                    attendee:'處長、吳副處長、賴副處長、王經理(視情況參加)、范組長陽錦、簡組長致煥、鄭組長素琴、郭組長東裕',                
                    dow:[1,2,3,4,5]
                },
                {
                	id:3,
                    title:'核心訓練',
                    start:'15:15',
                    end:'17:15',
                    dow:[1,3,5]
                }
        ]

        var eventSources=[events];

        vm.events=events
        vm.eventSources=[vm.events]
        //form
        var datetimeConfig = {
			datepickerOptions:{
				showWeeks:false,
				startingDay:1
			},
			timepickerOptions:{
				minuteStep:15,
				showMeridian:false
			}
		};

		var isOpen = false;

		var openCalendar=function(e){
			e.preventDefault();
			e.stopPropagation();
			this.isOpen=true;
		}

		var isOpen2 = false;

		var openCalendar2=function(e){
			e.preventDefault();
			e.stopPropagation();
			this.isOpen2=true;
		}

		var updateEvent=function(event){
			// var eventsNew;
			//console.log("events? "+events);
			//console.log(event);
			// eventsNew = _.filter(events, function(o){
			// 	console.log(o);
			// 	return o.id != event.id;
			// });
			
			uiCalendarConfig.calendars.calInstance.fullCalendar('updateEvent', event);
			// eventsNew.push(event);
			//console.log(eventsNew);
			
			// vm.events=eventsNew;
			// uiCalendarConfig.calendars.calInstance.fullCalendar('removeEventSource', vm.eventSources);
			// vm.eventSources=[];
			// vm.eventSources.push(vm.events);
			
			//console.log(uiCalendarConfig);

			//uiCalendarConfig.calendars.calInstance.fullCalendar('rerenderEvents');
			//console.log(vm.eventSources);

		}
		var deleteEvent=function(event){
			
			uiCalendarConfig.calendars.calInstance.fullCalendar('removeEvents', event._id);
						
			//console.log(uiCalendarConfig);

			//uiCalendarConfig.calendars.calInstance.fullCalendar('refetchEvents');
			console.log(vm.eventSources);

		}
		
		var dayEvent=function(){
        	events.push({
                    title:'核發處聯合晨會',
                    start:'15:15',
                    
                    dow:[1,2,3,4,5]
                });
        }

		var addEvent=function(event){
			console.log(event);
			console.log(event.start);
			
			events.push({
				title:"Test",
				start:"2016-03-04 16:33",
				end:"2016-03-04 17:33",
				location:"2008會議室",
				attendee:"test"
			});
		}

		angular.extend(this, {
			uiConfig:uiConfig,
			//Use vm for ensuring two-way binding
			//eventSources:eventSources,
			isOpen:isOpen,
			isOpen2:isOpen2,
			openCalendar:openCalendar,
			openCalendar2:openCalendar2,
			dateOptions:datetimeConfig.datepickerOptions,
			timeOptions:datetimeConfig.timepickerOptions,
			event:event,
			updateEvent:updateEvent,
			deleteEvent:deleteEvent,
			addEvent:addEvent

		});
	}

})();