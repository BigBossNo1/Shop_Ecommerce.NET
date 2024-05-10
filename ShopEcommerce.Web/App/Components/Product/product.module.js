(function () {
    angular.module("shop.product", ['shop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('product', {
                url: "/product",
                parent: 'base',
                templateUrl: "/App/Components/Product/productListView.html",
                controller: "productListController"
            })
            .state('product_add', {
                url: "/product_add",
                parent: 'base',
                templateUrl: "/App/Components/Product/productAddView.html",
                controller: "productAddController"
            })
            .state('product_edit', {
                url: "/product_edit/:id",
                parent: 'base',
                templateUrl: "/App/Components/Product/productUpdateView.html",
                controller: "productUpdateController"
            });
    }
})();