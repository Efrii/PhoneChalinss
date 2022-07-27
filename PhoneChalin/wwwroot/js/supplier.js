// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    // VALIDATE ADD DATA SUPPLIER
    var forms = document.getElementsByClassName('needs-validation');
    var validation = Array.prototype.filter.call(forms, function(form) {
        form.addEventListener('submit', function(event) {
            if (form.checkValidity() === false) {
            event.preventDefault();
            event.stopPropagation();
            } else{

                event.preventDefault();
                let obj = {};
                obj.brandSupplier = $("#brandSupplier").val();
                obj.nameSupplier = $("#nameSupplier").val();
                obj.phone = $("#phone").val();
                obj.address = $("#address").val();

                console.log(obj);

                // ADD DATA SUPPLIER
                $.ajax({
                    headers: { 
                        'Accept': 'application/json',
                        'Content-Type': 'application/json' 
                    },
                    url: "https://localhost:42573/api/Supplier",
                    type: "POST",
                    dataType: "json",
                    data: JSON.stringify(obj),
                    success: function(data){
                        $("#supplierDataTable").DataTable().ajax.reload();
                        $('#addSupplier').modal('hide');
                        Swal.fire({
                            icon: 'success',
                            text: 'Data has been saved'
                        })
                    },
                    error: function (errormessage) {
                        console.log(errormessage)
                        Swal.fire({
                            icon: 'error',
                            title: 'Oops...',
                            text: 'Error Code '+errormessage.responseJSON.status +' With '+ errormessage.responseJSON.title
                          })
                          
                    }
                });
                
            }
            form.classList.add('was-validated');
        }, false);
    });

    // DATATABLE SUPPLIER
    $("#supplierDataTable").DataTable({
        "processing": true,
        "serverside": true,
        "responsive": true,
        "dom": '<"row"B><"row mt-3"lf>t<"row"ip><"clear">',
        "buttons": {
            "buttons": [
                { 
                    extend: 'copyHtml5', 
                    text: '<i class="fas fa-copy"></i>',
                    className: 'btn btn-primary',
                    titleAttr: 'Copy',
                    exportOptions: {
                        columns: ':visible'
                    }
                },
                { 
                    extend: 'excelHtml5', 
                    text: '<i class="fas fa-file-excel"></i>',
                    className: 'btn btn-primary',
                    titleAttr: 'Excel',
                    exportOptions: {
                        columns: ':visible'
                    }
                },
                { 
                    extend: 'csvHtml5', 
                    text: '<i class="fas fa-file-csv"></i>',
                    className: 'btn btn-primary',
                    titleAttr: 'Csv',
                    exportOptions: {
                        columns: ':visible'
                    }
                },
                { 
                    extend: 'pdfHtml5', 
                    text: '<i class="fas fa-file-pdf"></i>',
                    className: 'btn btn-primary',
                    titleAttr: 'Pdf',
                    exportOptions: {
                        columns: ':visible'
                    }
                },
                { 
                    extend: 'print', 
                    text: '<i class="fas fa-print"></i>',
                    className: 'btn btn-primary',
                    titleAttr: 'Print',
                    exportOptions: {
                        columns: ':visible'
                    }
                },
                {
                    extend: 'colvis',
                    text: 'Colvis ',
                    className: 'btn btn-primary dropdown-toggledropdown-toggle',
                    titleAttr: 'Colvis'
                }
            ],
            "dom": {
                "button": {
                    className: 'btn'
                }
            }
        },
        "ajax": {
            "url": "https://localhost:42573/api/Supplier",
            "dataType": "json",
            "dataSrc": "data"
        },
        "columns": [
            {
                data: null,
                render: function (data, type, row, meta) {
                 return meta.row + meta.settings._iDisplayStart + 1;
                }  
            },
            {
                data: "brandSupplier",
            },
            {
                data: "nameSupplier"
            },
            {
                data: "phone",
            },
            {
                data: "address"
            },
            {
                data: null,
                render: function (data, type, row) {
                    return `<div class="text-center">
                                <a class="btn btn-primary" href="https://localhost:5001/Supplier/edit/`+ row['idSupplier'] +`"><i class="fas fa-edit"></i></a>
                                <a class="btn btn-primary" href="https://localhost:5001/Supplier/delete/`+ row['idSupplier'] +`"><i class="fas fa-trash-alt"></i></a>
                            </div>`
                }
            }
        ], 
        "columnDefs": [
            {
                "targets": [0,1],
                "className": 'text-center'
            },
            {
                "targets": 5,
                "orderable": false
            }
        ]
    });

    var paginate = document.getElementById("supplierDataTable_paginate");
    paginate.classList.add("col");

    var info = document.getElementById("supplierDataTable_info");
    info.classList.add("col");

    var lenght = document.getElementById("supplierDataTable_length");
    lenght.classList.add("col");

    var filter = document.getElementById("supplierDataTable_filter");
    filter.classList.add("col");
});