/// <reference path="../bower_install/angular/angular.js" />
(function () {
    angular.module("shopEcommerce",
        [    'shop.product'
            , 'shop.common'
            , 'shop.product_category'
            , 'shop.contact'
            , 'shop.cart'
            , 'shop.order'
        ])
        .config(config)
        .config(configAuthentication);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('base', {
                url: "",
                templateUrl: "/App/Share/View/base.html",
                abstract: true,
            })
            .state('home', {
                url: "/admin",
                parent: 'base',
                templateUrl: "/App/Home/HomeView.html",
                controller: "HomeController"
            })
            .state('login', {
                url: "/login",
                templateUrl: "/App/Components/Login/LoginView.html",
                controller: "LoginController"
            });
        $urlRouterProvider.otherwise('/login');
    }

    function configAuthentication($httpProvider) {
        $httpProvider.interceptors.push(function ($q, $location) {
            return {
                request: function (config) {
                    return config;
                },
                requestError: function (rejection) {
                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status == "401") {
                        $location.path('/login');
                    }
                    //the same response/modified/or a new one need to be returned.
                    return response;
                },
                responseError: function (rejection) {
                    if (rejection.status == "401") {
                        $location.path('/login');
                    }
                    return $q.reject(rejection);
                }
            };
        });
    }
})();