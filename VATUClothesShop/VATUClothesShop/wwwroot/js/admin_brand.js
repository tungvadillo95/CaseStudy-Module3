var brands = brands || {};
brands.delete = function (id) {
    bootbox.confirm({
        title: "Cảnh báo",
        message: "Bạn có muốn xóa thương hiệu này không?",
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
                    url: `/Admin/DeleteBrand/${id}`,
                    method: "GET",
                    contentType: 'json',
                    success: function (data) {
                        if (data > 0) {
                            window.location.href = "/Admin/ShowBrand";
                        }
                    }
                });
            }
        }
    });
}

$(document).ready(function () {
    $("#tbBrands").dataTable(
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