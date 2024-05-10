(function (app) {
    app.controller('productUpdateController', productUpdateController);
    productUpdateController.$inject = ['$scope', '$state', 'apiServiceCommon', 'notificationService', '$stateParams', 'commonService'];
    function productUpdateController($scope, $state, apiServiceCommon, notificationService, $stateParams, commonService) {
        $scope.product = {
            Status: false
        };

        $scope.parentCategory = [];
        $scope.moreImage = [];

        $scope.UpdateProduct = UpdateProduct;
        $scope.autoGetSeoTitle = autoGetSeoTitle;
        function autoGetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        } 
        function productDetails() {
            apiServiceCommon.get('api/product/getinfordetails/' + $stateParams.id, null, function (result) {
                $scope.product = result.data;
                $scope.moreImage = JSON.parse($scope.product.MoreImage);
            }, function (error) {
                console.log('Load details product fail !');
            });
        }
        function UpdateProduct() {
            $scope.product.MoreImage = JSON.stringify($scope.moreImage);
            apiServiceCommon.put('api/product/update', $scope.product, function (result) {
                notificationService.displaySuccess('Cập nhật thành công sản phẩm ' + $scope.product.Name);
                $state.go('product');
            }, function (error) {
                notificationService.displayError('Cập nhật không thành công ' + $scope.product.Name);
            });
        }
        function loadParent() {
            apiServiceCommon.get('api/productcategory/getparentid', null, function (result) {
                $scope.parentCategory = result.data;
            }, function (error) {
                console.log('Load parent productcategory fail !');
            });
        }
        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                })
            }
            finder.popup();
        }
        $scope.ChooseMoreImages = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImage.push(fileUrl);
                })
            }
            finder.popup();
        }
        loadParent();
        productDetails();
    }
})(angular.module('shop.product'));