(function (app) {
    app.filter('statusFilter', statusFilter);
    function statusFilter() {
        return function (input) {
            if (input == true) {
                return 'Còn hàng'
            } else {
                return 'Hết hàng'
            }
        }
    }
})(angular.module('shop.common'));