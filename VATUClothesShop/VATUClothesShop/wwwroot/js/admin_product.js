var products = products || {};
products.delete = function (id) {
    bootbox.confirm({
        title: "Cảnh báo",
        message: "Bạn có muốn xóa sản phẩm này không?",
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
                    url: `/Product/Delete/${id}`,
                    method: "GET",
                    contentType: 'json',
                    success: function (data) {
                        if (data > 0) {
                            window.location.href = "/Admin/Index";
                        }
                    }
                });
            }
        }
    });
}

$(document).ready(function () {
    $("#tbProducts").dataTable(
        {
            "columnDefs": [
                {
                    "targets": 4,
                    "orderable": false,
                    "searchable": false
                },
                {
                    "targets": 5,
                    "orderable": false,
                    "searchable": false
                },
                {
                    "targets": 6,
                    "orderable": false,
                    "searchable": false
                },
                {
                    "targets": 7,
                    "orderable": false,
                    "searchable": false
                }
            ]
        }
    );
});