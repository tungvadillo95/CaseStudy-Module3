var orders = orders || {};
orders.delete = function (id) {
    bootbox.confirm({
        title: "Cảnh báo",
        message: "Bạn có muốn xóa đơn hàng hàng này không?",
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
                    url: `/Admin/DeleteOrder/${id}`,
                    method: "GET",
                    contentType: 'json',
                    success: function (data) {
                        if (data > 0) {
                            window.location.href = "/Admin/ShowOrders";
                        }
                    }
                });
            }
        }
    });
}

$(document).ready(function () {
    $("#tbOrders").dataTable(
        {
            "columnDefs": [
                {
                    "targets": 4,
                    "orderable": false,
                    "searchable": false
                }
            ]
        }
    );
});