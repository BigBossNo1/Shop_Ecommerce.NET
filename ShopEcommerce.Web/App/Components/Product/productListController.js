(function (app) {
    app.controller('productListController', productListController);
    productListController.$inject = ['$scope', 'apiServiceCommon', 'notificationService', '$ngBootbox']
    function productListController($scope, apiServiceCommon, notificationService, $ngBootbox) {
        $scope.listAllProduct = [];
        $scope.getListAll = getListAll;

        $scope.page = 0;
        $scope.pagesCount = 0;

        $scope.keyword = '';
        $scope.search = search;
        $scope.deleteProduct = deleteProduct;

        function deleteProduct(id) {
            $ngBootbox.confirm('Bạn có chắc chắn muốn xóa').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiServiceCommon.del('api/product/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công ');
                    search();
                }, function () {
                    notificationService.displayWarning('Xóa không thành công ');
                });
            });
        }

        function search() {
            getListAll();
        }

        function getListAll(page) {
            page = page || 0;
            var config = {
                params: {
                    keyWord: $scope.keyword,
                    page: page,
                    pageSize: 10
                }
            }
            apiServiceCommon.get('api/product/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào tên ' + $scope.keyword);
                } else {
                    notificationService.displaySuccess('Tìm kiếm thành công ' + result.data.TotalCount + ' Bản ghi');
                }
                $scope.listAllProduct = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPage;
                $scope.totalCount = result.data.TotalCount;
            }, function (error) {
                console.log('Load list prodcut fail');
            });
        }
        $scope.getListAll();
        //
    }
})(angular.module('shop.product'));