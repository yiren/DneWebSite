(function () {
    angular.module('main')

    .controller('FeedsController', ['$scope', '$compile', '$http', function ($scope, $compile, $http, storage) {
      $scope.isOrigin = function () {
          var url = window.location.href.substring(window.location.href.lastIndexOf('/') + 1);
          return window.parent.location.href.indexOf(url) !== -1;
      };

      
      //RSS 來源網址及顯示名稱等參數設定
      $scope.feeds = [
  {
      "id": 1,
      "title": "NRC News Releases",
      "url": "http://www.nrc.gov/public-involve/rss.cfm?feed=news",
      //顯示幾筆
      "count": 5
  },
  {
      "id": 2,
      "count": 5,
      "title": "Nuclear Energy Institute",
      "url": "http://www.nei.org/rss-feeds?feed=News"
  },
  {
      "id": 3,
      "title": "World Nuclear News",
      "url": "http://www.world-nuclear-news.org/rss.aspx?fid=790",
      "count": 5
  }
      ];
      
      
    }])
   //預設，沒事別修改
  .directive('feedWidget', ['$compile', function ($compile) {
      return {
          restrict: 'A',
          controller: ['$scope', '$element', '$attrs', '$timeout', function ($scope, $element) {
              var feed = $scope.feed;
              feed.summary = true;
              var feedHTML = "<feed url='" + feed.url + "' count='" + feed.count + "' summary=" + (feed.summary ? 'true' : 'false') + " post-render='feedPostRender'/>";
              $element.append($compile(feedHTML)($scope));
          }]
      };
  }])
  //預設，沒事別修改
  .controller('FeedWidgetController', ['$scope', function ($scope) {
      $scope.toggleFeed = function () {
          $scope.collapsed = !$scope.collapsed;
      };

  }])
  

    
})();

function feedPostRender(element) {
        $(element).find('a').attr('target', '_blank');
    }
