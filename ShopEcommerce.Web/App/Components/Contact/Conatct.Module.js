(function () {
    angular.module("shop.contact", ['shop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('contact', {
                url: "/contact",
                parent: 'base',
                templateUrl: "/App/Components/Contact/ContactListView.html",
                controller: "contactListController"
            })
            .state('contact_detail', {
                url: "/contact_detail/:id",
                parent: 'base',
                templateUrl: "/App/Components/Contact/ContactDetailView.html",
                controller: "contactDetailController"
            })
            .state('contact_confirm', {
                url: "/contact_confirm",
                parent: 'base',
                templateUrl: "/App/Components/Contact/ContactConfirmView.html",
                controller: "contactConfirmController"
            });
    }
})();