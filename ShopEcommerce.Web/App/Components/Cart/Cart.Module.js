(function () {
    angular.module("shop.cart", ['shop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('order', {
                url: "/order",
                parent: 'base',
                templateUrl: "/App/Components/Cart/CartListView.html",
                controller: "cartListController"
            })
            .state('order_confirm', {
                url: "/order_confirm",
                parent: 'base',
                templateUrl: "/App/Components/Cart/ListCartConfirmView.html",
                controller: "ListCartConfirmController"
            })
            .state('order_detail', {
                url: "/order_detail/:id",
                parent: 'base',
                templateUrl: "/App/Components/Cart/CartDetailView.html",
                controller: "cartDetailController"
            });
    }
})();