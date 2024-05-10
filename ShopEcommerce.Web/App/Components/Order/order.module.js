(function () {
    angular.module("shop.order", ['shop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('listAllOrder', {
                url: "/listAllOrder",
                parent: 'base',
                templateUrl: "/App/Components/Order/getAllOrderView.html",
                controller: "getAllOrderController"
            })
            .state('listOrderByStatus', {
                url: "/orderByStatuss",
                parent: 'base',
                templateUrl: "/App/Components/Order/getListOrderByStatussView.html",
                controller: "getListOrderByStatussController"
            });
    }
})();