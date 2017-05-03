(function(){
	'use strict'

	angular.module('main')
		.controller('calViewCtrl', ['$uibModal', calendar]);
    
    //行事曆相關設定
	function calendar($modal){

	    var vm = this;

		//Modal
		var openDetailModal=function(event){
			var modalInstance=$modal.open({
				animation:true,
				template:require('../../templates/home/eventDetailModal.html'),
				controller:'modalCtrl as m',
				resolve:{
					data:function(){
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
		            right: 'month,basicWeek,basicDay'
	            },
	            timezone:'Asia/Taipei',
	            locale:'zh-tw',
                lang:'zh-tw',
	            weekends:true,
	            defaultView:'basicDay',
	            minTime:'07:00:00',
	            maxTime:'19:00:00',
	            firstHour:(new Date().getUTCHours-5),
	            nowIndicator:true,
	            allDaySlot:true,
                contentHeight:'auto',
                theme: false,
               // loading:true,
	            views:{
	                basic: {
                        timeFormat:"HH:mm"
	                },
	                agenda: {
	                    timeFormat: "HH:mm"
	                },
	                month: {
	                    timeFormat: "HH:mm"
	                }
	            },
	            businessHours:{
	            	start:'08:00',
	            	end:'17:20',
	            	dow:[1,2,3,4,5]
	            },
	            //Event Handling
	            eventClick: eventDetail,
	            viewRender: function (view, element) {
                    //自行格式化"日"表格
	                if (view.name == 'basicDay') {
	                    var additionalColumn = '<tr><td><div class="row"><div class="col-md-2">日期</div><div class="col-md-5">重要事項</div><div class="col-md-2">出席人員</div><div class="col-md-1">地點</div></div></td></tr>'
                        ;
	                   
	                   
	                    element.find('.fc-head').append(additionalColumn);
	                }
                    
	                
	            },
	            dayRender: function (date, cell) {
	              
	            },
	            eventRender: function (event, element, view) {

	               
                    element.attr('href', 'javascript:void(0)');
                    
                    
                    //如果沒有輸入出席人員，則顯示空白字串
                    if (event.description == null ||event.description == undefined) {
                        event.description='';
                    }
                    if (event.location == null ||event.location == undefined) {
                        event.location='';
                    }
	               
                    if (view.name == 'basicDay') {
                        var additionalInfo = '<div class="col-md-2 nowrap">' + event.description + '</div>'
                            + '<div class="col-md-1 nowrap">' + event.location + '</div>';
                        
                        if (event.allDay==false) {
                            
                            
                            element.find('.fc-content').addClass('row');
                            element.find('.fc-time').addClass("col-md-2 nowrap");
                            element.find('.fc-title').addClass("col-md-5 nowrap");
                            element.find('.fc-content').append(additionalInfo);
                        } else {
                            element.find('.fc-content').addClass('row');
                            element.find('.fc-content').prepend('<div class="col-md-2">全天</div>');
                            element.find('.fc-title').addClass("col-md-5 nowrap");
                            element.find('.fc-content').append(additionalInfo);
                        }
                    }
                    
                    if (view.name == 'basicWeek') {
                        element.find('.fc-title').addClass("nowrap");
                    }
                    if (view.name == 'month') {
                        element.find('.fc-title').addClass("nowrap");
                    }

                    var busOut = '出差';
                    var dutyOut = '公出';
                    var vac = '假';
                    var training = '受訓';
                    var aboard = '出國';
                    var supOutage = '大修';
                    var cancel = '取消';
                    var dateChanged = '改期';
                    var speech = '演講';
                    var project = '專案討論';

                    if (event.title.indexOf(dutyOut) >= 0 || event.title.indexOf(vac) >= 0
                        || event.title.indexOf(training) >= 0 || event.title.indexOf(aboard) >= 0
                        || event.title.indexOf(busOut) >= 0) {
                        
                        element.addClass('fc-event-dutyOut');
                       
                    }

                    if (event.title.indexOf(supOutage) >= 0) {
                        element.addClass('fc-event-supOutage');
                    }
                    if (event.title.indexOf(cancel) >= 0 || event.title.indexOf(dateChanged) >= 0) {
                        element.addClass('fc-event-changed');
                    }

                    if (event.title.indexOf(speech) >= 0 ||event.title.indexOf(project) >= 0) {
                        element.addClass('fc-event-speech');
                    }
                    
                  
                }
            }
            

        }
        //資料從Google Calendar來
		

        
            /*[
            
        		{
                    title:'核心訓練',
                    start:'15:15',
                    end: '17:15',
                    location: '總處2008會議室',
                    attendee: '88年後新進同仁',
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
                 
        ]*/


        vm.eventSources=[{
            googleCalendarApiKey: 'AIzaSyBGsSycErhrJgP8vlFfzbtCpNuStqcWjHo',
            googleCalendarId: 'c26rmjc50kbd6rqpvpb6ka555c@group.calendar.google.com'
        }];

		angular.extend(this, {
			uiConfig:uiConfig
		});
	}

})();