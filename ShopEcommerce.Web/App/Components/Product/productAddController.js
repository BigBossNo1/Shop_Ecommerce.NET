(function (app) {
    app.controller('productAddController', productAddController);
    productAddController.$inject = ['$scope', '$state', 'apiServiceCommon', 'notificationService', 'commonService'];
    function productAddController($scope, $state, apiServiceCommon, notificationService, commonService) {
        $scope.product = {
            Status: false
        };

        $scope.parentCategory = [];

        $scope.AddProduct = AddProduct;

        $scope.autoGetSeoTitle = autoGetSeoTitle;
        $scope.ckeditorOptions = {
            language: 'vi',
            height: '200px'
        }
        function autoGetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        function AddProduct() {
            $scope.product.MoreImage = JSON.stringify($scope.moreImage);
            apiServiceCommon.post('api/product/add', $scope.product, function (result) {
                notificationService.displaySuccess('Thêm mới thành công sản phẩm ' + result.data.Name);
                $state.go('product');
            }, function (error) {
                notificationService.displayError('Thêm mới không công ' + $scope.product.Name);
            });
        }
        function loadParent() {
            apiServiceCommon.get('api/productcategory/getparentid', null, function (result) {
                $scope.parentCategory = result.data;
            }, function (error) {
                console.log('Load parent productcategory fail !');
            });
        }
        loadParent();

        $scope.ChooseImages = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                })
            }
            finder.popup();
        }

        $scope.moreImage = [];
        $scope.ChooseMoreImages = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImage.push(fileUrl);
                })
            }
            finder.popup();
        }
    }
})(angular.module('shop.product'));