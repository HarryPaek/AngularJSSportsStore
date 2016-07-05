'use strict';

var app = angular.module('sportsStore');

app.controller('sportsStoreCtrl', ['$scope', '$http', function($scope, $http) {
    $scope.data = {};

    $http.get('/api/Products')
         .success(function (response) {
             $scope.data.products = response;
         })
         .error(function (error) {
             $scope.data.error = error;
         });
}]);
