(function () {
    angular.module("shop.product_category", ['shop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('product_category', {
                url: "/product_category",
                parent: 'base',
                templateUrl: "/App/Components/Product_Category/productCategoryListView.html",
                controller: "productCategoryListController"
            })
            .state('product_category_add', {
                url: "/product_category_add",
                parent: 'base',
                templateUrl: "/App/Components/Product_Category/productCategoryAddView.html",
                controller: "productCategoryAddController"
            })
            .state('product_category_edit', {
                url: "/product_category_edit/:id",
                parent: 'base',
                templateUrl: "/App/Components/Product_Category/productCategoryUpdateView.html",
                controller: "productCategoryUpdateController"
            });
    }
})();