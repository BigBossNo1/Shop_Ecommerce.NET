(function (app) {
    app.controller('contactListController', contactListController);
    contactListController.$inject = ['$scope', 'apiServiceCommon', 'notificationService', '$ngBootbox']
    function contactListController($scope, apiServiceCommon, notificationService, $ngBootbox) {
        $scope.listAllContact = [];
        $scope.getListAll = getListAll;

        function getListAll() {
            apiServiceCommon.get('/api/contact/getFalse', null, function (result) {
                $scope.listAllContact = result.data;
            }, function (error) {
                console.log('Load list prodcut fail');
            });
        }
        $scope.getListAll();
    }
})(angular.module('shop.contact'));