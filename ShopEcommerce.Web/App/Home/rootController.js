////(function (app) {
////    app.controller('rootController', rootController);
////    rootController.$inject = ['$scope', '$location'];
////    function rootController($scope, $location) {
////        $scope.logout = function () {
////            $location.path('login')
////        }
////    }
////})(angular.module('shopEcommerce'));

(function (app) {
    app.controller('rootController', rootController);

    rootController.$inject = ['$state', 'authData', 'loginService', '$scope', 'authenticationService'];

    function rootController($state, authData, loginService, $scope, authenticationService) {
        $scope.logOut = function () {

            loginService.logOut();
            $state.go('login');
        }
        $scope.authentication = authData.authenticationData;

        authenticationService.validateRequest();
    }
})(angular.module('shopEcommerce'));