(function (app) {
    app.controller('contactConfirmController', contactConfirmController);
    contactConfirmController.$inject = ['$scope', 'apiServiceCommon', 'notificationService', '$ngBootbox']
    function contactConfirmController($scope, apiServiceCommon, notificationService, $ngBootbox) {
        $scope.listAllContact = [];
        $scope.getListAll = getListAll;
        //$scope.deleteContact = deleteContact;

        //function deleteContact(id) {
        //    $ngBootbox.confirm('Bạn có chắc chắn muốn xóa').then(function () {
        //        var config = {
        //            params: {
        //                id: id
        //            }
        //        }
        //        apiServiceCommon.del('/api/contact/delete', config, function (result) {
        //            $scope.listAllContact = result.data;
        //            notificationService.displayError("Xóa thành công " + $scope.listAllContact.Name);
        //        }, function (error) {
        //            console.log('Delete contact fail');
        //        });
        //    });
        //}
        //
        $scope.deleteContact = deleteContact;

        function deleteContact(id) {
            $ngBootbox.confirm('Bạn có chắc chắn muốn xóa').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiServiceCommon.del('api/contact/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công ');
                }, function () {
                    notificationService.displayWarning('Xóa không thành công ');
                });
            });
        }
        //

        function getListAll() {
            apiServiceCommon.get('/api/contact/getTrue', null, function (result) {
                $scope.listAllContact = result.data;
            }, function (error) {
                console.log('Load list prodcut fail');
            });
        }
        $scope.getListAll();
    }
})(angular.module('shop.contact'));