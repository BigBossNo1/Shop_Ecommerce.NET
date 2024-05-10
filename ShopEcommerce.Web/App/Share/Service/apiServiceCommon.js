/// <reference path="../../../bower_install/angular/angular.js" />
(function (app) {
    app.service('apiServiceCommon', apiServiceCommon);
    apiServiceCommon.$inject = ['$http', 'notificationService', 'authenticationService']
    function apiServiceCommon($http, notificationService, authenticationService) {
        return {
            get: get,
            post: post,
            put: put,
            del : del
        }
        // them moi
        function post(url, data, success, fail) {
            authenticationService.setHeader();
            $http.post(url, data).then(function (result) {
                success(result);
            }, function (error) {
                if (error.status === 401) {
                    notificationService.displayError('Yêu cầu cần phải đăng nhập');
                } else if (error.status != null) {
                    fail(error);
                }
            });
        }
        // update
        function put(url, data, success, fail) {
            authenticationService.setHeader();
            $http.put(url, data).then(function (result) {
                success(result);
            }, function (error) {
                if (error.status === 401) {
                    notificationService.displayError('Yêu cầu cần phải đăng nhập');
                } else if (error.status != null) {
                    fail(error);
                }
            });
        }
        // lay ra
        function get(url, parameter, success, fail) {
            authenticationService.setHeader();
            $http.get(url, parameter).then(function (result) {
                success(result);
            }, function (error) {
                fail(error);
            });
        }
        // xoa
        function del(url, data, success, fail) {
            authenticationService.setHeader();
            $http.delete(url, data).then(function (result) {
                success(result);
            }, function (error) {
                if (error.status === 401) {
                    notificationService.displayError('Yêu cầu cần phải đăng nhập');
                } else if (error.status != null) {
                    fail(error);
                }
            });
        }
    }
})(angular.module('shop.common'));