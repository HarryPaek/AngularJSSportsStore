'use strict';

var app = angular.module('sportsStore');
app.constant("productPerPage", 4);

app.controller('productListCtrl', ['$scope', '$filter', 'productPerPage', function ($scope, $filter, productPerPage) {
    var selectedCategory = null;

    $scope.selectedPage = 1;
    $scope.pageSize = productPerPage;

    $scope.selectCategory = function (newCategory) {
        selectedCategory = newCategory;
        $scope.selectedPage = 1;
    }

    $scope.selectPage = function (newPage) {
        $scope.selectedPage = newPage;
    }

    $scope.categoryFilterFn = function (product) {
        return selectedCategory == null || product.Category == selectedCategory;
    }

    $scope.isCategorySelected = function (category) {
        return selectedCategory == category;
    }

    $scope.isPageSelected = function (page) {
        return $scope.selectedPage == page;
    }
}]);

