var carts = carts || {};
carts.delete = function (id) {
    bootbox.confirm({
        title: "Cảnh báo",
        message: "Bạn có muốn xóa sản phẩm này khỏi giỏ hàng không?",
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> Không'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Có'
            }
        },
        callback: function (result) {
            if (result) {
                $.ajax({
                    url: `/ShoppingCart/DeleteCart/${id}`,
                    method: "GET",
                    contentType: 'json',
                    success: function (data) {
                        if (data > 0) {
                            window.location.href = "/ShoppingCart/ListCart";
                        }
                    }
                });
            }
        }
    });
}

$(document).ready(function () {
    $("#tbCarts").dataTable(
        {
            "columnDefs": [
                {
                    "targets": 7,
                    "orderable": false,
                    "searchable": false
                },
                {
                    "targets": 6,
                    "orderable": false,
                    "searchable": false
                }
            ]
        }
    );
});