$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall'},
        "columns": [
            { data: 'name' },
            { data: 'listPrice' },
            { data: 'category.name' }
        ]
    });
}

