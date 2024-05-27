
//$(document).ready(function () {
//    loadDataTable();
//});

//function loadDataTable() {
//    dataTable = $('#tblData').DataTable({
//        "ajax": { url: '/admin/product/getall' },
//        "columns": [
//            { data: 'id', "width": "1%" },
//            { data: 'isbn', "width": "15%" },
//            { data: 'title', "width": "20%" },
//            { data: 'author', "width": "15%" },
//            { data: 'price', "width": "5%" },
//            { data: 'category.name', "width": "10%" },
//            {data: 'id',"render": function (data) {
//                return `<div class="w-75 btn-group" role="group">
//                     <a href="/admin/product/createorupdate?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>
//                     <a href="/admin/product/delete?id=${data}" class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
//                    </div>`
//            }, "width": "25%" }

//        ]
//    });
//}

function confirmDelete(url, text) {
    Swal.fire({
        title: `Are you sure you want to delete ${text}?`,
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#CA1929',
        cancelButtonColor: '#192E2F',
        cancelButtonText: 'No',
        confirmButtonText: 'Yes!'
    }).then((result) => {
        if (result.isConfirmed) {            
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                   
                    toastr.success(data.message);
                    setTimeout(function () {
                        window.location.href = '/admin/company'; // Adjust the URL as needed
                    }, 500);
                },
                error: function (xhr, status, error) {
                    // On error, show error message with Toastr
                    toastr.error('An error occurred while deleting.');
                }
            });
        }
    });
}

