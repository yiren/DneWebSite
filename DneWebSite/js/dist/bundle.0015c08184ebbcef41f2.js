webpackJsonp([1,2],{

/***/ 10:
/***/ (function(module, exports) {

$(document).ready(function () {

    $('#newDoc').qtip({
        content: '<h4>英文(2007~迄今)</h4>',
        position: {
            my: 'left center',
            at: 'right center',
            target: $('#newDoc')
        },
        show: {
            effect: function (offset) {
                $(this).slideDown(100);
            }
        },
        style: {
            classes: 'qtip-green qtip-rounded'
        }
    });
    $('#oldDoc').qtip({
        content: '<ul class="list"><li><h4>中文(1998~迄今)</h4></li><li><h4>英文(1998~2007)</h4></li></ul>',
        position: {
            my: 'left top',
            at: 'right center',
            target: $('#oldDoc')
        },
        show: {
            effect: function (offset) {
                $(this).slideDown(100);
            }
        },
        style: {
            classes: 'qtip-green qtip-rounded'
        }
    });
});

/***/ }),

/***/ 19:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__animations_init_js__ = __webpack_require__(8);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__animations_init_js___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0__animations_init_js__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__parallax_init_js__ = __webpack_require__(9);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__parallax_init_js___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1__parallax_init_js__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__qTip2_js__ = __webpack_require__(10);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__qTip2_js___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_2__qTip2_js__);




/***/ }),

/***/ 8:
/***/ (function(module, exports) {

$(document).ready(function () {
	var delay = 0;
	// Animations
	//-----------------------------------------------
	if ($("[data-animation-effect]").length > 0 && !Modernizr.touch) {
		$("[data-animation-effect]").each(function () {
			var item = $(this),
			    animationEffect = item.attr("data-animation-effect");

			if (Modernizr.mq('only all and (min-width: 768px)') && Modernizr.csstransitions) {
				item.appear(function () {
					if (item.attr("data-effect-delay")) item.css("effect-delay", delay + "ms");
					setTimeout(function () {
						item.addClass('animated object-visible ' + animationEffect);
					}, item.attr("data-effect-delay"));
				}, { accX: 0, accY: -130 });
			} else {
				item.addClass('object-visible');
			}
		});
	};

	// Animated Progress Bars
	//-----------------------------------------------
	if ($("[data-animate-width]").length > 0) {
		$("[data-animate-width]").each(function () {
			$(this).appear(function () {
				$(this).animate({
					width: $(this).attr("data-animate-width")
				}, 800);
			}, { accX: 0, accY: -100 });
		});
	};

	// Offcanvas side navbar
	//-----------------------------------------------

	if ($("#offcanvas").length > 0) {
		$('#offcanvas').offcanvas({
			disableScrolling: false,
			toggle: false
		});
	};

	if ($("#offcanvas").length > 0) {
		$('#offcanvas [data-toggle=dropdown]').on('click', function (event) {
			// Avoid following the href location when clicking
			event.preventDefault();
			// Avoid having the menu to close when clicking
			event.stopPropagation();
			// close all the siblings
			$(this).parent().siblings().removeClass('open');
			// close all the submenus of siblings
			$(this).parent().siblings().find('[data-toggle=dropdown]').parent().removeClass('open');
			// opening the one you clicked on
			$(this).parent().toggleClass('open');
		});
	};
});

/***/ }),

/***/ 9:
/***/ (function(module, exports) {

$(document).ready(function () {
	// Parallax section
	//-----------------------------------------------
	if ($(".parallax").length > 0 && !Modernizr.touch) {
		$(".parallax").parallax("50%", 0.2, false);
	};

	if ($(".parallax-2").length > 0 && !Modernizr.touch) {
		$(".parallax-2").parallax("50%", 0.2, false);
	};
	if ($(".parallax-text").length > 0 && !Modernizr.touch) {
		$(window).scroll(function () {
			//Get the scoll position of the page
			scrollPos = $(this).scrollTop();

			//Scroll and fade out the banner text
			$('.parallax-text').css({
				'opacity': 1 - scrollPos / 400
			});
		});
	};
});

/***/ })

},[19]);