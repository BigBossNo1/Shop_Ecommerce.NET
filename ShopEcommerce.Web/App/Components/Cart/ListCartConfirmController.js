(function (app) {
    app.controller('ListCartConfirmController', ListCartConfirmController);
    ListCartConfirmController.$inject = ['$scope', 'apiServiceCommon']
    function ListCartConfirmController($scope, apiServiceCommon) {
        $scope.listAllOrder = [];
        $scope.getListAll = getListAll;

        function getListAll() {
            var config = {
                params: { status: false } // Truyền tham số status = true
            };
            apiServiceCommon.get('/api/cart/getall', config, function (result) {
                $scope.listAllOrder = result.data;
            }, function (error) {
                console.log('Load list order fail');
            });
        }

        $scope.getListAll();

    }
})(angular.module('shop.cart'));