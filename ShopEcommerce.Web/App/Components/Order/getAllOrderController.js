(function (app) {
    app.controller('getAllOrderController', getAllOrderController);
    getAllOrderController.$inject = ['$scope', 'apiServiceCommon', 'notificationService', '$ngBootbox']
    function getAllOrderController($scope, apiServiceCommon, notificationService, $ngBootbox) {
        $scope.listAllOrder = [];
        $scope.getListAll = getListAll;

        function getListAll() {
            apiServiceCommon.get('api/order/getall', null , function (result) {
                notificationService.displaySuccess('Tìm kiếm thành công danh sách đặt hàng');
                $scope.listAllOrder = result.data;
            }, function (error) {
                console.log('Load list order fail');
            });
        }
        $scope.getListAll();
    }
})(angular.module('shop.order'));