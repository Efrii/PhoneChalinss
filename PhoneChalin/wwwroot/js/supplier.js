// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Function for Delete Supplier
function deleteSupplier(idSupplier) {
    // GET DETAIL Supplier
    $.ajax({
        url: "/supplier/get/"+idSupplier,
        method: "GET",
    }).done((result) => {
        // Using Swal for delete
        Swal.fire({
            title: 'Are you sure?',
            html: "You want to delete the data supplier <strong>" + result.nameSupplier +"</strong>",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
          }).then((result) => {
            if (result.isConfirmed) {
                // action delete
                $.ajax({
                    headers: { 
                        'Accept': 'application/json',
                        'Content-Type': 'application/json' 
                    },
                    url: "/supplier/delete/"+idSupplier,
                    type: "DELETE",
                    dataType: "json",
                    success: function(){
                        $("#supplierDataTable").DataTable().ajax.reload();
                        Swal.fire(
                            'Deleted!',
                            'Your data supplier has been deleted.',
                            'success'
                          )
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
        });
    });
}

function editSupplier(idSupplier){
    $.ajax({
        url: "/supplier/get/"+idSupplier,
        type: "GET",
    }).done((result) => {
        let val = result;
        let text = `
                <input type="text" class="form-control" name="idSupplier" id="idSuppliers" placeholder="Brand Supplier" required value="${val.idSupplier}" hidden disabled>
                <div class="form-group">
                    <div class="col mb-3">
                            <label for="brandSupplier">Brand Supplier</label>
                            <input type="text" class="form-control" name="brandSupplier" id="brandSuppliers" placeholder="Brand Supplier" required value="${val.brandSupplier}">
                        <div class="invalid-feedback">
                            Brand supplier is required
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col mb-3">
                            <label for="nameSupplier">Name Supplier</label>
                            <input type="text" class="form-control" name="nameSupplier" id="nameSuppliers" placeholder="Name Supplier" required value="${val.nameSupplier}">
                        <div class="invalid-feedback">
                            Name supplier is required
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col mb-3">
                            <label for="phone">Phone Supplier</label>
                            <input type="text" class="form-control" name="phone" id="phones" placeholder="Phone Supplier" required value="${val.phone}" minlength="12" maxlength="12" pattern="[0-9]+">
                        <div class="invalid-feedback">
                            Phone number cannot be less than 11 characters
                            <br>
                            Phone number must contain numbers
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col mb-3">
                        <label for="address">Address Supplier</label>
                        <textarea class="form-control" name="address" id="addresss" rows="3" required>${val.address}</textarea>
                        <div class="invalid-feedback">
                            Address supplier is required
                        </div>
                    </div>
                </div>
        `;
        console.log(text);
        $("#textEditSupplier").html(text);
    });
}

$(document).ready(function () {

    // VALIDATE EDIT DATA
    var forms = document.getElementsByClassName('needs-validation-edit');
    var validation = Array.prototype.filter.call(forms, function(form) {
        form.addEventListener('submit', function(event) {
            if (form.checkValidity() === false) {
            event.preventDefault();
            event.stopPropagation();
            } else{

                event.preventDefault();
                
                let obj = {};
                obj.idSupplier = parseInt($("#idSuppliers").val());
                obj.brandSupplier = $("#brandSuppliers").val();
                obj.nameSupplier = $("#nameSuppliers").val();
                obj.phone = $("#phones").val();
                obj.address = $("#addresss").val();

                console.log(obj);

                // EDIT DATA
                $.ajax({
                    headers: { 
                        'Accept': 'application/json',
                        'Content-Type': 'application/json' 
                    },
                    url: "/supplier/edit",
                    type: "PUT",
                    dataType: "json",
                    data: JSON.stringify(obj),
                    success: function(data){
                        $("#supplierDataTable").DataTable().ajax.reload();
                        $('#modaleditSupplier').modal('hide');
                        Swal.fire({
                            icon: 'success',
                            text: 'Data has been edit'
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
                    url: "/supplier/add",
                    type: "POST",
                    dataType: "json",
                    data: JSON.stringify(obj),
                    beforeSend: function (data) {
                        data.setRequestHeader("RequestVerificationToken", $("[name='__RequestVerificationToken']").val());
                    },
                    success: function(data){
                        $("#supplierDataTable").DataTable().ajax.reload();
                        $('#addSupplier').modal('hide');
                        Swal.fire({
                            icon: 'success',
                            text: 'Data has been saved'
                        }).then((result) => {
                            if (result.isConfirmed) {
                                $("#brandSupplier").val('');
                                $("#nameSupplier").val('');
                                $("#phone").val('');
                                $("#address").val('');
                            }
                        });
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
            "url": "/supplier/get",
            "dataType": "json",
            "dataSrc": ""
        },
        "columns": [
            {
                data: null,
                render: function (data, type, row, meta) {
                    return meta.row + 1;
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
                                <a onClick="editSupplier('${row['idSupplier']}')" href="#" class="btn btn-primary" data-toggle="modal" data-target="#modaleditSupplier"><i class="fas fa-edit"></i></a>
                                <a onClick="deleteSupplier('${row['idSupplier']}')" href="#" class="btn btn-primary"><i class="fas fa-trash-alt"></i></a>
                            </div>`;
                }
            }
        ], 
        "columnDefs": [
            {
                "targets": [0,3,5],
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