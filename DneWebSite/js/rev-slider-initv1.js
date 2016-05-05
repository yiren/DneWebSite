//Revolution Slider
$(document).ready(function(){
	if ($(".slider-banner-container").length>0) {
			
			$(".tp-bannertimer").show();

			$('.slider-banner-container .slider-banner-fullscreen').show().revolution({
				delay:6000,
				startwidth:640,
				startheight: 350,
                dottedOverlay: "twoxtwo",
				
				navigationArrows:"solo",
				
				navigationStyle: "round",
				navigationHAlign:"center",
				navigationVAlign:"bottom",
				navigationHOffset:0,
				navigationVOffset:20,

				soloArrowLeftHalign:"left",
				soloArrowLeftValign:"center",
				soloArrowLeftHOffset:20,
				soloArrowLeftVOffset:0,

				soloArrowRightHalign:"right",
				soloArrowRightValign:"center",
				soloArrowRightHOffset:20,
				soloArrowRightVOffset:0,

				fullWidth:"on",
				fullScreen: "on",
                fullScreenAlignForce:"on",
                

				spinner:"spinner0",
				
				stopLoop:"off",
				stopAfterLoops:-1,
				stopAtSlide:-1,
				onHoverStop: "on",

				shuffle:"on",
				
				autoHeight:"off",						
				forceFullWidth:"on",						
										
				hideThumbsOnMobile:"off",
				hideNavDelayOnMobile:1500,						
				hideBulletsOnMobile:"off",
				hideArrowsOnMobile:"off",
				hideThumbsUnderResolution:0,
				
				hideSliderAtLimit:0,
				hideCaptionAtLimit:0,
				hideAllCaptionAtLilmit:0,
				startWithSlide:0
			});
			
	};
});		
		