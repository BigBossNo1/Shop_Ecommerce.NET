(function (app) {
    app.controller('productCategoryListController', productCategoryListController);
    productCategoryListController.$inject = ['$scope', 'apiServiceCommon', 'notificationService', '$ngBootbox' , '$filter'];
    function productCategoryListController($scope, apiServiceCommon, notificationService, $ngBootbox, $filter) {
        $scope.listAllProductCategory = [];
        $scope.getListproductCategory = getListproductCategory;

        $scope.page = 0;
        $scope.pagesCount = 0;

        $scope.keyword = '';
        $scope.search = search;
        $scope.deleteProductCategory = deleteProductCategory;
        $scope.selectAll = selectAll;
        $scope.deleteMulti = deleteMulti;

        function deleteMulti() {
            var listID = [];
            $.each($scope.selected, function (i, item) {
                listID.push(item.ID);
            });
            var config = {
                params: {
                    checkProductCategory : JSON.stringify(listID)
                }
            }
            apiServiceCommon.del('api/productcategory/deletemulti', config, function (result) {
                notificationService.displaySuccess('Xóa thành công' + result.data + ' danh mục');
                search();
            }, function (error) {
                notificationService.displayError('Xóa không thành công ');
            });
        }

        $scope.isAll = false;
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.listAllProductCategory, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.listAllProductCategory, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }
         
        $scope.$watch("listAllProductCategory", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);


        function deleteProductCategory(id) {
            $ngBootbox.confirm('Bạn có chắc chắn muốn xóa !!').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiServiceCommon.del('api/productcategory/delete', config, function (result) {
                    notificationService.displaySuccess('Xóa thành công ' + result.data.Name);
                    search();
                }, function (error) {
                    notificationService.displayError('Xóa không thành công ');
                });
            });
        }

        function search() {
            getListproductCategory();
        }
        function getListproductCategory(page) {
            page = page || 0;
            var config = {
                params: {
                    keyWord : $scope.keyword,
                    page: page,
                    pageSize: 10
                }
            }
            apiServiceCommon.get('api/productcategory/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào tên ' + $scope.keyword);
                } else {
                    notificationService.displaySuccess('Tìm kiếm thành công ' + result.data.TotalCount + ' Bản ghi');
                }
                $scope.listAllProductCategory = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPage;
                $scope.totalCount = result.data.TotalCount;
            }, function (error) {
                console.log('Load List Product Category Fail !!')
            });
        }
        $scope.getListproductCategory();
    }
})(angular.module('shop.product_category'));