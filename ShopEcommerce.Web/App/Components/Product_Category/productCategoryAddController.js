(function (app) {
    app.controller("productCategoryAddController", productCategoryAddController);
    productCategoryAddController.$inject = ['$scope', 'apiServiceCommon', 'notificationService', '$state', 'commonService']
    // $state : Điều hướng
    // apiServiceCommon : các phương thức call api
    function productCategoryAddController($scope, apiServiceCommon, notificationService, $state, commonService) {
        $scope.productcategory = {
        }
        $scope.parentCategory = [];
        $scope.AddProductCategory = AddProductCategory;
        $scope.autoGetSeoTitle = autoGetSeoTitle;
        function autoGetSeoTitle() {
            $scope.productcategory.Alias = commonService.getSeoTitle($scope.productcategory.Name);
        }
        function AddProductCategory() {
            apiServiceCommon.post('api/productcategory/add', $scope.productcategory, function (result) {
                notificationService.displaySuccess('Thêm mới ' + result.data.Name + ' thành công');
                $state.go('product_category');
            }, function (error) {
                notificationService.displayError('Thêm mới ' + result.data.Name + ' không thành công');
            });
        }

        function loadParentID() {
            apiServiceCommon.get('api/productcategory/getparentid', null, function (result) {
                $scope.parentCategory = result.data;
            }, function (error) {
                console.log('Load Parent ProductCategory Fail');
            });
        }
        $scope.ChoseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.product.Image = fileUrl;
            }
            finder.popup();
        }
        loadParentID();
    }
})(angular.module('shop.product_category'));