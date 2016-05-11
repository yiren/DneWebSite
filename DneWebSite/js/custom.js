/* Theme Name:iDea - Clean & Powerful Bootstrap Theme
 * Author:HtmlCoder
 * Author URI:http://www.htmlcoder.me
 * Author e-mail:htmlcoder.me@gmail.com
 * Version: 1.3
 * Created:October 2014
 * License URI:http://support.wrapbootstrap.com/
 * File Description: Place here your custom scripts
 */

    //Inspired by :
//http://blog.legomushroom.com/2014/03/defining-advanced-animation-path/
//https://dribbble.com/shots/921928-Playing-With-Science


(function($){
  $('[class^="circle-"]').animate({opacity:1},500);
 //get the animation path node
var $path = $('.atom-1'), path = $path[0];
var $path2 = $('.atom-2'), path2 = $path2[0];
var $path3 = $('.atom-3'), path3 = $path3[0];
 //get the animation object node
var $obj = $('.circle-1');
var $obj2 = $('.circle-2');
var $obj3 = $('.circle-3');

// get path's length
var pathLength = path.getTotalLength();
var pathLength2 = path2.getTotalLength();
var pathLength3 = path3.getTotalLength();

 //create new tween by initializing TWEEN.Tween object from 0 
var tween = new TWEEN.Tween({ length: 0  })
  //   to path length
   //  in 2000 milliseconds
    .to({ length: pathLength }, 1500)
  //   on update callback fires on every tick
    .onUpdate(function(){
      var point = path.getPointAtLength(this.length);
      $obj.css({
        'transform': 'translate('+ point.x + 'px,'+ point.y +'px)'
      });
    }).repeat(999999999).start();

var tween2 = new TWEEN.Tween({ length: 0  })
 //to path length
 //in 2000 milliseconds
.to({ length: pathLength2 }, 1500)
// on update callback fires on every tick
.onUpdate(function(){
  var point2 = path2.getPointAtLength(this.length);
  $obj2.css({
    'transform': 'translate('+ point2.x + 'px,'+ point2.y +'px)'
  });
}).repeat(999999999).start();

var tween3 = new TWEEN.Tween({ length: 0  })
 //to path length
 //in 2000 milliseconds
.to({ length: pathLength3 }, 1500)
// on update callback fires on every tick
.onUpdate(function(){
  var point3 = path3.getPointAtLength(this.length);
  $obj3.css({
    'transform': 'translate('+ point3.x + 'px,'+ point3.y +'px)'
  });
}).repeat(999999999).start();



 //animate loop
animate = function(){
  requestAnimationFrame(animate)
  TWEEN.update()
}

//start the animation loop
animate()
  }(jQuery));