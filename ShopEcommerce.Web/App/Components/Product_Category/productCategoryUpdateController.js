(function (app) {
    app.controller("productCategoryUpdateController", productCategoryUpdateController);
    productCategoryUpdateController.$inject = ['$scope', 'apiServiceCommon', 'notificationService', '$state', '$stateParams', 'commonService']
    // $state : Điều hướng
    // apiServiceCommon : các phương thức call api
    function productCategoryUpdateController($scope, apiServiceCommon, notificationService, $state, $stateParams, commonService) {
        $scope.productcategory = {
        }
        $scope.parentCategory = [];
        $scope.UpdateProductCategory = UpdateProductCategory;
        $scope.getSeoTitle = getSeoTitle;

        function getSeoTitle() {
            $scope.productcategory.Alias = commonService.getSeoTitle($scope.productcategory.Name);
        }
        function loadProductCategoryDetail() {
            apiServiceCommon.get('api/productcategory/getidinfor/' + $stateParams.id, null, function (result) {
                $scope.productcategory = result.data;
            }, function (error) {
                console.log('Load detal fail');
            });
        }

        function UpdateProductCategory() {
            apiServiceCommon.put('api/productcategory/update', $scope.productcategory, function (result) {
                notificationService.displaySuccess('Cập nhật ' + result.data.Name + ' thành công');
                $state.go('product_category');
            }, function (error) {
                notificationService.displayError('Cập nhật ' + $scope.productcategory.Name + ' không thành công');
            });
        }

        function loadParentID() {
            apiServiceCommon.get('api/productcategory/getparentid', null, function (result) {
                $scope.parentCategory = result.data;
            }, function (error) {
                console.log('Load Parent ProductCategory Fail');
            });
        }
        loadParentID();
        loadProductCategoryDetail();
    }
})(angular.module('shop.product_category'));