'use strict';

var app = angular.module('sportsStore');

app.controller('sportsStoreCtrl', ['$scope', '$http', function($scope, $http) {
    $scope.data = {};
    $scope.paging = { itemsPerPage: 4, maxSize: 5 };

    $http.get('/api/Products')
         .success(function (response) {
             $scope.data.products = response.Items;
             $scope.paging.currentPage = response.Page;
             $scope.paging.totalPages = response.TotalPages;
             $scope.paging.currentCount = response.Count;
             $scope.paging.totalCount = response.TotalCount;
         })
         .error(function (error) {
             $scope.data.error = error;
         });
}]);
