var cart = {
    init: function () {
        $(document).ready(function () {
            cart.resEvents();
        });
    },

    resEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/home";
        });

        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.quantity-input');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    ProductID: $(item).data('id'),
                    Quantity: $(this).val(),
                    Product: {
                        ID: $(item).data('id')
                    }
                });
            });
            $.ajax({
                url: '/Cart/Update',
                data: { cartData: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = '/cart-infor';
                    }
                }
            });
        });
        $('#btnDeleteProduct').off('click').on('click', function () {
            var productIdToDelete = $(this).data('id'); // Lấy productId từ nút Xóa
            $.ajax({
                url: '/Cart/DeleteById',
                data: { productId: productIdToDelete },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = '/cart-infor';
                    }
                }
            });
        });
        document.getElementById('payment').addEventListener('click', function () {
            // Lấy giá trị tổng cộng từ thẻ span
            var totalPriceElement = document.getElementById('totalPrice');
            var totalPrice = parseFloat(totalPriceElement.textContent.replace(/\D/g, ''));

            // Chuyển hướng sang trang thanh toán và truyền số tiền đã đặt hàng
            window.location.href = '/payment?amount=' + totalPrice;
        });
    }
};

cart.init();


//// Gọi hàm init khi trang được load
//window.onload = function () {
//    cart.init();
//};