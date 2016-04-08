//FullCalendar
$(document).ready(function(){
    $('#calendar').fullCalendar({
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
            views:{
                week:{
                    
                },
                day:{
                   
                }
            },
            nowIndicator:true,
            allDaySlot:true,
            theme: true,
            googleCalendarApiKey:'AIzaSyC7RwCZBBk5R7Ch_Syv1YmO_GfHfYE-Tmw',
            events: {
                googleCalendarId: '13juf6evptsnbc83704vkhgh00@group.calendar.google.com',
                
            }
                /*
                [
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
            ]*/
        });
})  ;      

