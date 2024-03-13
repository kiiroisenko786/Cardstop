var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/order/getall'},
        "columns": [
            { data: 'id' },
            { data: 'name'},
            { data: 'phoneNumber' },
            { data: 'applicationUser.email' },
            { data: 'orderStatus' },
            { data: 'orderTotal' },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/admin/order/details?orderId=${data}" class="btn btn-primary mx-2" <i class="bi bi-pencil-square"></i> Edit</a>
                    </div>`
                },
                "width": "15%"
            }
        ]
    });
}