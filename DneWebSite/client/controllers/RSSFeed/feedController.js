(function () {
    angular.module('main')

    .controller('FeedsController', ['$scope', '$compile', '$http', 'storage', function ($scope, $compile, $http, storage) {
      $scope.isOrigin = function () {
          var url = window.location.href.substring(window.location.href.lastIndexOf('/') + 1);
          return window.parent.location.href.indexOf(url) !== -1;
      };

      //$scope.$watch('feeds', function (newValue, oldValue) {
      //    if (newValue) {
      //        storage.set('feeds', newValue);
      //    }
      //}, true);

      //if (!storage.get('feeds')) {
      //    $http.get('feeds.json').success(function (feeds) {
      //        $scope.feeds = feeds;
      //    });
      //}
      //else {
      //    $scope.feeds = storage.get('feeds');
        //}

      $scope.feeds = [
  {
      "id": 1,
      "title": "NRC News Releases",
      "url": "http://www.nrc.gov/public-involve/rss.cfm?feed=news",
      "count": 10
  },
  {
      "id": 2,
      "count": 10,
      "title": "NEI",
      "url": "http://www.nei.org/rss-feeds?feed=News"
  },
  {
      "id": 3,
      "title": "World Nuclear News",
      "url": "http://www.world-nuclear-news.org/rss.aspx?fid=790",
      "count": 10
  }
      ];
      
      
  }])
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
  .controller('FeedWidgetController', ['$scope', function ($scope) {
      $scope.toggleFeed = function () {
          $scope.collapsed = !$scope.collapsed;
      };

  }])
  .factory('storage', function () {
      return {
          set: function (name, obj) {
              localStorage[name] = angular.toJson(obj);
          },
          get: function (name) {
              return angular.fromJson(localStorage[name]);
          }
      };
  });

    
})();

function feedPostRender(element) {
        $(element).find('a').attr('target', '_blank');
    }
