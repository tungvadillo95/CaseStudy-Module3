var categories = categories || {};
categories.delete = function (id) {
    bootbox.confirm({
        title: "Cảnh báo",
        message: "Bạn có muốn xóa loại hàng này không?",
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
                    url: `/Admin/DeleteCatergory/${id}`,
                    method: "GET",
                    contentType: 'json',
                    success: function (data) {
                        if (data > 0) {
                            window.location.href = "/Admin/ShowCatergories";
                        }
                    }
                });
            }
        }
    });
}

$(document).ready(function () {
    $("#tbCategories").dataTable(
        {
            "columnDefs": [
                {
                    "targets": 2,
                    "orderable": false,
                    "searchable": false
                }
            ]
        }
    );
});