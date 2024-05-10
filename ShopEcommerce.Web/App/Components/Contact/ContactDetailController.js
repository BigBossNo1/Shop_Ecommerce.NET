(function (app) {
    app.controller('contactDetailController', contactDetailController);
    contactDetailController.$inject = ['$scope', '$state', 'apiServiceCommon', 'notificationService', '$stateParams', 'commonService'];

    function contactDetailController($scope, $state, apiServiceCommon, notificationService, $stateParams, commonService) {
        $scope.contactDetal = {};
        $scope.confirmInfor = confirmInfor;

        function confirmInfor() {
            apiServiceCommon.put('api/contact/update', $scope.contactDetal , function (result) {
                $scope.contactDetal = result.data;
                notificationService.displaySuccess("Thông tin đã được Xác nhận thành công");
                $state.go('contact_confirm');
            }, function (error) {
                console.log('Xác nhận thông tin không thành công!', error);
            });
        }

        function contacttDetails() {
            var config = {
                params: { id: $stateParams.id }
            };

            apiServiceCommon.get('api/contact/detail', config, function (result) {
                $scope.contactDetal = result.data;
            }, function (error) {
                console.log('Load details product fail !');
            });
        }
        contacttDetails();
    }
})(angular.module('shop.contact'));