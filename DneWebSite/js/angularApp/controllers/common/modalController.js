(function(){
    'use strict'
    //�u������
    angular.module('main')
		.controller('modalCtrl', ['$uibModalInstance','$log','data',calModal]);

    function calModal($uibModalInstance, $log, data){


        //var start=moment(event.start).toDate();
        //console.log(data.start.format('YYYY-MM-DD'));
        //console.log(data);

        //�p�G�O��ƾ��ơA�n�榡�Ʈɶ��榡
        if (data.start !== undefined || data.end !== undefined) {
            if (data.allDay === true) {
                data.startTime=data.start.format('YYYY-MM-DD');
                data.endTime=data.end.format('YYYY-MM-DD');
            } else {
                data.startTime=data.start.format('HH:mm');
                data.endTime=data.end.format('HH:mm');
            }
            

            
        }
		//var datetimeConfig = {
		//	datepickerOptions:{
		//		showWeeks:false,
		//		startingDay:1
		//	},
		//	timepickerOptions:{
		//		minuteStep:15,
		//		showMeridian:false
		//	}
		//};

		//var isOpen = false;

		//var openCalendar=function(e){
		//	e.preventDefault();
		//	e.stopPropagation();
		//	this.isOpen=true;
		//}

		//var isOpen2 = false;

		//var openCalendar2=function(e){
		//	e.preventDefault();
		//	e.stopPropagation();
		//	this.isOpen2=true;
        //}

		var save=function(){

			$uibModalInstance.close();
		};
		
		var cancel=function(){
			$uibModalInstance.dismiss('cancel');
		};


        //�@���ô��
		angular.extend(this, {
			save:save,
			cancel:cancel,
			data:data
			//isOpen:isOpen,
			//isOpen2:isOpen2,
			//openCalendar:openCalendar,
			//openCalendar2:openCalendar2,
			//dateOptions:datetimeConfig.datepickerOptions,
			//timeOptions:datetimeConfig.timepickerOptions
		});
	}

})();