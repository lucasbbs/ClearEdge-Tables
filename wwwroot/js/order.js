var dataTable;

$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("inprocess")) {
        loadDataTable("inprocess");
    }
    else {
        if (url.includes("completed")) {
            loadDataTable("completed");
        }
        else {
            if (url.includes("pending")) {
                loadDataTable("pending");
            }
            else {
                if (url.includes("approved")) {
                    loadDataTable("approved");
                }
                else {
                    loadDataTable("all");
                }
            }
        }
    }
});

function loadDataTable(status) {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            url: '/admin/order/getall?status=' + status },
        "columns": [
            { data: 'id', "width": "5%" },
            { data: 'name', "width": "25%" },
            { data: 'phoneNumber', "width": "20%" },
            { data: 'customer.email', "width": "20%" },
            {
                data: 'status',
                "width": "10%",
                'render': function (data, type, full, meta) {
                    switch (data) {
                        case "Pending":
                            return '<span class="badge text-bg-warning">Pending</span>'
                        case "Shipped":
                            return '<span class="badge text-bg-success">Shipped</span>'
                        case "Cancelled":
                            return '<span class="badge text-bg-danger">Cancelled</span>'
                        case "Approved":
                            return '<span class="badge text-bg-info">Approved</span>'
                        case "Processing":
                            return '<span class="badge text-bg-dark">Processing</span>'
                        default:
                            return data
                            break;
                    }
                }
            },
            {
                data: 'total_amount',
                "width": "10%",
                'render': function (data, type, full, meta) {
                    return new Intl.NumberFormat('en-US', {
                        style: 'currency',
                        currency: 'CAD',
                    }).format(data)
                }
            },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a href="/admin/order/details?orderId=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i></a>               
                    
                    </div>`
                },
                "width": "10%"
            }
        ]
    });
}