﻿'use strict';

var customFilters = angular.module('customFilters', []);

customFilters.filter('unique', [function () {
    return function (data, propertyName) {
        if (angular.isArray(data) && angular.isString(propertyName)) {
            var results = [];
            var keys = {};

            for (var i = 0; i < data.length; i++) {
                var val = data[i][propertyName];
                if (angular.isUndefined(keys[val])) {
                    keys[val] = true;
                    results.push(val);
                }
            }

            return results;
        }
        else {
            return data;
        }
    }
}]);

customFilters.filter('range', ['$filter', function ($filter) {
    return function (data, page, size) {
        if (angular.isArray(data) && angular.isNumber(page) && angular.isNumber(size)) {
            var start_index = (page - 1) * size;
            if (data.length < start_index) {
                return [];
            }
            else {
                return $filter("limitTo")(data.splice(start_index), size);  //Refer to https://jsfiddle.net/bdLbgp4q/
            }
        }
        else {
            return data;
        }
    }
}]);

customFilters.filter('pageCount', [function () {
    return function (data, size) {
        if (angular.isArray(data) && angular.isNumber(size)) {
            var result = [];

            for (var i = 0; i < Math.ceil(data.length / size) ; i++) {
                result.push(i)
            }

            return result;
        }
        else {
            return data;
        }
    }
}]);

