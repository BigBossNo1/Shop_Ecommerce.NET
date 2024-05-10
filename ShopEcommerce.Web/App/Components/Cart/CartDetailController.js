(function (app) {
    app.controller('cartDetailController', cartDetailController);
    cartDetailController.$inject = ['$scope', '$state', 'apiServiceCommon', 'notificationService', '$stateParams', 'commonService'];

    function cartDetailController($scope, $state, apiServiceCommon, notificationService, $stateParams, commonService) {
        $scope.cartDetal = {};
        $scope.informationCustomer = '';
        $scope.updateStatus = updateStatus;

        function cartDetails() {
            var config = {
                params: { id: $stateParams.id }
            };

            apiServiceCommon.get('/api/cart/getdetail', config, function (result) {
                $scope.cartDetal = result.data;
            }, function (error) {
                console.log('Load cart detail fail !');
            });
        }
        cartDetails();
        // information user
        function informationCustomer() {
            var config = {
                params: { id: $stateParams.id }
            };

            apiServiceCommon.get('/api/cart/getInformationCustomer', config, function (result) {
                $scope.informationCustomer = result.data;
            }, function (error) {
                console.log('Load cart detail fail !');
            });
        }
        informationCustomer();
        // update status
        function updateStatus() {
            var config = {
                params: { id: $stateParams.id }
            };

            apiServiceCommon.get('/api/cart/updateStatus', config, function (result) {
                notificationService.displaySuccess('Xác nhận thành công đơn hàng !!');
            }, function (error) {
                console.log(' Confirm order fail !');
            });
        }
        //
        $scope.confirmOrder = function (event) {
            event.preventDefault(); // Ngăn chặn hành vi mặc định của thẻ <a>
            updateStatus(); // Gọi hàm updateStatus()
        };

    }
})(angular.module('shop.cart'));
