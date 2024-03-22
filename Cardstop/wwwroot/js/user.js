var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/user/getall' },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "email", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            { "data": "company.name", "width": "15%" },
            { "data": "role", "width": "15%" },
            {
                data: { id: "id", lockoutEnd: "lockoutEnd" },
                "render": function (data) {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();

                    if (lockout > today) {
                        return `
                        <div class="text-center">
                            <a onclick=LockUnlock('${data.id}') class="btn btn-danger text-white" style="cursor:pointer; width:152px; font-size:13px;">
                                <i class="bi bi-lock-fill"></i> Locked
                            </a>
                            <a class="btn btn-primary text-white" style="cursor:pointer; width:152px; font-size:13px; white-space:nowrap; padding-left: 5px; padding-right: 5px;">
                                <i class="bi bi-pencil-square"></i> Permissions
                            </a>
                        </div>`
                    }
                    else {
                        return `
                        <div class="text-center">
                            <a onclick=LockUnlock('${data.id}') class="btn btn-success text-white" style="cursor:pointer; width:152px; font-size:13px;">
                                <i class="bi bi-lock-fill"></i> Unlocked
                            </a>
                            <a class="btn btn-primary text-white" style="cursor:pointer; width:152px; font-size:13px; white-space:nowrap; padding-left: 5px; padding-right: 5px;">
                                <i class="bi bi-pencil-square"></i> Permissions
                            </a>
                        </div>`
                    }


                },
                "width": "25%"
            }
        ]
    });
}


function LockUnlock(id) {
    $.ajax({
        type: "POST",
        url: '/Admin/User/LockUnlock',
        data: JSON.stringify(id),
        contentType: "application/json",
        success: function (data) {
            if (data.success) {
                toastr.success(data.message);
                dataTable.ajax.reload();
            }
        }
    });
}